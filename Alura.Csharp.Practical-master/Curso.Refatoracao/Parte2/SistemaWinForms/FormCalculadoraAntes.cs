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
    public partial class FormCalculadoraAntes : Form
    {
        public FormCalculadoraAntes()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double.TryParse(txtAltura.Text, out double altura);
            double.TryParse(txtPeso.Text, out double peso);

            if (altura == 0 || peso == 0)
            {
                MessageBox.Show("Altura ou peso inválidos!");
                return;
            }

            double imc = peso / (Math.Pow(altura, 2));
            txtIMC.Text = $"IMC calculado: {imc:0.00}";
        }
    }
}
