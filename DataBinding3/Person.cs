using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataBinding3
{
    public class Person : INotifyPropertyChanged
    {
        private String firstName = "";
        private String lastName = "";
        private DateTime birthDate;

        private BindingList<Book> books = new BindingList<Book>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        {
            books.ListChanged += new ListChangedEventHandler(books_ListChanged);
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; NotifyPropertyChanged("FirstName"); }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; NotifyPropertyChanged("LastName"); }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; NotifyPropertyChanged("BirthDate"); }
        }

        public BindingList<Book> Books
        {
            get { return books; }
            set { books = value; books.ListChanged += new ListChangedEventHandler(books_ListChanged); NotifyPropertyChanged("Books"); NotifyPropertyChanged("BookCount"); }
        }

        void books_ListChanged(object sender, ListChangedEventArgs e)
        {
            NotifyPropertyChanged("Books"); NotifyPropertyChanged("BookCount");
        }

        public Int32 BookCount
        {
            get { return books.Count; }
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
