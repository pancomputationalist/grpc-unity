using HttpTwo;
using System;

namespace Grpc.Core
{
    public class Channel
    {
        public Uri Host { get; private set; }

        public Channel(string host, ChannelCredential credential)
        {
            Host = new Uri("http://" + host);
        }

        public Http2Client client
        {
            get
            {
                return new Http2Client(Host);
            }
        }
    }
}
