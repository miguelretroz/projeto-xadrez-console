

namespace Tabuleiro
{
    class TabuleiroCod
    {
        private Peca[,] Pecas;
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public TabuleiroCod(int linha, int coluna, Peca[,] pecas)
        {            
            Linha = linha;
            Coluna = coluna;
            Pecas = new Peca[Linha, Coluna];
        }
    }
}
