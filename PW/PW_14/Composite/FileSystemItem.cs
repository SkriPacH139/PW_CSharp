namespace PW_14.Composite
{
    internal abstract class FileSystemItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }

        public abstract void Display(int depth);
        public abstract void Add(FileSystemItem item);
        public abstract void Remove(FileSystemItem item);
    }
}
