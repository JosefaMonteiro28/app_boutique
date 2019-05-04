using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boutique.Domain;
using Boutique.RepositoryADO.Contrato;
using System.Data.SqlClient;

namespace Boutique.RepositoryADO
{
    public class UsuarioRepositoryADO : IRepository<Usuario>
    {
        private Contexto contexto;
        public void Delete(Usuario usuario)
        {
            var query = "";
            query += string.Format("DELETE FROM tb_usuario Where UserId ={0}", usuario.UserId);
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        private void Insert(Usuario usuario)
        {
            var query = "";
            query += "INSERT INTO tb_usuario(Nome,UserName,Password)";
            query += string.Format("VALUES('{0}','{1}','{2}')", usuario.Nome, usuario.UserName, usuario.Password);
            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }

        }

        public IEnumerable<Usuario> ListarAll()
        {
            contexto = new Contexto();
            var query = "SELECT *FROM tb_usuario ORDER BY Nome";
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornarDataReader);
        }


        public IEnumerable<Usuario> ListarByName(string name)
        {
            contexto = new Contexto();
            var query = string.Format("SELECT * FROM tb_usuario WHERE  Nome LIKE '%{0}%'  ORDER BY Nome", name);
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornarDataReader);
        }
        public List<Usuario> ListarObjec(SqlDataReader reader)
        {
            var Usuario = new List<Usuario>();
            while (reader.Read())
            {
                var TemObje = new Usuario()
                {
                    UserId = Convert.ToInt32(reader["UserId"].ToString()),
                    Nome = (reader["Nome"].ToString()),
                    UserName = (reader["UserName"].ToString()),
                    Password = (reader["Password"].ToString()),

                };
                Usuario.Add(TemObje);
            }
            return Usuario;
        }
        public Usuario ListarById(string id)
        {
            contexto = new Contexto();
            var query = "SELECT *FROM tb_usuario WHERE UserId='{0}'";
            var RetornarDataReader = contexto.ExeWithRetorno(query);
            return ListarObjec(RetornarDataReader).FirstOrDefault();
        }

        private void Update(Usuario usuario)
        {
            var query = "";
            query += "UPDATE tb_usuario SET";
            query += string.Format(" Nome = '{0}',", usuario.Nome);
            query += string.Format(" UserName = '{0}',", usuario.UserName);
            query += string.Format(" Password = '{0}'", usuario.Password);
            query += string.Format(" WHERE UserId= {0}", usuario.UserId);

            using (contexto = new Contexto())
            {
                contexto.Exe(query);
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.UserId > 0)
            {
                Update(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }
    }
}
