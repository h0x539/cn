using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    //http://adhalanay.github.io/calcul-numeric/probleme1.html
    //halanay@fmi.unibuc.ro
    class Program
    {
        float x;
        List<Tuple<Double, Double>> lista = new List<Tuple<Double, Double>>();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Bisectie();
            Console.WriteLine("\n");
            p.Falsei();
            Console.WriteLine("\n");
            p.Coarda();
            Console.WriteLine("\n");
            p.Secanta();
            Console.WriteLine("\n");
            p.Newton();
            Console.ReadLine();
        }

        private double f(double x)
        {
            return (20 * Math.Pow(Math.E, -2 * x) * Math.Sin(5 * x * x * Math.Sqrt(x)) - (1d / 4d));
        }

        public double fDerivat(double x)
        {
            return Math.Pow(Math.E, -2 * x) * ((250 * Math.Pow(x, 3 / 2) * Math.Cos(5 * Math.Pow(x, 5 / 2))) - (40 * Math.Sin(5 * Math.Pow(5, 2))));
        }

        public double fd(double x)
        {
            return (Math.Pow(Math.E, -2 * x)) * (-40 * Math.Sin(5 * Math.Pow(x, 2) * Math.Sqrt(x)) + 20 * Math.Cos(5 * Math.Pow(Math.Sqrt(x), -1)));
        }

        public void Bisectie() {
            Console.WriteLine("/*----------------- Metoda Bisectiei -----------------*/\n");
            double a, b, a1, b1;
            int i = 0;
            int j = 1;
            while (i++ < 40)
            {
                a = 1d * (i-1) / 20d;
                b = a + (1d / 20d);
                a1 = a;
                b1 = b;
                if (f(a) * f(b) < 0)
                {
                    double m = (b + a) / 2d;
                    while (!(Math.Abs(f(m)) < (double)Math.Pow(10d, -14)))
                    {
                        if (f(a) * f(m) < 0)
                        {
                            b = m;
                            m = (m + a) / 2d;
                        }
                        else
                        {
                            a = m;
                            m = (b + m) / 2d;
                        }
                    }
                    Tuple<Double, Double> tuple = new Tuple<Double, Double>(a1, b1);
                    lista.Add(tuple);
                    Console.WriteLine((j++) + ". " + "m = " + m + "  f = " + f(m));
                }
            }
            Console.WriteLine("\n/*----------------- Metoda Bisectiei -----------------*/");
        }

        public void Falsei() {
            Console.WriteLine("/*----------------- Metoda Falsei -----------------*/\n");
            double a, b;
            int j = 1;
            int i = 0;
            while (i++ < 40){
                a = 1d * (i-1) / 20d;
                b = a + (1d / 20d);
                if (f(a) * f(b) < 0) {
                    double m = (a * f(b) - b * f(a)) / (f(b) - f(a));
                    while (!(Math.Abs(f(m)) < (double)Math.Pow(10d, -14)))
                    {
                        if (f(a) * f(m) < 0)
                        {
                            b = m;
                            m = (a * f(b) - b * f(a)) / (f(b) - f(a));
                        }
                        else
                        {
                            a = m;
                            m = (a * f(b) - b * f(a)) / (f(b) - f(a));
                        }
                    }
                    Console.WriteLine((j++) + ". " + "m = " + m + "  f(m) = " + f(m));
                }
            }
            Console.WriteLine("\n/*----------------- Metoda Falsei -----------------*/");
        }

        public void Coarda() {
            Console.WriteLine("/*----------------- Metoda Coardei -----------------*/\n");
            int j = 1;
            for(int i = 0;i<lista.Count;i++){
                Tuple<Double, Double> tuple = lista[i];
                double a = tuple.Item1;
                double b = tuple.Item2;
                double x1 = b;
                double x2 = (a * f(b) - b * f(a)) / (f(b) - f(a));
                long it = 1000000;
                while (Math.Abs(x2 - x1) > (double) Math.Pow(10d, -14) && it > 0) {
                    it--;
                    b = x2;
                    x2 = (a * f(b) - b * f(a)) / (f(b) - f(a));
                }
                Console.WriteLine((j++) + ". " + "x2 = " + x2 + "  f(x2) = " + f(x2));
            }
            Console.WriteLine("\n/*----------------- Metoda Coardei -----------------*/");
        }

        public void Secanta() {
            Console.WriteLine("/*----------------- Metoda Secantei -----------------*/\n");
            int j = 1;
            for(int i = 0;i<lista.Count;i++){
                Tuple<Double, Double> tuple = lista[i];
                double a = tuple.Item1;
                double b = tuple.Item2;
                double x1 = b;
                double x2 = (a * f(b) - b * f(a)) / (f(b) - f(a));
                while (Math.Abs(f(x2)) > (double) Math.Pow(10d, -14)) {
                    a = x1;
                    b = x2;
                    x2 = (a * f(b) - b * f(a)) / (f(b) - f(a));
                }
                Console.WriteLine((j++) + ". " + "x3 = " + x2 + " | f(X3) = " + f(x2));
            }
            Console.WriteLine("\n/*----------------- Metoda Secantei -----------------*/");
        }

        public void Newton() {
            Console.WriteLine("/*----------------- Metoda Netwon -----------------*/\n");
            int j = 1;
            int i = 0;
            for(i = 0;i<lista.Count;i++){
                Tuple<Double, Double> tuple = lista[i];
                double a = tuple.Item1;
                double b = tuple.Item2;
                double x0 = (a + b) / 2;
                double x1 = x0 - f(x0) / fDerivat(x0){
                while (Math.Abs(f(x0)) > (double) Math.Pow(10d, -14)) {
                    x0 = x1;
                    x1 = x0 - f(x0) / fDerivat(x0);
                }
                Console.WriteLine((j++) + ". " + "x1 = " + x1 + "  f(x1) = " + f(x1));
            }
            Console.WriteLine("\n/*----------------- Metoda Netwon -----------------*/");
        }

    }
}
