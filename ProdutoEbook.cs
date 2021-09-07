using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestorEstoque
{
    [System.Serializable]
    class ProdutoEbook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public ProdutoEbook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("[ERRO!] Não é possível dar entrada em um produto digital");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"-- ADICIONAR VENDAS - E-BOOK [{nome}] -- ");
            Console.WriteLine("VENDAS: ");
            int venda = int.Parse(Console.ReadLine());
            vendas += venda; 
            Console.WriteLine("[SUCESSO] Venda Registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"NOME  :  {nome}");
            Console.WriteLine($"AUTOR :  {autor}");
            Console.WriteLine($"PREÇO :R${preco}");
            Console.WriteLine($"VENDAS:  {vendas}");
            Console.WriteLine("-------------------------");
        }
    }
}