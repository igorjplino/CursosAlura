using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R37.ReplaceConditionalWithPolymorphism.antes
{
    class Pograma
    {
        void Main()
        {
            var r2d2 = new Robo(0, 10, 5, 0, false, 20);
            var wally = new Robo(1, 20, 25, 10, false, 5);
            var baymax = new Robo(2, 90, 170, 0, true, 40);

            Console.WriteLine($"Velocidade do r2d2: {r2d2.GetVelocidade()}");
            Console.WriteLine($"Velocidade do wally: {wally.GetVelocidade()}");
            Console.WriteLine($"Velocidade do baymax: {baymax.GetVelocidade()}");
        }
    }

    public class Robo
    {
        private readonly int tipo;
        private readonly double velocidadePadrao = 12.43;
        private readonly double capacidadeDeCarga = 1.67;
        private readonly int numeroDeBlocos = 34;
        private readonly bool comArmadura = false;
        private readonly double potencia;

        private const int R2D2 = 0;
        private const int WALLY = 1;
        private const int BAYMAX = 2;

        public Robo(int tipo, double velocidadePadrao, double capacidadeDeCarga, int numeroDeBlocos, bool comArmadura, double potencia)
        {
            this.tipo = tipo;
            this.velocidadePadrao = velocidadePadrao;
            this.capacidadeDeCarga = capacidadeDeCarga;
            this.numeroDeBlocos = numeroDeBlocos;
            this.comArmadura = comArmadura;
            this.potencia = potencia;
        }

        public double GetCapacidadeDeCarga()
        {
            return capacidadeDeCarga;
        }

        public double GetVelocidadePadrao()
        {
            return GetVelocidadePadrao(1);
        }

        public double GetVelocidadePadrao(double potencia)
        {
            return velocidadePadrao * potencia;
        }

        public double GetVelocidade()
        {
            switch (tipo)
            {
                case R2D2:
                    return GetVelocidadePadrao();
                case WALLY:
                    return GetVelocidadePadrao() - GetCapacidadeDeCarga() * numeroDeBlocos;
                case BAYMAX:
                    return comArmadura ? 0 : GetVelocidadePadrao(potencia);
                default:
                    throw new Exception("Tipo não identificado");
            }
        }
    }
}
