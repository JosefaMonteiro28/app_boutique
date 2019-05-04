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
    /// Interaction logic for frmHome.xaml
    /// </summary>
    public partial class frmHome : Window
    {
        usrHome home = new usrHome();
        usrVenda venda = new usrVenda();
        usrProduct product = new usrProduct();
        usrStock stock = new usrStock();
        usrCaixa caixa = new usrCaixa();
        usrClientes clientes = new usrClientes();
        usrUsuarios users = new usrUsuarios();


        /**
         HORA
             */

        DispatcherTimer tmHr = new DispatcherTimer();
        public frmHome()
        {
            InitializeComponent();
            tmHr.Interval = TimeSpan.FromMilliseconds(1000);
            tmHr.Start();
            tmHr.Tick += TmHr_Tick;
            container.Children.Add(home);

          
        }

        private void TmHr_Tick(object sender, EventArgs e)
        {
            var hora = DateTime.Now.Hour.ToString();
            var min = DateTime.Now.Minute.ToString();

            if (hora.Length  == 1)
            {
                hora = "0" + hora;
                letterTimer.Text = hora + "h0" + min;
            }
            else
            {
                letterTimer.Text = DateTime.Now.Hour + "h" + DateTime.Now.Minute;
            }

            
            if (min.Length == 1)
            {
                letterTimer.Text = hora + "h0" + min;
            }
            else
            {
                letterTimer.Text = hora + "h" + min;
            }


        }

        private void opneMenu_Click(object sender, RoutedEventArgs e)
        {
            drMenu.IsLeftDrawerOpen = true;
        }

        private void listMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    container.Children.Clear();
                    container.Children.Add(home);
                    break;

                case 1:
                    container.Children.Clear();
                    container.Children.Add(venda);
                    break;

              case 2:
                    container.Children.Clear();
                    container.Children.Add(product);
                    break;

                case 3:
                    container.Children.Clear();
                    container.Children.Add(stock);
                    break;

                case 4:
                    container.Children.Clear();
                    container.Children.Add(caixa);
                    break;

                case 5:
                    container.Children.Clear();
                    container.Children.Add(clientes);
                    break;

                case 6:
                    container.Children.Clear();
                    container.Children.Add(users);
                    break;

                case 7:
                    this.Hide();
                    new frmLogin().ShowDialog();                 
                    break;

                case 8:
                    dialog.IsOpen = true;
                    break;
                default:
                    break;
            }
        }

        private void btnSim_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnNao_Click(object sender, RoutedEventArgs e)
        {
            dialog.IsOpen = false;
        }
    }
}
