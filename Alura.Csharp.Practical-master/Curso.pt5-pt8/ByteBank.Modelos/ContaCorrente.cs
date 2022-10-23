using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Classe para representar uma Conta Corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente : IComparable
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; set; }
        public int ContadorTransferenciasNaoPermitidas { get; set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia"> Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero. </param>
        /// <param name="numero"> Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero. </param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if(numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary> Sacar o dinheiro da conta  </summary>
        /// <param name="valor"> Valor que deseja sacar </param>
        /// <exception cref="ArgumentException"> Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>. </exception>
        /// <exception cref="SaldoInsuficienteException"> Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/>. </exception>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor do saque menor que 0", nameof(valor));
            }

            if (Saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            
            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor de tranferência menor que 0", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Não foi possível executar a operação de Tranferir", ex);
            }

            contaDestino.Depositar(valor);
        }

        public override string ToString()
        {
            return $"Número {Numero}, Agência {Agencia}, Saldo {Saldo}";
        }

        public override bool Equals(object obj)
        {
            var outraConta = obj as ContaCorrente;

            if (obj == null)
            {
                return false;
            }

            return Agencia == outraConta.Agencia && Numero == outraConta.Numero;
        }

        public int CompareTo(object obj)
        {
            // Retornar negativo quando a instância precede o obj
            // Retornar zero quando nossa instância e obj forem equivalentes;
            // Retornar positivo diferente de zero quando a precedência for de obj;

            var outraConta = obj as ContaCorrente;

            if (outraConta == null)
            {
                return -1;
            }

            if (Numero < outraConta.Numero)
            {
                return -1;
            }

            if (Numero == outraConta.Numero)
            {
                return 0;
            }

            return 1;
        }
    }
}
