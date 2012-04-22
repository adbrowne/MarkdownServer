namespace MarkPadServer.PageStore
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileSytemPageStore : IPageStore
    {
        private readonly string directory;

        public FileSytemPageStore(string directory)
        {
            if(!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException("Could not find store location: " + directory);
            }
            this.directory = directory;
        }

        public IEnumerable<string> ListPages()
        {
            return Directory.GetFiles(this.directory, "*.md").Select(Path.GetFileNameWithoutExtension);
        }

        public void Add(string name, string fileContent)
        {
            using(var writer = File.CreateText(this.GetFilePath(name)))
            {
                writer.Write(fileContent);
            }
        }

        public string GetPageContent(string name)
        {
            return File.ReadAllText(this.GetFilePath(name)) ;
        }

        private string GetFilePath(string name)
        {
            return Path.Combine(this.directory, GetFileName(name));
        }
        
        private static string GetFileName(string name)
        {
            return name + ".md";
        }
    }
}