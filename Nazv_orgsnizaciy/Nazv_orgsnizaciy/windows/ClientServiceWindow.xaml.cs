using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

/*
namespace Nazv_orgsnizaciy
{
    public partial class Client
    {
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }
    }

    public partial class ClientService
    {
        public string StartTimeText
        {
            get
            {
                // в принципе то же самое вернет и просто ToString(), но его значение зависит
                // от культурной среды, поэтому лучше задать жестко
                return StartTime.ToString("dd.MM.yyyy hh:mm:ss");
            }
            set
            {
                // в круглых скобках регуляного выражения те значения, которые попадут в match.Groups
                // точка спецсимвол, поэтому ее экранируем
                // \s - пробел (любой разделитель)
                // \d - цифра
                // модификатор "+" означает что должен быть как минимум один элемент (можно больше)
                Regex regex = new Regex(@"(\d+)\.(\d+)\.(\d+)\s+(\d+):(\d+):(\d+)");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    try
                    {
                        StartTime = new DateTime(
                            Convert.ToInt32(match.Groups[3].Value),
                            Convert.ToInt32(match.Groups[2].Value),
                            Convert.ToInt32(match.Groups[1].Value),
                            Convert.ToInt32(match.Groups[4].Value),
                            Convert.ToInt32(match.Groups[5].Value),
                            Convert.ToInt32(match.Groups[6].Value)
                            );
                    }
                    catch
                    {
                        MessageBox.Show("Не верный формат даты/времени");
                    }
                }
                else
                {
                    MessageBox.Show("Не верный формат даты/времени");
                }
            }
        }
    }
}

namespace Nazv_orgsnizaciy.windows
{
    /// <summary>
    /// Логика взаимодействия для ClientServiceWindow.xaml
    /// </summary>
    public partial class ClientServiceWindow : Window
    {
        public List<Client> ClientList { get; set; }
        public ClientService CurrentClientService { get; set; }
        //public List<Service> ServiceList { get; set; }

        public ClientServiceWindow(Service selected)
        {
            InitializeComponent();
            DataContext = this;
            //ServiceList = serviceList;
            ClientList = Core.DB.Client.ToList();
            CurrentClientService = new ClientService();
            CurrentClientService.Service = selected;
            CurrentClientService.StartTime = DateTime.Now;
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            // сохранение в БД
            try
            {
                if (CurrentClientService.Client == null)
                    throw new Exception("Не выбран клиент");

                if (CurrentClientService.Service == null)
                    throw new Exception("Не выбрана услуга");

                Core.DB.ClientService.Add(CurrentClientService);
                Core.DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            DialogResult = true;
        }
    }
}
*/