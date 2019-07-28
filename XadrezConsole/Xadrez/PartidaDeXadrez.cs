using System;
using Tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public Cor JogadorAtual { get; private set; }
        public int Turno { get; private set; }
        public TabuleiroCod Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }


        public PartidaDeXadrez()
        {
            Tabuleiro = new TabuleiroCod(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
            Terminada = false;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);  
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if (Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiro.Peca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                aux.Add(x);
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tabuleiro));            

            ColocarNovaPeca('c', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 7, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preta, Tabuleiro));

        }
    }
}
