using Newtonsoft.Json;

namespace HTS.Tcp
{
    [JsonObject]
    public class ErrorPayload
    {
        public string Message { get; set; }
    }

    [JsonObject]
    public class RemoteMessagePayload
    {
        public string Target { get; set; }
        public string Data { get; set; }
    }

    [JsonObject]
    public class HtsEndpointPayload
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }

}
