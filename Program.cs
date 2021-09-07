using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; // SERIALIZADOR - Arquivo Binário
using System.IO; //FileStream

namespace GestorEstoque
{
    class Program
    {
        enum Menu {Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}
        static List<IEstoque> produtos= new List<IEstoque>(); 

        static void Main(string[] args)
        {
            Carregar();
            bool sair = false;
            
            while(sair == false)
            {
                Console.WriteLine(" -- BEM VINDO -- ");
                Console.WriteLine("[1] LISTAR\n[2] ADICIONAR\n[3] REMOVER\n[4] REGISTRAR ENTRADA\n[5] REGISTRAR SAÍDA\n[6] SAIR");
                int opInt = int.Parse(Console.ReadLine());

                if(opInt > 0 && opInt < 7) 
                {
                    Menu escolha = (Menu)opInt; //Cast -> int / enum
                    switch(escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        
                        case Menu.Adicionar:
                            Cadastro();
                            break;

                        case Menu.Remover:
                            Remover();
                            break;
                        
                        case Menu.Entrada:
                            Entrada();
                            break;

                        case Menu.Saida:
                            Saida();
                            break;
                        
                        case Menu.Sair:
                            sair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("[ERRO 01] Opção Inválida!");
                    sair = true;
                }
                Console.Clear();
            }
        }

        static void Listagem()
        {
            Console.WriteLine(" -- LISTA -- ");

            int i =0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: "+ i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do Elemento que deseja remover: ");
            int id = int.Parse(Console.ReadLine());

            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do Elemento que deseja dar entrada: ");
            int id = int.Parse(Console.ReadLine());

            if(id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do Elemento que deseja dar baixa: ");
            int id = int.Parse(Console.ReadLine());

            if(id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine(" -- CADASTRAR -- ");
            Console.WriteLine("[1] PRODUTO FÍSICO\n[2] EBOOK\n[3] CURSO ");
            int opcao = int.Parse(Console.ReadLine());

            if(opcao > 0 && opcao < 4)
            {
                switch(opcao)
                {
                    case 1:
                        CadastrarProdutoFisico();
                        break;
                    case 2:
                        CadastrarEbook();
                        break;
                    case 3:
                        CadastrarCurso();
                        break;
                }
            }
            else
            {
                Console.WriteLine("[ERRO 02] Opção de Cadastro Inválida!");
            }
        }

        static void CadastrarProdutoFisico()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(" -- PRODUTO FÍSICO -- ");

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf); //Lista produtos
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(" -- CADASTRO EBOOK -- ");

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            ProdutoEbook eb = new ProdutoEbook(nome, preco, autor);
            produtos.Add(eb); 
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine(" -- CADASTRO CURSO -- ");

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            ProdutoCurso curso = new ProdutoCurso(nome, preco, autor);
            produtos.Add(curso); 
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);
            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                } 
            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }
    }
}
