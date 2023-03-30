using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MELDv2.FileWorkers
{
    internal class FolderScaner
    {
        private string Path { get; set; }
        List<string> filesList = new List<string>();
        public FolderScaner(string folderPath) 
        {
            Path = folderPath;
            Scan();
        }
        private void Scan() 
        {
            var arr = Directory.GetFiles(Path);
            foreach (var item in arr)
            {
                filesList.Add(item);
            }
        }
        public IEnumerable<string> GetFileNames() 
        {
            foreach (var item in filesList)
            {
                yield return item.Split('\\')[item.Split('\\').Length - 1];
            }
        }
        public string GetPathAtIndexOf(int index) 
        {
            return filesList[index];
        }
    }
}
