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
            DialogResult result = MessageBox.Show("Nuestro algoritmo tiene una complejidad lineal: T(n) = A + B*N. El tiempo que el algoritmo tarda en encontrar la primera solución depende de ciertos elementos aleatorios, sin embargo, no depende de la entrada, las otras soluciones se forman con la primera solucioón por lo que tampoco dependen de la entrada, lo tomamos constante. Ésta es nuestra constante A. B depende de las funciones de FormSoluciones que a su vez dependen de las variables a, b, c, d, e, n, m y p, todas éstas se caracterizan generalmente por no variar tanto o por depender de cómo están posicionadas las piezas en el tablero a imprimir, es decir que no depende de la entrada N, su T lo tomamos también como constante. N es la cantidad de soluciones que se quiere imprimir.\n" +
                "El peor y el mejor caso dependerán de la cantidad de soluciones a imprimir y su constante B también difiere.\n" +
                "Las variables de las que depende B son:\n" +
                "-a es la cantidad de casillas que recorre la reina desde su posición hasta los extremos de su fila y columna hasta toparse con otra pieza, b lo mismo pero con sus diagonales.\n" +
                "-n es la cantidad de columnas que ataca el rey que estén dentro del tablero.\n" +
                "-c es el número de estas casillas que estén vacías alrededor del rey.\n-d es la cantidad de casillas con ataque leve.\n" +
                "-e depende de si hay un caballo posicionado en la misma casilla que un alfil.\n-m es la cantidad de soluciones impresas.\n" +
                "-p es la cantidad de veces necesarias encontrar un número de solución no repetida.\n" +
                "-Si las soluciones a mostrar son 30, h = 3341, si son más o menos a 30, h = 3347\n" +
                "El mejor caso está dado si CantSoluciones = 5 y h = 3347, por lo que Omega(27,497).\n El peor caso es O((N-1)*(544a + 732b + 42n*c + 640d + 71e + 6m*p + 1720) + 11434 + h).\n\n"
                , "Análisis de complejidad del algoritmo.", MessageBoxButtons.OK);
        }
    }
}
