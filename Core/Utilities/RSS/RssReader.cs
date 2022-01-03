using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace Core.Utilities.RSS
{
    public class RssReader
    {
        private string _targetURL { get; set; }
        public RssReader(string targetURL)
        {
            _targetURL = targetURL;

        }

        public SyndicationFeed Read()
        {
            using (XmlReader xmlReader = XmlReader.Create(_targetURL))
            {

                SyndicationFeed Feed = SyndicationFeed.Load(xmlReader);
                xmlReader.Close();

                return Feed;

            }

        }





    }
}
