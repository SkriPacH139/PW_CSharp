using System;
using System.Collections.Generic;

namespace PW_14.Composite
{
    internal class Directory : FileSystemItem
    {
        private List<FileSystemItem> _items = new List<FileSystemItem>();

        public Directory(string name, string fullPath)
        {
            Name = name;
            FullPath = fullPath;
        }

        public override void Display(int depth)
        {            
            if (this is Directory)
            {
                Console.WriteLine(); 
            }

            Console.WriteLine($"{new string(' ', depth * 2)}Папка: {Name} ({FullPath})");
            
            foreach (var item in _items)
            {
                item.Display(depth + 1);
            }

        }

        public override void Add(FileSystemItem item) => _items.Add(item);

        public override void Remove(FileSystemItem item) => _items.Remove(item);
    }
}
