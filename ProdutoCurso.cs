using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestorEstoque
{
    [System.Serializable]
    class ProdutoCurso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public ProdutoCurso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"-- ADICIONAR VAGAS [{nome}] -- ");
            Console.WriteLine("VAGAS: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada; 
            Console.WriteLine("[SUCESSO!] Vagas Registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"-- CONSUMIR VAGAS [{nome}] -- ");
            Console.WriteLine("VAGAS -> BAIXA: ");
            int saida = int.Parse(Console.ReadLine());
            vagas -= saida; 
            Console.WriteLine("[SUCESSO] Vagas Retirada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"NOME  :  {nome}");
            Console.WriteLine($"AUTOR :  {autor}");
            Console.WriteLine($"PREÇO :R${preco}");
            Console.WriteLine($"VAGAS :  {vagas}");
            Console.WriteLine("-------------------------");
        }
    }
}