using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Pet_shop
{
    public partial class Form_Suporte : Form
    {
        public Form_Suporte()
        {
            InitializeComponent();
        }

        private void button_Sair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Gerenciamento Form_Suporte = new Form_Gerenciamento();
            Form_Suporte.ShowDialog();
            this.Close();
        }
    }
}
