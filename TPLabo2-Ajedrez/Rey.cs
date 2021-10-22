using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Rey : Pieza
    {
        int N = 8;
        int cont = 0;
        public Rey() : base(ePieza.REY) { }

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
        public void CargarPosRey(Tablero MatrizPrueba, int fila, int col)
        {
            for (int i = col - 1; i < col + 2; i++)
            {
                if (i < N && i >= 2)
                {
                    if(fila - 1 >= 2)
                    MatrizPrueba.matriz[fila - 1, i] = 1;
                    if(fila + 1 < N)
                    MatrizPrueba.matriz[fila + 1, i] = 1;
                }
            }
            if(col + 1 < N)
            MatrizPrueba.matriz[fila, col + 1] = 1;
            if(col - 1 >= 2)
            MatrizPrueba.matriz[fila, col - 1] = 1;
        }
        public void BuscarPosicionRey(Tablero MatrizPrueba, Pieza[] LOOKUP, Pieza REY, int cantLlenas, int i, int j)//LLAMAR CON I Y J EN CERO
        {
            if ((i >= 2) && (i < N) && (j >= 2) && (j < N))//Si la casilla está dentro de nuestro 6x6
            {
                if (MatrizPrueba.matriz[i, j] == 0 && (MatrizPrueba.PosLibre(LOOKUP, i, j)))
                {
                    REY.setFILA(i);
                    REY.setCOL(j);
                    cantLlenas = VerificarPosRey(MatrizPrueba, REY);
                    MatrizPrueba.contador = 0;
                    if (MatrizPrueba.contarVacias() - cantLlenas > 3)//Si las casillas que quedan vacías al posicionar al rey allí son más de 3, no nos sirve
                    {
                        if (i == N - 1)
                        {
                            i = 2;
                            j++;
                        }
                        else i++;
                        BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, cantLlenas, i, j);
                    }
                    else
                    {//Nos sirve, dejamos al rey en esa posición y volvemos
                        return;
                    }
                }
                else//Si no está dentro del 6x6, intentamos con otra
                {
                    if (i == N - 1)
                    {
                        i = 2;
                        j++;
                    }
                    else i++;
                    BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, cantLlenas, i, j);
                }
            }
        }
        public int VerificarPosRey(Tablero MatrizPrueba, Pieza REY)
        {
            for (int i = REY.getCOL() - 1; i <= REY.getCOL() + 1; i++)
            {
                if (REY.getFILA() + 1 < N)
                {
                    if (MatrizPrueba.matriz[REY.getFILA() + 1, i] == 0) cont++;
                }
                if (REY.getFILA() - 1 >= 0)
                {
                    if (MatrizPrueba.matriz[REY.getFILA() - 1, i] == 0) cont++;
                }
            }
            if (REY.getCOL() + 1 < N)
            {
                if (MatrizPrueba.matriz[REY.getFILA(), REY.getCOL() + 1] == 0) cont++;
            }
            if (REY.getCOL() - 1 >= 0)
            {
                if (MatrizPrueba.matriz[REY.getFILA(), REY.getCOL() - 1] == 0) cont++;
            }
            return cont + 1;//retornamos las casillas que atacaría el rey más la casilla en donde está posicionado
        }
        public void BuscarPosReyFor(Tablero MatrizPrueba, Pieza[] LOOKUP, Pieza REY)
        {
            int cantLlenas = 0;
            for (int i = 2; i < N ; i++)
            {
                for (int j = 2; j < N; j++)
                {
                    if (MatrizPrueba.matriz[i, j] == 0 && (MatrizPrueba.PosLibre(LOOKUP, i, j)))
                    {
                        REY.setFILA(i);
                        REY.setCOL(j);
                        cantLlenas = VerificarPosRey(MatrizPrueba, REY);
                        if (MatrizPrueba.contarVacias() - cantLlenas <= 3)//Si las casillas que quedan vacías al posicionar al rey allí son más de 3, no nos sirve
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}
