namespace Grpc.Core
{
    public enum MethodType
    {
        /// <summary>Single request sent from client, single response received from server.</summary>
        Unary,

        /// <summary>Stream of request sent from client, single response received from server.</summary>
        ClientStreaming,

        /// <summary>Single request sent from client, stream of responses received from server.</summary>
        ServerStreaming,

        /// <summary>Both server and client can stream arbitrary number of requests and responses simultaneously.</summary>
        DuplexStreaming
    }

    public class Method<TRequest, TResponse>
    {
        readonly MethodType type;
        readonly string serviceName;
        readonly string name;
        readonly Marshaller<TRequest> requestMarshaller;
        readonly Marshaller<TResponse> responseMarshaller;
        readonly string fullName;

        public Method(MethodType type, string serviceName, string name, Marshaller<TRequest> requestMarshaller, Marshaller<TResponse> responseMarshaller)
        {
            this.type = type;
            this.serviceName = serviceName;
            this.name = name;
            this.requestMarshaller = requestMarshaller;
            this.responseMarshaller = responseMarshaller;
            fullName = GetFullName(serviceName, name);
        }

        /// <summary>
        /// Gets the type of the method.
        /// </summary>
        public MethodType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Gets the name of the service to which this method belongs.
        /// </summary>
        public string ServiceName
        {
            get
            {
                return serviceName;
            }
        }

        /// <summary>
        /// Gets the unqualified name of the method.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the marshaller used for request messages.
        /// </summary>
        public Marshaller<TRequest> RequestMarshaller
        {
            get
            {
                return requestMarshaller;
            }
        }

        /// <summary>
        /// Gets the marshaller used for response messages.
        /// </summary>
        public Marshaller<TResponse> ResponseMarshaller
        {
            get
            {
                return responseMarshaller;
            }
        }

        /// <summary>
        /// Gets the fully qualified name of the method. On the server side, methods are dispatched
        /// based on this name.
        /// </summary>
        public string FullName
        {
            get
            {
                return fullName;
            }
        }

        /// <summary>
        /// Gets full name of the method including the service name.
        /// </summary>
        internal static string GetFullName(string serviceName, string methodName)
        {
            return "/" + serviceName + "/" + methodName;
        }
    }
}
