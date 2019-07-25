

namespace Tabuleiro
{
    class TabuleiroCod
    {
        //Private para evitar que sejam cometidos erros com a matriz
        private Peca[,] Pecas;
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public TabuleiroCod(int linha, int coluna)
        {            
            Linha = linha;
            Coluna = coluna;
            Pecas = new Peca[Linha, Coluna];
        }
        //Método para acessar uma peça individual da matriz
        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao posicao)
        {
            Pecas[posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }
    }
}
