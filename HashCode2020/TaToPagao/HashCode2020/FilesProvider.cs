using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using HashCode2020.Model;

namespace HashCode2020
{
    public class FilesProvider
    {
        #region Public Constructors

        /// <summary>
        /// Directory path and file names
        /// </summary>
        /// <param name="config"></param>
        public FilesProvider(Settings config)
        {
            _config = config;
        }

        #endregion Public Constructors

        #region Public Methods

        public List<FileInfo> GetFiles()
        {
            var pathFiles = Directory.GetFiles(_config.DataDirectory).Where(x => _config.FilesName.Any(f => x.EndsWith(f)));
            var files = pathFiles.Select(p => new FileInfo(p)).ToList();

            return files;
        }

        public Scheduler GetContentFile(FileInfo file)
        {
            StreamReader stream = file.OpenText();
            int id = 0;
            int rows = 0;

            // Read first line
            string[] firstLine = stream.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] bookScores = stream.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Scheduler scheduler = new Scheduler(Int32.Parse(firstLine[2]));


            //while (!stream.EndOfStream)
            //{
            //    string line = stream.ReadLine();
            //    if (line.Split(' ').Count() == 1)
            //    {
            //        rows = Convert.ToInt32(line);
            //        continue;
            //    }

            //    photos.Add(new Photo { Id = id++, Orientation = line.Split(' ')[0], Tags = new List<string>(line.Split(' ').Skip(2)) });
            //}

            //if (photos.Count != rows)
            //    throw new ApplicationException("el numero de elementos indicados en el fichero, no coincide con el numero de elementos recuperados");

            return scheduler;
        }

        public bool SaveFileOutput(List<Scheduler> schedulerList)
        {
            // TODO create output file

            //StringBuilder file = new StringBuilder();

            //file.AppendLine(simpleSlidesList.Count.ToString());

            //StringBuilder line = new StringBuilder();
            //foreach (SimpleSlide simpleSlide in simpleSlidesList)
            //{
            //    foreach (Photo photo in simpleSlide.Photos)
            //    {
            //        line.Append($"{photo.Id.ToString()} ");
            //    }

            //    file.AppendLine(line.ToString().TrimEnd());
            //    line.Clear();
            //}

            //File.WriteAllText(Path.Combine(_config.OutputDirectory, $"{DateTime.Now.ToLongTimeString().Replace(":", "_")}.txt"), file.ToString());

            return true;
        }

        #endregion Public Methods

        #region Private Fields

        private Settings _config;

        #endregion Private Fields
    }
}