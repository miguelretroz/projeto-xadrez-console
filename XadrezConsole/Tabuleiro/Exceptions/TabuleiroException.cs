using System;

namespace Tabuleiro
{
    class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string mensagem) : base(mensagem)
        {
        }
    }
}
