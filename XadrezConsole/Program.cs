using System;
using Tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TabuleiroCod tabuleiro = new TabuleiroCod(8, 8);

            Tela.ImprimirTabuleiro(tabuleiro);
        }
    }
}
