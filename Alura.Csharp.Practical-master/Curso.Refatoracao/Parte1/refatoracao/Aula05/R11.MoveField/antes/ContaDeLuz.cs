using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R11.MoveField.antes
{
    class ContaDeLuz
    {
        private TipoDeConta tipoDeConta;
        public TipoDeConta TipoDeConta
        {
            get { return tipoDeConta; }
        }

        private decimal jurosAoMes;
        public decimal JurosAoMes
        {
            get { return jurosAoMes; }
            set { jurosAoMes = value; }
        }

        public ContaDeLuz(TipoDeConta tipoDeConta)
        {
            this.tipoDeConta = tipoDeConta;

            if (tipoDeConta is ContaResidencial)
            {
                this.jurosAoMes = .030M;
            }
            else
            {
                this.jurosAoMes = .060M;
            }
        }

        public decimal CalcularValorDosJuros(decimal principal, int diasAtraso)
        {
            decimal jurosAoDia = JurosAoMes / 30.0M;
            decimal juros = jurosAoDia * diasAtraso;
            return juros * principal;
        }
    }
    
    abstract class TipoDeConta
    {

    }

    class ContaResidencial : TipoDeConta
    {

    }


    class ContaComercial : TipoDeConta
    {

    }
}

