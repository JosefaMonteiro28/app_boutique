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
using System.Windows.Threading;
using Boutique.Applicacion;
using Boutique.Domain;
using Boutique.RepositoryADO;
using System.IO;

namespace DevAppMAXI
{
    /// <summary>
    /// Interaction logic for usrProduct.xaml
    /// </summary>
    public partial class usrProduct : UserControl
    {
        static int id;
        string caminho = "C:\\SGBD\\Imagens\\";

        OpenFileDialog getImg;
        DispatcherTimer tmWarning = new DispatcherTimer();
        ProdutoRepositoryADO exe = new ProdutoRepositoryADO();
        public usrProduct()
        {
            getImg = new OpenFileDialog
            {
                Title = "Imagem do produto",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Filter = "JPG |*.JPG| PNG |*.PNG"
            };


            tmWarning.Interval = TimeSpan.FromMilliseconds(2000);
            tmWarning.Tick += TmWarning_Tick;

            InitializeComponent();

            PreencheCbx();
            GetAll();

            BitmapImage d = new BitmapImage(new Uri(@caminho+"icone.png"));
            imgProduct.Source = d;

          

            
        }

        #region ========CRUD==========
        private void PreencheCbx()
        {
            var exe = CategoriaAppConstutor.CategoriaAppDO();
            var dados = exe.ListarAll();
            cbxCategoria.DisplayMemberPath = "DescricaoCategoria";
            cbxCategoria.SelectedValuePath = "CategoriaId";
            cbxCategoria.ItemsSource = dados.ToList();
        }
        private void Save()
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o campo nome";
                tmWarning.Start();
                return;
            }
            else
            {
                if (cbxCategoria.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Escolhe uma categoria";
                    tmWarning.Start();
                    return;
                }
                else
                {
                    if (txtImg.Text.Trim() == string.Empty)
                    {
                        txtAviso.Text = "Escolhe uma imagem";
                        tmWarning.Start();
                        return;
                    }
                    else
                    {

                        try
                        {
                            if (txtImg.Text == "Nenhuma imagem seleccionada")
                            {

                                Produto estoque = new Produto
                                {

                                    Descricao = txtNome.Text.Trim(),
                                    CategoriaId = Convert.ToInt32(cbxCategoria.SelectedValue),
                                    Imagem = @caminho + "icone.png"

                                };


                                var exe = ProdutoAppConstrutor.ProdutoAppDO();
                                exe.Save(estoque);

                                txtAviso.Text = "Guardado com succeso";
                                smsAviso.IsActive = true;
                                tmWarning.Start();
                            }

                            else
                            {
                                var ficheiro = caminho + System.IO.Path.GetFileName(getImg.SafeFileName);
                                if (File.Exists(ficheiro))
                                {
                                    txtAviso.Text = "Ficheiro existente";
                                    tmWarning.Start();
                                    return;
                                }
                                else
                                {
                                    File.Copy(txtImg.Text, ficheiro);
                                    Produto estoque = new Produto
                                    {

                                        Descricao = txtNome.Text.Trim(),
                                        CategoriaId = Convert.ToInt32(cbxCategoria.SelectedValue),
                                        Imagem = ficheiro

                                    };


                                    var exe = ProdutoAppConstrutor.ProdutoAppDO();
                                    exe.Save(estoque);

                                    txtAviso.Text = "Guardado com succeso";
                                    smsAviso.IsActive = true;
                                    tmWarning.Start();
                                }
                            }

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
        private void Edit()
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o campo nome";
                tmWarning.Start();
                return;
            }
            else
            {
                if (cbxCategoria.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Escolhe uma categoria";
                    tmWarning.Start();
                    return;
                }
                else
                {
                    if (txtImg.Text.Trim() == string.Empty)
                    {
                        txtAviso.Text = "Escolhe uma imagem";
                        tmWarning.Start();
                        return;
                    }
                    else
                    {

                        try
                        {
                            if (txtImg.Text == "Nenhuma imagem seleccionada")
                            {

                                Produto estoque = new Produto
                                {
                                    ProdutoId = id,
                                    Descricao = txtNome.Text.Trim(),
                                    CategoriaId = Convert.ToInt32(cbxCategoria.SelectedValue),
                                    Imagem = @caminho + "icone.png",

                                };


                                var exe = ProdutoAppConstrutor.ProdutoAppDO();
                                exe.Save(estoque);

                                txtAviso.Text = "Editado com succeso";
                                smsAviso.IsActive = true;
                                tmWarning.Start();
                            }

                            else
                            {
                                if (getImg.SafeFileName == "")
                                {
                                    string ficheiro = caminho + "icone.png";


                                    if (File.Exists(ficheiro))
                                    {
                                        txtAviso.Text = "Ficheiro existente.";
                                        tmWarning.Start();
                                    }
                                    else
                                    {
                                        File.Copy(txtImg.Text, ficheiro);
                                        Produto estoque = new Produto
                                        {
                                            ProdutoId = id,
                                            Descricao = txtNome.Text.Trim(),
                                            CategoriaId = Convert.ToInt32(cbxCategoria.SelectedValue),
                                            Imagem = ficheiro

                                        };


                                        var exe = ProdutoAppConstrutor.ProdutoAppDO();
                                        exe.Save(estoque);

                                        txtAviso.Text = "Editado com succeso";
                                        smsAviso.IsActive = true;
                                        tmWarning.Start();
                                    }

                                }
                                else
                                {
                                    string ficheiro = caminho + System.IO.Path.GetFileName(getImg.SafeFileName);


                                    if (File.Exists(ficheiro))
                                    {
                                        txtAviso.Text = "Ficheiro existente.";
                                        tmWarning.Start();
                                    }
                                    else
                                    {
                                        File.Copy(txtImg.Text, ficheiro);
                                        Produto estoque = new Produto
                                        {
                                            ProdutoId = id,
                                            Descricao = txtNome.Text.Trim(),
                                            CategoriaId = Convert.ToInt32(cbxCategoria.SelectedValue),
                                            Imagem = ficheiro

                                        };

                                      
                                        var exe = ProdutoAppConstrutor.ProdutoAppDO();
                                        exe.Save(estoque);

                                        txtAviso.Text = "Editado com succeso";
                                        smsAviso.IsActive = true;
                                        tmWarning.Start();
                                    }
                                }
                            }
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
        private void Delete()
        {
            Produto produto = new Produto
            {
                ProdutoId = id
            };

            var exe = ProdutoAppConstrutor.ProdutoAppDO();
            try
            {
                exe.Delete(produto);
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
        private void GetAll()
        {
            dgProduct.ItemsSource = exe.GetAll();
            GetTotal();
        }
        private void GetByName()
        {
            dgProduct.ItemsSource = exe.GetByName(txtSearch.Text.Trim());
            GetTotal();
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtImg.Clear();
            tgEnable.IsChecked = true;
        }
        private void OrganizaDgView()
        {

            dgProduct.Columns[0].Visibility = Visibility.Hidden;
            dgProduct.Columns[1].Header = "Nome";
            dgProduct.Columns[2].Header = "Categoria";
            dgProduct.Columns[3].Visibility = Visibility.Hidden;


            dgProduct.Columns[1].Width = 385;
            dgProduct.Columns[2].Width = 385;

        }
        private void GetTotal()
        {
            txtTotal.Text = "Total : " + dgProduct.Items.Count;
        }
        #endregion

        #region =====EVENTOS========
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
        private void txtImg_GotFocus(object sender, RoutedEventArgs e)
        {


            getImg.ShowDialog();
            string v = getImg.FileName;

            if (getImg.FileName == "")
            {
                txtImg.Text = "Nenhuma imagem seleccionada";
                txtImg.IsEnabled = false;
                tgEnable.IsChecked = false;
            }
            else
            {
                txtImg.Text = getImg.FileName.ToString();
                BitmapImage bi = new BitmapImage(new Uri(getImg.FileName));
                imgProduct.Source = bi;
                txtImg.IsEnabled = false;
                tgEnable.IsChecked = false;
            }


        }
        private void btntest_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Focus();
            dgProduct.SelectedIndex = -1;
            LimparCampos();   
            dialogEdit.IsOpen = true;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(@"" + caminho + "icone.png"));
            imgProduct.Source = bi;
            dialogEdit.IsOpen = false;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            GetAll();
            OrganizaDgView();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
            GetAll();
            OrganizaDgView();
        }
        private void tgEnable_Click(object sender, RoutedEventArgs e)
        {
            if (tgEnable.IsChecked == true)
            {
                txtImg.IsEnabled = true;
            }
            else
            {
                txtImg.IsEnabled = false;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
            GetAll();
            OrganizaDgView();
        }
        private void dgProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProduct.SelectedIndex == -1)
            {
                BitmapImage bi = new BitmapImage(new Uri(@"" + caminho + "icone.png"));
                imgProduct.Source = bi;
            }
            else
            {
                ViewProduto getImg = dgProduct.SelectedItem as ViewProduto;
                BitmapImage bi = new BitmapImage(new Uri(@"" + getImg.Imagem));
                imgProduct.Source = bi;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OrganizaDgView();
        }
        private void dgProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewProduto dados = dgProduct.SelectedItem as ViewProduto;
            id = dados.ProdutoId;
            txtNome.Text = dados.Nome;
            cbxCategoria.Text = dados.Categoria;
            txtImg.Text = dados.Imagem;

            insert.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Visible;
            txtTitle.Text = "Editar Produto";
            dialogEdit.IsOpen = true;
            
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetByName();
            OrganizaDgView();
        }

        #endregion


    }
}
