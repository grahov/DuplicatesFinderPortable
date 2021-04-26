using System.IO;

namespace DuplicatesFinderPortable.Core.Services
{
    public interface IDirectorySearcher
    {
        DirectoryInfo GetAll(string path);
    }
}
