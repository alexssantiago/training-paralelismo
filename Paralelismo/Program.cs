using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Paralelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int qtde = 1000000;

                string tempoProcessamentoNormal = ProcessamentoNormal(qtde);
                string tempoProcessamentoParalelo = ProcessamentoParalelo(qtde);

                Console.WriteLine($"Tempo Processamento Normal: {tempoProcessamentoNormal}");
                Console.WriteLine($"Tempo Processamento Paralelo: {tempoProcessamentoParalelo}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.ReadKey();
        }

        private static string ProcessamentoNormal(int qtde)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < qtde; i++)
            {
                Console.WriteLine($"Escrevendo a linha {i.ToString()}");
            }

            sw.Stop();

            return sw.Elapsed.ToString();
        }

        private static string ProcessamentoParalelo(int qtde)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, qtde, index => { Console.WriteLine($"Escrevendo a linha {index.ToString()}"); });

            sw.Stop();

            return sw.Elapsed.ToString();
        }

    }
}
