using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, TabuleiroCod tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
