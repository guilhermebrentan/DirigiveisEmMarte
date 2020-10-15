using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apCaminhosMarte
{
    public partial class Form1 : Form
    {
        ArvoreBinaria arvore = null;
        Cidade origem, destino;
        public Form1()
        {
            InitializeComponent();
            if(openCidades.ShowDialog() == DialogResult.OK)
            {
                arvore = new ArvoreBinaria(openCidades.FileName);
            }
        }

        private void TxtCaminhos_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscar caminhos entre cidades selecionadas");
        }

        private void pnlArvore_Paint(object sender, PaintEventArgs e)
        {
            if (arvore != null)
            {
                Graphics g = e.Graphics;
                arvore.DesenharArvore(true, arvore.Raiz, (int)pnlArvore.Width / 2, 0, Math.PI / 2, Math.PI / 2.5, 300, g);
            }
        }

        private void lsbOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            origem = arvore.EnconctrarCidade(int.Parse(lsbOrigem.SelectedItem.ToString().Substring(0,2)), arvore.Raiz);
        }

        private void lsbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            destino = arvore.EnconctrarCidade(int.Parse(lsbOrigem.SelectedItem.ToString().Substring(0, 2)), arvore.Raiz);
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            if(arvore != null)
            {
                Graphics g = e.Graphics;
                double fatorDeReducaoX = pbMapa.Width / 4096.0;
                double fatorDeReducaoY = pbMapa.Height / 2048.0;
                arvore.DesenharCidades(fatorDeReducaoX, fatorDeReducaoY, g, arvore.Raiz);
            }
        }
    }
}
