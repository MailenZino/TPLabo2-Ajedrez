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
            Solucion_Maestra = new sPieza[8, 8];
        }
        public void ReproducirSoluciones(sPieza[] lookup)
        {
            //guardamos la solucion original
            CANT_SOL_MAESTRA++;
            for (int i = 0; i < 8; i++)
            {
                Solucion_Maestra[CANT_SOL_MAESTRA, i] = lookup[i];
            }
            ImprimirSolucion(lookup);

            sPosicion auxReacomodar1 = new sPosicion(0, N - 1); //con aux avisamos a reacomodar las modificaciones que hicimos
            sPosicion auxReacomodar2 = new sPosicion(N - 1, N - 1);
            sPosicion modificarPos1 = new sPosicion(lookup[1].posicion.FILA, N - 1);
            sPosicion modificarPos0 = new sPosicion(lookup[0].posicion.FILA, N-1);

            lookup[1].posicion = modificarPos1;
            Reacomodar(auxReacomodar1, lookup);

            modificarPos1.FILA = N - 1;
            modificarPos1.COL = 1;
            lookup[1].posicion = modificarPos1;
            auxReacomodar1.FILA = N - 1; auxReacomodar1.COL = 0;
            Reacomodar(auxReacomodar1, lookup);


            modificarPos1.COL = N - 1;
            lookup[1].posicion = modificarPos1;
            auxReacomodar1.COL = N - 1;
            Reacomodar(auxReacomodar1, lookup);

          
            modificarPos1.COL = 0;
            lookup[1].posicion = modificarPos1;
            lookup[0].posicion = modificarPos0;
            auxReacomodar1.FILA = N - 1;
            Reacomodar(auxReacomodar1, lookup);



            modificarPos1.COL = N - 2;
            lookup[1].posicion = modificarPos1;
            auxReacomodar1.FILA = 0;
            Reacomodar(auxReacomodar1, lookup, auxReacomodar2);

            modificarPos1.FILA = 1;
            lookup[1].posicion= modificarPos1;
            auxReacomodar1.FILA = 0;
            Reacomodar(auxReacomodar1, lookup, auxReacomodar2);

            modificarPos1.FILA = N-1;
            lookup[1].posicion = modificarPos1;
            modificarPos0.FILA = N - 2;
            lookup[0].posicion = modificarPos0;
            Reacomodar(auxReacomodar2, lookup, auxReacomodar2);

            modificarPos1.COL = N - 1;
            lookup[1].posicion = modificarPos1;
            modificarPos0.COL = 0;
            lookup[0].posicion = modificarPos0;
            
            auxReacomodar1.FILA = N - 1; auxReacomodar1.COL = 0;
            Reacomodar(auxReacomodar1, lookup, auxReacomodar2);

            modificarPos1.COL = 1;
            lookup[1].posicion= modificarPos1;
            Reacomodar(auxReacomodar1, lookup, auxReacomodar1);
        }
        public void ImprimirSolucion(sPieza[] lookup)
        {
            /*
             * IMPRIMIMOS TABLERO CON PRINTF E IMÁGENES, SABEMOS QUE EN 
                0 Y 1 - TORRES
                2 Y 3 - ALFILES
                4 - REINA
                5 Y 6 CABALLOS
                7 REY
            */
        }
        public void Reacomodar(sPosicion pos, sPieza[] lookup, sPosicion pos2)
        {
            sPieza[] LOOKUPaux = new sPieza[8];
           for(int i=0;i<8;i++)
           {    LOOKUPaux[i]=lookup[i]; }



           /*
            * //si es una columna sabes que moves a izq o derecha y va a ser la n-1 o la 
 1- SI (PosCritica.COL!=0)
      1.1 - SI(PosCrtica.COL>1)
               MIENTRAS(i=2;i<N;i++)
                  LOOKUPResolucionAUX[i].COL--;
           SI NO
               MIENTRAS(i=2;i<N;i++)
                  LOOKUPResolucionAUX[i].COL++;         
 2- SINO SI (PosCritica.FILA!=0)
      2.1- SI(PosCrtica.FILA>1)
              MIENTRAS(i=2;i<N;i++)
                  LOOKUPResolucionAUX[i].FILA--;
           SI NO
              MIENTRAS(i=2;i<N;i++)
                  LOOKUPResolucionAUX[i].FILA++;
3- SI(PosCritica2!={0,0})
        LLAMAR Reacomodar(PosCritica2,LOOKUP)
4- LLAMAR ImprimirSolucion(LOOKUPResolucionAUX);

            * 
           */

        }

        public bool SolucionExistente(sPieza[] lookup)
        {
            //TODO: SOLUCION EXISTENTE EN SOLUCIONES.CS
            return false;
        }
    }
}
