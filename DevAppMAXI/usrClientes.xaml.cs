using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using Boutique.Applicacion;
using Boutique.Domain;

namespace DevAppMAXI
{
    /// <summary>
    /// Interaction logic for usrClientes.xaml
    /// </summary>
    public partial class usrClientes : UserControl
    {
        static int id;

        DispatcherTimer tmWarning = new DispatcherTimer();
        public usrClientes()
        {
            tmWarning.Interval = TimeSpan.FromMilliseconds(2000);
            tmWarning.Tick += TmWarning_Tick;
            InitializeComponent();
            GetAll();
            
        }

       


        #region ========CRUD===========
        private void LimaprCampos()
        {
            txtNome.Clear();
            txtBi.Clear();
            txtEmail.Clear();
            txtMorada.Clear();
        }
        private void Save()
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o campo nome.";
                tmWarning.Start();
            }
            else
            {
                if (txtBi.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o campo BI";
                    tmWarning.Start();
                }
                else
                {
                    if (txtEmail.Text.Trim() == string.Empty)
                    {
                        txtEmail.Text = "Null";
                    }
                    else
                    {
                        if (dtNascimento.Text == string.Empty)
                        {
                            dtNascimento.SelectedDate = null;
                        }
                        else
                        {
                            if (txtMorada.Text.Trim() == string.Empty) 
                            {
                                txtMorada.Text = "Null";
                            }
                            else
                            {
                                Cliente cliente = new Cliente
                                {
                                    NomeCliente = txtNome.Text.Trim(),
                                    Bi = txtBi.Text.Trim(),
                                    Email = txtEmail.Text.Trim(),
                                    DataNascimento = dtNascimento.SelectedDate.Value.ToShortDateString(),
                                    Morada = txtMorada.Text.Trim()
                                };

                                var exe = ClienteAppConstrutor.ClienteAppDO();
                                try
                                {
                                    exe.Save(cliente);
                                    LimaprCampos();
                                    txtAviso.Text = "Editado com succeso";
                                    smsAviso.IsActive = true;
                                    tmWarning.Start();
                                }
                                catch
                                {
                                    txtAviso.Text = "ocorreu um erro!";
                                    smsAviso.IsActive = true;
                                    tmWarning.Start();
                                }
                            }
                        }
                    }
                }
            }
           
        }

        private void Edit()
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o campo nome.";
                tmWarning.Start();
            }
            else
            {
                if (txtBi.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o campo BI";
                    tmWarning.Start();
                }
                else
                {
                    if (txtEmail.Text.Trim() == string.Empty)
                    {
                        txtEmail.Text = "Null";
                    }
                    else
                    {
                        if (dtNascimento.SelectedDate.Value == null)
                        {
                            dtNascimento.SelectedDate = DateTime.Now;
                        }
                        else
                        {
                            if (txtMorada.Text.Trim() == string.Empty)
                            {
                                txtMorada.Text = "Null";
                            }
                            else
                            {
                                Cliente cliente = new Cliente
                                {
                                    ClienteId = id,
                                    NomeCliente = txtNome.Text.Trim(),
                                    Bi = txtBi.Text.Trim(),
                                    Email = txtEmail.Text.Trim(),
                                    DataNascimento = dtNascimento.SelectedDate.Value.ToShortDateString(),
                                    Morada = txtMorada.Text.Trim()
                                };

                                var exe = ClienteAppConstrutor.ClienteAppDO();
                                try
                                {
                                    exe.Save(cliente);
                                    LimaprCampos();
                                    txtAviso.Text = "Editado com succeso";
                                    smsAviso.IsActive = true;
                                    tmWarning.Start();
                                }
                                catch
                                {
                                    txtAviso.Text = "ocorreu um erro!";
                                    smsAviso.IsActive = true;
                                    tmWarning.Start();
                                }
                            }
                        }
                    }
                }
            }

        }

        private void Delete()
        {
            Cliente client = new Cliente
            {
                ClienteId = id
            };

            var exe = ClienteAppConstrutor.ClienteAppDO();
            try
            {
                exe.Delete(client);
                LimaprCampos();
                txtAviso.Text = "Eliminado com succeso";
                smsAviso.IsActive = true;
                tmWarning.Start();
            }
            catch
            {
                txtAviso.Text = "ocorreu um erro!";
                smsAviso.IsActive = true;
                tmWarning.Start();
            }
        }

        private void GetAll()
        {
            var exe = ClienteAppConstrutor.ClienteAppDO();
            dtClientes.ItemsSource = exe.ListarAll();
            GetTotal();
        }

        private void GetByName()
        {
            var exe = ClienteAppConstrutor.ClienteAppDO();
            dtClientes.ItemsSource = exe.ListarByName(txtSearch.Text.Trim());
            GetTotal();
        }

        private void GetTotal()
        {
            txtTotal.Text = "Total : " + dtClientes.Items.Count;
        }

        #endregion



        #region ========EVENTOS=========

        private void TmWarning_Tick(object sender, EventArgs e)
        {
            if (smsAviso.IsActive == false)
            {
                smsAviso.IsActive = true;
            }
            else
            {
                smsAviso.IsActive = false;
                tmWarning.Stop();
            }

        }

        private void btntest_Click(object sender, RoutedEventArgs e)
        {
            dialogEdit.IsOpen = true;
            txtNome.Focus();
            insert.Visibility = Visibility.Visible;
            update.Visibility = Visibility.Hidden;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            dialogEdit.IsOpen = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dtClientes.Columns[0].Visibility = Visibility.Hidden;
            dtClientes.Columns[1].Header = "Nome";
            dtClientes.Columns[2].Header = "BI";
            dtClientes.Columns[4].Header = "Data de nascimento";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            LimaprCampos();
            Save();
            GetAll();
            dtClientes.Columns[0].Visibility = Visibility.Hidden;
            dtClientes.Columns[1].Header = "Nome";
            dtClientes.Columns[2].Header = "BI";
            dtClientes.Columns[4].Header = "Data de nascimento";
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtBi.Focus();
            }
        }

        private void txtBi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                dtNascimento.Focus();
            }
        }

        private void dtNascimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtMorada.Focus();
            }
        }

        private void txtMorada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (insert.Visibility == Visibility.Hidden)
                {
                    Edit();
                    GetAll();
                    dtClientes.Columns[0].Visibility = Visibility.Hidden;
                    dtClientes.Columns[1].Header = "Nome";
                    dtClientes.Columns[2].Header = "BI";
                    dtClientes.Columns[4].Header = "Data de nascimento";
                }
                else
                {
                    Save();
                    GetAll();
                    dtClientes.Columns[0].Visibility = Visibility.Hidden;
                    dtClientes.Columns[1].Header = "Nome";
                    dtClientes.Columns[2].Header = "BI";
                    dtClientes.Columns[4].Header = "Data de nascimento";
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            GetAll();
            Thread.Sleep(2000);
            dialogEdit.IsOpen = false;
            dtClientes.Columns[0].Visibility = Visibility.Hidden;
            dtClientes.Columns[1].Header = "Nome";
            dtClientes.Columns[2].Header = "BI";
            dtClientes.Columns[4].Header = "Data de nascimento";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
            GetAll();
            Thread.Sleep(2000);
            dialogEdit.IsOpen = false;
            dtClientes.Columns[0].Visibility = Visibility.Hidden;
            dtClientes.Columns[1].Header = "Nome";
            dtClientes.Columns[2].Header = "BI";
            dtClientes.Columns[4].Header = "Data de nascimento";
        }

        private void dtClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Cliente client = dtClientes.SelectedItem as Cliente;
            id = client.ClienteId;
            txtNome.Text = client.NomeCliente;
            txtBi.Text = client.Bi;
            txtEmail.Text = client.Email;
            dtNascimento.SelectedDate = Convert.ToDateTime(client.DataNascimento);
            txtMorada.Text = client.Morada;


            dialogEdit.IsOpen = true;
            txtNome.Focus();
            insert.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Visible;
        }

   

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetByName();
            dtClientes.Columns[0].Visibility = Visibility.Hidden;
            dtClientes.Columns[1].Header = "Nome";
            dtClientes.Columns[2].Header = "BI";
            dtClientes.Columns[4].Header = "Data de nascimento";
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            frmPrint print = new frmPrint();
            print.ShowDialog();
        }

        #endregion
    }
}
