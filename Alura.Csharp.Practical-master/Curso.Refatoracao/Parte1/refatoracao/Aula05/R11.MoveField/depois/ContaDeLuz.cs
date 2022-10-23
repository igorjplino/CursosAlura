using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R11.MoveField.depois
{
    class ContaDeLuz
    {
        private TipoDeConta tipoDeConta;
        public TipoDeConta TipoDeConta
        {
            get { return tipoDeConta; }
        }

        public ContaDeLuz(TipoDeConta tipoDeConta)
        {
            this.tipoDeConta = tipoDeConta;
        }

        public decimal CalcularValorDosJuros(decimal principal, int diasAtraso)
        {
            decimal jurosAoDia = tipoDeConta.JurosAoMes / 30.0M;
            decimal juros = jurosAoDia * diasAtraso;
            return juros * principal;
        }
    }
    
    abstract class TipoDeConta
    {
        protected decimal jurosAoMes;
        public decimal JurosAoMes
        {
            get { return jurosAoMes; }
        }
    }

    class ContaResidencial : TipoDeConta
    {
        public ContaResidencial()
        {
            this.jurosAoMes = .030M;
        }
    }


    class ContaComercial : TipoDeConta
    {
        public ContaComercial()
        {
            this.jurosAoMes = .060M;
        }
    }
}

