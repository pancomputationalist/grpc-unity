
using HttpTwo;
using System;
using System.Collections.Specialized;
using System.Net;

namespace Grpc.Core
{
    public abstract class CallInvoker
    {
        readonly Channel channel;

        public TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request) 
            where TResponse : class
        {
            Http2Client client = channel.client;
            byte[] serialized = method.RequestMarshaller.Serializer(request);

            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ContentTypeKey, Constants.ContentTypeVal);
            header.Add(Constants.UserAgentKey, Constants.UserAgentVal);

            var response = client.Post(new Uri(channel.Host, method.ServiceName), header, serialized);
            if (response.Status != HttpStatusCode.OK)
            {
                return null;
            }

            return method.ResponseMarshaller.Deserializer(response.Body);
        }
    }
}
