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




namespace Nazv_orgsnizaciy.Frames
{
    /// <summary>
    /// Логика взаимодействия для InputBoxFrame.xaml
    /// </summary>
    /// 
    

    public partial class InputBoxFrame : Page
    {

        public static bool b;
        public static string InputText { get; set; }


        public InputBoxFrame()
        {
            InitializeComponent();
            
            this.DataContext = this;
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            //Navigate(new MainPage());
            //b = true;
            if (TextBox.Text == "0000")
            {
                MainWindow._IsAdminMode = true;
                (Application.Current.MainWindow as MainWindow).DoUpdate();
            }
            else
            {
                MainWindow._IsAdminMode = false;
            }
           
           //IsAdminMode = InputBox.InputText == "0000";
            //DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
          
            
            b = false;
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            //DialogResult = false;
        }
    }
}
