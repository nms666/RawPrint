using System.IO;

namespace RawPrint
{
    public interface IPrinter
    {
        void PrintRawFile(string printer, string path, string documentName);
        void PrintRawFile(string printer, string path);
        void PrintRawStream(string printer, Stream stream, string documentName);
    }
}