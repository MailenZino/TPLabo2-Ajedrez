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
        bool PosicionarCaballos(bool [,] MatrizPrueba , sPieza [] LOOKUPResolucion, sPieza CABALLO)
        {
            RecursividadCaballo(MatrizPrueba, LOOKUPResolucion, CABALLO, 2, 2);
            if (contarVacias(MatrizPrueba, 0) != 0) return false;
            else return true;
        }
        void RecursividadCaballo(bool [,] MatrizPrueba, sPieza [] LOOKUPResolucion, sPieza CABALLO, int i, int j)// i = 2 y j = 2
        {
            if(i >= 2 && i < N && j >= 2 && j < N)
            {
                if(PosLibre(LOOKUPResolucion, i, j))
                {
                    CABALLO.posicion.FILA = i;
                    CABALLO.posicion.COL = j;
                }
            }
        }
        int VerificarPosCaballo(bool [,] MatrizPrueba, sPieza CABALLO)
        {

        }
    }
}
