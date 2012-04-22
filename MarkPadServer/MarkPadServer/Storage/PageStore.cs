namespace MarkPadServer.Storage
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PageStore
    {
        private readonly string directory;

        public PageStore(string directory)
        {
            if(!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException("Could not find store location: " + directory);
            }
            this.directory = directory;
        }

        public IEnumerable<string> GetFilesList()
        {
            return Directory.GetFiles(this.directory, "*.md").Select(Path.GetFileNameWithoutExtension);
        }

        public void Add(string name, string fileContent)
        {
            var fileName = name + ".md";
            using(var writer = File.CreateText(Path.Combine(this.directory, fileName)))
            {
                writer.Write(fileContent);
            }
        }

        public string GetContent(string name)
        {
            return File.ReadAllText(Path.Combine(this.directory, name + ".md")) ;
        }
    }
}