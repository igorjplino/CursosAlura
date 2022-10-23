using System;
using System.Collections.Generic;
using System.Text;

namespace refatoracao.R12.ExtractClass.depois
{
    class Empresa
    {
        public Empresa(string razaoSocial, string cNPJ, string endEntregaLogradouro, string endEntregaNumero, string endEntregaComplemento, string endEntregaBairro, string endEntregaCEP, string endEntregaMunicipio, string endEntregaUF, string endComercialLogradouro, string endComercialNumero, string endComercialComplemento, string endComercialBairro, string endComercialCEP, string endComercialMunicipio, string endComercialUF)
        {
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;
            EndEntrega = new Endereco(endEntregaLogradouro, endEntregaNumero, endEntregaComplemento, endEntregaBairro, endEntregaCEP, endEntregaMunicipio, endEntregaUF);
            EndComercial = new Endereco(endComercialLogradouro, endComercialNumero, endComercialComplemento, endComercialBairro, endComercialCEP, endComercialMunicipio, endComercialUF);
        }

        public string RazaoSocial { get; private set; }
        public string CNPJ { get; private set; }

        public Endereco EndEntrega { get; private set; }

        public Endereco EndComercial { get; private set; }

        public string GetTextoEnderecoComercial()
        {
            return EndComercial.GetTexto();
        }

        public string GetTextoEnderecoEntrega()
        {
            return EndEntrega.GetTexto();
        }

        public void UpdateEnderecoEntrega(string endEntregaLogradouro, string endEntregaNumero, string endEntregaComplemento, string endEntregaBairro, string endEntregaCEP, string endEntregaMunicipio, string endEntregaUF)
        {
            EndEntrega.Update(endEntregaLogradouro, endEntregaNumero, endEntregaComplemento, endEntregaBairro, endEntregaCEP, endEntregaMunicipio, endEntregaUF);
        }

        public void UpdateEnderecoComercial(string endComercialLogradouro, string endComercialNumero, string endComercialComplemento, string endComercialBairro, string endComercialCEP, string endComercialMunicipio, string endComercialUF)
        {
            EndComercial.Update(endComercialLogradouro, endComercialNumero, endComercialComplemento, endComercialBairro, endComercialCEP, endComercialMunicipio, endComercialUF);
        }
    }

    class Endereco
    {
        public Endereco(string logradouro, string numero, string complemento, string bairro, string cEP, string municipio, string uF)
        {
            Update(logradouro, numero, complemento, bairro, cEP, municipio, uF);
        }

        public void Update(string logradouro, string numero, string complemento, string bairro, string cEP, string municipio, string uF)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cEP;
            Municipio = municipio;
            UF = uF;
        }

        public string GetTexto()
        {
            return $"Endereço: {Logradouro} {Numero} {Complemento} - {Bairro} - CEP {CEP} - {Municipio} - {UF}";
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Municipio { get; private set; }
        public string UF { get; private set; }
    }
}
