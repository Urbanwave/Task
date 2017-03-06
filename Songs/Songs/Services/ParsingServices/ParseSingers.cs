using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using Songs.Models.DBModels;
using System.Threading;


namespace Songs.Services.ParsingService
{
    public class ParseSingers
    {
        public List<string> AllSingersNames = new List<string>();
        public List<string> AllSingerSongsAmountAndViews = new List<string>();
        public List<string> AllSingerDiscriptions = new List<string>();

        public void ParseSingersName(int pageamount)
        {
            HtmlWeb webDoc = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            HtmlDocument discriptiondoc = new HtmlDocument();
            HtmlNodeCollection tr,div;

            for (int i = 1; i <= pageamount; i++)
            {
                string id = i.ToString();
                string url = "http://amdm.ru/chords/page"+ id;
                doc = webDoc.Load(url);
                tr = doc.DocumentNode.SelectNodes("//table[@class='items']//tr//td");

                if (tr != null)
                {
                    foreach (HtmlNode HN in tr)
                    {
                        if (HN.Attributes["class"].Value != null)
                        {
                            if (HN.Attributes["class"].Value == "number")
                            {
                                AllSingerSongsAmountAndViews.Add(HN.InnerText.Replace(",",""));
                            }

                            if (HN.Attributes["class"].Value == "artist_name")
                            {
                                foreach (var a in HN.ChildNodes)
                                {
                                    if (a.Name == "a")
                                    {
                                        AllSingersNames.Add(a.InnerText);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ParseSingersBiography(int pageamount)
        {
            HtmlWeb webDoc = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            HtmlDocument discriptiondoc = new HtmlDocument();
            HtmlNodeCollection tr, div;

            for (int i = 1; i <= pageamount; i++)
            {
                string id = i.ToString();
                string url = "http://amdm.ru/chords/page" + id;
                doc = webDoc.Load(url);
                tr = doc.DocumentNode.SelectNodes("//table[@class='items']//tr//td");

                if (tr != null)
                {
                    foreach (HtmlNode HN in tr)
                    {
                        if (HN.Attributes["class"].Value != null)
                        {
                            if (HN.Attributes["class"].Value == "artist_name")
                            {
                                foreach (var a in HN.ChildNodes)
                                {                             
                                    if (a.Name == "a")
                                    {
                                        discriptiondoc = webDoc.Load("http:" + a.Attributes["href"].Value);
                                        div = discriptiondoc.DocumentNode.SelectNodes("//div[@class='artist-profile__bio']");

                                        foreach (HtmlNode disc in div)
                                        {
                                            AllSingerDiscriptions.Add(disc.InnerText);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(60000);
            }
        }

        //public List<string> ParseSingersViews(int pageamount)
        //{
        //    List<string> SingersSongsCountAndViews = new List<string>();
        //    HtmlWeb webDoc = new HtmlWeb();
        //    HtmlDocument doc = new HtmlDocument();

        //    for (int i = 1; i <= pageamount; i++)
        //    {
        //        string id = i.ToString();
        //        string url = "http://amdm.ru/chords/page" + id;
        //        doc = webDoc.Load(url);
        //        HtmlNodeCollection tr = doc.DocumentNode.SelectNodes("//table[@class='items']//tr//td");

        //        if (tr != null)
        //        {
        //            foreach (HtmlNode HN in tr)
        //            {
        //                if (HN.Attributes["class"].Value != null)
        //                {
        //                    if (HN.Attributes["class"].Value == "number")
        //                    {
        //                        SingersSongsCountAndViews.Add(HN.InnerText);
        //                    }
        //                }
        //            }
        //        }
        //        Thread.Sleep(60000);
        //    }
        //    return SingersSongsCountAndViews;
        //}

        public ParseSingers()
        {
            ParseSingersName(10);   
            ParseSingersBiography(10);

            using (DBContext context = new DBContext())
            {
                SingerModel Singer = new SingerModel();
                for (int i = 0; i < 300; i++)
                {
                    Singer.Name = AllSingersNames[i];
                    Singer.Biography = AllSingerDiscriptions[i];

                    if (i == 0)
                    {
                        Singer.SongsAmount = Convert.ToInt32(AllSingerSongsAmountAndViews[0]);
                        Singer.ViewsAmount = Convert.ToInt32(AllSingerSongsAmountAndViews[1]);

                    }
                    else
                    {
                        Singer.SongsAmount = Convert.ToInt32(AllSingerSongsAmountAndViews[i * 2]);
                        Singer.ViewsAmount = Convert.ToInt32(AllSingerSongsAmountAndViews[i * 2 + 1]);
                    }

                    context.Singers.Add(Singer);
                    context.SaveChanges();
                }
            }
        }
    }
}