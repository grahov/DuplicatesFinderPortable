using DuplicatesFinderPortable.Core.Services;
using System.IO;

namespace DuplicatesFinderPortable.Services
{
    public class DirectorySearcher : IDirectorySearcher
    {
        public DirectoryInfo GetAll(string path)
        {
            return new DirectoryInfo(path);
        }
    }
}
