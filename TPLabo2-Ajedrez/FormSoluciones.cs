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
        Pieza[,] soluciones;
        private Panel[,] _chessBoardPanels;
        // array tipo panel que representa el tablero de ajedrez
        static int count = 0;
        public FormSoluciones(Pieza[,] look_soluciones)
        {
            InitializeComponent();
            soluciones = new Pieza[10,8];
            soluciones = look_soluciones;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            count += 1;
            const int tileSize = 40;
            const int gridSize = 8;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

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

        private void ImprimirSol()
        {
            /* cada fila de soluciones representa un look up solucion que tiene
            * 0 1 TORRES 
            * 2 3 ALFILES
            * 4 REINA
            * 5 REY
            * 6 7 CABALLOS
           */
            if (count < 10)
            {

                _chessBoardPanels[soluciones[count, 0].getFILA(), soluciones[count, 0].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaTorre;
                _chessBoardPanels[soluciones[count, 1].getFILA(), soluciones[count, 1].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaTorre;


                _chessBoardPanels[soluciones[count, 2].getFILA(), soluciones[count, 2].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;
                _chessBoardPanels[soluciones[count, 3].getFILA(), soluciones[count, 3].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;

                _chessBoardPanels[soluciones[count, 4].getFILA(), soluciones[count, 4].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaReina;

                _chessBoardPanels[soluciones[count, 5].getFILA(), soluciones[count, 5].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaRey;

                _chessBoardPanels[soluciones[count, 6].getFILA(), soluciones[count, 6].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;
                _chessBoardPanels[soluciones[count, 7].getFILA(), soluciones[count, 7].getCOL()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;

            }
        }


        private void btnProxSol_Click(object sender, EventArgs e)
        {
            count++;
            NroSol.Text = Convert.ToString("Solucion nro. "+(count+1));
            ImprimirSol();
        }

        private void btn_GenerarSol_Click(object sender, EventArgs e)
        {
            ImprimirSol();
            btn_GenerarSol.Enabled=false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
