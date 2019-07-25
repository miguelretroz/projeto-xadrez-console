using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, TabuleiroCod tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
