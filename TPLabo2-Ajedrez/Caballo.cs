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

        //FUNCIONES POSICIONAR
        public void PosicionarCaballos(Tablero MatrizPrueba , Pieza [] LOOKUP, Pieza CABALLO)
        {
            //llamar a Casilla candidata y mandar a recursividad caballo con casilla candidata en ves 2,2 

            RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, 2, 2);//Probamos casilla por casilla cuál es la mejor posición

        }
        public void RecursividadCaballo(Tablero MatrizPrueba, Pieza[] LOOKUP, Pieza CABALLO, int i, int j)
        {
            int NLibres = 0;
            if(i >= 2 && i < N && j >= 2 && j < N)
            {
                if (MatrizPrueba.PosLibre(LOOKUP, i, j,true))//Si la casilla no esta ocupada
                {
                    //Posicionamos el caballo ahí y vemos cuántas casillas ocuparía posicionado ahi
                    CABALLO.setFILA(i);
                    CABALLO.setCOL(j);
                    
                    if (MatrizPrueba.matriz[i, j] == 0) cont++;
                    cont = VerificarPosCaballo(MatrizPrueba, CABALLO);

                    //Si estamos posicionando al primer caballo, queremos que quede solo 1 casilla libre maximo. Si no, 0
                    if (LOOKUP[6] == null) 
                        NLibres = 1;
                    else 
                        NLibres = 0;


                    //Si las casillas libres sin contar las que ocuparia caballo son más que las que queremos
                    if (MatrizPrueba.contarVacias() - cont > NLibres)
                    {
                        //Probamos otro posicionamiento
                        // aca podriamos usar la funcion que devuelva la direccion de la prox casilla libre y definir i j para que la tape y probar si sirve
                        //tambien podriamos llamar directamente con i j tapando la 1er casilla libre que se encuentre
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

        /*
        ----- ALTERNATIVA
        public void RecursividadCaballo(Tablero MatrizPrueba, Pieza[] LOOKUP, Pieza CABALLO, int i, int j)
        {
            int NLibres = 0;
            if(i >= 2 && i < N && j >= 2 && j < N)
            {
                if (MatrizPrueba.PosLibre(LOOKUP, i, j))//Si la casilla no esta ocupada
                {
                    //Posicionamos el caballo ahí y vemos cuántas casillas ocuparía posicionado ahi
                    CABALLO.setFILA(i);
                    CABALLO.setCOL(j);
                    
                    if (MatrizPrueba.matriz[i, j] == 0) cont++;
                    cont = VerificarPosCaballo(MatrizPrueba, CABALLO);

                    //Si estamos posicionando al primer caballo, queremos que quede solo 1 casilla libre maximo. Si no, 0
                    if (LOOKUP[6] == null) 
                        NLibres = 1;
                    else 
                        NLibres = 0;


                    if (MatrizPrueba.contarVacias() - cont <= NLibres)
                            return;
           
                }
             //Si las casillas libres son más que las que queremos o esta la pos ocupada
             //Probamos otro posicionamiento
                sPosicion Nueva.posicionCasillaCandidata(MatrizPrueba,i,j);  i=Nueva.fila j=Nueva.col;
               RecursividadCaballo(MatrizPrueba,LOOKUP,CABALLO, i, j)
            }
   
        }


        sPosicion CasillaCandidata(int[,]MatrizPrueba,int i=0,int j=0)
        {
            sPosicion aux= MatrizPrueba.ProxCasillaVacia(i,j);
                if(Posicion.COL<N-1&&Posicion.COL>3)
                 {
                           j=Posicion.COL-2;
                           if(Posicion.FILA==2)
                              i=Posicion.FILA--;
                           else
                             i=Posicion.FILA++; 
                           RecursividadCaballo(MatrizPrueba, LOOKUP, CABALLO, i, j);
                }
                else
                 {
                          j=Posicion.COL+2;
                          if(Posicion.FILA==2)
                              i=Posicion.FILA--;
                           else
                             i=Posicion.FILA++;
                 }
        }


        sPosicion ProxCasillaVacia(int fila=0;int col=0)
        {
           sPosicion aux;
            for(int i = 2;i < N;i++)
            {
                for(int j=2;j<N;j++)
                {
                    if (Matriz[i, j] == 0&&i!=fila&&col!=j) 
                     {   aux=new sPosicion(i,j); return aux;}
        
                }
            }
            
        }

        */





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
