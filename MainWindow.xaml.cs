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
using DIGORANDEY_AVTOSERVIS.ApplicationData;
using DIGORANDEY_AVTOSERVIS.Page;

namespace DIGORANDEY_AVTOSERVIS
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

        private void btnVxod_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var userObj = AppConnect.model1db.user.FirstOrDefault(x => x.Login == txbLogin.Text && x.password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    switch (userObj.userrole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Мастер приемщик " + userObj.firstname + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.MainFrame.Navigate(new PageMasteraPriemshika());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, автодиагност " + userObj.firstname + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.MainFrame.Navigate(new PageAvtomexanik());
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, механик" + userObj.firstname + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.MainFrame.Navigate(new PageAvtodiagnost());
                            break;


                    }

                }


            }
    }
}
