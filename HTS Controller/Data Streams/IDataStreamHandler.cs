using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDataStreamHandler
{
    Task<bool> StartDataStreamsAsync(string filename);
    Task<bool> StartDataStreamsAsync(string filename, string playerName);
    Task StopDataStreamsAsync();
    List<string> GetProblemStreams();
}
