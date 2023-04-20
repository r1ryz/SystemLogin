using ClientForApi.Services;
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

namespace ClientForApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnReg.Click += BtnReg_Click;
            btnGo.Click += BtnGo_Click;
        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            ServiceAPI service = new ServiceAPI();
            try
            {
                var us = service.Auth(tbLogin.Text, tbPassword.Text);
                MessageBox.Show($"Привет {us.name} - ваш ID {us.id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow window = new AddUserWindow();
            window.ShowDialog();
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
