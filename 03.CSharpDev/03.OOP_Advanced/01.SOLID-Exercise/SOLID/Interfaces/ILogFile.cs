namespace SOLID.Interfaces
{
    public interface ILogFile
    {
        string Path { get; }

        long Size { get; }

        void Write(string reportLog);
    }
}