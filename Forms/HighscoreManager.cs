using Core;
using DataAccess;
using Domain;

namespace Forms
{
    //TODO: Combobox in Gametitle implementieren
    public partial class HighscoreManager : Form
    {
        private IHighscoreService<HighscoreModel> dataService = new CsvDataService();

        public HighscoreManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataReload();
        }

        private void DataReload()
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.DataSource = this.dataService.GetAll();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            HighscoreModel model = new()
            {
                Username = this.textBoxUserName.Text,
                Gametitle = this.textBoxGametitle.Text,
                Highscore = this.textBoxHighscore.Text,
                Date = this.dateTimePicker.Value,
                Comment = this.textBoxUserName.Text
            };

            this.dataService.Save(model);

            DataReload();
        }
    }
}