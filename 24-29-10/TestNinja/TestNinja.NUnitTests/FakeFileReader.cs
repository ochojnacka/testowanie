using TestNinja.Mocking;

namespace TestNinja.NUnitTests
{
    internal class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
