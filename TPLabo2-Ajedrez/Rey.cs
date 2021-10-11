using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Rey
    {
        //ALTERNATIVA 1
        public void BuscarPosicionRey(bool [,] MatrizPrueba, sPieza [] LOOKUP, sPieza REY, int CantLlenas,int i, int j)
        {
            sPosicion posEspaciosMax = new sPosicion(3, 3);
            REY.posicion = PosRey(MatrizPrueba, posEspaciosMax);
            LOOKUP[5] = REY;
        }
        //se mueve analizando el tablero en cuadrados 3x3 para ubicar al rey donde más espacios vacíos haya
        sPosicion Pos;
        sPosicion PosRey(bool[,] MatrizPrueba, sPosicion posEspaciosMax, int EspaciosMax = 0, int fila=3, int col=3)
        {
            int Llenas = 0;
            for(int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    Llenas += int(MatrizPrueba[fila + i, col + j]);  //No anda el casteo
                }
                if(j == -1 && Llenas == 3) //si 1er columnita esta llena
                {
                    EspaciosPosRey(MatrizPrueba, fila, col + 1);  //Esta funcion me falta
                    //analizo el centro del 3x3 (rey) una col + a derecha
                }
            }
            if(EspaciosMax < 9 - Llenas && PosLibre(LOOKUP, fila, col)) //si encontré más espacios vacíos en un lugar que no tiene piezas
            {

            }
        }



        //ALTERNATIVA 2
    }
}
