using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class Cidade
    {
        private int codCidade;
        private string nomeCidade;
        private int coordX, coordY;
        public Cidade(int codCidade, string nomeCidade, int coordX, int coordY)
        {
            CodCidade = codCidade;
            NomeCidade = nomeCidade;
            CoordX = coordX;
            CoordY = coordY;
        }
        public int CodCidade 
        { 
            get => codCidade; 
            set => codCidade = value; 
        }
        public string NomeCidade 
        { 
            get => nomeCidade; 
            set => nomeCidade = value; 
        }
        public int CoordX 
        { 
            get => coordX; 
            set => coordX = value; 
        }
        public int CoordY 
        { 
            get => coordY; 
            set => coordY = value; 
        }
    }
}
