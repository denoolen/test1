using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
            this.DataContext = new Person
            {
                Name = "Ta", Surname = "Ta"
            };

            sp.BindingGroup.BeginEdit();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        private void OnCancel(object sender, RoutedEventArgs e)
        {
            // Cancel the pending changes and begin a new edit transaction.
            sp.BindingGroup.CancelEdit();
            sp.BindingGroup.BeginEdit();
        }
        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            if (sp.BindingGroup.CommitEdit())
            {
                MessageBox.Show("Item submitted");
                sp.BindingGroup.BeginEdit();
            }
        }
    }

    public class ValidateLength : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;

            var person = bg.Items[0] as Person;

			if (person.Name?.Length<5 || person.Surname?.Length < 5)
			{
                return new ValidationResult(false, "Name less than 5!");
            }
        
            return ValidationResult.ValidResult;
        }
    }
    public class Person : INotifyPropertyChanged
    {
        private string name, surname;
        private int age;

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
    }

}