using DuplicatesFinderPortable.Core;
using DuplicatesFinderPortable.Core.Services;
using DuplicatesFinderPortable.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DuplicatesFinderPortable
{
    internal class Program
    {
        private static readonly IDialogService _dialogService = new DialogService();
        private static readonly IDirectorySearcher _directorySearcher = new DirectorySearcher();
        private static readonly IHashSumService _hashSumService = new HashSumService();
        private static DirectoryInfo _currentDirectory;
        private static readonly List<FileInforamtion> _listFiles = new List<FileInforamtion>();
        private static string _path;

        private static void Main(string[] args)
        {
            Console.WriteLine("Поиск дубликатов файлов.");

            GetDirectory();

            Console.WriteLine("Подождите, выполнятеся поиск...");

            _currentDirectory = _directorySearcher.GetAll(_path);

            foreach (FileInfo PathFile in _currentDirectory.GetFiles("*"))
            {
                _listFiles.Add(new FileInforamtion(PathFile.Name, _hashSumService.ComputeCheckSum(PathFile.FullName)));
            }

            List<string> _duplicateHash = _listFiles.GroupBy(x => x.Hash).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

            if (_duplicateHash == null)
            {
                _dialogService.Info("Дубликаты не найдены.");
                return;
            }

            Console.WriteLine();

            _dialogService.Info($"Обнаружено дубликатов: {_duplicateHash.Count}.");

            Console.WriteLine();

            foreach (string row in _duplicateHash)
            {
                foreach (FileInforamtion item in _listFiles)
                {
                    if (item.Hash == row)
                    {
                        Console.WriteLine("\t\t [*] " + item.FileName + " \t\tHASH: " + item.Hash);
                    }
                }
            }
            Console.ReadKey();
        }

        private static void GetDirectory()
        {
            _dialogService.Info("Путь поиска: ");
            _path = Console.ReadLine();
        }
    }
}
