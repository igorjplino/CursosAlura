using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace csharp73.Aula4
{
    [Serializable]
    public class FormularioCadastro
    {
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        /// Na 7.3 essa funcionalidade é possível indicar a quem o atributo está se referindo 
        /// e o 'field' diz ao compilador que o atributo está se referindo ao Backfield e não a propriedade
        [field: NonSerialized]
        public string Senha { get; set; }

        /// Antes da versão 7.3, não era possível adicionar um atributo a uma propriedade
        /// somente na sua Backfield
        //[NonSerialized]
        //private string _senha;
        //public string Senha
        //{
        //    get
        //    {
        //        return _senha;
        //    }
        //    set
        //    {
        //        _senha = value;
        //    }
        //}
    }

    public static class BackfieldAttribute
    {
        public static void Testa()
        {
            var novoCadastro = new FormularioCadastro
            {
                Nome = "Igor",
                Email = "igor@email.com",
                Senha = "senha complexa"
            };

            using (var arquivo = File.Create("cadastro.bin"))
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(arquivo, novoCadastro);
            }
        }
    }
}
