using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Rey
    {
        int N = 6;
        int cont = 0;
        public Rey()
        {
            sPieza p_rey = new sPieza(ePieza.REY);
        }
        public sPieza p_rey { get { return p_rey; } }
        //ALTERNATIVA 1
        //public void BuscarPosicionRey(int [,] MatrizPrueba, sPieza [] LOOKUP, sPieza REY, int CantLlenas,int i, int j)
        //{
        //    sPosicion posEspaciosMax = new sPosicion(3, 3);
        //    REY.posicion = PosRey(MatrizPrueba, posEspaciosMax);
        //    LOOKUP[5] = REY;
        //}
        ////se mueve analizando el tablero en cuadrados 3x3 para ubicar al rey donde más espacios vacíos haya
        //sPosicion Pos;
        //sPosicion PosRey(int[,] MatrizPrueba, sPosicion posEspaciosMax, int EspaciosMax = 0, int fila=3, int col=3)
        //{
        //    int Llenas = 0;
        //    for(int j = -1; j <= 1; j++)
        //    {
        //        for (int i = -1; i <= 1; i++)
        //        {
        //            Llenas += MatrizPrueba[fila + i, col + j];  
        //        }
        //        if(j == -1 && Llenas == 3) //si 1er columnita esta llena
        //        {
        //            EspaciosPosRey(MatrizPrueba, fila, col + 1);  //Esta funcion me falta
        //            //analizo el centro del 3x3 (rey) una col + a derecha
        //        }
        //    }
        //    if(EspaciosMax < 9 - Llenas && PosLibre(LOOKUP, fila, col)) //si encontré más espacios vacíos en un lugar que no tiene piezas
        //    {
        //        EspaciosMax = 9 - Llenas;
        //        posEspaciosMax.FILA = fila;
        //        posEspaciosMax.COL = col;
        //    }
        //    if (col == 5 && col == 6) //si quedo acá es porque se desplazó
        //    {
        //        EspaciosPosRey(MatrizPrueba, fila, col++);  //Esta funcion me falta
        //    }
        //    if (col + 3 < N) EspaciosPosRey(MatrizPrueba, fila, col + 3);
        //    //analizo el cuadrado con centro a 3 col respecto el centro del ya analizado
        //    else if (fila + 3 < N - 1) EspaciosPosRey(MatrizPrueba, fila + 3, 3, EspaciosMax, posEspaciosMax);
        //   //analizo los de abajo
        //   return posEspaciosMax;
        //}



        //ALTERNATIVA 2
        public void BuscarPosicionRey(int[,] MatrizPrueba, sPieza[] LOOKUP, sPieza REY, int cantLlenas, int i, int j)//LLAMAR CON I Y J EN CERO
        {
            if (i >= 0 && i < N && j >= 0 && j < N)
            {
                if (MatrizPrueba[i, j] == 0)
                {
                    sPosicion pos = new sPosicion(i, j);
                    REY.posicion = pos;
                    cantLlenas = VerificarPosRey(MatrizPrueba, REY);
                    if (cantLlenas > 5)
                    {
                        if (i == N - 1)
                        {
                            i = 0;
                            j++;
                        }
                        else i++;
                        BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, cantLlenas, i, j);
                    }
                    else
                    {
                        LOOKUP[5] = REY;
                    }
                }
            }
            else
            {
                if (i == N - 1)
                {
                    i = 0;
                    j++;
                }
                else i++;
                BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, cantLlenas, i, j);
            }
        }
        public int VerificarPosRey(int[,] MatrizPrueba, sPieza REY)
        {
            for (int i = REY.posicion.COL - 1; i <= REY.posicion.COL + 1; i++)
            {
                if (REY.posicion.FILA + 1 < N)
                {
                    if (MatrizPrueba[REY.posicion.FILA + 1, i] == 0) cont++;
                }
                if (REY.posicion.FILA - 1 >= 0)
                {
                    if (MatrizPrueba[REY.posicion.FILA - 1, i]==0) cont++;
                }
            }
            if (REY.posicion.COL + 1 < N)
            {
                if (MatrizPrueba[REY.posicion.FILA, REY.posicion.COL + 1]==0) cont++;
            }
            if (REY.posicion.COL - 1 >= 0)
            {
                if (MatrizPrueba[REY.posicion.FILA, REY.posicion.COL - 1]==0) cont++;
            }
            return cont;
        }
    }
}
