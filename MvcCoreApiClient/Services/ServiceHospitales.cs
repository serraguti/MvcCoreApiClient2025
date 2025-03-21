using MvcCoreApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreApiClient.Services
{
    public class ServiceHospitales
    {
        //NECESITAMOS LA URL DE ACCESO AL SERVICIO, SOLO LA URL
        private string ApiUrl;
        //NECESITAMOS INDICAR A NUESTRO SERVICE QUE LEEMOS 
        //CODIGO JSON
        private MediaTypeWithQualityHeaderValue header;

        public ServiceHospitales()
        {
            this.ApiUrl = "https://apicorehospitalespaco.azurewebsites.net/";
            this.header = new MediaTypeWithQualityHeaderValue
                ("application/json");
        }

        //CREAMOS UN METODO ASINCRONO PARA LEER LOS HOSPITALES
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            //SE UTILIZA LA CLASE HttpClient PARA LAS PETICIONES 
            //AL SERVIDOR
            using (HttpClient client = new HttpClient())
            {
                //NECESITAMOS UNA PETICION
                string request = "api/hospitales";
                //INDICAMOS LA URL BASE PARA ACCEDER AL SERVICIO API
                client.BaseAddress = new Uri(this.ApiUrl);
                //COMO ES POSIBLE QUE SE CRUCEN PETICIONES ENTRE 
                //METODOS CON DISTINTAS INFORMACIONES, DEBEMOS 
                //LIMPIAR LOS HEADER COMO NORMA
                client.DefaultRequestHeaders.Clear();
                //CREAMOS UN NUEVO Header PARA INDICAR QUE 
                //LEEREMOS JSON
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //HACEMOS LA PETICION AL SERVICIO (GET) Y 
                //CAPTURAMOS LA RESPUESTA
                HttpResponseMessage response =
                    await client.GetAsync(request);
                //EN LA RESPUESTA, SE OFRECEN DISTINTOS STATUS CODE
                if (response.IsSuccessStatusCode)
                {
                    //DESCARGAMOS EL JSON COMO STRING
                    string json = await
                        response.Content.ReadAsStringAsync();
                    //UTILIZAMOS NEWTON PARA RECUPERAR LOS DATOS
                    //SERIALIZADOS DE JSON A List<Hospital>
                    List<Hospital> data =
                        JsonConvert.DeserializeObject<List<Hospital>>
                        (json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
