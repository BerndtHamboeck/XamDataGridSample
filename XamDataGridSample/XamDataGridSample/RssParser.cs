using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XamDataGridSample
{
    public static class RssParser
    {
        public static async Task<List<RssEntry>> GetFeedInfo(Uri rssSource)
        {

            var rssEntries = new List<RssEntry>();
            int i = 0;
            try
            {
                using (var webClient = new HttpClient())
                {
                    try
                    {

                        string result = await webClient.GetStringAsync(rssSource);
                        XDocument document = XDocument.Parse(result);

                        var temp = ((from u in document.Descendants("item")
                                     select new RssEntry()
                                     {
                                         Id = i++,
                                         Author = u.Element("author").Value,
                                         Title = u.Element("title").Value,
                                         Description = u.Element("description").Value,
                                         Link = new Uri(u.Element("link").Value),
                                         PubDate = DateTime.Parse(u.Element("pubDate").Value)
                                     }).ToList());

                        rssEntries.AddRange(temp);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rssEntries;
        }
    }
}
