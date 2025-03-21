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

    }
}
