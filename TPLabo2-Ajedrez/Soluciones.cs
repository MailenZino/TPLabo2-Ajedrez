using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    public class Soluciones
    {
        public Pieza[,] Solucion_Maestra;
        private Pieza[,] Soluciones_totales;
        int CANT_SOL_TOTALES;
        int CANT_SOL_MAESTRA;
        public int CANT_SOL_IMPRESAS;
        public int SOL_A_MOSTRAR;
        MainForm mainForm;
        int N = 8;
        public Soluciones()
        {
            CANT_SOL_MAESTRA = 0;
            CANT_SOL_TOTALES = 0;
            CANT_SOL_IMPRESAS = 0;
            SOL_A_MOSTRAR = 5; //minimo
            Solucion_Maestra = new Pieza[8, 8];
            Soluciones_totales = new Pieza[36, 8];

        }


        //chequear solucion existente
        public bool SolucionExistente(Pieza[] lookup)
        {

            if (CANT_SOL_MAESTRA > 0)
            {
                int iguales = 0;
                for (int j = 0; j < CANT_SOL_MAESTRA; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (Solucion_Maestra[j, i].getFILA() == lookup[i].getFILA() && Solucion_Maestra[j, i].getCOL() == lookup[i].getCOL())
                        {
                            iguales++;
                        }
                    }
                    if (iguales == 8)
                        return true;
                }
            }
            return false;
        }


        /// <summary>
        /// nos permite encontrar mas soluciones a partir del lookup recibido que contiene una ""solucion maestra""
        /// Reacomodar tiene una complejidad constante, Omega(2*2*8 + 1072 + 2 + 52 + 4 + 4 + 52 + 760 + 8*(218 + 4 + 4 + 52 + 144 + 760))
        /// Omega(11434)
        /// </summary>
        /// <param name="lookup"></param>
        public void ReproducirSoluciones(Pieza[] lookup, MainForm mainForm)
        {

            Pieza[] lookup_aux = new Pieza[8];//8*2
            Pieza[] lookup_aux2 = new Pieza[8];//8*2

            //guardamos la solucion original y la contamos
            for (int i = 0; i < 8; i++)//8*(6 + 2*8*8) = 1072
            {
                Solucion_Maestra[CANT_SOL_MAESTRA, i] = new Pieza(lookup[i]); //copiamos el lookup como solucion maestra
                lookup_aux[i] = new Pieza(lookup[i]); //copiamos el look up original a el auxiliar
                lookup_aux2[i] = new Pieza(lookup[i]);
            }
            CANT_SOL_MAESTRA++;//2
            CargarSolucion(lookup);//52

            // Imprimimos las soluciones que pueden reproducirse sin desplazar las fichas del 6x6 encerrado x las torres 
            lookup_aux[0].setFILA(0); lookup_aux[0].setCOL(1);//4
            lookup_aux[1].setFILA(1); lookup_aux[1].setCOL(0);//4
            CargarSolucion(lookup_aux);//52

            Espejar(lookup, 1, 0, 1, 1, 0);//760
            
            
            //Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 col hacia izq
            lookup_aux = Reacomodar(lookup, 0, 1);//218

            lookup_aux[0].setFILA(0); lookup_aux[0].setCOL(N - 1);//4
            lookup_aux[1].setFILA(1); lookup_aux[1].setCOL(0);//4
            CargarSolucion(lookup_aux);//52

            Copiar6x6(lookup_aux, 0, 0, 1, N - 1);//144

            //760
            Espejar(lookup_aux,-1,0,0,1,N - 1); //una vez cargadas las originales las espejamos para obtener 2 sol mas
            
            
            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 fila arriba 
            lookup_aux = Reacomodar(lookup, 1);
            lookup_aux[0].setFILA(0); lookup_aux[0].setCOL(0);
            lookup_aux[1].setFILA(N - 1); lookup_aux[1].setCOL(1);
            CargarSolucion(lookup_aux);

            Copiar6x6(lookup_aux, 0, 1, N - 1, 0);
      
            Espejar(lookup_aux,1, 0, 1, N - 1, 0);


            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 col a izq y 1 fila hacia arriba
            lookup_aux = Reacomodar(lookup, 1, 1);

            lookup_aux[0].setFILA(0); lookup_aux[0].setCOL(N-1);
            lookup_aux[1].setFILA(N - 1); lookup_aux[1].setCOL(0);
            CargarSolucion(lookup_aux);

            Copiar6x6(lookup_aux, 0, 0, N - 1, N - 1);
    
            Espejar(lookup_aux,-1, 0, 0, N - 1, N - 1);


            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 col a izq
            // SOL 13 - 16 ME PARECE QUE NOS FALTA HACER SUBIR UNA FILA
            lookup_aux = Reacomodar(lookup, 1, 2);

            lookup_aux[0].setFILA(0); lookup_aux[0].setCOL(N-2);
            lookup_aux[1].setFILA(N - 1); lookup_aux[1].setCOL(N-1);
            CargarSolucion(lookup_aux);

            Copiar6x6(lookup_aux, 0, N - 1, N - 1, N - 2);

            Espejar(lookup_aux,-3,0, N - 1, N - 1, N - 2);

            
            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 col a izq
            lookup_aux = Reacomodar(lookup, 0, 2);

            lookup_aux[0].setFILA(0); lookup_aux[0].setCOL(N-1);
            lookup_aux[1].setFILA(1); lookup_aux[1].setCOL(N-2);
            CargarSolucion(lookup_aux);

            Copiar6x6(lookup_aux, 0, N - 2, 1, N - 1);

            Espejar(lookup_aux,-3, 0, N - 2, 1, N - 1);

            
            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 col a izq y 2 fila hacia arriba
            lookup_aux = Reacomodar(lookup, 2, 2);

            lookup_aux[0].setFILA(N-2); lookup_aux[0].setCOL(N-2);
            lookup_aux[1].setFILA(N - 1); lookup_aux[1].setCOL(N - 1);
            CargarSolucion(lookup_aux);

            Copiar6x6(lookup_aux, N - 2, N - 1,N-1,N-2);

            Espejar(lookup_aux,-3,N - 2, N - 1,N-1,N-2);
            
            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 fila a arriba y 1 col a izq
            lookup_aux = Reacomodar(lookup, 2, 1);

            lookup_aux[0].setFILA(N - 2); lookup_aux[0].setCOL(0);
            lookup_aux[1].setFILA(N - 1); lookup_aux[1].setCOL(N - 1);
            CargarSolucion(lookup_aux);

            Copiar6x6(lookup_aux, N - 2, N - 1,N-1,0);
           
            Espejar(lookup_aux,-1, N - 2, N - 1,N-1,0);
           
            
            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 fila hacia arriba
            lookup_aux = Reacomodar(lookup, 2);


            lookup_aux[0].setFILA(N - 2); lookup_aux[0].setCOL(1);
            lookup_aux[1].setFILA(N - 1); lookup_aux[1].setCOL(0);
            CargarSolucion(lookup_aux);

            Copiar6x6(lookup_aux, N - 2, 0, N - 1, 1);

            Espejar(lookup_aux, 0, N - 2, 0, N - 1, 1);

            ImprimirSoluciones(mainForm);//Su complejidad dependerá de la cantidad de soluciones que el usuario elija mostrar, el mejor caso es
            //cuando selecciona mostrar 5, el peor es cuando selecciona 36
            //T(CantSoluciones,a,b,c,d,e,n,m,p,h) = (CantSoluciones-1)*(544a + 732b + 42n*c + 640d + 71e + 6m*p + 1720) + h
            //a es la cantidad de casillas que recorre la reina desde su posición hasta los extremos de su fila y columna, b lo mismo pero con sus diagonales,
            // n es la cantidad de columnas que ataca el rey que estén dentro del tablero y c el número de estas casillas que estén vacías alrededor del rey,
            //d es  la cantidad de casillas con ataque leve, e depende de si hay un caballo posicionado en la misma casilla que un alfil, 
            // m es la cantidad de soluciones impresas y p la cantidad de veces que el algoritmo hace para encontrar un número de solución no repetida
            // Si SOL_A_MOSTRAR es 30, h = 3341
            // Si SOL_A_MOSTRAS != 30, h = 3347
        }

        //Complejidad cte. Omega(16 + 64 + 6 + 6 + 52) = Omega(144)
        public void Copiar6x6(Pieza[] lookup_fuente, int F1, int C1, int F2,int C2)
        {
            Pieza[] lookup_aux;
            lookup_aux = new Pieza[8];//2*8

            for(int i=0;i<8;i++)//8*8
            {
                lookup_aux[i] = new Pieza(lookup_fuente[i]);
            }
            lookup_aux[0].setFILA(F1); lookup_aux[0].setCOL(C1);//6
            lookup_aux[1].setFILA(F2); lookup_aux[1].setCOL(C2);//6
            CargarSolucion(lookup_aux);//52
        }


        //----------------------------- ajustan el  6x6 para reproducir soluciones ----------------------------

        /// <summary>
        /// Se reajusta la posicion de las piezas en el 6x6 delimitado x las torres
        /// Complejidad constante de 218
        /// </summary>
        /// <param name="lookup"></param>
        /// <param name="fila"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        
        public Pieza[] Reacomodar(Pieza[] lookup, int fila, int col = 0)
        {
            Pieza[] LOOKUPaux = new Pieza[8];//2*8
            for (int i = 0; i < 8; i++) //8*8=64
            { LOOKUPaux[i] = new Pieza(lookup[i]); }


            for (int i = 2; i < N; i++)//6*2*(5 + 7)=144
            {
                if (fila > 0 && fila < 3)
                {
                    LOOKUPaux[i].setFILA(LOOKUPaux[i].getFILA()-fila);
                }
                if (col > 0 && col < 3)
                {
                    LOOKUPaux[i].setCOL(LOOKUPaux[i].getCOL()-col);
                }
            }
            return LOOKUPaux;

        }



        /// <summary>
        /// espejar hacia el costado las piezas del 6x6 delimitado por las torres para encontrar otra solucion
        /// Complejidad cte de 2 + 2 + 8*(8 + 2 + 6*(2 + 7 + 4)) + 52 = 760
        /// </summary>
        /// <param name="desplazamiento"></param>
        public void Espejar(Pieza[] lookup, int desplazamiento,int F1, int C1,int F2,int C2)
        {
            int aux = 0;//2
            Pieza[] lookupaux = new Pieza[8];//2
            for (int i = 0; i < 8; i++)//8*(8 + 2 + 6*(2 + 7 + 4))
            {
                lookupaux[i] = new Pieza(lookup[i]);
                if (i >= 2)
                {
                    aux = Constants.N + desplazamiento - lookup[i].getCOL();
                    //aux = Constants.N - 1 - lookup[i].getCOL();
                    lookupaux[i].setCOL(aux);
                }
            }
            CargarSolucion(lookupaux);//52
            Copiar6x6(lookupaux, F1, C1, F2, C2);
            //espeja hacia el costado tambien podria espejarse hacia abajo
            //CargarSolucion(lookupaux);//52

        }


        //---------------------------------------------------------------------------------------------------


        /// <summary>
        /// Se copia el look up a sol totales que contiene todas las soluciones
        /// Complejidad cte de 52
        /// </summary>
        /// <param name="lookup"></param>
        public void CargarSolucion(Pieza[] lookup)
        {
            if (CANT_SOL_TOTALES <= 35)//2
            {
                for (int i = 0; i < 8; i++)//8*6=48
                {
                    Soluciones_totales[CANT_SOL_TOTALES, i] = lookup[i];
                }
                CANT_SOL_TOTALES++;//2
            }
        }

        /// <summary>
        /// Guardamos las soluciones en un vector que al llenarse se envia al form para imprimir 10 soluciones de manera aleatoria.
        /// En el vector nos quedan las soluciones: original - espejada - torres desplazadas - torres desplazadas espejadas
        /// </summary>
        ///  
        /// <param name="lookup"></param>
        public void ImprimirSoluciones(MainForm mainForm)
        {
           FormSoluciones FORM = new FormSoluciones(Soluciones_totales, this, mainForm);
           FORM.Visible = true;
          
        }

      
        
    }
}
