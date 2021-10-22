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
    public partial class FormSoluciones : Form
    {
        Pieza[,] soluciones;                       //guardara las soluciones encontradas en el programa
        private Panel[,] _chessBoardPanels;       // array tipo panel que representa el tablero de ajedrez
        int count = 0;
        //int CANT_SOL_IMPRESAS;
        int[] Sol_Mostradas;
        Soluciones SolucionMadre;
        public FormSoluciones(Pieza[,] look_soluciones, Soluciones Sol_madre)
        {
            InitializeComponent();
            soluciones = new Pieza[36, 8];
            soluciones = look_soluciones;
            Sol_Mostradas = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            SolucionMadre = Sol_madre;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int tileSize = 40;
            const int gridSize = 8;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;
            btnProxSol.Enabled = false;
            // inicializamos el tablero
            _chessBoardPanels = new Panel[gridSize, gridSize];

            // loop doble para manejar todas las filas y columnas
            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    // creamos un panel nuevo que va a ser una casilla nueva del tablero
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n, tileSize * m)
                    };

                    // Hacemos que se vea en el form
                    Controls.Add(newPanel);

                    // lo agregamos al tablero para utilizarlo más tarde
                    _chessBoardPanels[n, m] = newPanel;

                    // Le agregamos los colores
                    if (n % 2 == 0)
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                }
            }
            
        }

        /// <summary>
        /// cada fila de soluciones representa un look up solucion.
        /// Traducimos esta informacion al panel/tablero _chessBoardPanels e imprimimos. 
        /// Se inhabilita el botonProxSol una vez alcanzado el numero de impresiones determinado
        /// </summary>
        private void ImprimirSol()
        {

            if (count < Constants.SOL_A_MOSTRAR)
            {
                Random rd = new Random();
                int numSol = 0;
                do
                {
                    numSol = rd.Next(0, 36);
                }
                while (VerificarRepeticion(numSol));

                _chessBoardPanels[soluciones[numSol, 0].getCOL(), soluciones[numSol, 0].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaTorre;
                _chessBoardPanels[soluciones[numSol, 1].getCOL(), soluciones[numSol, 1].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaTorre;


                _chessBoardPanels[soluciones[numSol, 2].getCOL(), soluciones[numSol, 2].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;
                _chessBoardPanels[soluciones[numSol, 3].getCOL(), soluciones[numSol, 3].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;

                _chessBoardPanels[soluciones[numSol, 4].getCOL(), soluciones[numSol, 4].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaReina;

                _chessBoardPanels[soluciones[numSol, 5].getCOL(), soluciones[numSol, 5].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaRey;

                _chessBoardPanels[soluciones[numSol, 6].getCOL(), soluciones[numSol, 6].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;
                _chessBoardPanels[soluciones[numSol, 7].getCOL(), soluciones[numSol, 7].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;

                
            }
            if (count == Constants.SOL_A_MOSTRAR - 1)
            {
                btnProxSol.Enabled = false;
                
            }

        }
        /// <summary>
        /// Verifica que no mostremos la misma sol 2 veces
        /// </summary>
        /// <param name="numSol"></param>
        /// <returns></returns>
        private bool VerificarRepeticion(int numSol)
        {
            int i = 0;
            for (i = 0; i < SolucionMadre.CANT_SOL_IMPRESAS; i++)
            {
                if (Sol_Mostradas != null)
                {
                    if (Sol_Mostradas[i] == numSol)
                        return true;
                }
                else
                    break;
            }
            Sol_Mostradas[i] = numSol;
            return false;
        }


        private void btnProxSol_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8;j++)
                {
                    _chessBoardPanels[i, j].BackgroundImage = null;
                }
            }
            count++;
            SolucionMadre.CANT_SOL_IMPRESAS++;
            NroSol.Text = Convert.ToString("Solucion nro. "+(count+1));
            ImprimirSol();
        }

        private void btn_GenerarSol_Click(object sender, EventArgs e)
        {
            ImprimirSol();
            btnProxSol.Enabled = true;
            btn_GenerarSol.Enabled=false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            //Mostrar main form
            
        }
    }
}
