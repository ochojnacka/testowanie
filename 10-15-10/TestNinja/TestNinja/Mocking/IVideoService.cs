namespace TestNinja.Mocking
{
    public interface IVideoService
    {
        VideoService Object { get; }

        string GetUnprocessedVideosAsCsv();
        string ReadVideoTitle();
    }
}