namespace DuplicatesFinderPortable.Core
{
    public class FileInforamtion
    {
        public string FileName { get; set; }
        public string Hash { get; set; }

        public FileInforamtion(string name, string hash)
        {
            FileName = name;
            Hash = hash;
        }
    }
}
