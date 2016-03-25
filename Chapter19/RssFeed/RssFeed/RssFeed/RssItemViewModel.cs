using System;
using System.Xml.Linq;

namespace RssFeed
{
    public class RssItemViewModel
    {
        public RssItemViewModel(XElement element)
        {
            // Although this code might appear to be generalized, it is
            //  actually based on desired elements from the particular 
            //  RSS feed set in the RssFeedPage.xaml file.
            Title = element.Element(XName.Get("title")).Value;
            Description = element.Element(XName.Get("description")).Value;
            Link = element.Element(XName.Get("link")).Value;
            PubDate = element.Element(XName.Get("pubDate")).Value;

            // Sometimes there's no thumbnail, so check for its presence.
            XElement thumbnailElement = element.Element(
                XName.Get("thumbnail", "http://search.yahoo.com/mrss/"));

            if (thumbnailElement != null)
            {
                Thumbnail = thumbnailElement.Attribute(XName.Get("url")).Value;
            }
        }

        public string Title { protected set; get; }

        public string Description { protected set; get; }

        public string Link { protected set; get; }

        public string PubDate { protected set; get; }

        public string Thumbnail { protected set; get; }
    }
}
