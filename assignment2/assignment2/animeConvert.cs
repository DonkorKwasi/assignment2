using System;
using System.Collections.Generic;
using System.Text;

namespace assignment2
{
    public class animeConvert
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string title { get; set; }
        public bool airing { get; set; }
        public string synopsis { get; set; }
        public string type { get; set; }

        public int episodes { get; set; }
        public double score { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public int members { get; set; }
        public string rated { get; set; }

        public animeConvert(int id, string rl, string irl, string ti, bool air, string syn, string ty, int epi, double sco, DateTime st, DateTime end, int mem, string rate)
        {
            mal_id = id;
            url = rl;
            image_url = irl;
            title = ti;
            airing = air;
            synopsis = syn;
            type = ty;
            episodes = epi;
            score = sco;
            start_date = st;
            end_date = end;
            members = mem;
            rated = rate;

        }





    }
    public class Root
    {
        public string request_hash { get; set; }
        public bool request_cached { get; set; }
        public int request_cache_expiry { get; set; }
        public List<animeConvert> results { get; set; }
    }
}
 