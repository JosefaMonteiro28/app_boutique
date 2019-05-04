using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Boutique.Domain;
using Boutique.RepositoryADO;

namespace Boutique.Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            // cliente teste = new cliente
            // {
            //     clienteid = convert.toint32(2),

            // };

            //clienterepositoryado novo = new clienterepositoryado();
            // novo.delete(teste);


            //CaixaRepositoryADO novo = new CaixaRepositoryADO();
            //var testes = novo.ListarAll();
            //foreach (var teste1 in testes)
            //{
            //    Console.WriteLine( teste1.ValorActual + teste1.ValorInicial, teste1.UserId, teste1.CaixaId );
            //}


            //Stock teste = new Stock
            //{
            //    DataCriacao = DateTime.Parse("2019.1.11"),

            //    PrecoCompra = "500.00",
            //    PrecoVenda = "2000.00",
            //    QtdEncomendada = Convert.ToInt32(3),
            //    QtdExistente = Convert.ToInt32(1),
            //    QtdMinima = Convert.ToInt32(1),
            //    ProdutoId = Convert.ToInt32(1),

            //    };
            //    StockRepositoryADO novo = new StockRepositoryADO();
            //    novo.Insert(teste);
            //Produto testes = new Produto
            //{
            //    Descricao = "Lacoste",
            //    Imagem = "http/testes/juytn",
            //    CategoriaId = Convert.ToInt32(2),

            //};
            //ProdutoRepositoryADO novos = new ProdutoRepositoryADO();
            //novos.Insert(testes);


            Usuario teste = new Usuario
            {
                Nome = "Manucha",
                UserName = "monteiro",
                Password = "ana",
                UserId = Convert.ToInt32(2)
                
            };

            UsuarioRepositoryADO novo = new UsuarioRepositoryADO();
            //novo.Save(teste);

            foreach (var item in novo.ListarAll())
            {
                Console.WriteLine(item.Nome);
            }

            //Categoria teste = new Categoria
            //{
            //    DescricaoCategoria = "Cascos",
            //    CategoriaId = Convert.ToInt32(1),


            //};
            //CategoriaRepositoryADO novo = new CategoriaRepositoryADO();
            //novo.Save(teste);


            Console.WriteLine("gravado");
            Console.ReadKey();


        }
    }
}
