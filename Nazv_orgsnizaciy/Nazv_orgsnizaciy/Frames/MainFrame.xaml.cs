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
using System.Windows.Shapes;

namespace Nazv_orgsnizaciy.Frames
{
    /// <summary>
    /// Логика взаимодействия для MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Window, INotifyPropertyChanged
    {
        public List<Service> ServiceList;
        public MainFrame()
        {
            InitializeComponent();
            this.DataContext = this;
            ServiceList = Core.DB.Service.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void EditButon_Click(object sender, RoutedEventArgs e)
        {
            var SelectedService = MainDataGrid.SelectedItem as Service;
            var EditServiceWindow = new ServiceWindow(SelectedService);
            if ((bool)EditServiceWindow.ShowDialog())
            {
                // при успешном завершении не забываем перерисовать список услуг
                PropertyChanged(this, new PropertyChangedEventArgs("ServiceList"));
                // и еще счетчики - их добавьте сами
            }
        }


        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var item = MainDataGrid.SelectedItem as Service;

            if (item.ClientService.Count > 0)
            {
                MessageBox.Show("Нельзя удалять услугу, она уже оказана");
                return;
            }

            Core.DB.Service.Remove(item);

            Core.DB.SaveChanges();

            ServiceList = Core.DB.Service.ToList();
        }

        private void SubscrideButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedService = MainDataGrid.SelectedItem as Service;
            //var SubscrideServiceWindow = new windows.ClientServiceWindow(SelectedService);
            //SubscrideServiceWindow.ShowDialog();

        }

    }
}
