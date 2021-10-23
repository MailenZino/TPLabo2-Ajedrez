using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Caballo:Pieza
    {
        static int N = 8;
        int cont = 0;
        
        public Caballo():base(ePieza.CABALLO) {  }

        // PARA POSICIONAR CABALLO
        public void PosicionarCaballos(Tablero MatrizPrueba , Pieza [] LOOKUP, Pieza CABALLO)
        {

            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, 2, 2);
            //Probamos casilla por casilla cuál es la mejor posición

        }

        /// <summary>
        /// se utiliza para obtener la mejor posicion del caballo
        /// </summary>
        /// <param name="MatrizPrueba"></param>
        /// <param name="LOOKUP"></param>
        /// <param name="CABALLO"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void RecursividadCaballo(Tablero MatrizPrueba, Pieza[] LOOKUP, Pieza CABALLO, int i, int j)
        {
            int NLibres = 0;
            if(i >= 2 && i < N && j >= 2 && j < N)
            {
                if (MatrizPrueba.PosLibre(LOOKUP, i, j,true))//Si la casilla no esta ocupada
                {
                    //Posicionamos el caballo ahí y contamos cuantas casillas libres ocupa
                    CABALLO.setFILA(i);
                    CABALLO.setCOL(j);
                    
                    if (MatrizPrueba.matriz[i, j] == 0) cont++;
                    cont = VerificarPosCaballo(MatrizPrueba, CABALLO);

                    //Si es el primer caballo, queremos que deje 1 casilla libre maximo. Si no, 0
                    if (LOOKUP[6] == null) 
                        NLibres = 1;
                    else 
                        NLibres = 0;


                    //Si las casillas libres que quedarian son más que las que queremos
                    if (MatrizPrueba.contarVacias() - cont > NLibres)
                    {
                        //Probamos otro posicionamiento
                        if (i == N - 1)
                        {
                            i = 2;
                            j++;
                        }
                        else i++;
                        RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, i, j);
                    }
                    else
                        return;
                }
                else//Si la casilla está ocupada por otra pieza, seguimos probando 
                {
                    if (i == N - 1)
                    {
                        i = 2;
                        j++;
                    }
                    else i++;
                    RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, i, j);//LLamamos nuevamente la función con un posicionamiento diferente
                }
                
            }
            
            
        }

       
        /// <summary>
        /// Cuenta cantidad de casillas que ocupa el caballo en la posicion que tiene cargada
        /// </summary>
        /// <param name="MatrizPrueba"></param>
        /// <param name="CABALLO"></param>
        /// <returns></returns>
        public int VerificarPosCaballo(Tablero MatrizPrueba, Pieza CABALLO)
        {
            cont = 0;
            if(CABALLO.getFILA() + 1 < N)
            {
                if (CABALLO.getCOL() - 2 >= 0 && MatrizPrueba.matriz[CABALLO.getFILA() + 1, CABALLO.getCOL() - 2] == 0) cont++;
                if (CABALLO.getCOL() + 2 < N && MatrizPrueba.matriz[CABALLO.getFILA() + 1, CABALLO.getCOL() + 2] == 0) cont++; ;
                if(CABALLO.getFILA() + 2 < N)
                {
                    if (CABALLO.getCOL() - 1 >= 0 && MatrizPrueba.matriz[CABALLO.getFILA() + 2, CABALLO.getCOL() - 1] == 0) cont++; ;
                    if (CABALLO.getCOL() + 1 < N && MatrizPrueba.matriz[CABALLO.getFILA() + 2, CABALLO.getCOL() + 1] == 0) cont++;
                }
            }
            if(CABALLO.getFILA() - 1 >= 0)
            {
                if (CABALLO.getCOL() - 2 >= 0 && MatrizPrueba.matriz[CABALLO.getFILA() - 1, CABALLO.getCOL() - 2] == 0) cont++;
                if (CABALLO.getCOL() + 2 < N && MatrizPrueba.matriz[CABALLO.getFILA() - 1, CABALLO.getCOL() + 2] == 0) cont++;
                if(CABALLO.getFILA() - 2 >= 0)
                {
                    if (CABALLO.getCOL() - 1 >= 0 && MatrizPrueba.matriz[CABALLO.getFILA() - 2, CABALLO.getCOL() - 1] == 0) cont++;
                    if (CABALLO.getCOL() + 1 < N && MatrizPrueba.matriz[CABALLO.getFILA() - 2, CABALLO.getCOL() + 1] == 0) cont++;
                }
            }
            return cont;
        }

        //PARA CARGAR A LA MATRIZ

        /// <summary>
        /// se llena la matriz segun los movimientos del caballo en fila col
        /// </summary>
        /// <param name="MatrizPrueba"></param>
        /// <param name="fila"></param>
        /// <param name="col"></param>
        public void CargarPosCaballo(Tablero MatrizPrueba, int fila, int col)
        {
            if (fila + 1 < N)
            {
                if (col - 2 >= 0) MatrizPrueba.matriz[fila + 1, col - 2] = 1;
                if (col + 2 < N) MatrizPrueba.matriz[fila + 1, col + 2]=1;
                if (fila + 2 < N)
                {
                    if (col - 1 >= 0) MatrizPrueba.matriz[fila + 2, col - 1] = 1;
                    if (col + 1 < N) MatrizPrueba.matriz[fila + 2, col + 1] = 1;
                }
            }
            if (fila - 1 >= 0)
            {
                if (col - 2 >= 0) MatrizPrueba.matriz[fila - 1, col - 2] = 1;
                if (col + 2 < N) MatrizPrueba.matriz[fila - 1, col + 2] = 1;
                if (fila - 2 >= 0)
                {
                    if (col - 1 >= 0) MatrizPrueba.matriz[fila - 2, col - 1] = 1;
                    if (col + 1 < N) MatrizPrueba.matriz[fila - 2, col + 1] = 1;
                }
            }
        }
    }
}
