using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogos
{
    public partial class Form1 : Form
    {
        private ModuloDesktopEntities ctx = new ModuloDesktopEntities();

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            var jogos = ctx.Jogos.Select(x => new
            {
                Jogo = x,
                Data = x.Data,
                Hora = x.Data.Value.Hour,
                Time1 = x.Selecao.Nome,
                Placar1 = x.Placar1,
                X = "X",
                Placar2 = x.Placar2,
                Time2 = x.Selecao3.Nome
            }).ToList();

            dgv.DataSource = jogos;

            dgv.Columns["Jogo"].Visible = false;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var jogo = dgv.Rows[i].Cells[0].Value as Jogos;

                if (jogo.Placar1 > jogo.Placar2)
                {
                    dgv.Rows[i].Cells[3].Style.ForeColor = Color.Blue;
                }

                else if (jogo.Placar2 > jogo.Placar1)
                    dgv.Rows[i].Cells[7].Style.ForeColor = Color.Blue;

                else
                {
                    dgv.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                    dgv.Rows[i].Cells[7].Style.BackColor = Color.Yellow;
                }
                   
            }

            //for (int i = 9; i <= 11; i++)
            //    dgv.Columns[i].Visible = false;

            //dgv.Columns["idjogo"].Visible = false;

        }
        
    }
}
