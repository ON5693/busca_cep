using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IPC.Correios.Web
{
    public class AddressSearch
    {
        public string CEP { get; set; }
        public string Codigo { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Message { get; set; }


        public static AddressSearch Busca(string uf, string city, string ad)
        {
            var cepObj = new AddressSearch();

            var url = "https://viacep.com.br/ws/" + uf + "/" + city + "/" + ad + "/json/?callback?";

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
                var cepJson = json_serializer.Deserialize<List<JsonAddressObject>>(json);
            
            if (cepJson.Count > 1)
            {

                cepObj.Message = "Por Favor digitar o nome do logradouro completo";

                return cepObj;
            }

            cepObj.CEP = cepJson[0].cep;
            cepObj.Cidade = cepJson[0].localidade;
            cepObj.Codigo = cepJson[0].ibge;
            cepObj.Logradouro = cepJson[0].logradouro;

            return cepObj;
            
        }
    }

    public class JsonAddressObject
    {
        public string cep { get; set; }
        public string localidade { get; set; }
        public string ibge { get; set; }
        public string logradouro { get; set; }
    }
}