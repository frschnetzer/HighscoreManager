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
            // Get the csv from the Forms/bin/debug/.net6.0-windows/Highscores.txt
            string currentDirectory = Directory.GetCurrentDirectory();
            string relativePath = Path.Combine("Highscores.txt");
            string filePath = Path.Combine(currentDirectory, relativePath);

            return filePath;
        }

        public override void Dispose()
        {
            highscoreList?.Clear();
        }
    }
}