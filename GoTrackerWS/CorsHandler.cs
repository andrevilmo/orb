﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GoTrackerWS
{
    public class CorsHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isPreflightRequest = request.Method == HttpMethod.Options;
            bool isCorsRequest = request.Headers.Contains(Origin);
            if (isCorsRequest)
            {
                if (isPreflightRequest)
                {
                    return Task.Factory.StartNew<HttpResponseMessage>(() =>
                    {
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());

                        string accessControlRequestMethod = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                        if (accessControlRequestMethod != null)
                        {
                            response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod);
                        }

                        string requestedHeaders = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
                        if (!string.IsNullOrEmpty(requestedHeaders))
                        {
                            response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
                        }

                        return response;
                    }, cancellationToken);
                }
            }
        }
    }
}