using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R31.ReplaceSubclassWithFields.antes
{
    class Programa
    {
        void Main()
        {
            var fabrica = new Fabrica();
            fabrica.Fabricar();
        }
    }

    abstract class Microondas
    {
        public abstract int GetVoltagem();
    }

    class Microondas110 : Microondas
    {
        public override int GetVoltagem()
        {
            return 110;
        }
    }

    class Microondas220 : Microondas
    {
        public override int GetVoltagem()
        {
            return 220;
        }
    }

    class Fabrica
    {
        public void Fabricar()
        {
            var aparelho1 = new Microondas220();
            var aparelho2 = new Microondas110();

            Fabricar(aparelho1);
            Fabricar(aparelho2);
        }

        public void Fabricar(Microondas microondas)
        {
            //código para fabricar equipamento...
        }
    }
}
