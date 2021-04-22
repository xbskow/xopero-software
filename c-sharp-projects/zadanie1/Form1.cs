using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace zadanie1
{
    public partial class Form1 : Form
    {
        FileOperations FileOps = new FileOperations();
        public Form1()
        {
            InitializeComponent();
        }
        #region UI events
        private void processButton_Click(object sender, EventArgs e)
        {
            // debugOutput(txtInput.Text);
            deserializeJSON(txtInput.Text);
        }

        private void UseFunctionality(string type, string source, string destination, bool isFolder, bool toEncrypt)
        {
            switch (type)
            {
                case "encrypt":
                    break;
                case "decrypt":
                    break;
                case "compress":
                    FileOps.Compress(source, destination, isFolder, toEncrypt);
                    break;
                case "decompress":
                    FileOps.Decompress(source, destination, isFolder);
                    break;
                case "copy":
                    FileOps.Copy(source, destination, isFolder, toEncrypt);
                    break;
                case "delete":
                    FileOps.Delete(source, isFolder);
                    break;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textDebugOutput.Text = string.Empty;
        }
        #endregion

        #region json functions
        private void deserializeJSON(string strJSON)
        {
            try
            {
                var jsonQuery = JsonConvert.DeserializeObject<JsonOps>(strJSON);

                debugOutput($"json object: {jsonQuery.ToString()}");
                debugOutput($"\ntask info:");
                debugOutput($"\n - name: {jsonQuery.task.type}");
                debugOutput($"\n - is folder: {jsonQuery.task.isFolder}");
                debugOutput($"\n - source: {jsonQuery.task.source}");
                debugOutput($"\n - destination: {jsonQuery.task.destination}");
                debugOutput($"\n - to encrypt: {jsonQuery.task.toEncrypt}");

                UseFunctionality(jsonQuery.task.type, jsonQuery.task.source, jsonQuery.task.destination, jsonQuery.task.isFolder, jsonQuery.task.toEncrypt);

            }
            catch (Exception ex)
            {
                debugOutput($"We had a problem: {ex.Message.ToString()}");
            }
        }
        #endregion

        #region Debug Output
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                textDebugOutput.Text += strDebugText + Environment.NewLine;
                textDebugOutput.SelectionStart = textDebugOutput.TextLength;
                textDebugOutput.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }
        #endregion

    }
}
