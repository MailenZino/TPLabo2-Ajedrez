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
        Soluciones SolucionMadre;
        Pieza[,] soluciones;                       //guardara las soluciones encontradas en el programa
        int[] Sol_Mostradas;                      // guarda el numero de solucion que se va imprimiendo
        int count = 0;

        private Panel[,] _chessBoardPanels;       // array tipo panel que representa el tablero de ajedrez
        const int gridSize=8;

        MainForm Madre;

        public FormSoluciones(Pieza[,] look_soluciones, Soluciones Sol_madre, MainForm mainForm)
        {

            InitializeComponent();
            soluciones = new Pieza[36, 8];
            soluciones = look_soluciones;
            Sol_Mostradas = new int[36];
            SolucionMadre = Sol_madre;
            Madre = mainForm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int tileSize = 40;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

            BoxcantSoluciones.DropDownStyle = ComboBoxStyle.DropDownList;
            btnProxSol.Enabled = false;
            btn_GenerarSol.Enabled = false;
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
            NroSol.Enabled = false;
        }

        /// <summary>
        /// cada fila de soluciones representa un look up solucion.
        /// Traducimos esta informacion al panel/tablero _chessBoardPanels e imprimimos. 
        /// Se inhabilita el botonProxSol una vez alcanzado el numero de impresiones determinado
        /// </summary>
        private void ImprimirSol()
        {

            if (count < SolucionMadre.SOL_A_MOSTRAR)
            {
                //ELEJIMOS ALEATORIAMENTE UNA SOLUCION DEL VECTOR
                Random rd = new Random();
                int numSol = 0;
                do
                {
                    numSol = rd.Next(0, 36);
                }
                while (VerificarRepeticion(numSol)); //CHEQUEAMOS QUE NO SE REPITA

                //CARGAMOS FICHAS AL TABLERO

                _chessBoardPanels[soluciones[numSol, 0].getCOL(), soluciones[numSol, 0].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaTorre;
                _chessBoardPanels[soluciones[numSol, 1].getCOL(), soluciones[numSol, 1].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaTorre;

                _chessBoardPanels[soluciones[numSol, 4].getCOL(), soluciones[numSol, 4].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaReina;

                _chessBoardPanels[soluciones[numSol, 5].getCOL(), soluciones[numSol, 5].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaRey;


                //TENEMOS EN CUENTA EL CASO DE QUE ALFIL Y CABALLO ESTEN EN LA MISMA CASILLA
               
                if (soluciones[numSol, 2].getCOL() == soluciones[numSol, 6].getCOL() && soluciones[numSol, 2].getFILA() == soluciones[numSol, 6].getFILA())
                {
                    _chessBoardPanels[soluciones[numSol, 2].getCOL(), soluciones[numSol, 2].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfilCaballo;
                    _chessBoardPanels[soluciones[numSol, 3].getCOL(), soluciones[numSol, 3].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;
                    _chessBoardPanels[soluciones[numSol, 7].getCOL(), soluciones[numSol, 7].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;
                }
                else if (soluciones[numSol, 3].getCOL() == soluciones[numSol, 6].getCOL() && soluciones[numSol, 3].getFILA() == soluciones[numSol, 6].getFILA())
                {
                    _chessBoardPanels[soluciones[numSol, 3].getCOL(), soluciones[numSol, 3].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfilCaballo;
                    _chessBoardPanels[soluciones[numSol, 2].getCOL(), soluciones[numSol, 2].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;
                    _chessBoardPanels[soluciones[numSol, 7].getCOL(), soluciones[numSol, 7].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;
                }
                else
                {
                    _chessBoardPanels[soluciones[numSol, 2].getCOL(), soluciones[numSol, 2].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;
                    _chessBoardPanels[soluciones[numSol, 3].getCOL(), soluciones[numSol, 3].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaAlfil;
                    _chessBoardPanels[soluciones[numSol, 6].getCOL(), soluciones[numSol, 6].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;
                    _chessBoardPanels[soluciones[numSol, 7].getCOL(), soluciones[numSol, 7].getFILA()].BackgroundImage = (Image)Properties.Resources.piezaCaballo;
                }

                //CARGAMOS LOS ATAQUES

                PrepararForm(numSol);

            }
            if (count == SolucionMadre.SOL_A_MOSTRAR - 1)
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

        /// <summary>
        /// Se encarga de cargar ataques leves y fuertes
        /// </summary>
        /// <param name="numSol"></param>
        private void PrepararForm(int numSol)
        {
            //cargamos a la reina porque es la que mas abarca en el tablero 
            CargarReina(numSol);



            // EN soluciones[numSol,0] y soluciones[numSol,1] estan las torres y atacan fuerte SIEMPRE
            CargarFilaCol(numSol, soluciones[numSol, 0].getFILA());
            CargarFilaCol(numSol, soluciones[numSol, 1].getFILA());

            CargarFilaCol(numSol, soluciones[numSol, 0].getCOL(), false);
            CargarFilaCol(numSol, soluciones[numSol, 1].getCOL(), false);

            // EN soluciones[numSol,5] esta el rey y en soluciones[numSol,6 y 7] estan los caballos que tambien atacan fuerte SIEMPRE
            int stop_rey = soluciones[numSol, 5].getCOL() + 1, start_rey = soluciones[numSol, 5].getCOL() - 1;
            if (stop_rey >= gridSize) stop_rey = gridSize - 1;
            if (start_rey < 0) start_rey = 0;
            for (int i = -1; i < 2; i++)
            { 
                CargarFilaCol(numSol, soluciones[numSol, 5].getFILA() + i, true, stop_rey, start_rey);

                // para cargar al rey llamamos a cargar fila col con la fila que esta por encima del rey desde la col anterior hasta la posterior y repetimos hasta la fila inferior a su pos
            }
            CargarCaballo(soluciones[numSol, 6].getFILA(), soluciones[numSol, 6].getCOL());
            CargarCaballo(soluciones[numSol, 7].getFILA(), soluciones[numSol, 7].getCOL());


            CargarAtaquesLeves();//Los paneles que quedan vacíos tienen ataque leve.
        }

        public void CargarReina(int numSol)
        {
            CargarDiagos(numSol, soluciones[numSol, 4].getFILA(), soluciones[numSol, 4].getCOL());
            CargarDiagos(numSol, soluciones[numSol, 2].getFILA(), soluciones[numSol, 2].getCOL());
            CargarDiagos(numSol, soluciones[numSol, 3].getFILA(), soluciones[numSol, 3].getCOL());
           
            

            CargarFilaCol(numSol, soluciones[numSol, 4].getFILA(), true, 0, soluciones[numSol, 4].getCOL() - 1, true, false);
            CargarFilaCol(numSol, soluciones[numSol, 4].getFILA(), true, gridSize, soluciones[numSol, 4].getCOL() + 1, true, true);
            CargarFilaCol(numSol, soluciones[numSol, 4].getCOL(), false, 0, soluciones[numSol, 4].getFILA() - 1, true, false);
            CargarFilaCol(numSol, soluciones[numSol, 4].getCOL(), false, gridSize, soluciones[numSol, 4].getFILA() + 1, true, true);

        }

        public void CargarCaballo(int fila, int col)
        {

            if (fila + 1 < gridSize)
            {
                if (col - 2 >= 0 && _chessBoardPanels[col - 2, fila + 1].BackgroundImage == null)
                {
                    _chessBoardPanels[col - 2, fila + 1].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                    _chessBoardPanels[col - 2, fila + 1].BackgroundImageLayout = ImageLayout.Center;
                }
                if (col + 2 < gridSize && _chessBoardPanels[col + 2, fila + 1].BackgroundImage == null)
                {
                    _chessBoardPanels[col + 2, fila + 1].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                    _chessBoardPanels[col + 2, fila + 1].BackgroundImageLayout = ImageLayout.Center;
                }
                if (fila + 2 < gridSize)
                {
                    if (col - 1 >= 0 && _chessBoardPanels[col - 1, fila + 2].BackgroundImage == null)
                    {
                        _chessBoardPanels[col - 1, fila + 2].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[col - 1, fila + 2].BackgroundImageLayout = ImageLayout.Center;
                    }
                    if (col + 1 < gridSize && _chessBoardPanels[col + 1, fila + 2].BackgroundImage == null)
                    {
                        _chessBoardPanels[col + 1, fila + 2].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[col + 1, fila + 2].BackgroundImageLayout = ImageLayout.Center;
                    }
                }
            }
            if (fila - 1 >= 0)
            {
                if (col - 2 >= 0 && _chessBoardPanels[col - 2, fila - 1].BackgroundImage == null)
                {
                    _chessBoardPanels[col - 2, fila - 1].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                    _chessBoardPanels[col - 2, fila - 1].BackgroundImageLayout = ImageLayout.Center;
                }
                if (col + 2 < gridSize && _chessBoardPanels[col + 2, fila - 1].BackgroundImage == null)
                {
                    _chessBoardPanels[col + 2, fila - 1].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                    _chessBoardPanels[col + 2, fila - 1].BackgroundImageLayout = ImageLayout.Center;
                }
                if (fila - 2 >= 0)
                {
                    if (col - 1 >= 0 && _chessBoardPanels[col - 1, fila - 2].BackgroundImage == null)
                    {
                        _chessBoardPanels[col - 1, fila - 2].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[col - 1, fila - 2].BackgroundImageLayout = ImageLayout.Center;
                    }
                    if (col + 1 < gridSize && _chessBoardPanels[col + 1, fila - 2].BackgroundImage == null)
                    {
                        _chessBoardPanels[col + 1, fila - 2].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[col + 1, fila - 2].BackgroundImageLayout = ImageLayout.Center;
                    }
                }
            }
        }

        private void CargarFilaCol(int numSol, int numero, bool fila=true, int stop=gridSize, int start=0, bool romper= false, bool aDerecha= true)
        {
            int inc_dec = 1;
            int i = start;
            bool condicion = (i < stop);
            bool EsPieza1 = false;
            bool EsPieza2 = false;

            if (!aDerecha) //si vamos a izq start arranca con mayor valor que stop entonces vamos a decrementar i desde start a stop con inc_dec
            {
                inc_dec = -1;
                condicion = (i >= stop); 
            }

            do
            {
                if (i >= gridSize || i < 0)
                    break;
                if (fila)
                {
                    if (_chessBoardPanels[i, numero].BackgroundImage == null) //cargamos si no hay ficha en la pos
                    {
                        _chessBoardPanels[i, numero].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[i, numero].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else
                    {
                        if (romper)
                        {
                            for (int j = 0; j < gridSize; j++)
                            {
                                if (soluciones[numSol, j].getCOL() == i && soluciones[numSol, j].getFILA() == numero)
                                    EsPieza1 = true;
                            }
                            if (EsPieza1)
                                break;
                        }
                    }
                }
                else
                {
                    if (_chessBoardPanels[numero, i].BackgroundImage == null)
                    {
                        _chessBoardPanels[numero, i].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[numero, i].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else
                    {
                        if (romper)
                        {
                            for (int j = 0; j < gridSize; j++)
                            {
                                if (soluciones[numSol, j].getCOL() == numero && soluciones[numSol, j].getFILA() == i)
                                    EsPieza2 = true;
                            }
                            if (EsPieza2)
                                break;
                        }
                    }
                }
                i += inc_dec;
            } while (condicion);

           
        }
      

        public void CargarDiagos(int numSol, int fila, int col)
        {
            i = 1;
            CargarDiagonalesInferiores(numSol, fila+1, col);
            l = 1;
            CargarDiagonalesSuperiores(numSol, fila - 1, col);

        }


        int i = 1;
        void CargarDiagonalesInferiores(int numSol, int fila, int col,bool disable_1=false,bool disable_2=false)
        {
            if (fila > gridSize - 1 || fila < 0|| (disable_1 && disable_2))
                return;
            else
            {
                if (col + i < gridSize)
                {
                    if (!disable_1)
                    {
                        if (_chessBoardPanels[col + i, fila].BackgroundImage == null)// si ninguna pieza atacaba la pos
                        {
                            _chessBoardPanels[col + i, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte; //marco el ataque
                            _chessBoardPanels[col + i, fila].BackgroundImageLayout = ImageLayout.Center;
                        }
                        else 
                        {
                            for(int j = 0; j<gridSize;j++)
                            {
                                if (soluciones[numSol, j].getCOL() == col + i && soluciones[numSol, j].getFILA() == fila)
                                    disable_1 = true;
                            }
                            //si no es null es porque hay una ficha (las diagos son lo primero q cargamos) 
                        }
                    }
                }
                
                if (col - i >= 0)
                {
                    if (!disable_2)
                    {
                        if (_chessBoardPanels[col - i, fila].BackgroundImage == null)// si ninguna pieza atacaba la pos
                        {
                            _chessBoardPanels[col - i, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte; //marco el ataque
                            _chessBoardPanels[col - i, fila].BackgroundImageLayout = ImageLayout.Center;
                        }
                        else 
                        {
                            for (int j = 0; j < gridSize; j++)
                            {
                                if (soluciones[numSol, j].getCOL() == col - i && soluciones[numSol, j].getFILA() == fila)
                                    disable_2 = true;
                            }
                            //si no es null es porque hay una ficha (las diagos son lo primero q cargamos) 
                        }
                    }
                }
                

            }
            i++;
            fila++;
            CargarDiagonalesInferiores(numSol, fila, col,disable_1,disable_2);
        }

        int l = 1;
        void CargarDiagonalesSuperiores(int numSol, int fila, int col, bool disable_1 = false, bool disable_2 = false)
        {
            if (fila > gridSize - 1 || fila < 0|| (disable_1 && disable_2))
                return;
            else
            {
                if (col + l < gridSize)
                {
                    if (!disable_1)
                    {
                        if (_chessBoardPanels[col + l, fila].BackgroundImage == null) // si ninguna pieza atacaba la pos
                        {
                            _chessBoardPanels[col + l, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte; //marco el ataque fuerte
                            _chessBoardPanels[col + l, fila].BackgroundImageLayout = ImageLayout.Center;
                        }
                        else 
                        {
                            for (int j = 0; j < gridSize; ++j)
                            {
                                if (soluciones[numSol, j].getCOL() == col + l && soluciones[numSol, j].getFILA() == fila)
                                    disable_1 = true;
                            }
                            //si no es null es porque hay una ficha (las diagos son lo primero q cargamos) 
                        }
                    }
                }
               
                if ((col - l >= 0))
                {
                    if (!disable_2)
                    {
                        if (_chessBoardPanels[col - l, fila].BackgroundImage == null) // si ninguna pieza atacaba la pos
                        {
                            _chessBoardPanels[col - l, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                            _chessBoardPanels[col - l, fila].BackgroundImageLayout = ImageLayout.Center;
                        }
                        else
                        {
                            for (int j = 0; j < gridSize; j++)
                            {
                                if (soluciones[numSol, j].getCOL() == col - l && soluciones[numSol, j].getFILA() == fila)
                                    disable_2 = true;
                            }
                            //si no es null es porque hay una ficha (las diagos son lo primero q cargamos) 
                        }
                    }
                }
               

            }
            l++;
            fila--;
            CargarDiagonalesSuperiores(numSol, fila, col,disable_1,disable_2);
        }

       
        private void CargarAtaquesLeves()
        {
            //Recorremos el tablero y cualquier panel vacío es porque tiene un ataque leve, pongo la imagen que muestre eso.
            for(int i=0;i<gridSize;++i)
            {
                for(int j=0;j<gridSize; ++j)
                {
                    if (_chessBoardPanels[i, j].BackgroundImage == null)
                    {
                        _chessBoardPanels[i, j].BackgroundImage = (Image)Properties.Resources.ataqueLeve;
                        _chessBoardPanels[i, j].BackgroundImageLayout = ImageLayout.Center;
                    }
                }
            }
        }



        //eventos del form soluciones
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
            BoxcantSoluciones.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            SolucionMadre.CANT_SOL_IMPRESAS = SolucionMadre.SOL_A_MOSTRAR;
            Madre.Show();
            this.Close();
            
        }

        private void BoxcantSoluciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SolucionMadre.SOL_A_MOSTRAR = int.Parse(BoxcantSoluciones.SelectedItem.ToString());
            btn_GenerarSol.Enabled = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
