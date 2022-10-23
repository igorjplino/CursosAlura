using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R31.ReplaceSubclassWithFields.depois
{
    class Programa
    {
        void Main()
        {
            var fabrica = new Fabrica();
            fabrica.Fabricar();
        }
    }

    class Microondas
    {
        readonly int voltagem;
        public int GetVoltagem()
        {
            return voltagem;
        }

        private Microondas(int voltagem)
        {
            this.voltagem = voltagem;
        }

        public static Microondas CriarMicroondas110()
        {
            return new Microondas(110);
        }

        public static Microondas CriarMicroondas220()
        {
            return new Microondas(220);
        }

    }

    class Fabrica
    {
        public void Fabricar()
        {
            var aparelho1 = Microondas.CriarMicroondas220();
            var aparelho2 = Microondas.CriarMicroondas110();

            Fabricar(aparelho1);
            Fabricar(aparelho2);
        }

        public void Fabricar(Microondas microondas)
        {
            //código para fabricar equipamento...
        }
    }
}
