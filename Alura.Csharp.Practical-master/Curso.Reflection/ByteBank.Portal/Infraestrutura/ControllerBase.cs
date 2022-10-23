using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public abstract class ControllerBase
    {
        protected string View([CallerMemberName] string nomeArquivo = default)
        {
            var type = GetType();
            var diretorioNome = type.Name.Replace("Controller", string.Empty);

            var nomeCompletoResource = $"ByteBank.Portal.View.{diretorioNome}.{nomeArquivo}.html";
            var assembly = Assembly.GetExecutingAssembly();

            var streamRecurso = assembly.GetManifestResourceStream(nomeCompletoResource);

            var streamLeitura = new StreamReader(streamRecurso);
            var textoPagina = streamLeitura.ReadToEnd();

            return textoPagina;
        }

        protected string View(object modelo, [CallerMemberName]string nomeArquivo = null)
        {
            var todasAsPropriedadesDoModelo = modelo.GetType().GetProperties();
            var viewBruta = View(nomeArquivo);

            var regex = new Regex("\\{{(?<props>.*?)\\}}");

            var viewProcessada = regex.Replace(viewBruta, (match) =>
            {
                var nomePropriedade = match.Groups["props"].Value;
                var propriedade = todasAsPropriedadesDoModelo.Single(prop => prop.Name == nomePropriedade);

                var valorBruto = propriedade.GetValue(modelo);
                return valorBruto?.ToString();
            });

            return viewProcessada;
        }
    }
}
