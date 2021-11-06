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
            programa_.LookSoluciones.CANT_SOL_IMPRESAS = 0;
            this.Hide();
            programa_.BuscarSoluciones(this);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnComplejidad_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("T(CantSoluciones,a,b,c,d,e,n,m,p,h) = (CantSoluciones-1)*(544a + 732b + 42n*c + 640d + 71e + 6m*p + 1720) + 11434 + h.\nLas variables son:\n -a es la cantidad de casillas que recorre la reina desde su posición hasta los extremos de su fila y columna hasta toparse con otra pieza, b lo mismo pero con sus diagonales.\n-n es la cantidad de columnas que ataca el rey que estén dentro del tablero.\n -c es el número de estas casillas que estén vacías alrededor del rey.\n-d es la cantidad de casillas con ataque leve.\n-e depende de si hay un caballo posicionado en la misma casilla que un alfil.\n-m es la cantidad de soluciones impresas.\n-p es la cantidad de veces necesarias encontrar un número de solución no repetida.\n-Si las soluciones a mostrar son 30, h = 3341, si son más o menos a 30, h = 3347\nEl mejor caso está dado si a = b = c = d = e = m = n = p = 1, CantSoluciones = 5 y h = 3347, por lo que Omega(27,497).\n El peor caso es O((CantSoluciones-1)*(544a + 732b + 42n*c + 640d + 71e + 6m*p + 1720) + 11434 + h).\n\nNuestro algoritmo tiene una complejidad lineal: T(n) = A + B.N donde N es CantSoluciones, B queda determinado por las funciones del form soluciones (es decir que B = 544a + 732b + 42n*c + 640d + 71e + 6m*p + 1720) y A es una constante que queda determinada por BuscarSoluciones. ", "Análisis de complejidad del algoritmo.", MessageBoxButtons.OK);
        }
    }
}
