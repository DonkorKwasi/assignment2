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
    public partial class MyAnime : ContentPage
    {

        AnimeDisplay selected = null;
        List<AnimeDisplay> all = null;
        
        public MyAnime(List<AnimeDisplay> faves)
        {

            InitializeComponent();
            AniList.ItemsSource = faves;
            all = faves;

            
        }

        private void swapUp(object sender, EventArgs e)
        {

            if(selected == null)
            {
                DisplayAlert("Error", "An anime from your fave list must be selected before it can be moved", "ok");
            }
            else if (all.Count < 2)
            {
                DisplayAlert("Error", "Fave list  has less than 2 anime so this operation cant work", "ok");
            }
            
            else if(selected.img == all[0].img && selected.place == all[0].place && selected.score == all[0].score && selected.synop == all[0].synop && selected.title == all[0].title)
            {
                DisplayAlert("Error", "cant move anime up as this is the first in the list ", "ok");
            }
            else
            {
                int spot = all.IndexOf(selected);
                AnimeDisplay temp = all[spot];
                all[spot] = all[spot - 1];
                all[spot - 1] = temp;


                all[spot].place++;
                all[spot - 1].place--;
            }
        }

        private void swapDown(object sender, EventArgs e)
        {
            if (selected == null)
            {
                DisplayAlert("Error", "An anime from your fave list must be selected before it can be moved", "ok");
                

            }

            else if(all.Count < 2)
            {
                DisplayAlert("Error", "Fave list  has less than 2 anime so this operation cant work", "ok");
            }

            else if (selected.img == all[(all.Count-1)].img && selected.place == all[(all.Count - 1)].place && selected.score == all[(all.Count - 1)].score && selected.synop == all[(all.Count - 1)].synop && selected.title == all[(all.Count - 1)].title)
            {
                DisplayAlert("Error", "cant move anime down as this is the last in the list ", "ok");
            }
            else
            {
                
             int spot =   all.IndexOf(selected);
                AnimeDisplay temp = all[spot];

                all[spot] = all[spot + 1];
                all[spot + 1] = temp;


                all[spot].place--;
                all[spot + 1].place++;
            }
        }

        private void selectedOne(object sender, SelectedItemChangedEventArgs e)
        {
            selected = (e.SelectedItem as AnimeDisplay);
           
        }

        private void Save(object sender, EventArgs e)
        {
            if(all.Count > 0)
            {
                for(int i = 0; i < all.Count; i++ )
                {
                    App.Database.SaveAnimeAsync(all[i]);
                }
            }
        }

        private void delete(object sender, EventArgs e)
        {
            App.Database.DeleteAnimeAsync();
        }

        //edit buttons so they swap up and down


    }
}