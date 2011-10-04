using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace EH.Interview.Todo.ViewModels
{
    public class ToDoItemViewModel : PropertyChangedBase
    {
        private string description;
        public Guid ID
        {
            private get;
            set;
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
    }
}
