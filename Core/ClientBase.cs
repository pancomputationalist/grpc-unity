namespace Grpc.Core
{
    public abstract class ClientBase
    {
        private Channel channel;
        private CallInvoker callInvoker;

        public ClientBase(Channel channel)
        {
            this.channel = channel;
        }

        protected CallInvoker CallInvoker
        {
            get { return callInvoker; }
        }
    }
}
