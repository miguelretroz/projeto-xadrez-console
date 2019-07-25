using System;
using Tabuleiro;

namespace XadrezConsole
{
    class Tela
    {
        public static void ImprimirTabuleiro(TabuleiroCod tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    if (tabuleiro.Peca(i, j) == null)
                        Console.Write("- ");
                    else
                    Console.Write( tabuleiro.Peca(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
