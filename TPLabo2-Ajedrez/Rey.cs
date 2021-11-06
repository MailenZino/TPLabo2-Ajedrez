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


        //CARGA EN LA MATRIZ
        /// <summary>
        /// CARGA A LA MATRIZ LOS ESPACIOS QUE OCUPA EL REY EN FILA COL 
        /// </summary>
        /// <param name="MatrizPrueba"></param>
        /// <param name="fila"></param>
        /// <param name="col"></param>
        public void CargarPosRey(Tablero MatrizPrueba, int fila, int col)
        {
            for (int i = col - 1; i < col + 2; i++)
            {
                if (i < N && i >= 2)
                {
                    if (fila - 1 >= 2)
                        MatrizPrueba.matriz[fila - 1, i] = 1;
                    if (fila + 1 < N)
                        MatrizPrueba.matriz[fila + 1, i] = 1;
                }
            }
            if (col + 1 < N)
                MatrizPrueba.matriz[fila, col + 1] = 1;
            if (col - 1 >= 2)
                MatrizPrueba.matriz[fila, col - 1] = 1;
        }

        //POSICIONAMIENTO
        //Complejidad:
        //El mejor caso es que posicione al Rey en la primer casilla que encuentra, es decir en el 3,3
        //Omega(8 + 4 + 13*5 + 1 + 6 + 109 + 2 + 217 + 3)
        //Omega(415)

        public void BuscarPosicionRey(Tablero MatrizPrueba, Pieza[] LOOKUP, Pieza REY, int cantLlenas, int i, int j)//LLAMAR CON I Y J EN CERO
        {
            if ((i >= 2) && (i < N) && (j >= 2) && (j < N))//Si la casilla está dentro de nuestro 6x6       8
            {
                if (MatrizPrueba.matriz[i, j] == 0 && (MatrizPrueba.PosLibre(LOOKUP, i, j)))              //4 + (13*CantPiezasCargadas + 1)
                {
                    REY.setFILA(i);                                                                       //3
                    REY.setCOL(j);                                                                        //3
                    cantLlenas = VerificarPosRey(MatrizPrueba, REY);                                     //Depende de la casilla en donde esté posicionado el rey
                    MatrizPrueba.contador = 0;
                    if (MatrizPrueba.contarVacias() - cantLlenas > 3)//Si las casillas que quedan vacías al posicionar al rey allí son más de 3, no nos sirve
                    {//217 + 3
                        if (i == N - 1)//2
                        {
                            i = 2;//2
                            j++;//2
                        }
                        else i++;//2
                        BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, cantLlenas, i, j);
                    }
                    else
                    {//Nos sirve, dejamos al rey en esa posición y volvemos
                        return;
                    }
                }
                else//Si no está dentro del 6x6, intentamos con otra
                {
                    if (i == N - 1)//2
                    {
                        i = 2;//2
                        j++;//2
                    }
                    else i++;//2
                    BuscarPosicionRey(MatrizPrueba, LOOKUP, REY, cantLlenas, i, j);
                }
            }
        }
       
        /// <summary>
        /// Cuenta cantidades de espacios libres que ocupa el rey en la pos cargada
        /// Complejidad: Depende de la posición del Rey. El for recorre las tres columnas en donde están las casillas
        /// que atacaría el rey. Si esta en algúno de los dos límites del costado del tablero, una columna está fuera del tablero.
        /// En el mejor caso, Rey está en 3,3: 4*(5 + 3 + 7) + 2*( 5 + 3 + 6) + 3 + 7 + 3 + 8 = 109
        /// 
        /// </summary>
        /// <param name="MatrizPrueba"></param>
        /// <param name="REY"></param>
        /// <returns></returns>
        public int VerificarPosRey(Tablero MatrizPrueba, Pieza REY)
        {
            for (int i = REY.getCOL() - 1; i <= REY.getCOL() + 1; i++)                
            {
                if (i < N && i >= 0)                                               //5
                {   
                    if (REY.getFILA() + 1 < N)                                     //3
                    {
                        if (MatrizPrueba.matriz[REY.getFILA() + 1, i] == 0) cont++;//6 si condicion es false, 7 si es true
                    }
                    if (REY.getFILA() - 1 >= 0)                                    //3
                    {
                        if (MatrizPrueba.matriz[REY.getFILA() - 1, i] == 0) cont++;//6 si condicion es false, 7 si es true
                    }
                }
                if (REY.getCOL() + 1 < N)                                          //3
                {
                    if (MatrizPrueba.matriz[REY.getFILA(), REY.getCOL() + 1] == 0) cont++;//7 false, 8 true
                }
                if (REY.getCOL() - 1 >= 0)                                         //3
                {
                    if (MatrizPrueba.matriz[REY.getFILA(), REY.getCOL() - 1] == 0) cont++;//7 false, 8 true
                }
            }
            return cont + 1;//retornamos las casillas que atacaría el rey más la casilla en donde está posicionado
        }
    }
}
