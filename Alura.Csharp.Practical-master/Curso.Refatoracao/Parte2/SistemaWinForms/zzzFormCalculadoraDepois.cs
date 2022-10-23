using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateObservedData
{
    public partial class FormCalculadoraDepois : Form, ICalculadoraObserver
    {
        private readonly CalculadoraIMC calculadora;
            
        public FormCalculadoraDepois()
        {
            InitializeComponent();
            calculadora = new CalculadoraIMC();
            calculadora.Adiciona(this);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double.TryParse(txtAltura.Text, out double altura);
            double.TryParse(txtPeso.Text, out double peso);

            try
            {
                calculadora.Calcular(altura, peso);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void ResultadoIMC(double imc)
        {
            txtIMC.Text = $"{imc:0.00}";
        }
    }
}
