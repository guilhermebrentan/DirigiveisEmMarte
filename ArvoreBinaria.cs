using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace apCaminhosMarte
{
    class ArvoreBinaria
    {
        private const int inicioCodCidade = 0, tamanhoCodCidade = 3;
        private const int inicioNomeCidade = 3, tamanhoNomeCidade = 15;
        private const int inicioCoordXCidade = 18, tamanhoCoordXCidade = 5;
        private const int inicioCoordYCidade = 23, tamanhoCoordYCidade = 5;

        public class No
        {
            private Cidade conteudo;
            private No direita;
            private No esquerda;

            public No (Cidade cidade)
            {
                Conteudo = cidade;
                Direita = null;
                Esquerda = null;
            }

            public Cidade Conteudo { get => conteudo; set => conteudo = value; }
            public No Direita { get => direita; set => direita = value; }
            public No Esquerda { get => esquerda; set => esquerda = value; }
        }
        public ArvoreBinaria(string nomeArquivo)
        {
            var arquivo = new StreamReader(nomeArquivo);

            var linha = arquivo.ReadLine();        
            while(linha != null)
            {
                int codCidade = int.Parse(linha.Substring(inicioCodCidade, tamanhoCodCidade));
                string nomeCidade = linha.Substring(inicioNomeCidade, tamanhoNomeCidade);
                int coordX = int.Parse(linha.Substring(inicioCoordXCidade, tamanhoCoordXCidade));
                int coordY = int.Parse(linha.Substring(inicioCoordYCidade, tamanhoCoordYCidade));

                var cidade = new Cidade(codCidade, nomeCidade, coordX, coordY);
                Add(cidade);

                linha = arquivo.ReadLine();
            }
        }

        private No raiz = null;

        public No Raiz { get => raiz; set => raiz = value; }

        public void Add(Cidade cidade)
        {
            No atual = null;
            if (raiz == null)
                raiz = new No(cidade);
            else
            {
                atual = raiz;

                while(atual != null)
                {
                    if(atual.Conteudo.CodCidade < cidade.CodCidade)
                    {
                        if (atual.Direita == null)
                        {
                            atual.Direita = new No(cidade);
                            atual = null;
                        }
                        else
                            atual = atual.Direita;
                    }
                    else
                    {
                        if (atual.Esquerda == null)
                        {
                            atual.Esquerda = new No(cidade);
                            atual = null;
                        }
                        else
                            atual = atual.Esquerda;
                    }
                }
            }

        }

        public void DesenharArvore(bool primeiraVez, No raiz,
                          int x, int y, double angulo, double incremento,
                          double comprimento, Graphics g)
        {
            int xf, yf;
            if (raiz != null)
            {
                Pen caneta = new Pen(Color.Black);
                xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
                yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);
                if (primeiraVez)
                    yf = 25;
                g.DrawLine(caneta, x, y, xf, yf);
                Thread.Sleep(200);
                DesenharArvore(false, raiz.Esquerda, xf, yf, Math.PI / 2 + incremento,
                                       incremento * 0.55, comprimento * 0.75, g);
                DesenharArvore(false, raiz.Direita, xf, yf, Math.PI / 2 - incremento,
                                        incremento * 0.55, comprimento * 0.75, g);
                Thread.Sleep(500);
                SolidBrush preenchimento = new SolidBrush(Color.Black);
                g.FillRectangle(preenchimento, xf - 25, yf - 5, 80, 50);
                g.DrawString(Convert.ToString(raiz.Conteudo.NomeCidade), new Font("Comic Sans", 10),
                    new SolidBrush(Color.White), xf - 10, yf + 10);

            }
        }
    }
}
