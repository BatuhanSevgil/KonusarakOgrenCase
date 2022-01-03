using Business.Abstract;
using Core.Utilities.Result;
using Core.Utilities.RSS;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Newtonsoft.Json;
using System;

namespace Business.Concrete
{
  public class ContentManager : IContentService
  {
    private readonly IContentDal _contentDal;

    public ContentManager(IContentDal contentDal)
    {
      _contentDal = contentDal;

    }
    public IDataResult<Content> Add(Content tentity)
    {
      Content result = _contentDal.Add(tentity);
      if (result != null)
      {
        return new DataResult<Content>(true, result);

      }
      return new DataResult<Content>(false, result);

    }

    public IResult Delete(int Id)
    {
      var entity = _contentDal.Get(item => item.Id == Id);
      if (entity != null)
      {
        _contentDal.Delete(entity);
        return new Result(true);
      }
      return new Result(false);


    }

    public IDataResult<List<Content>> GetAll()
    {
      List<Content> items = _contentDal.GetAll();
      if (items.Count == 0)
      {
        this.SyncContentWithWired();
        items = _contentDal.GetAll();

        return new DataResult<List<Content>>(true, items);

      }
      return new DataResult<List<Content>>(true, items);
    }

    public IDataResult<Content> GetById(int id)
    {
      Content content = _contentDal.Get(content => content.Id == id);
      if (content == null)
      {
        return new DataResult<Content>(false, null);
      }
      return new DataResult<Content>(true, content);
    }

    public IResult SyncContentWithWired()
    {
      try
      {
        RssReader rssReader = new RssReader(@"https://www.wired.com/feed/rss");
        SyndicationFeed feed = rssReader.Read();

        DateTime lastAddedContentDate = _contentDal.LastUpdateDate();
        TimeSpan diff = lastAddedContentDate - feed.LastUpdatedTime.UtcDateTime;

        if (diff.TotalSeconds == 0)
        {
          return new Result(true);
        }


        List<Content> contents = new List<Content>();

        foreach (var item in feed.Items)
        {
          Content entity = new Content()
          {
            Description = item.Summary.Text,
            Detail = item.ToJson(false),
            PublishContentDate = feed.LastUpdatedTime.UtcDateTime,
            PublishRssDate = item.PublishDate.UtcDateTime,
            Title = item.Title.Text,

          };
          contents.Add(entity);
        }

        foreach (var item in contents)
        {
          _contentDal.Add(item);
        }
        return new Result(true);
      }
      catch (System.Exception e)
      {

        return new Result(false, e.ToString());
      }

    }

    public IResult Update(Content tentity)
    {
      var checkItem = _contentDal.Get(item => item.Id == tentity.Id);
      if (checkItem != null)
      {

        _contentDal.Update(tentity);
        return new Result(true);
      }
      return new Result(false);


    }
  }
}
