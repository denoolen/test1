using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.VievModel
{
    public class Person : INotifyPropertyChanged
    {
       
        private string name, surname;
        private int age;


        public Person()
        {
            this.Name = "No name";
            this.Surname = "No Surname";
            this.Age = 1;
        }
        public Person(int age)
          //  : this()
        {
			this.Age = age;
		}

		public Person(string name, int age)
		//: this(age)
		{
			this.Name = name;
		}
		public Person(string surname, int age, string name)
		 //: this(age)
		{
			this.surname = surname;
		}

		public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged(Name);
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            { 
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public int Age
        {
            get { return age; }
            set 
            {
                age = value;
                OnPropertyChanged("age");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
           
                                          
        }

		protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!Equals(field, newValue))
			{
				field = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}

			return false;
		}

		
	}
   
}
