using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraTDD.Services
{
    public class CalculadoraImp
    {
        private List<string> listaHistorico;

        public CalculadoraImp()
        {
            listaHistorico = new List<string>();
        }

        public int Somar(int num1, int num2)
        {
            int res = num1 + num2;

            listaHistorico.Insert(0, "Res: " + res);

            return res;
        }

        public int Subtrair(int num1, int num2)
        {
            int res = num1 - num2;
            listaHistorico.Insert(0, "Res: " + res);
            return res;
        }

        public int Multiplicar(int num1, int num2)
        {
            int res = num1 * num2;
            listaHistorico.Insert(0, "Res: " + res);
            return res;
        }

        public int Dividir(int num1, int num2)
        {
            int res = num1 / num2;
            listaHistorico.Insert(0, "Res: " + res);
            return res;
        }

        public List<string> historico()
        {
            if (listaHistorico.Count > 3)
            {
                listaHistorico.RemoveRange(3, listaHistorico.Count - 3);
            }
            return listaHistorico;
        }

    }
}