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
        int[] Sol_Mostradas;
        Soluciones SolucionMadre;
        const int gridSize=8;
        public FormSoluciones(Pieza[,] look_soluciones, Soluciones Sol_madre)
        {
            InitializeComponent();
            soluciones = new Pieza[36, 8];
            soluciones = look_soluciones;
            Sol_Mostradas = new int[36];
            SolucionMadre = Sol_madre;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int tileSize = 40;
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
            NroSol.Enabled = false;
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

        /// <summary>
        /// Se encarga de cargar ataques leves y fuertes
        /// </summary>
        /// <param name="numSol"></param>
        private void PrepararForm(int numSol)
        {
            // Cargamosa a la reina primero porque es la que mas abarca
            CargarReina(numSol);
            // EN soluciones[numSol,0] y soluciones[numSol,1] estan las torres y atacan fuerte SIEMPRE
            CargarFilaCol(soluciones[numSol, 0].getFILA());
            CargarFilaCol(soluciones[numSol, 1].getFILA());

            CargarFilaCol(soluciones[numSol, 0].getCOL(), false);
            CargarFilaCol(soluciones[numSol, 1].getCOL(), false);

            // EN soluciones[numSol,5] esta el rey y en soluciones[numSol,6 y 7] estan los caballos que tambien atacan fuerte SIEMPRE
            for (int i = -1; i < 2; i++)
            { 

                CargarFilaCol(soluciones[numSol, 5].getFILA()+i, true, soluciones[numSol, 5].getCOL() + 1, soluciones[numSol, 5].getCOL() - 1); 
               
                // para cargar al rey llamamos a cargar fila col con la fila que esta por encima del rey desde la col anterior hasta la posterior y repetimos hasta la fila inferior a su pos
            }
            CargarCaballo(soluciones[numSol, 6].getFILA(), soluciones[numSol, 6].getCOL());
            CargarCaballo(soluciones[numSol, 7].getFILA(), soluciones[numSol, 7].getCOL());

            CargarDiagos(soluciones[numSol, 2].getFILA(), soluciones[numSol, 4].getCOL());
            CargarDiagos(soluciones[numSol, 3].getFILA(), soluciones[numSol, 5].getCOL());
            

            //TODO: FALTA CARGAR LEVES
        }

        private void CargarFilaCol( int numero, bool fila=true, int stop=gridSize, int start=0, bool romper= false, bool aDerecha= true)
        {
            int inc_dec = 1;
            int i = start;
            bool condicion = (i < stop);

            if (!aDerecha) //si vamos a izq true start arranca con mayor valor que stop entonces vamos a decrementar i de start a stop con inc_dec
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
                    else if(romper && _chessBoardPanels[i, numero].BackgroundImage != (Image)Properties.Resources.ataqueFuerte)
                        break;
                }
                else
                {
                    if (_chessBoardPanels[numero,i].BackgroundImage == null)
                    {
                        _chessBoardPanels[numero, i].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[numero, i].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if(romper && _chessBoardPanels[numero,i].BackgroundImage != (Image)Properties.Resources.ataqueFuerte)
                        break;
                }
                i += inc_dec;
            } while (condicion);

            /*
            for (int i = start; i < stop; i++)
            {
                if (i >= gridSize || i < 0)
                    break;
                if (fila)
                {
                    if (_chessBoardPanels[numero, i].BackgroundImage == null) //cargamos si no hay ficha cargada en la pos
                    {
                        _chessBoardPanels[numero, i].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[numero, i].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if (romper) //este parametro lo usamos cuando sabemos que habra ataques leves
                        break;
                }
                else
                {
                    if (_chessBoardPanels[numero, i].BackgroundImage == null)
                    {
                        _chessBoardPanels[i, numero].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[i, numero].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if (romper)
                        break;
                }
            }
            */
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

        public void CargarDiagos(int fila, int col)
        {
            CargarDiagonalesInferiores(fila+1, col);
            i = 1;
            CargarDiagonalesSuperiores(fila-1, col);
            l = 1;
        }


        int i = 1;
        void CargarDiagonalesInferiores(int fila, int col,int carga_completa=0,bool disable_1=false,bool disable_2=false)
        {
            
            if (fila > gridSize - 1 || fila < 0||carga_completa>=2)
                return;
            else
            {
               
                if (col + i < gridSize&&!disable_1)
                {
                    if (_chessBoardPanels[col + i, fila].BackgroundImage ==null)// si ninguna pieza atacaba la pos
                    {
                        _chessBoardPanels[col + i, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte; //marco el ataque
                        _chessBoardPanels[col + i, fila].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if(_chessBoardPanels[col + i, fila].BackgroundImage != (Image)Properties.Resources.ataqueFuerte)
                    {
                        //si la imagen cargada no se trata de un ataque es porque me tope con una pieza y por ende ya no puedo atacar mas fuerte x esta diago 
                        disable_1 = true;
                        carga_completa++;
                    }
                }
                //else
                //{
                //    //si me paso de los limites ya no puedo atacar mas x esta diago 
                //    disable_1 = true;
                //    carga_completa++;
                //}
                if (col - i >= 0&&!disable_2)
                {
                    if (_chessBoardPanels[col - i, fila].BackgroundImage == null)// si ninguna pieza atacaba la pos
                    {
                        _chessBoardPanels[col - i, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte; //marco el ataque
                        _chessBoardPanels[col - i, fila].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if(_chessBoardPanels[col - i, fila].BackgroundImage != (Image)Properties.Resources.ataqueFuerte)
                    {
                        //si la imagen cargada no se trata de un ataque es porque me tope con una pieza y por ende ya no puedo atacar mas fuerte x esta diago 
                        disable_2 = true;
                        carga_completa++;
                    }

                }
                //else
                //{
                //    //si me paso de los limites ya no puedo atacar mas x esta diago 
                //    disable_2 = true;
                //    carga_completa++;
                //}

            }
            i++;
            fila++;
            CargarDiagonalesInferiores(fila, col, carga_completa,disable_1,disable_2);
        }

        int l = 1;
        void CargarDiagonalesSuperiores(int fila, int col, int carga_completa = 0, bool disable_1 = false, bool disable_2 = false)
        {
            if (fila > gridSize - 1 || fila < 0||carga_completa==2)
                return;
            else
            {
                if (col + l < gridSize&&!disable_1)
                {
                    if (_chessBoardPanels[col + l, fila].BackgroundImage == null) // si ninguna pieza atacaba la pos
                    {
                        _chessBoardPanels[col + l, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte; //marco el ataque fuerte
                        _chessBoardPanels[col + l, fila].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if(_chessBoardPanels[col + l, fila].BackgroundImage != (Image)Properties.Resources.ataqueFuerte)
                    {
                        //si la imagen cargada no se trata de un ataque es porque me tope con una pieza y por ende ya no puedo atacar mas fuerte x esta diago 
                        disable_1 = true;
                        carga_completa++;
                    }
                }
                //else
                //{
                //    //si me paso de los limites ya no puedo atacar mas x esta diago 
                //    disable_1 = true;
                //    carga_completa++;
                //}
                if (col - l >= 0&&!disable_2)
                {
                    if (_chessBoardPanels[col - l, fila].BackgroundImage == null) // si ninguna pieza atacaba la pos
                    {
                        _chessBoardPanels[col - l, fila].BackgroundImage = (Image)Properties.Resources.ataqueFuerte;
                        _chessBoardPanels[col - l, fila].BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if (_chessBoardPanels[col - l, fila].BackgroundImage != (Image)Properties.Resources.ataqueFuerte)
                    {
                        //si la imagen cargada no se trata de un ataque es porque me tope con una pieza y por ende ya no puedo atacar mas fuerte x esta diago 
                        disable_2 = true;
                        carga_completa++;
                    }
                }
                //else
                //{
                //    //si me paso de los limites ya no puedo atacar mas x esta diago 
                //    disable_2 = true;
                //    carga_completa++;
                //}

            }
            l++;
            fila--;
            CargarDiagonalesSuperiores(fila, col,carga_completa,disable_1,disable_2);
        }

        public void CargarReina(int numSol)
        {
            CargarDiagos(soluciones[numSol, 4].getFILA(), soluciones[numSol, 4].getCOL());
            CargarFilaCol(soluciones[numSol, 4].getFILA(), true, 0, soluciones[numSol, 4].getCOL() - 1, true, false);
            CargarFilaCol(soluciones[numSol, 4].getFILA(), true, gridSize, soluciones[numSol, 4].getCOL()+1, true,true);
            CargarFilaCol(soluciones[numSol, 4].getCOL(), false, 0, soluciones[numSol, 4].getFILA()-1, true, false);
            CargarFilaCol(soluciones[numSol, 4].getCOL(), false, gridSize, soluciones[numSol, 4].getFILA() + 1, true, true);
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
            
            
        }
    }
}
