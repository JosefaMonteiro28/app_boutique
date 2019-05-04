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
using Boutique.Domain;
using Boutique.Applicacion;
using System.Windows.Threading;
using System.Threading;

namespace DevAppMAXI
{
    /// <summary>
    /// Interaction logic for usrUsuarios.xaml
    /// </summary>
    public partial class usrUsuarios : UserControl
    {
        static int id;

        DispatcherTimer tmWarning = new DispatcherTimer();
        public usrUsuarios()
        {
            tmWarning.Interval = TimeSpan.FromMilliseconds(2000);
            tmWarning.Tick += TmWarning_Tick;
            InitializeComponent();
            GetAll();
        }

      



        #region ========CRUD===========
       
        private void Save()
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o campo nome.";
                tmWarning.Start();
            }
            else
            {
                if (txtUsrName.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o nome do usuário";
                    tmWarning.Start();
                }
                else
                {
                    if (txtPassWord.Password.Trim() == string.Empty)
                    {
                        txtAviso.Text = "Preencha a palavra-passe";
                        tmWarning.Start();
                    }
                    else
                    {

                        Usuario cliente = new Usuario
                        {
                           
                            Nome = txtNome.Text.Trim(),
                            UserName = txtUsrName.Text.Trim(),
                            Password = txtPassWord.Password.Trim()
                        };

                        var exe = UsuarioAppConstrutor.UsuarioAppDO();
                        try
                        {
                            exe.Save(cliente);
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
        private void Edit()
        {
            if (txtNome.Text.Trim() == string.Empty)
            {
                txtAviso.Text = "Preencha o campo nome.";
                tmWarning.Start();
            }
            else
            {
                if (txtUsrName.Text.Trim() == string.Empty)
                {
                    txtAviso.Text = "Preencha o nome do usuário";
                    tmWarning.Start();
                }
                else
                {
                    if (txtPassWord.Password.Trim() == string.Empty)
                    {
                        txtAviso.Text = "Preencha a palavra-passe";
                        tmWarning.Start();
                    }
                    else
                    {

                        Usuario cliente = new Usuario
                        {
                            UserId = id,
                            Nome = txtNome.Text.Trim(),
                            UserName = txtUsrName.Text.Trim(),
                            Password = txtPassWord.Password.Trim()
                        };

                        var exe = UsuarioAppConstrutor.UsuarioAppDO();
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
        private void Delete()
        {
            Usuario client = new Usuario
            {
                UserId = id
            };

            var exe = UsuarioAppConstrutor.UsuarioAppDO();
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
            var exe = UsuarioAppConstrutor.UsuarioAppDO();
            dgUsrs.ItemsSource = exe.ListarAll();
            GetTotal();
        }
        private void GetByName()
        {
            var exe = UsuarioAppConstrutor.UsuarioAppDO();
            dgUsrs.ItemsSource = exe.ListarByName(txtSearch.Text.Trim());
            GetTotal();
        }
        private void LimaprCampos()
        {
            txtNome.Clear();
            txtPassWord.Clear();
            txtUsrName.Clear();

        }
        private void OrganizaDgView()
        {
            dgUsrs.Columns[0].Visibility = Visibility.Hidden;
            dgUsrs.Columns[1].Header = "Nome";
            dgUsrs.Columns[2].Header = "Nome de usuário";
            dgUsrs.Columns[3].Header = "Palavra-passe";
        }

        private void GetTotal()
        {
            txtTotal.Text = "Total : " + dgUsrs.Items.Count;
        }

        #endregion


        #region=======EVENTOS========
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
            txtTitle.Text = "Novo usuário";
            dialogEdit.IsOpen = true;
            txtNome.Focus();
            insert.Visibility = Visibility.Visible;
            update.Visibility = Visibility.Hidden;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            dialogEdit.IsOpen = false;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
            GetAll();
            OrganizaDgView();
            LimaprCampos();
            dialogEdit.IsOpen = false;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            GetAll();
            OrganizaDgView();
            LimaprCampos();
            Thread.Sleep(2000);
            dialogEdit.IsOpen = false;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OrganizaDgView();  
        }
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtUsrName.Focus();
            }
        }
        private void txtUsrName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key  == Key.Return)
            {
                txtPassWord.Focus();
            }
        }
        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Save();
                GetAll();
                OrganizaDgView();
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
            GetAll();
            OrganizaDgView();
            LimaprCampos();
            dialogEdit.IsOpen = false;
        }
        private void dgUsrs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LimaprCampos();
            txtTitle.Text = "Editar usuário";
            insert.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Visible;

            Usuario user = dgUsrs.SelectedItem as Usuario;
            id = user.UserId;
            txtNome.Text = user.Nome;
            txtUsrName.Text = user.UserName;
            txtPassWord.Password = user.Password;
            
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
