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
using System.Windows.Threading;
using Boutique.Applicacion;
using Boutique.RepositoryADO;
using Boutique.Domain;

namespace DevAppMAXI
{
    /// <summary>
    /// Interaction logic for usrCaixa.xaml
    /// </summary>
    public partial class usrCaixa : UserControl
    {
        static int id;
        CaixaRepositoryADO caixaAdo = new CaixaRepositoryADO();
        DispatcherTimer tmWarning = new DispatcherTimer();


        public usrCaixa()
        {

            tmWarning.Interval = TimeSpan.FromMilliseconds(2000);
            tmWarning.Tick += TmWarning_Tick;
            InitializeComponent();
            GetAll();  
        }


        

        #region ========CRUD===========
        private void LimaprCampos()
        {
            txtValorActual.Clear();
            txtValorInicial.Clear();
            dtClose.Text = "";
            dtOpen.Text = "";
            hrClose.Text = "";
            hrOpen.Text = "";

        }
        private void Organiza()
        {
            dgCiaxa.Columns[0].Header = "Funcinário";
            dgCiaxa.Columns[1].Visibility = Visibility.Hidden;
            dgCiaxa.Columns[2].Header = "Valor inicial";
            dgCiaxa.Columns[3].Header = "Valor actual";
            dgCiaxa.Columns[4].Header = "Data/hora de abertura";
            dgCiaxa.Columns[5].Header = "Data/hora de fecho";
        }
        private void Save()
        {


            if (txtValorInicial.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o o valor inicial";
                tmWarning.Start();
            }
            else
            {
                if (txtValorActual.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o valor actual.";
                    tmWarning.Start();
                }
                else
                {
                    if (dtOpen.Text.Trim() == string.Empty)
                    {
                        dtOpen.SelectedDate = DateTime.Now;
                    }
                    else
                    {
                        if (dtClose.Text.Trim() == string.Empty || dtClose.SelectedDate < dtOpen.SelectedDate)
                        {
                            dtClose.SelectedDate = DateTime.Now;
                        }
                        else
                        {
                            if (hrOpen.Text.Trim() == string.Empty)
                            {
                                hrOpen.SelectedTime = DateTime.Now;
                            }
                            else
                            {
                                if (hrClose.Text.Trim() == string.Empty)
                                {
                                    hrClose.SelectedTime = DateTime.Now;
                                }
                                else
                                {
                                    try
                                    {
                                        Caixa caixa = new Caixa
                                        {
                                            HoraAbertura = Convert.ToDateTime(dtOpen.SelectedDate.Value.ToShortDateString() + " " + hrOpen.SelectedTime.Value.ToLongTimeString()),
                                            HoraFecho = Convert.ToDateTime(dtClose.SelectedDate.Value.ToShortDateString() + " " + hrClose.SelectedTime.Value.ToLongTimeString()),
                                            ValorInicial = txtValorInicial.Text.Trim(),
                                            ValorActual = txtValorActual.Text.Trim(),
                                            UserId = 3
                                        };

                                        var exe = CaixaAppConstrutor.CaixaAppDO();

                                        exe.Save(caixa);
                                        LimaprCampos();
                                        txtAviso.Text = "Guardado com succeso";
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



        }
        private void Edit()
        {


            if (txtValorInicial.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o o valor inicial";
                tmWarning.Start();
            }
            else
            {
                if (txtValorActual.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o valor actual.";
                    tmWarning.Start();
                }
                else
                {
                    if (dtOpen.Text.Trim() == string.Empty)
                    {
                        dtOpen.SelectedDate = DateTime.Now;
                    }
                    else
                    {
                        if (dtClose.Text.Trim() == string.Empty || dtClose.SelectedDate.Value < dtOpen.SelectedDate.Value)
                        {
                            dtClose.SelectedDate = DateTime.Now;
                        }
                        else
                        {
                            if (hrOpen.Text.Trim() == string.Empty)
                            {
                                hrOpen.SelectedTime = DateTime.Now;
                            }
                            else
                            {
                                if (hrClose.Text.Trim() == string.Empty)
                                {
                                    hrClose.SelectedTime = DateTime.Now;
                                }
                                else
                                {


                                    try
                                    {
                                        Caixa caixa = new Caixa
                                        {


                                            CaixaId = id,
                                            ValorInicial = Convert.ToInt32(GetNumber(txtValorInicial.Text.Trim())).ToString(),
                                            ValorActual = Convert.ToInt32(GetNumber(txtValorActual.Text.Trim())).ToString(),
                                            HoraAbertura = Convert.ToDateTime(dtOpen.SelectedDate.Value.ToShortDateString() + " " + hrOpen.SelectedTime.Value.ToLongTimeString()),
                                            HoraFecho = Convert.ToDateTime(dtClose.SelectedDate.Value.ToShortDateString() + " " + hrClose.SelectedTime.Value.ToLongTimeString()),
                                            UserId = 3
                                            /*
                                             O ID do user tem que vir do user logado
                                             */
                                        };

                                        var exe = CaixaAppConstrutor.CaixaAppDO();

                                        exe.Save(caixa);
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



        }
        private void Delete()
        {
            Caixa caixa = new Caixa
            {
                CaixaId = id
            };

            var exe = CaixaAppConstrutor.CaixaAppDO();
            try
            {
                exe.Delete(caixa);
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

            dgCiaxa.ItemsSource = caixaAdo.GetAll();
            GetTotal();

        }
        private void GetByName()
        {

            dgCiaxa.ItemsSource = caixaAdo.GetByName(txtSearch.Text.Trim());
            GetTotal();

        }
        private void GetTotal()
        {
            txtTotal.Text = "Total : " + dgCiaxa.Items.Count;
        }
        private string GetNumber(string campo)
        {
            string strRight = "";
            char comman = ',';
            char[] campos = campo.ToArray();
            for (int i = 0; i < campo.Length; i++)
            {
                if (campos[i] != comman)
                {
                    strRight += campos[i];
                }
                else
                {
                    break;
                }

            }

            return strRight;
        }
        #endregion


        #region =======EVENTOS========
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
            insert.Visibility = Visibility.Visible;
            update.Visibility = Visibility.Hidden;
            dialogEdit.IsOpen = true;
            txtTitle.Text = "Nova Ciaxa";
            dialogEdit.IsOpen = true;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            dialogEdit.IsOpen = false;
        }
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
            GetAll();
            Organiza();
            LimaprCampos();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            GetAll();
            Organiza();
            LimaprCampos();
            dialogEdit.IsOpen = false;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
            GetAll();
            Organiza();
            dialogEdit.IsOpen = false;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Organiza();
        }
        private void txtValorInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtValorActual.Focus();
            }
        }
        private void txtValorActual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                dtOpen.Focus();
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetByName();
            Organiza();
        }
        private void dgCiaxa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewCaixa caixa = dgCiaxa.SelectedItem as viewCaixa;
            id = caixa.CaixaId;
            txtValorInicial.Text = caixa.ValorInicial;
            txtValorActual.Text = caixa.ValorActual;
            dtOpen.SelectedDate = caixa.HoraAbertura;
            dtClose.SelectedDate = caixa.HoraFecho;
            hrOpen.SelectedTime = caixa.HoraAbertura;
            hrClose.SelectedTime = caixa.HoraFecho;
            insert.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Visible;
            dialogEdit.IsOpen = true;
            txtTitle.Text = "Editar Caixa";

        }
        #endregion
    }


}
