using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class seasonalSearch : ContentPage
    {
        List<AnimeDisplay> list;
        int counter = 0;
        NetworkManager Net = new NetworkManager();
        SRoot root = null;
        int rating = 0;
        public seasonalSearch(List<AnimeDisplay> faves)
        {
            InitializeComponent();
            list = faves;
            if (faves.Count > 0)
            {
                rating = faves[faves.Count - 1].place;
            }
        }

        private async void SearchingSeason(object sender, EventArgs e)
        {
            root = await Net.SearchS(Year.Text, Szn.Text);
            counter = 0;
            if (root != null)
            {
                title.Text = root.anime[counter].title;
                rate.Text = "rating:" + root.anime[counter].score;
                img.Source = root.anime[counter].image_url;
                syn.Text = root.anime[counter].synopsis;
            }
            else
            {
                title.Text = "no search results try again";
                rate.Text = "";
                img.Source = "";
                syn.Text = "";
            }
        }

        private void goNext(object sender, EventArgs e)
        {

            if (root != null)
            {
                if (counter < (root.anime.Count - 1))
                {
                    counter++;
                    title.Text = root.anime[counter].title;
                    rate.Text = "rating:" + root.anime[counter].score;
                    img.Source = root.anime[counter].image_url;
                    syn.Text = root.anime[counter].synopsis;
                }
            }
        }

        private void goPrev(object sender, EventArgs e)
        {
            if (root != null)
            {
                if (counter > 0)
                {
                    counter--;
                    title.Text = root.anime[counter].title;
                    rate.Text = "rating:" + root.anime[counter].score;
                    img.Source = root.anime[counter].image_url;
                    syn.Text = root.anime[counter].synopsis;
                }
            }
        }

        private void addToFave(object sender, EventArgs e)
        {

            if (root != null && list.Count < 20)
            {



                AnimeDisplay fav = new AnimeDisplay();
                fav.img = root.anime[counter].image_url;
                fav.score = (double)root.anime[counter].score;
                fav.synop = root.anime[counter].synopsis;
                fav.title = root.anime[counter].title;
                rating++;
                fav.place = rating;
                bool isalreadyinseterd = false;


                for (int i = 0; i < list.Count; i++)
                {
                    if (fav.img == list[i].img && fav.score == list[i].score && fav.synop == list[i].synop && fav.title == list[i].title)
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
                    list.Add(fav);
                    App.Database.SaveAnimeAsync(fav);
                    DisplayAlert("New fave found!", "This anime has successfully been added to your favourites", "ok");
                }

            }
            else
            {
                if (list.Count == 20 && root != null)
                {
                    DisplayAlert("Error", "max amount of favourite anime  has been reached, you cant add more than 20 anime to faves", "ok");
                }
                else
                {
                    DisplayAlert("Error", "You must first search for an anime before adding one to your fave list", "ok");
                }
            }

        }

       
    }
   }
 