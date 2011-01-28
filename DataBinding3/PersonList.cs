using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataBinding3
{
    public class PersonList : BindingList<Person>, IComponent
    {
        public event EventHandler Disposed;

        private ISite site;

        public ISite Site
        {
            get
            {
                return site;
            }
            set
            {
                site = value;
            }
        }

        public void Dispose()
        {
            Disposed(this,new EventArgs());
        }
    }
}
