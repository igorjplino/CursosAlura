using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWinForms
{
    public interface ICalculadoraObserver
    {
        void ResultadoIMC(double imc);
    }

    class CalculadoraIMC
    {
        IList<ICalculadoraObserver> observadores =
            new List<ICalculadoraObserver>();

        public void Adicionar(ICalculadoraObserver observador)
        {
            observadores.Add(observador);
        }

        public void Remover(ICalculadoraObserver observador)
        {
            observadores.Remove(observador);
        }

        public void Calcular(double altura, double peso)
        {
            if (altura == 0 || peso == 0)
            {
                throw new ArgumentException("Altura ou peso inválidos!");
            }

            double imc = peso / (Math.Pow(altura, 2));

            foreach (var observador in observadores)
            {
                observador.ResultadoIMC(imc);
            }
        }
    }
}
