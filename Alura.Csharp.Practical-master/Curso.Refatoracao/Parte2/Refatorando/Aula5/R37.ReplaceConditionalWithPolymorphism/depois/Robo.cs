using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R37.ReplaceConditionalWithPolymorphism.depois
{
    class Pograma
    {
        void Main()
        {
            var r2d2 = new R2D2(10, 5, 0, false, 20);
            var wally = new Wally(20, 25, 10, false, 5);
            var baymax = new Baymax(90, 170, 0, true, 40);

            Console.WriteLine($"Velocidade do r2d2: {r2d2.GetVelocidade()}");
            Console.WriteLine($"Velocidade do wally: {wally.GetVelocidade()}");
            Console.WriteLine($"Velocidade do baymax: {baymax.GetVelocidade()}");
        }
    }

    public abstract class Robo
    {
        private readonly int tipo;
        private readonly double velocidadePadrao = 12.43;
        private readonly double capacidadeDeCarga = 1.67;
        protected readonly int numeroDeBlocos = 34;
        protected readonly bool comArmadura = false;
        protected readonly double potencia;

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

        public abstract double GetVelocidade();
    }

    class R2D2 : Robo
    {
        public R2D2(double velocidadePadrao, double capacidadeDeCarga, int numeroDeBlocos, bool comArmadura, double potencia) 
            : base(0, velocidadePadrao, capacidadeDeCarga, numeroDeBlocos, comArmadura, potencia)
        {
        }

        public override double GetVelocidade()
        {
            return GetVelocidadePadrao();
        }
    }

    class Wally : Robo
    {
        public Wally(double velocidadePadrao, double capacidadeDeCarga, int numeroDeBlocos, bool comArmadura, double potencia) 
            : base(1, velocidadePadrao, capacidadeDeCarga, numeroDeBlocos, comArmadura, potencia)
        {
        }

        public override double GetVelocidade()
        {
            return GetVelocidadePadrao() - GetCapacidadeDeCarga() * numeroDeBlocos;
        }
    }

    class Baymax : Robo
    {
        public Baymax(double velocidadePadrao, double capacidadeDeCarga, int numeroDeBlocos, bool comArmadura, double potencia) 
            : base(2, velocidadePadrao, capacidadeDeCarga, numeroDeBlocos, comArmadura, potencia)
        {
        }

        public override double GetVelocidade()
        {
            return comArmadura ? 0 : GetVelocidadePadrao(potencia);
        }
    }
}
