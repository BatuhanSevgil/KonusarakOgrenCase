using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebUI.Entities.Models;
using WebUI.Services.Abstract;

namespace WebUI.Services.Concrete
{
  public class ContentManager : IContentService
  {
    private HttpClient _http;
    public ContentManager(HttpClient http)
    {
      _http = http;

    }

    public async Task<DataResult<List<Content>>> GetAll()
    {
      return await _http.GetFromJsonAsync<DataResult<List<Content>>>("content");

    }

    public async Task<Result> Sync()
    {
      return await _http.GetFromJsonAsync<Result>("content/sync");
    }
  }
}
