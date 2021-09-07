using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestorEstoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"-- ADICIONAR ESTOQUE [{nome}] -- ");
            Console.WriteLine("QUANTIDADE: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada; 
            Console.WriteLine("[SUCESSO!] Entrada Registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"-- ADICIONAR SAIDA ESTOQUE [{nome}] -- ");
            Console.WriteLine("QUANTIDADE -> BAIXA: ");
            int saida = int.Parse(Console.ReadLine());
            estoque -= saida; 
            Console.WriteLine("[SUCESSO] Saida Registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"NOME  :   {nome}");
            Console.WriteLine($"PREÇO : R${preco}");
            Console.WriteLine($"FRETE : R${frete}");
            Console.WriteLine($"ESTOQUE:  {estoque}");
            Console.WriteLine("-------------------------");
        }
    }
}