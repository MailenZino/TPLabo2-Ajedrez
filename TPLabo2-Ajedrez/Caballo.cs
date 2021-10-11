using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Caballo
    {
        static int N = 6;
        int cont = 0;
        public Caballo()
        {
            sPieza CABALLO = new sPieza(ePieza.CABALLO);
        }
        bool PosicionarCaballos(bool [,] MatrizPrueba , sPieza [] LOOKUP, sPieza CABALLO)
        {
            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, 2, 2);
            if (contarVacias(MatrizPrueba, 0) != 0) return false;
            else return true;
        }
        void RecursividadCaballo(bool[,] MatrizPrueba, sPieza[] LOOKUP, sPieza CABALLO, int i, int j)// i = 2 y j = 2
        {
            int NLibres = 0;
            if(i >= 2 && i < N && j >= 2 && j < N)
            {
                if(PosLibre(LOOKUP, i, j))
                {
                    sPosicion pos = new sPosicion(i, j);
                    CABALLO.posicion = pos;
                }
                cont = VerificarPosCaballo(MatrizPrueba, CABALLO);
                if (LOOKUP[6].pieza == ePieza.LIBRE) NLibres = 5;
                else NLibres = 3;
                if(contarVacias(MatrizPrueba) - cont > NLibres)
                {
                    if (i == N - 1)
                    {
                        i = 0;
                        j++;
                    }
                    else i++;
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
            }
            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, i, j);
        }
        int VerificarPosCaballo(bool [,] MatrizPrueba, sPieza CABALLO)
        {
            cont = 8;
            if(CABALLO.posicion.FILA + 1 < N)
            {
                if (CABALLO.posicion.COL - 2 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 1, CABALLO.posicion.COL - 2]);
                if (CABALLO.posicion.COL + 2 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 1, CABALLO.posicion.COL + 2]);
                if(CABALLO.posicion.FILA + 2 < N)
                {
                    if (CABALLO.posicion.COL - 1 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 2, CABALLO.posicion.COL - 1]);
                    if (CABALLO.posicion.COL + 1 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA + 2, CABALLO.posicion.COL + 1]);
                }
            }
            if(CABALLO.posicion.FILA - 1 > 1)
            {
                if (CABALLO.posicion.COL - 2 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 1, CABALLO.posicion.COL - 2]);
                if (CABALLO.posicion.COL + 2 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 1, CABALLO.posicion.COL + 2]);
                if(CABALLO.posicion.FILA - 2 < 1)
                {
                    if (CABALLO.posicion.COL - 1 > 1) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 2, CABALLO.posicion.COL - 1]);
                    if (CABALLO.posicion.COL + 1 < N) cont -= int(MatrizPrueba[CABALLO.posicion.FILA - 2, CABALLO.posicion.COL + 1]);
                }
            }
            return cont;
        }
    }
}
