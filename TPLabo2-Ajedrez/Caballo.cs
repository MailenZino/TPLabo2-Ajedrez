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
        //Constructor de clase Caballo
        public Caballo():base(ePieza.CABALLO) {  }
        //Función para posicionar caballos en el tablero
        public bool PosicionarCaballos(Tablero MatrizPrueba , Pieza [] LOOKUP, Pieza CABALLO)
        {
            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, 2, 2);//Probamos casilla por casilla cuál es la mejor posición
            if (MatrizPrueba.contarVacias(0) != 0) return false;//Si en la posición donde pusimos al caballo quedan más de ... casillas vacias, no lo ponemos ahi
            else return true;//Si esta bien ahí, lo dejamos en esa posición
        }
        public void RecursividadCaballo(Tablero MatrizPrueba, Pieza[] LOOKUP, Pieza CABALLO, int i, int j)//i=2,j=2
        {
            int NLibres = 0;
            if(i >= 2 && i < N && j >= 2 && j < N)
            {
                if (MatrizPrueba.PosLibre(LOOKUP, i, j))//Si en la casilla [i,j] no hay otra pieza posicionada es una posición válida que hay que verificar si sirve
                {
                    //Posisionamos el caballo ahí
                    CABALLO.setFILA(i);
                    CABALLO.setCOL(j);
                    //sPosicion pos = new sPosicion(i, j);
                    //CABALLO.posicion = pos;

                    cont = VerificarPosCaballo(MatrizPrueba, CABALLO);//Verificamos cuántas casillas ocuparía el caballo posicionado de esta forma
                    if (LOOKUP[6] == null) NLibres = 5;//Si estamos posicionando al primer caballo, entonces las casillas libres serían 3 o menos
                    else NLibres = 1;//Si estamos posicionando el segundo, solo nos queda una casilla libre

                    if (MatrizPrueba.contarVacias() - cont - 1 > NLibres)//Si las casillas libres en el tablero al posicionar al caballo de esta manera son más que las que podría ocupar la próxima pieza
                    {//Cambiamos la cassila en donde probamos el posicionamiento y lo hacemos de nuevo
                        if (i == N - 1)
                        {
                            i = 2;
                            j++;
                        }
                        else i++;
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
                }
            }
            
            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, i, j);//LLamamos nuevamente la función con un posicionamiento diferente
        }
        public int VerificarPosCaballo(Tablero MatrizPrueba, Pieza CABALLO)
        {
            cont = 8;
            if(CABALLO.posicion.FILA + 1 < N)
            {
                if (CABALLO.getCOL() - 2 >= 0) cont -= MatrizPrueba.matriz[CABALLO.getFILA() + 1, CABALLO.getCOL() - 2];
                if (CABALLO.getCOL() + 2 < N) cont -= MatrizPrueba.matriz[CABALLO.getFILA() + 1, CABALLO.getCOL() + 2];
                if(CABALLO.getFILA() + 2 < N)
                {
                    if (CABALLO.getCOL() - 1 >= 0) cont -= MatrizPrueba.matriz[CABALLO.getFILA() + 2, CABALLO.getCOL() - 1];
                    if (CABALLO.getCOL() + 1 < N) cont -= MatrizPrueba.matriz[CABALLO.getFILA() + 2, CABALLO.getCOL() + 1];
                }
            }
            if(CABALLO.getFILA() - 1 >= 0)
            {
                if (CABALLO.getCOL() - 2 > 1) cont -= MatrizPrueba.matriz[CABALLO.getFILA() - 1, CABALLO.getCOL() - 2];
                if (CABALLO.getCOL() + 2 < N) cont -= MatrizPrueba.matriz[CABALLO.getFILA() - 1, CABALLO.getCOL() + 2];
                if(CABALLO.getFILA() - 2 >= 0)
                {
                    if (CABALLO.getCOL() - 1 >= 0) cont -= MatrizPrueba.matriz[CABALLO.getFILA() - 2, CABALLO.getCOL() - 1];
                    if (CABALLO.getCOL() + 1 < N) cont -= MatrizPrueba.matriz[CABALLO.getFILA() - 2, CABALLO.getCOL() + 1];
                }
            }
            return cont;
        }
    }
}
