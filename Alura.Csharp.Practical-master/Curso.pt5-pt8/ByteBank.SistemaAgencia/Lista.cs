using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia
{
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao = 0;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
        }

        public void Adicionar(T item)
        {
            //Console.WriteLine($"Adicionando no índice {_proximaPosicao} conta {item.Agencia}/{item.Numero}");

            VerificarCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }

        public void Remover(T item)
        {
            var indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                var itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < (_proximaPosicao - 1); i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = default;
        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;
            //Console.WriteLine("Aumentando capacidade da lista!");

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            T[] novoArray = new T[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                //Console.WriteLine(".");
            }

            _itens = novoArray;
        }
    }
}
