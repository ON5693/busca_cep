using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IPC.Correios.Web
{
    public class CepSearch
    {
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Message { get; set; }

        public static CepSearch Busca(string cep)
        {

            var cepObj = new CepSearch();

            Regex reg = new Regex(@"^\\d*(\\-\\d+)?$");

            if (!reg.IsMatch(cep))
            {
                cepObj.Message = "Informe um CEP valido!";
                return cepObj;
            }

            var url = "https://viacep.com.br/ws/" + cep + "/json/?callback?";

            string json = string.Empty;
                        
            HttpWebResponse response;

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            JsonCepObject cepJson = json_serializer.Deserialize<JsonCepObject>(json);

            cepObj.CEP = cepJson.cep;
            cepObj.Estado = cepJson.uf;
            cepObj.Cidade = cepJson.localidade;
            cepObj.Bairro = cepJson.bairro;
            cepObj.Endereco = cepJson.logradouro;

            return cepObj;
        }
    }

    public class JsonCepObject
    {
        public string cep { get; set; }
        public string uf { get; set; }
        public string localidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
    }
}