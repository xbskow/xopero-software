using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strona464
{
    class Excuse
    {
        public string Description { get; set; }
        public string Results { get; set; }
        public string ExcusePath { get; set; }
        public DateTime LastUsed { get; set; }

        public Excuse()
        {
            ExcusePath = "";
        }
        public Excuse(string excusePath)
        {
            OpenFile(excusePath);
        }

        public Excuse(Random random, string folder)
        {
            string[] filenames = Directory.GetFiles(folder, "*.txt");
            OpenFile(filenames[random.Next(filenames.Length)]);
        }

        private void OpenFile(string excusePath)
        {
            this.ExcusePath = excusePath;
            using (StreamReader file = new StreamReader(excusePath))
            {
                Description = file.ReadLine();
                Results = file.ReadLine();
                LastUsed = Convert.ToDateTime(file.ReadLine());
            }
        }

        public void Save(string path)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(Description);
                file.WriteLine(Results);
                file.WriteLine(LastUsed);
            }
        }

    }
}
