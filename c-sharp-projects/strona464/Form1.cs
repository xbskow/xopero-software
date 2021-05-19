using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace strona464
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        private Excuse currentExcuse = new Excuse();
        private bool formChanged = false;
        private string folder = "";
        public Form1()
        {
            InitializeComponent();
            currentExcuse.LastUsed = lastUsed.Value;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(description.Text) || String.IsNullOrEmpty(results.Text))
            {
                MessageBox.Show("Określ wymówkę i rezultat.");
                return;
            }
            saveFileDialog1.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.InitialDirectory = folder;
            saveFileDialog1.FileName = $"{description.Text}.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentExcuse.Save(saveFileDialog1.FileName);
                UpdateForm(false);
                MessageBox.Show("Wymówka zapisana.");
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            openFileDialog1.InitialDirectory = folder;
            openFileDialog1.FileName = $"{description.Text}.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentExcuse = new Excuse(openFileDialog1.FileName);
                UpdateForm(false);
            }
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = folder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folder = folderBrowserDialog1.SelectedPath;
                openButton.Enabled = true;
                saveButton.Enabled = true;
                randomExcuseButton.Enabled = true;
            }

        }

        private void UpdateForm(bool changed)
        {
            if (!changed)
            {
                this.description.Text = currentExcuse.Description;
                this.results.Text = currentExcuse.Results;
                this.lastUsed.Value = currentExcuse.LastUsed;
                if (!String.IsNullOrEmpty(currentExcuse.ExcusePath))
                    fileDate.Text = File.GetLastWriteTime(currentExcuse.ExcusePath).ToString();
                this.Text = "Program do zarządzania wymówkami";
            }
            else
            {
                this.Text = "Program do zarządzania wymówkami";
                this.formChanged = changed;
            }
        }

        private void randomExcuseButton_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                currentExcuse = new Excuse(random, folder);
                UpdateForm(false);
            }
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Description = description.Text;
            UpdateForm(true);
        }

        private void results_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Results = results.Text;
            UpdateForm(true);
        }

        private void lastUsed_ValueChanged(object sender, EventArgs e)
        {
            currentExcuse.LastUsed = lastUsed.Value;
            UpdateForm(true);
        }

        private bool CheckChanged()
        {
            if (formChanged)
            {
                DialogResult result = MessageBox.Show("Bieżąca wymówka nie została zapisana. Czy kontynuować?",
                    "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return false;
            }
            return true;
        }
    }
}
