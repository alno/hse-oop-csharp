using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataBinding3
{
    public class Book : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private String title;

        public String Title
        {
            get { return title; }
            set { this.title = value; NotifyPropertyChanged("Title"); }
        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
