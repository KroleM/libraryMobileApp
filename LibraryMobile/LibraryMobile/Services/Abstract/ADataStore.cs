using LibraryMobile.Service.Reference;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryMobile.Services.Abstract
{
    public abstract class ADataStore
    {
        protected readonly LibraryService _service;
        protected ADataStore()
        {
            //Use this code to test locally - localhost does not have SSL certificate
            var handler = new HttpClientHandler();
#if DEBUG
            //ręczne ustawienie certyfikatu
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);
            //adres lokalny do Swaggera z KrupniokDeliveryAPI (RestAPI)
            _service = new LibraryService("https://localhost:7119/", client);
        }
    }
}
