using Microsoft.Win32;
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

namespace Nazv_orgsnizaciy.Frames
{
    /// <summary>
    /// Логика взаимодействия для ServiceFrame.xaml
    /// </summary>
    public partial class ServiceFrame : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Service CurrentService { get; set; }

        public ServiceFrame(Service service)
        {
            InitializeComponent();
            DataContext = this;
            CurrentService = service;
        }
        public string WindowName
        {
            get
            {
                return CurrentService.ID == 0 ? "Новая услуга" : "Редактирование услуги";
            }
        }

        private void GetImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog GetImageDialog = new OpenFileDialog();
            // задаем фильтр для выбираемых файлов
            // до символа "|" идет произвольный текст, а после него шаблоны файлов раздеренные точкой с запятой
            GetImageDialog.Filter = "Файлы изображений: (*.png, *.jpg)|*.png;*.jpg";
            // чтобы не искать по всему диску задаем начальный каталог
            GetImageDialog.InitialDirectory = Environment.CurrentDirectory;
            if (GetImageDialog.ShowDialog() == true)
            {
                // перед присвоением пути к картинке обрезаем начало строки, т.к. диалог возвращает полный путь
                // (тут конечно еще надо проверить есть ли в начале Environment.CurrentDirectory)
                CurrentService.MainImagePath = GetImageDialog.FileName.Substring(Environment.CurrentDirectory.Length + 1);
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentService"));
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentService.Cost <= 0)
            {
                MessageBox.Show("Стоимость услуги должна быть больше ноля");
                return;
            }

            if (CurrentService.Discount < 0 || CurrentService.Discount > 1)
            {
                MessageBox.Show("Скидка на услугу должна быть в диапазоне от 0 до 1");
                return;
            }

            // если запись новая, то добавляем ее в список
            if (CurrentService.ID == 0)
                Core.DB.Service.Add(CurrentService);

            // сохранение в БД
            try
            {
                Core.DB.SaveChanges();
            }
            catch
            {
            }
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            
            //DialogResult = true;
        }
    }
}
