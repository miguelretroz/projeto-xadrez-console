

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

        public Peca Peca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }

        public void ColocarPeca(Peca p, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linha || posicao.Coluna < 0 || posicao.Coluna >= Coluna)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
