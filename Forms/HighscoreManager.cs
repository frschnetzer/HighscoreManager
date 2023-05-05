using Core;
using DataAccess;
using Domain;
using System.Windows.Forms;

namespace Forms
{
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

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var gametitle = row.Cells["Gametitle"].Value.ToString();

                    if (!comboBox.Items.Contains(gametitle))
                    {
                        comboBox.Items.Add(gametitle);
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            HighscoreModel model = new()
            {
                Username = this.textBoxUserName.Text,
                Gametitle = this.comboBox.Text,
                Highscore = this.textBoxHighscore.Text,
                Date = this.dateTimePicker.Value,
                Comment = this.richTextBox.Text
            };

            try
            {
                this.dataService.Save(model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!comboBox.Items.Contains(this.comboBox.Text)) {
                comboBox.Items.Add(this.comboBox.Text);
            }
            
            DataReload();
        }
    }
}