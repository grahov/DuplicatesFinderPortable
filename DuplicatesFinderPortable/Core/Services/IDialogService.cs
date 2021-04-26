namespace DuplicatesFinderPortable.Core.Services
{
    public interface IDialogService
    {
        void Ask(string message);
        void Warn(string message);
        void Info(string message);
    }
}
