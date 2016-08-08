using System.Text;

namespace Grpc.Core
{
    public class Marshaller<T>
    {
        public delegate byte[] SerializerType(T obj);
        public delegate T DeserializerType(byte[] data);

        readonly SerializerType serializer;
        readonly DeserializerType deserializer;

        /// <summary>
        /// Initializes a new marshaller.
        /// </summary>
        /// <param name="serializer">Function that will be used to serialize messages.</param>
        /// <param name="deserializer">Function that will be used to deserialize messages.</param>
        public Marshaller(SerializerType serializer, DeserializerType deserializer)
        {
            this.serializer = serializer;
            this.deserializer = deserializer;
        }

        /// <summary>
        /// Gets the serializer function.
        /// </summary>
        public SerializerType Serializer
        {
            get
            {
                return this.serializer;
            }
        }

        /// <summary>
        /// Gets the deserializer function.
        /// </summary>
        public DeserializerType Deserializer
        {
            get
            {
                return this.deserializer;
            }
        }
    }

    /// <summary>
    /// Utilities for creating marshallers.
    /// </summary>
    public static class Marshallers
    {
        /// <summary>
        /// Creates a marshaller from specified serializer and deserializer.
        /// </summary>
        public static Marshaller<T> Create<T>(Marshaller<T>.SerializerType serializer, Marshaller<T>.DeserializerType deserializer)
        {
            return new Marshaller<T>(serializer, deserializer);
        }

        /// <summary>
        /// Returns a marshaller for <c>string</c> type. This is useful for testing.
        /// </summary>
        public static Marshaller<string> StringMarshaller
        {
            get
            {
                return new Marshaller<string>(Encoding.UTF8.GetBytes,
                                              Encoding.UTF8.GetString);
            }
        }
    }
}
