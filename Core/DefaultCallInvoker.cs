namespace Grpc.Core
{
    public class DefaultCallInvoker : CallInvoker
    {
        Channel channel;

        public DefaultCallInvoker(Channel channel)
        {
            this.channel = channel;
        }
    }
}
