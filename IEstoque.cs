using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestorEstoque
{
    interface IEstoque
    {
        void Exibir(); //Exibir informações do produto
        void AdicionarEntrada(); //Adicionar um novo item no estoque
        void AdicionarSaida(); //Para registrar a venda dos produtos
    }
}