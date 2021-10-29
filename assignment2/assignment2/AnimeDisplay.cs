using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SQLite;

namespace assignment2
{
    public class AnimeDisplay : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        
        private string _title;
        private double _score;
        private string _synop;
        private string _img;
        private int _place;

        [MaxLength(255)]
        public string title
        {
            get { return _title; }
            set
            {
                if (value == _title)
                    return;

                _title = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(title)));
                }
            }

        }
        public string synop
        {
            get { return _synop; }

            set
            {
                if(value == _synop)
                    return;

                _synop = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(synop)));
                }

            }
        }

        public double score
        {
            get { return _score; }
            set
            {
                if (value == _score)
                    return;

                _score = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(score)));
                }
            }

        }

        public string img
        {
            get { return _img; }

            set
            {
                if (_img == value)
                    return;

                _img = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(img)));
                }
            }
            

            
        }


        public int place
        {
            get { return _place; }

            set
            {
                if (_place == value)
                    return;

                _place = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(place)));
                }
            }



        }


    }
}
