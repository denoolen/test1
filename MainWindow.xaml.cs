using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>   
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox tb = sender as TextBox;
            if (tb.Text.Length >= 4 & tb.Text.Length > 0)
             tb.Background = new SolidColorBrush(Color.FromRgb(3, 81, 3));
             else tb.Background = new SolidColorBrush(Color.FromRgb(189, 0, 36));

             if (AgeBox.Text.Length >= 4 & SurnameBox.Text.Length >= 4 & NameBox.Text.Length >= 4)
             btn.IsEnabled = true;
            else btn.IsEnabled = false;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
