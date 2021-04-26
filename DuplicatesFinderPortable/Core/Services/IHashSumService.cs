namespace DuplicatesFinderPortable.Core.Services
{
    public interface IHashSumService
    {
        string ComputeCheckSum(string path);
    }
}
