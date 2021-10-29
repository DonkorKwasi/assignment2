using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data;

namespace assignment2
{
    public partial class MainPage : ContentPage
    {

        NetworkManager net = new NetworkManager();
        //PopulATE this list with all the anime added to faves pass it too fave anime page
        List<AnimeDisplay> faves = new List<AnimeDisplay>();
       
        int counter = 0;
        int rating = 0;
      const  int max = 20;

        Root obj = null;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
           faves = await App.Database.GetAnimeAsync();
        }
        public MainPage(List<AnimeDisplay> fave)
        {
            InitializeComponent();
        }
        


        private async void  Button_Clicked(object sender, EventArgs e)
        {

            
              obj = await net.SearchAnime(input.Text);
            counter = 0;
            if (obj != null)
            {
                title.Text = obj.results[counter].title;
                rate.Text = "rating:" +  obj.results[counter].score;
                img.Source = obj.results[counter].image_url;
                syn.Text = obj.results[counter].synopsis;
            }
            else
            {
                title.Text = "no search results try again";
                rate.Text = "";
                img.Source = "";
                syn.Text = "";
            }
            
        }

        private void prev_Clicked(object sender, EventArgs e)
        {

            if (obj != null)
            {
                if (counter > 0)
                {
                    counter--;
                    title.Text = obj.results[counter].title;
                    rate.Text = "rating:" + obj.results[counter].score;
                    img.Source = obj.results[counter].image_url;
                    syn.Text = obj.results[counter].synopsis;
                }
            }
        }

        private void next_Clicked(object sender, EventArgs e)
        {
            if (obj != null)
            {
                if (counter < (obj.results.Count - 1))
                {
                    counter++;
                    title.Text = obj.results[counter].title;
                    rate.Text = "rating:" + obj.results[counter].score;
                    img.Source = obj.results[counter].image_url;
                    syn.Text = obj.results[counter].synopsis;
                }
            }
        }

        private void addToFave(object sender, EventArgs e)
        {



            

            if (obj != null && faves.Count < 20)
            {


                
                AnimeDisplay fav = new AnimeDisplay();
                fav.img = obj.results[counter].image_url;
                fav.score = obj.results[counter].score;
                fav.synop = obj.results[counter].synopsis;
                fav.title = obj.results[counter].title;
                rating++;
                fav.place = rating;
                bool isalreadyinseterd = false;


                for(int i = 0; i < faves.Count; i++)
                {
                    if(fav.img == faves[i].img && fav.score == faves[i].score && fav.synop == faves[i].synop && fav.title == faves[i].title)
                    {
                        isalreadyinseterd = true;
                    }
                }

                if (isalreadyinseterd == true)
                {
                    DisplayAlert("Error", "This anime is already in your favourites", "ok");
                }
                else
                {
                    faves.Add(fav);
                    DisplayAlert("New fave found!", "This anime has successfully been added to your favourites", "ok");
                }
                
            }
            else
            {
                if (faves.Count == 20 && obj != null)
                {
                    DisplayAlert("Error", "max amount of favourite anime  has been reached, you cant add more than 20 anime to faves", "ok");
                }
                else
                {
                    DisplayAlert("Error", "You must first search for an anime before adding one to your fave list", "ok");
                }
            }
        }

   
        private async void goToAnime(object sender, EventArgs e)
        {
            await Navigation.PushAsync( new MyAnime(faves));
        }

        private async void goToSeason(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new seasonalSearch(faves));
        }
    }
}