using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Tablero
    {
        bool[,] Matriz;
        int N;
        public Tablero(int n)
        {
            bool[,] Matriz = new bool[n, n];
            N = n;
        }
        public void CargarFILACOL(int numero, bool fila = true)
        {
            for (int i = 0; i < N; i++)
            {
                if (fila)
                    Matriz[numero, i] = true;
                else
                    Matriz[i, numero] = true;
            }
        }
        void CargarDiagonalesInferiores(int fila, int col) { }
        void CargarDiagonalesSuperiores(int fila, int col) { }
        public void CargarDiagonales(int fila, int col)
        {
            CargarDiagonalesInferiores(fila, col);
            CargarDiagonalesSuperiores(fila, col);

        }
        public bool VerificarLibredeAtaque(int fila, int col)
        {
            if (Matriz[fila, col])
                return false;
            return true;
        }
    }
}
