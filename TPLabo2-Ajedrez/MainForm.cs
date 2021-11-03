using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPLabo2_Ajedrez
{
    public partial class MainForm : Form
    {
        public MainForm(Program programa)
        {
            InitializeComponent();
            programa_ = programa;
        }
        Program programa_;
        private void btnSln_Click(object sender, EventArgs e)
        {
            if (programa_.LookSoluciones.CANT_SOL_IMPRESAS == 0 || programa_.LookSoluciones.CANT_SOL_IMPRESAS < programa_.LookSoluciones.SOL_A_MOSTRAR)
            {
                btnSln.Enabled = false;
                programa_.BuscarSoluciones();
            }
            else
            {
                programa_.LookSoluciones.CANT_SOL_IMPRESAS = 0;
                btnSln.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
