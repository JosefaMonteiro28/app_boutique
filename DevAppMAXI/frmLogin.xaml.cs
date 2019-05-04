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
using System.Windows.Threading;

namespace DevAppMAXI
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerEntrar = new DispatcherTimer();
        public frmLogin()
        {
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += Timer_Tick;


            /****************/
            timerEntrar.Interval = TimeSpan.FromMilliseconds(100);
            timerEntrar.Tick += TimerEntrar_Tick;
            InitializeComponent();
        }

        private void TimerEntrar_Tick(object sender, EventArgs e)
        {
            if (prEntrar.Value != 99)
            {
                prEntrar.Value += 1;
                //txtNameUser.Text = prEntrar.Value.ToString();
            }
            else
            {
                timerEntrar.Stop();
                this.Hide();
                MainWindow splash = new MainWindow();
                splash.ShowDialog();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (smsAviso.IsActive == true)
            {
                smsAviso.IsActive = false;
                timer.Stop();
            }
            else
            {
                smsAviso.IsActive = true;
            }
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            Gravar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNameUser.Focus();
        }

        private void txtNameUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtPassWord.Focus();
            }
        }


        /*-----------> TODAS FUNCTIONS <-----------------*/
        private void Gravar()
        {
            if (txtNameUser.Text.Trim() == "Dorivaldo dos Santos" && txtPassWord.Password.Trim() == "Dorivaldo2")
            {
                btnEntrar.IsEnabled = false;
                btnEntrar.IsEnabled = false;
                txtNameUser.IsEnabled = false;
                txtPassWord.IsEnabled = false;
                prEntrar.Visibility = Visibility.Visible;
                timerEntrar.Start();
            }
            else
            {
                timer.Start();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Gravar();
            }
        }
    }
}
