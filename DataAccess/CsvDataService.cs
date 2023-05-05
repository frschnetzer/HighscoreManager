using Core;
using CsvHelper;
using Domain;
using System.Globalization;

namespace DataAccess
{
    public class CsvDataService : HighscoreService
    {
        public static List<HighscoreModel> highscoreList = new();

        public override void Save(HighscoreModel item)
        {
            // validating
            base.Save(item);
            
            highscoreList.Add(item);

            // writing to the csv file
            using var writer = new StreamWriter(getFilePath());
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(highscoreList);
        }
        public override List<HighscoreModel> GetAll()
        {
            highscoreList.Clear();
            
            using var reader = new StreamReader(getFilePath());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            highscoreList.AddRange(csv.GetRecords<HighscoreModel>());

            return highscoreList;
        }

        public string getFilePath()
        {
            string fileName = "Highscores.txt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);
            return filePath;
        }

        public override void Dispose()
        {
            highscoreList?.Clear();
        }
    }
}