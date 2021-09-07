using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestorEstoque
{
    [System.Serializable]
    abstract class Produto
    {
        public string nome;
        public float preco;
    }
}