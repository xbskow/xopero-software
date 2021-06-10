using FileOperations;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region UI events
        private void processButton_Click(object sender, EventArgs e)
        {
            deserializeJSON(txtInput.Text);
        }

        private void UseFunctionality(JsonOps jsonQuery)
        {
            Thread[] threads = new Thread[jsonQuery.tasks.Length];
            int threadCount = 0;
            foreach (JsonOps.taskArr taskDetails in jsonQuery.tasks)
            {
                JsonOps.taskInfo task = taskDetails.task;
                DateTime datetime;
                try
                {
                    datetime = DateTime.Parse(task.datetime);
                    if (Misc.TimeUntil(datetime) > 0)
                        debugOutput($"Zadanie {task.title} zostanie rozpoczęte: {datetime.ToLongDateString()} o godzinie: {datetime.ToLongTimeString()} \n\n");
                    else
                        debugOutput($"Rozpoczęto zadanie {task.title}\n\n");
                }
                catch (Exception)
                {
                    datetime = DateTime.Now;
                    debugOutput($"Rozpoczęto zadanie {task.title}\n\n");
                }
                
                try
                {
                    switch (task.type)
                    {
                        case "encrypt":
                            threads[threadCount] = new Thread(() => debugOutput(Encryption.Encrypt(task.source, task.title, task.verify, task.encryptionPassword, datetime)));
                            threads[threadCount].IsBackground = true;
                            break;
                        case "decrypt":
                            threads[threadCount] = new Thread(() => debugOutput(Encryption.Decrypt(task.source, task.title, task.encryptionPassword, datetime)));
                            break;
                        case "compress":
                            threads[threadCount] = new Thread(() => debugOutput(Compression.Compress(task.source, task.title, task.verify, datetime)));
                            threads[threadCount].IsBackground = true;
                            break;
                        case "decompress":
                            threads[threadCount] = new Thread(() => debugOutput(Compression.Decompress(task.source, task.title, datetime)));
                            break;
                        case "copy":
                            threads[threadCount] = new Thread(() => debugOutput(CopyDelete.Copy(task.source, task.copyDestination, task.title, datetime)));
                            break;
                        case "delete":
                            threads[threadCount] = new Thread(() => debugOutput(CopyDelete.Delete(task.source, datetime)));
                            break;
                        default:
                            debugOutput($"Zadanie {task.type} nie jest w puli dostępnych zadań");
                            break;
                    }
                        threads[threadCount].Start();
                        threadCount++;
                    }
                    catch (FileNotFoundException e)
                    {
                        debugOutput($"{e.Message} w zadaniu {task.title}");
                    }
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
                strJSON = strJSON.Replace(@"\", @"\\");
                JsonOps jsonQuery = JsonConvert.DeserializeObject<JsonOps>(strJSON);
                debugOutput($"{jsonQuery.tasks.Length.ToString()} tasks...");
                foreach (JsonOps.taskArr i in jsonQuery.tasks)
                {
                    debugOutput($"json object: {jsonQuery.ToString()}");
                    debugOutput($"\ntask info:");
                    debugOutput($"\n - title: {i.task.title}");
                    debugOutput($"\n - type: {i.task.type}");
                    debugOutput($"\n - source: {i.task.source}");

                    UseFunctionality(jsonQuery);
                }
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
