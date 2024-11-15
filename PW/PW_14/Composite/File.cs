using System;

namespace PW_14.Composite
{
    internal class File : FileSystemItem
    {
        public File(string name, string fullPath)
        {
            Name = name;
            FullPath = fullPath;
        }

        public override void Display(int depth) => Console.WriteLine($"{new string(' ', depth * 2)}Файл: {Name} ({FullPath})");

        public override void Add(FileSystemItem item) => throw new NotSupportedException("Нельзя добавить элемент в файл");

        public override void Remove(FileSystemItem item) => throw new NotSupportedException("Нельзя удалить элемент из файла");
    }
}
