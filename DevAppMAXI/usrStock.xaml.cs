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
using Microsoft.Win32;
using System.Data;
using System.Windows.Threading;
using Boutique.Domain;
using Boutique.Applicacion;
using Boutique.RepositoryADO;

namespace DevAppMAXI
{
    /// <summary>
    /// Interaction logic for usrStock.xaml
    /// </summary>
    public partial class usrStock : UserControl
    {

        static int id;

        DispatcherTimer tmWarning = new DispatcherTimer();
        StockRepositoryADO exe = new StockRepositoryADO();
        

        public usrStock()
        {
            tmWarning.Interval = TimeSpan.FromMilliseconds(2000);
            tmWarning.Tick += TmWarning_Tick;
            InitializeComponent();
            GetAll();         
            PreencheCbx();
        }
        #region============CRUD==========


        private void Save()
        {
            if (cbxProdut.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Escolhe o produto.";
                tmWarning.Start();
            }
            else {
                if (txtQtdEnco.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o campo Quatidade encomentada";
                    tmWarning.Start();
                }
                else
                {
                    if (txtQtdExist.Text.Trim() == string.Empty)
                    {
                        txtAviso.Text = "Preencha o campo Quatidade exiteste";
                        tmWarning.Start();
                    }
                    else
                    {
                        if (txtQtdMinima.Text == string.Empty)
                        {
                            txtAviso.Text = "Preencha o campo Quatidade mínima";
                            tmWarning.Start();
                        }
                        else
                        {
                            if (txtPreComp.Text.Trim() == string.Empty)
                            {
                                txtAviso.Text = "Preencha o campo preço de compra";
                                tmWarning.Start();
                            }
                            else
                            {
                                if (txtPreVend.Text.Trim() == string.Empty)
                                {
                                    txtAviso.Text = "Preencha o campo preço de venda";
                                    tmWarning.Start();
                                }
                                else
                                {
                                    if (dtCriacao.Text.Trim() == string.Empty)
                                    {
                                        dtCriacao.SelectedDate = DateTime.Now;
                                    }
                                    else
                                    {
                                        if (hrCricao.Text.Trim() == string.Empty)
                                        {
                                            hrCricao.SelectedTime = DateTime.Now;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(txtQtdEnco.Text) < Convert.ToInt32(txtQtdExist.Text) || Convert.ToInt32(txtQtdEnco.Text) < Convert.ToInt32(txtQtdMinima.Text) || Convert.ToInt32(txtQtdExist.Text) < Convert.ToInt32(txtQtdExist.Text))
                                            {
                                                txtAviso.Text = "Os valores das quantidades estão errada";
                                                tmWarning.Start();
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    Stock estoque = new Stock
                                                    {

                                                        QtdEncomendada = Convert.ToInt32(txtQtdEnco.Text.Trim()),
                                                        QtdExistente = Convert.ToInt32(txtQtdExist.Text.Trim()),
                                                        QtdMinima = Convert.ToInt32(txtQtdMinima.Text.Trim()),
                                                        DataCriacao = dtCriacao.SelectedDate.Value,
                                                        PrecoCompra = Convert.ToInt32(GetNumber(txtPreComp.Text.Trim())).ToString(),
                                                        PrecoVenda = Convert.ToInt32(GetNumber(txtPreVend.Text.Trim())).ToString(),
                                                        ProdutoId = Convert.ToInt32(cbxProdut.SelectedValue)


                                                    };



                                                    var exe = StockAppConstrutor.SctoAppADO();

                                                    exe.Save(estoque);
                                                    LimparCampos();
                                                    txtAviso.Text = "Guardado com succeso";

                                                    tmWarning.Start();
                                                }
                                                catch
                                                {
                                                    txtAviso.Text = "ocorreu um erro!";

                                                    tmWarning.Start();
                                                }
                                            }
                                        }
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
            if (cbxProdut.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Escolhe o produto.";
                tmWarning.Start();
            }
            else
            {
                if (txtQtdEnco.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o campo Quatidade encomentada";
                    tmWarning.Start();
                }
                else
                {
                    if (txtQtdExist.Text.Trim() == string.Empty)
                    {
                        txtAviso.Text = "Preencha o campo Quatidade exiteste";
                        tmWarning.Start();
                    }
                    else
                    {
                        if (txtQtdMinima.Text == string.Empty)
                        {
                            txtAviso.Text = "Preencha o campo Quatidade mínima";
                            tmWarning.Start();
                        }
                        else
                        {
                            if (txtPreComp.Text.Trim() == string.Empty)
                            {
                                txtAviso.Text = "Preencha o campo preço de compra";
                                tmWarning.Start();
                            }
                            else
                            {
                                if (txtPreVend.Text.Trim() == string.Empty)
                                {
                                    txtAviso.Text = "Preencha o campo preço de venda";
                                    tmWarning.Start();
                                }
                                else
                                {
                                    if (dtCriacao.Text.Trim() == string.Empty)
                                    {
                                        dtCriacao.SelectedDate = DateTime.Now;
                                    }
                                    else
                                    {
                                        if (hrCricao.Text.Trim() == string.Empty)
                                        {
                                            hrCricao.SelectedTime = DateTime.Now;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(txtQtdEnco.Text) < Convert.ToInt32(txtQtdExist.Text) || Convert.ToInt32(txtQtdEnco.Text) < Convert.ToInt32(txtQtdMinima.Text) || Convert.ToInt32(txtQtdExist.Text) < Convert.ToInt32(txtQtdExist.Text))
                                            {
                                                txtAviso.Text = "Os valores das quantidades estão errada";
                                                tmWarning.Start();
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    Stock estoque = new Stock
                                                    {

                                                        StockId = id,
                                                        QtdEncomendada = Convert.ToInt32(txtQtdEnco.Text.Trim()),
                                                        QtdExistente = Convert.ToInt32(txtQtdExist.Text.Trim()),
                                                        QtdMinima = Convert.ToInt32(txtQtdMinima.Text.Trim()),
                                                        DataCriacao = dtCriacao.SelectedDate.Value,
                                                        PrecoCompra = Convert.ToInt32(GetNumber(txtPreComp.Text.Trim())).ToString(),
                                                        PrecoVenda = Convert.ToInt32(GetNumber(txtPreVend.Text.Trim())).ToString(),
                                                        ProdutoId = Convert.ToInt32(cbxProdut.SelectedValue)


                                                    };



                                                    var exe = StockAppConstrutor.SctoAppADO();

                                                    exe.Save(estoque);
                                                    LimparCampos();
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
                }
            }
        }
        private void Delete()
        {
            Stock stock = new Stock
            {
                StockId = id
            };

            var exe = StockAppConstrutor.SctoAppADO();
            try
            {
                exe.Delete(stock);
                LimparCampos();
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
        private void PreencheCbx()
        {
            var exe = ProdutoAppConstrutor.ProdutoAppDO();
            var dados = exe.ListarAll();
            cbxProdut.DisplayMemberPath = "Descricao";
            cbxProdut.SelectedValuePath = "ProdutoId";
            cbxProdut.ItemsSource = dados.ToList();
        }
        private void GetAll()
        { 
            dgStock.ItemsSource = exe.GetAll();
            GetTotal();
        }
        private void GetByName()
        {          
            dgStock.ItemsSource = exe.GetByName(txtSearch.Text.Trim());
            GetTotal();
        }
        private void LimparCampos()
        {
            txtPreComp.Clear();
            txtPreVend.Clear();
            txtQtdEnco.Clear();
            txtQtdExist.Clear();
            txtQtdMinima.Clear();
            cbxProdut.Text = "";

        }
        private void OrganizaDgView()
        {
            dgStock.Columns[1].Visibility = Visibility.Hidden;
            dgStock.Columns[0].Header = "Produto";
            dgStock.Columns[2].Header = "Quantidade encomendada";
            dgStock.Columns[3].Header = "Quantidade existente";
            dgStock.Columns[4].Header = "Quantidade mínima";
            dgStock.Columns[5].Header = "Preço de compra";
            dgStock.Columns[6].Header = "Preço de venda";
            dgStock.Columns[7].Header = "Data da criação";

            dgStock.Columns[2].Width = 170;
            dgStock.Columns[3].Width = 170;
            dgStock.Columns[4].Width = 170;
            dgStock.Columns[5].Width = 170;
            dgStock.Columns[6].Width = 170;
            dgStock.Columns[7].Width = 170;   
        }
        private void GetTotal()
        {
            txtTotal.Text = "Total : " + dgStock.Items.Count;
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


        #region ==========EVENTOS===============
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
            txtTitle.Text = "Novo Estoque";
            dialogEdit.IsOpen = true;
            insert.Visibility = Visibility.Visible;
            update.Visibility = Visibility.Hidden;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            dialogEdit.IsOpen = false;
            LimparCampos();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
            GetAll();
            OrganizaDgView();
            dialogEdit.IsOpen = false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            GetAll();
            OrganizaDgView();
            dialogEdit.IsOpen = false;
        }

       

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          OrganizaDgView();
            hrCricao.SelectedTime = DateTime.Now;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
            GetAll();
            OrganizaDgView();
           dialogEdit.IsOpen = false;
        }

        private void dgStock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewStock stock = dgStock.SelectedItem as ViewStock;
            id = stock.StockId;
            cbxProdut.Text = stock.Produto;
            txtQtdEnco.Text = stock.QtdEncomendada.ToString();
            txtQtdExist.Text = stock.QtdExistente.ToString();
            txtQtdMinima.Text = stock.QtdMinima.ToString();
            txtPreComp.Text = stock.PrecoCompra;
            txtPreVend.Text = stock.PrecoVenda;
            dtCriacao.SelectedDate = stock.DataCriacao;
            hrCricao.SelectedTime = stock.DataCriacao;

            insert.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Visible;
            dialogEdit.IsOpen = true;
            txtTitle.Text = "Editar Estoque";
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetByName();
            OrganizaDgView();
        }

        private void txtQtdEnco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtQtdExist.Focus();
            }
        }

        private void txtQtdExist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtQtdMinima.Focus();
            }
        }

        private void txtQtdMinima_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtPreComp.Focus();
            }
        }

        private void txtPreComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtPreVend.Focus();
            }
        }

        private void txtPreVend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                dtCriacao.Focus();
            }
        }

        #endregion
    }


}
