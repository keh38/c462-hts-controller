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
    public class FilenamePayload
    {
        public string Filename { get; set; }
    }

    [JsonObject]
    public class TransferFilePayload
    {
        public string Folder { get; set; }
        public string Filename { get; set; }
        public string Content { get; set; }
    }

    [JsonObject]
    public class FileInformationPayload
    {
        public string Filename { get; set; }
        public System.DateTime LastModified { get; set; }
    }

    [JsonObject]
    public class BufferedFilePayload
    {
        public string Filename { get; set; }
        public long NumBuffers { get; set; }
        public int BufferSize { get; set; }
    }

    [JsonObject]
    public class HtsEndpointPayload
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }

}
