using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class mdClausula : Form
    {
        public string Clausulas { get; set; }
        public mdClausula()
        {
            InitializeComponent();
        }

        private void mdClausula_Load(object sender, EventArgs e)
        {
            txtclausulas.Text = this.Clausulas;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            this.Clausulas = txtclausulas.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
