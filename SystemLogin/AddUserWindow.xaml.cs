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
using System.Windows.Shapes;

namespace ClientForApi
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            btnReg.Click += BtnReg_Click;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Services.ServiceAPI service = new Services.ServiceAPI();

            try
            {
                service.AddUser(tbName.Text, tbLogin.Text, tbPassword.Text);
                MessageBox.Show("Успешно зарегистрировались!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
