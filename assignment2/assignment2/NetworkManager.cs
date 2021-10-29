using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Data;
namespace assignment2
{
   public class NetworkManager
    {
        HttpClient client = new HttpClient();
       private string urlAnimeSearch = "https://api.jikan.moe/v3/search/anime?q=";
        private string page = "&page=1";
        private string seasonSearch = "https://api.jikan.moe/v3/season/";

        public NetworkManager()
        {
        }

        public async Task<Root> SearchAnime(string input)
        {

            string TotalUrl = urlAnimeSearch + input + page;
            var response = await client.GetAsync(TotalUrl);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            else
            {

                var jsontxt = await response.Content.ReadAsStringAsync();

                var list = JsonConvert.DeserializeObject<Root>(jsontxt);
                return list;
            }


        }


        public async Task<SRoot> SearchS(string year,string season)
        {

            if (year == null|| season == null)
            {
                return null;
            }

            string totalrl = seasonSearch + year + "/" + season;
            var response = await client.GetAsync(totalrl);

          
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest )
            {
                return null;
            }

            else
            {
                var jsontxt = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<SRoot>(jsontxt);
                return list;
            }
        }
    }
}
