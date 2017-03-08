using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsDBLayer.Entities;
using SongsLogicLayer.BusinessModels;
using HtmlAgilityPack;
using System.Threading;
using SongsLogicLayer.Services;
using SongsLogicLayer.DTO;

namespace SongsLogicLayer.Services
{
    public class ParseService
    {

        public List<string> AllSingersNames = new List<string>();
        public List<string> AllSingerSongsAmountAndViews = new List<string>();
        public List<string> AllSingerDiscriptions = new List<string>();
        public List<string> AllSingerLinks = new List<string>();

        public List<ParseSongsModel> Songs = new List<ParseSongsModel>();

        public void ParseSingersName(int pageamount)
        {
            HtmlWeb webDoc = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            HtmlDocument discriptiondoc = new HtmlDocument();
            HtmlNodeCollection tr;

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
                            if (HN.Attributes["class"].Value == "number")
                            {
                                AllSingerSongsAmountAndViews.Add(HN.InnerText.Replace(",", ""));
                            }

                            if (HN.Attributes["class"].Value == "artist_name")
                            {
                                foreach (var a in HN.ChildNodes)
                                {
                                    if (a.Name == "a")
                                    {
                                        AllSingersNames.Add(a.InnerText);
                                        AllSingerLinks.Add("http:" + a.Attributes["href"].Value);
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
               // Thread.Sleep(60000);
            }
        }

        public void ParseSongs(int amount)
        {
            HtmlWeb webDoc = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            HtmlNodeCollection div;

            List<string> urls = new List<string>();
            List<SingerModelDTO> singers = new SingerService().GettAllSingers(); 

            urls = new SingerService().GetSingersUrl();

            for (int i = 0; i < 30; i++)
            {
                if (i > 0 && i % 50 == 0)
                {
                    Thread.Sleep(60000);
                }
                doc = webDoc.Load(urls[i]);

                div = doc.DocumentNode.SelectNodes("//div[@class='artist-profile-song-list']//tr");

                if (div != null)
                {
                    foreach (HtmlNode HN in div.Cast<HtmlNode>().Take(amount + 1))
                    {
                        if (HN.Name == "tr")
                        {
                            SongModelDTO song = new SongModelDTO();
                            foreach (var item in HN.ChildNodes)
                            {
                                if (item.Name == "td")
                                {
                                    foreach (var a in item.ChildNodes)
                                    {
                                        if (a.Name == "a")
                                        {
                                            song.Name = a.InnerText;
                                            song.SongURL = "http:" + a.Attributes["href"].Value;
                                        }
                                    }

                                    if (item.HasAttributes == true)
                                    {
                                        if (item.Attributes["class"].Value == "number hidden-phone")
                                        {
                                            song.ViewsAmount = Convert.ToInt32(item.InnerText.Replace(",", ""));
                                        }
                                    }
                                }
                            }
                            if (song.Name != null)
                            {
                                //foreach (var item in singers)
                                //{ 
                                //    if(item.SingerURL == urls[i])
                                //    {
                                        song.Singer = new SingerService().GetSingersByUrl(urls[i]);
                                //    }
                                //}
                                new SongService().AddSong(song);
                            }
                        }
                    }
                }
            }
        }


        //public void ParseSongs(int pageamount)
        //{
        //    HtmlWeb webDoc = new HtmlWeb();
        //    HtmlDocument doc = new HtmlDocument();
        //    HtmlDocument discriptiondoc = new HtmlDocument();
        //    HtmlDocument songdiscriptiondoc = new HtmlDocument();
        //    HtmlNodeCollection tr, div, pre, accords;


        //    for (int i = 1; i <= pageamount; i++)
        //    {
        //        string[] view = new string[3];
        //        string singerName;
        //        string id = i.ToString();
        //        string url = "http://amdm.ru/chords/page" + id;
        //        doc = webDoc.Load(url);
        //        tr = doc.DocumentNode.SelectNodes("//table[@class='items']//tr//td");
        //        int j = 0;

        //        if (tr != null)
        //        {
        //            foreach (HtmlNode HN in tr)
        //            {

        //                j++;
        //                if (j == 15)
        //                {
        //                    Thread.Sleep(60000);
        //                    j = 0;
        //                }
        //                if (HN.Attributes["class"].Value != null)
        //                {
        //                    if (HN.Attributes["class"].Value == "artist_name")
        //                    {

        //                        foreach (var a in HN.ChildNodes)
        //                        {
        //                            if (a.Name == "a")
        //                            {
        //                                singerName = a.InnerText;

        //                                discriptiondoc = webDoc.Load("http:" + a.Attributes["href"].Value);
        //                                div = discriptiondoc.DocumentNode.SelectNodes("//div[@class='artist-profile-song-list']//a");

        //                                foreach (HtmlNode disc in div.Cast<HtmlNode>().Take(3))
        //                                {
        //                                    ParseSongsModel Song = new ParseSongsModel();

        //                                    Song.SongName = disc.InnerText;
        //                                    Song.SingerName = singerName;
        //                                    songdiscriptiondoc = webDoc.Load("http:" + disc.Attributes["href"].Value);
        //                                    pre = songdiscriptiondoc.DocumentNode.SelectNodes("//div[@class='b-podbor__text']//pre");


        //                                    if (pre != null)
        //                                    {
        //                                        foreach (HtmlNode item in pre)
        //                                        {
        //                                            Song.SongText = item.InnerHtml;
        //                                        }
        //                                    }
        //                                    accords = songdiscriptiondoc.DocumentNode.SelectNodes("//div[@id='song_chords']//img");

        //                                    if (accords != null)
        //                                    {
        //                                        foreach (HtmlNode item in accords)
        //                                        {
        //                                            Song.AccodrsImages += (("http:" + item.Attributes["src"].Value) + ";");
        //                                        }
        //                                        Songs.Add(Song);
        //                                    }
        //                                }
        //                            }

        //                        }

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    // Thread.Sleep(60000);
        //}

        public void ParseSingers()
        {
            ParseSingersName(1);
            ParseSingersBiography(1);

            SingerService singerService = new SingerService();

            SingerModelDTO Singer = new SingerModelDTO();

            for (int i = 0; i < 30; i++)
            {
                Singer.Name = AllSingersNames[i];
                Singer.Biography = AllSingerDiscriptions[i];
                Singer.SingerURL = AllSingerLinks[i];

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
                singerService.AddSinger(Singer);
            }
        }
    }
}

