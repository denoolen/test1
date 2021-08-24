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
 

		public string Name
        {
            get { return name; }
			set
			{
                name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get { return surname; }
            set
			{
				surname = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return age; }
            set 
            {
                age = value;
                OnPropertyChanged();
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
