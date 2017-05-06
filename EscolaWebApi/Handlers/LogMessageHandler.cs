using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EscolaWebApi.Handlers
{
    public class LogMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine(request);

            // Invoca o próximo MessageHandler. 
            var response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine(response);

            return response;
        }
    }
}