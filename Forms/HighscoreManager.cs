using Core;
using DataAccess;
using Domain;

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

        /// <summary>
        /// Refreshing the datagrid and readding the usernames and gametitles in the comboboxes.
        /// </summary>
        private void DataReload()
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.DataSource = this.dataService.GetAll();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var username = row.Cells["Username"].Value.ToString();

                    if (!comboBoxUsername.Items.Contains(username))
                    {
                        comboBoxUsername.Items.Add(username);
                    }

                    var gametitle = row.Cells["Gametitle"].Value.ToString();

                    if (!comboBoxGamtetitle.Items.Contains(gametitle))
                    {
                        comboBoxGamtetitle.Items.Add(gametitle);
                    }
                }
            }
        }
              
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Creating a new model
            HighscoreModel model = new()
            {
                Username = this.comboBoxUsername.Text,
                Gametitle = this.comboBoxGamtetitle.Text,
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

            // adding new username to the combobox
            if (!comboBoxUsername.Items.Contains(this.comboBoxUsername.Text))
            {
                comboBoxUsername.Items.Add(this.comboBoxUsername.Text);
            }

            // adding new gametitle to the combobox
            if (!comboBoxGamtetitle.Items.Contains(this.comboBoxGamtetitle.Text)) {
                comboBoxGamtetitle.Items.Add(this.comboBoxGamtetitle.Text);
            }

            DataReload();
        }
    }
}