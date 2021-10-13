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

        public bool[,] matriz { get { return Matriz; } }
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

        int i = 0;
        void CargarDiagonalesInferiores(int fila, int col)
        {
            if (fila > N - 1 || fila < 2 || (col + i > N - 1 && col - i < 2))
                return;
            else
            {
                if (col + i < N)
                    Matriz[fila, col + i] = true;
                if (col - i >= 2)
                    Matriz[fila, col - i] = true;
            }
            i++;
            CargarDiagonalesInferiores(fila + i, col);
        }
        
        int l = 0;
        void CargarDiagonalesSuperiores(int fila, int col)
        {
            if (fila > N - 1 || fila < 2 || col - l < 2 && col + l > N - 1)
                return;
            else
            {
                if (col + l < N)
                    Matriz[fila, col + l] = true;
                if (col - l >= 2)
                    Matriz[fila, col - l] = true;
            }
            l++;
            CargarDiagonalesSuperiores(fila - l, col);
        }
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

        int contador;
        public int contarVacias(int col= 2)
        {
            for(int i=2;i<N;i++)
            {
                contador += int(Matriz[i, col]);
            }
            if (col < N - 1)
                contarVacias(col++);
            else
                return contador;
        }
    }
}
