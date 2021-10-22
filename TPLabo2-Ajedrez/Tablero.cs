﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLabo2_Ajedrez
{
    class Tablero
    {
        int[,] Matriz;
        int N;
        public Tablero(int n)
        {
            Matriz = new int[n, n];
            N = n;
        }

        public int[,] matriz { get { return Matriz; } }
        public void CargarFILACOL(int numero, bool fila = true)
        {
            for (int i = 0; i < N; i++)
            {
                if (fila)
                    Matriz[numero, i] = 1;
                else
                    Matriz[i, numero] = 1;
            }
        }

        int i = 0;
        void CargarDiagonalesInferiores(int fila, int col)
        {
            if (fila > N - 1 || fila < 2 )
                return;
            else
            {
                if (col + i < N)
                    Matriz[fila, col + i] = 1;
                if (col - i >= 2)
                    Matriz[fila, col - i] = 1;
            }
            i++;
            fila++;
            CargarDiagonalesInferiores(fila, col);
        }
        
        int l = 0;
        void CargarDiagonalesSuperiores(int fila, int col)
        {
            if (fila > N - 1 || fila < 2 )//|| col - l < 2 && col + l > N - 1)
                return;
            else
            {
                if (col + l < N)
                    Matriz[fila, col + l] = 1;
                if (col - l >= 2)
                    Matriz[fila, col - l] = 1;
            }
            l++;
            fila--;
            CargarDiagonalesSuperiores(fila, col);
        }
        public void CargarDiagonales(int fila, int col)
        {
          
            CargarDiagonalesInferiores(fila, col);
            i = 0;
            CargarDiagonalesSuperiores(fila, col);
            l = 0;
        }
        public bool VerificarLibredeAtaque(int fila, int col)
        {
            if (Matriz[fila, col]!=0)
                return false;
            return true;
        }

        public int contador;
        public int contarVacias(int col= 2)
        {
            //for(int i=2;i<N;i++)
            //{
            //    if (Matriz[i, col] == 0) contador++;
            //}
            //if (col < N - 1)
            //{
            //    col++;
            //    contarVacias(col);
            //}

            //return contador;
            contador = 0;
            for(int i = 2;i < N;i++)
            {
                for(int j=2;j<N;j++)
                {
                    if (Matriz[i, j] == 0) contador++;
                }
            }
            return contador;
        }

        public bool PosLibre(Pieza[] LOOKUP, int fila, int col)
        {
            int piezas_cargadas = 7;
            for (int i = 0; i < piezas_cargadas; i++)
            {
                if (LOOKUP[i] != null)
                {
                    if (LOOKUP[i].posicion.FILA == fila && LOOKUP[i].posicion.COL == col)
                        return false;
                }
                else
                    break;
            }
            return true;
        }
    }
}
