using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultaCEP.Services.Model;
using Newtonsoft.Json;

namespace ConsultaCEP.Services
{
    public class ViaCEPService
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.Cep == null) return null;

            return end;
        }
    }
}
