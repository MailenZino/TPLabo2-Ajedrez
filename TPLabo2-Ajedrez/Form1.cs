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
    public partial class Form1 : Form
    {
        Soluciones solucion_;
        public Form1(Soluciones solucion)
        {
            InitializeComponent();
            solucion_ = solucion;
        }
        // array tipo panel que representa el tablero de ajedrez
        private Panel[,] _chessBoardPanels;
        static int count = 0;
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
            if(count < 10)
            {
                //_chessBoardPanels[solucion_.Solucion_Maestra[count - 1, 0].FILA, solucion_.Solucion_Maestra[count - 1, 0].FILA].BackgroundImage = (Image)Properties.Resources.alfil;
                _chessBoardPanels[0, 0].BackgroundImage = (Image)Properties.Resources.piezaAlfil;
                _chessBoardPanels[0, 1].BackgroundImage = (Image)Properties.Resources.piezaTorre;
                _chessBoardPanels[0, 2].BackgroundImage = (Image)Properties.Resources.piezaRey;
                _chessBoardPanels[0, 3].BackgroundImage = (Image)Properties.Resources.piezaReina;
                _chessBoardPanels[0, 4].BackgroundImage = (Image)Properties.Resources.piezaCaballo;
            }
        }
    }
}
