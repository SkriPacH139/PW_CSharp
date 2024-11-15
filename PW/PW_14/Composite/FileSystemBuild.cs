using System;
using System.IO;

namespace PW_14.Composite
{
    internal class FileSystemBuilder
    {
        public Directory BuildFileSystemTree(string path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                Directory dirItem = new Directory(dirInfo.Name, dirInfo.FullName);

                foreach (FileInfo fileInfo in dirInfo.GetFiles())
                {
                    dirItem.Add(new File(fileInfo.Name, fileInfo.FullName));
                }

                foreach (DirectoryInfo subDirInfo in dirInfo.GetDirectories())
                {
                    Directory subDirItem = BuildFileSystemTree(subDirInfo.FullName); 
                    {
                        dirItem.Add(subDirItem);
                    }
                }

                return dirItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return null;
            }
        }
    }

}
