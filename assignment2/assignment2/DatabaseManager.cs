using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace assignment2
{
   public class DatabaseManager
    {
       readonly SQLiteAsyncConnection con;

        public DatabaseManager(string dbpath)
        {
            con = new SQLiteAsyncConnection(dbpath);
            con.CreateTableAsync<AnimeDisplay>().Wait();
        }
        public Task<List<AnimeDisplay>>  getAnime()
        {
            return con.Table<AnimeDisplay>().ToListAsync();
        }

        public Task<List<AnimeDisplay>> GetAnimeAsync()
        {
            return con.Table<AnimeDisplay>().ToListAsync();
        }
        public Task<int> SaveAnimeAsync(AnimeDisplay anime)
        {
            return con.InsertAsync(anime);
            
        }

        public Task<int> DeleteAnimeAsync()
        {

            return con.DeleteAllAsync<AnimeDisplay>();
        }



    }
}
