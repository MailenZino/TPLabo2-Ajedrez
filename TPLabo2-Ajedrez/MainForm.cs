﻿using System;
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
            Form1 form1 = new Form1(programa_.LookSoluciones);
            form1.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //while (Program.CANT_SOL_TOTALES < 10)
            //{
            //    Programa.BuscarSoluciones();
            //}
        }
    }
}
