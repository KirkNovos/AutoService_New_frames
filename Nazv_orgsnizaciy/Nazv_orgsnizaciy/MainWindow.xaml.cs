using Nazv_orgsnizaciy.windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace Nazv_orgsnizaciy
{
    
  

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    //
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static bool _IsAdminMode = false;
        
        //public static MainWindow MainWindRef = null;
        Frames.MainPage MP;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            //MainWindRef = this;
            //MainFrame page = new MainFrame;
            //MainFrame.Content = MainFrame;
            
            MP = new Frames.MainPage();
            MainFrame.Navigate(MP);
            
            //ServiceList = Core.DB.Service.ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        public void DoUpdate()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("AdminModeCaption"));
            PropertyChanged(this, new PropertyChangedEventArgs("AdminVisibility"));
        }
        //private Boolean _IsAdminMode = false;

        public event PropertyChangedEventHandler PropertyChanged;

        // публичный геттер, который меняет текущий режим (Админ/не Админ)
        public Boolean IsAdminMode
        {
            get { return _IsAdminMode; }
            set
            {
                _IsAdminMode = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AdminModeCaption"));
                    PropertyChanged(this, new PropertyChangedEventArgs("AdminVisibility"));
                }
            }
        }
        // этот геттер возвращает текст для кнопки в зависимости от текущего режима
        public string AdminModeCaption
        {
            get
            {
                if (IsAdminMode) return "Выйти из режима\nАдминистратора";
                return "Войти в режим\nАдминистратора";
            }
        }


        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            // если мы уже в режиме Администратора, то выходим из него 
            if (IsAdminMode == true) {
                IsAdminMode = false;
                //(Frames.MainPage as MainPage).DoUpdate();
                //(Application.Current.MainWindow as MainWindow).DoUpdate();
                //Frames.MainPage().DoUpdateMainPage();
                
                //Frames.MainPage CurrentMainPage;
                //CurrentMainPage = Frames.MainPage;
                MP. DoUpdateMainPage();
                PropertyChanged(this, new PropertyChangedEventArgs("WindText"));
            }
            else
            {
                MainFrame.Navigate(new Frames.InputBoxFrame());
            }
        }


        public string AdminVisibility
        {
            get
            {
                if (IsAdminMode) return "Visible";
                return "Collapsed";
            }
        }
       
        private void AddService_Click(object sender, RoutedEventArgs e)
        {

            

            // создаем новую услугу
            var NewService = new Service();
            MainFrame.Navigate(new Frames.ServiceFrame(NewService));
            //var NewServiceWindow = new ServiceWindow(NewService);
            //if ((bool)NewServiceWindow.ShowDialog())
            //{
                // список услуг нужно перечитать с сервера
                //ServiceList = Core.DB.Service.ToList();
                PropertyChanged(this, new PropertyChangedEventArgs("FilteredProductsCount"));
                PropertyChanged(this, new PropertyChangedEventArgs("ProductsCount"));
            //}
        }
     }
}
