using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Soluciones
    {
        sPieza[,] Solucion_Maestra;
        int CANT_SOL_MAESTRA;
        int N = 8;
        public Soluciones()
        {
            CANT_SOL_MAESTRA = 0;
            Solucion_Maestra = new sPieza[8,8];
        }
        public void ReproducirSoluciones(sPieza[] lookup)
        {
            //guardamos la solucion original
            CANT_SOL_MAESTRA++;
            for (int i = 0; i < 8; i++)
            {
                Solucion_Maestra[CANT_SOL_MAESTRA,i] = lookup[i];
            }
            ImprimirSolucion(lookup);

            sPosicion aux= new sPosicion(0,N-1);
            lookup[1].posicion.COL = N-1;
            Reacomodar(aux, lookup);

            lookup[1].posicion.FILA = N - 1;
            lookup[1].posicion.COL = 1;
            aux.FILA = N - 1; aux.COL = 0;
            Reacomodar(aux, lookup);

            
            lookup[1].posicion.COL =N-1;
            aux.COL = N - 1;
            Reacomodar(aux, lookup);

            lookup[0].posicion.COL = N - 1;
            lookup[1].posicion.COL = 0;
            aux.FILA = N - 1;
            Reacomodar(aux, lookup);


         
            lookup[1].posicion.COL = N-2;
            aux.FILA = 0;
            sPosicion aux2 = new sPosicion(N - 1, N - 1);
            Reacomodar(aux, lookup,aux2);

            lookup[1].posicion.FILA = 1;
            aux.FILA = 0;
            Reacomodar(aux, lookup, aux);

            lookup[1].posicion.FILA = N - 1;
            lookup[0].posicion.FILA = N - 2;
            Reacomodar(aux2, lookup, aux2);

            lookup[0].posicion.COL = 0;
            lookup[1].posicion.COL = N - 1;
            aux.FILA = N - 1; aux.COL = 0;
            Reacomodar(aux, lookup, aux2);

            lookup[1].posicion.COL = 1;
            Reacomodar(aux, lookup, aux);
        }
        public void ImprimirSolucion(sPieza[] lookup)
        {

        }
        public void Reacomodar(sPosicion pos, sPieza[] lookup, sPosicion pos2 ={ 0,0})
        {
        }
    }
}
