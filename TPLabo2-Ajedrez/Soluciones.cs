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
            //guardamos la solucion original y la contamos como nueva sol maestra
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
            Program.CANT_SOL_TOTALES = 10;
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
        public void Reacomodar(sPosicion PosCritica, sPieza[] lookup, sPosicion PosCritica2=new sPosicion())
        {
            sPieza[] LOOKUPaux = new sPieza[8];
           for(int i=0;i<8;i++)
           {    LOOKUPaux[i]=lookup[i]; }

           
            //si es una columna sabes que moves a izq o derecha y va a ser la n-1 o la
            if (PosCritica.COL != 0)
            {
                if (PosCritica.COL > 1)
                {
                    for (int i = 2; i < N; i++)
                        LOOKUPaux[i].COL--;
                }
                else
                {
                    for (int i = 2; i < N; i++)
                        LOOKUPaux[i].COL++;
                }
            }
            else if (PosCritica.FILA != 0)
            {
                if (PosCritica.FILA > 1)
                {
                    for (int i = 2; i < N; i++)
                        LOOKUPaux[i].FILA--;
                }
            }
            else
            {
                for (int i = 2; i < N; i++)
                { LOOKUPaux[i].FILA++; }
            }
            if (PosCritica2.FILA != 0 && PosCritica2.COL != 0)
                Reacomodar(PosCritica2, lookup);
            
            ImprimirSolucion(LOOKUPaux);

        }

        public bool SolucionExistente(sPieza[] lookup)
        {
            //TODO: pinta sobrecarga == para fila y col  ??????
            if (CANT_SOL_MAESTRA > 0)
            {
                int iguales = 0;
                for (int j = 0; j <= CANT_SOL_MAESTRA; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (Solucion_Maestra[CANT_SOL_MAESTRA, i].posicion.FILA == lookup[i].posicion.FILA && Solucion_Maestra[CANT_SOL_MAESTRA, i].posicion.COL == lookup[i].posicion.COL)
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
