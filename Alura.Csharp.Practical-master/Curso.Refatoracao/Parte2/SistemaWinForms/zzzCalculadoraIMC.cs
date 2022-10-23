using System;
using System.Collections;
using System.Collections.Generic;

namespace DuplicateObservedData
{
    interface ICalculadoraObserver
    {
        void ResultadoIMC(double imc);
    }

    internal class CalculadoraIMC
    {
        private IList<ICalculadoraObserver> observadores = new List<ICalculadoraObserver>();

        public void Adiciona(ICalculadoraObserver observador)
        {
            observadores.Add(observador);
        }

        public void Remove(ICalculadoraObserver observador)
        {
            observadores.Remove(observador);
        }

        public void Calcular(double altura, double peso)
        {
            if (altura == 0 || peso == 0)
            {
                throw new ArgumentOutOfRangeException("Altura ou peso inválidos!");
            }

            double imc = peso / (Math.Pow(altura, 2));
            foreach (var observador in observadores)
            {
                observador.ResultadoIMC(imc);
            }
        }
    }
}