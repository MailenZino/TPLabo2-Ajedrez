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

        int N = 8;
        public Soluciones()
        {
            CANT_SOL_MAESTRA = 0;
            CANT_SOL_TOTALES = 0;
            CANT_SOL_IMPRESAS = 0;
            Solucion_Maestra = new Pieza[8, 8];
            Soluciones_totales = new Pieza[36, 8];
        }
        /// <summary>
        /// nos permite encontrar mas soluciones a partir del lookup recibido que contiene una ""solucion maestra""
        /// </summary>
        /// <param name="lookup"></param>
        public void ReproducirSoluciones(Pieza[] lookup)
        {

            Pieza[] lookup_aux = new Pieza[8];
            //FormSoluciones FORM = new FormSoluciones(Soluciones_totales, this);
            //guardamos la solucion original y la contamos
            for (int i = 0; i < 8; i++)
            {
                Solucion_Maestra[CANT_SOL_MAESTRA, i] = new Pieza(lookup[i]); //copiamos el lookup como solucion maestra
                lookup_aux[i] = new Pieza(lookup[i]); //copiamos el look up original a el auxiliar

            }
            CANT_SOL_MAESTRA++;

            // Imprimimos las soluciones que pueden reproducirse sin desplazar las fichas del 6x6 encerrado x las torres 
            CargarSolucion(lookup);
            Espejar(lookup);
            lookup_aux[0].posicion.COL = 1;
            lookup_aux[1].posicion.COL = 0;
            CargarSolucion(lookup);
            Espejar(lookup_aux);

            /*
             * hasta aca teniamos la torre1
             *                     lookup[0].posicion={0,0}
             * y la torre 2
             *                      lookup[1].posicion={1,1}             
            */

            //Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 col hacia arriba
            lookup_aux = Reacomodar(lookup, 0, 1);
            lookup_aux[0].posicion.COL = N - 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = 0;
            lookup_aux[1].posicion.COL = N - 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);

            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 fila a izq 
            lookup_aux = Reacomodar(lookup, 1);
            lookup_aux[1].posicion.FILA = N - 1;
            lookup_aux[1].posicion.COL = 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = 1;
            lookup_aux[1].posicion.COL = 0;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);

            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 fila a izq y 1 col hacia arriba
            lookup_aux = Reacomodar(lookup, 1, 1);
            lookup_aux[0].posicion.COL = N - 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = 0;
            lookup_aux[1].posicion.COL = N - 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);

            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 fila a izq y 1 col hacia arriba
            lookup_aux = Reacomodar(lookup, 2, 1);
            lookup_aux[0].posicion.COL = N - 2;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = N - 1;
            lookup_aux[1].posicion.COL = N - 2;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);


            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 fila a izq y 2 col hacia arriba
            lookup_aux = Reacomodar(lookup, 1, 2);
            lookup_aux[1].posicion.FILA = 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = N - 2;
            lookup_aux[1].posicion.COL = N - 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);


            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 fila a izq y 2 col hacia arriba
            lookup_aux = Reacomodar(lookup, 2, 2);
            lookup_aux[0].posicion.FILA = N - 2;
            lookup_aux[1].posicion.FILA = N - 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = N - 1;
            lookup_aux[1].posicion.COL = N - 2;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);

            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 1 fila a izq y 2 col hacia arriba
            lookup_aux = Reacomodar(lookup, 1, 2);
            lookup_aux[0].posicion.COL = 0;
            lookup_aux[1].posicion.COL = N - 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = N - 1;
            lookup_aux[1].posicion.COL = 0;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);

            // Imprimimos las soluciones que pueden reproducirse desplazando las fichas del 6x6 2 col hacia arriba
            lookup_aux = Reacomodar(lookup, 0, 2);
            lookup_aux[0].posicion.COL = 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);
            lookup_aux[0].posicion.COL = 0;
            lookup_aux[1].posicion.COL = 1;
            CargarSolucion(lookup_aux);
            Espejar(lookup_aux);

            ImprimirSoluciones();
        }
        /// <summary>
        /// Guardamos las soluciones en un vector que al llenarse se envia al form para imprimir 10 soluciones de manera aleatoria.
        /// En el vector nos quedan las soluciones: original - espejada - torres desplazadas - torres desplazadas espejadas
        /// </summary>
        ///  
        /// <param name="lookup"></param>

        public void ImprimirSoluciones()
        {
            
          FormSoluciones FORM = new FormSoluciones(Soluciones_totales, this);
           FORM.Visible = true;
        }
        public Pieza[] Reacomodar(Pieza[] lookup, int fila, int col = 0)
        {
            Pieza[] LOOKUPaux = new Pieza[8];
            for (int i = 0; i < 8; i++)
            { LOOKUPaux[i] = new Pieza(lookup[i]); }


            for (int i = 2; i < N; i++)
            {
                if (fila > 0 && fila < 3)
                {
                    LOOKUPaux[i].posicion.FILA -= fila;
                }
                if (col > 0 && col < 3)
                {
                    LOOKUPaux[i].posicion.COL -= col;
                }
            }
            return LOOKUPaux;

        }

        /// <summary>
        /// espejar hacia el costado las piezas del 6x6 delimitado por las torres para encontrar otra solucion
        /// </summary>
        /// <param name="lookup"></param>
        public void Espejar(Pieza[] lookup)
        {
            int aux = 0;
            Pieza[] lookupaux = new Pieza[8];
            for (int i = 0; i < 8; i++)
            {
                lookupaux[i] = new Pieza(lookup[i]);
                if (i >= 2)
                {
                    aux = Constants.N - 1 - lookup[i].getCOL();
                    lookupaux[i].setCOL(aux);
                }
            }
            //espeja hacia el costado tambien podria espejarse hacia abajo
            CargarSolucion(lookupaux);
        }

        public void CargarSolucion(Pieza[] lookup)
        {
            if (CANT_SOL_TOTALES <= 35)
            {
                for (int i = 0; i < 8; i++)
                {
                    Soluciones_totales[CANT_SOL_TOTALES, i] = lookup[i];
                }
                CANT_SOL_TOTALES++;
            }
        }
            public bool SolucionExistente(Pieza[] lookup)
        {
            //TODO: pinta sobrecarga == para fila y col  ??????
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
    }
}
