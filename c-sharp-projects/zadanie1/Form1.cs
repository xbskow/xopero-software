using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using FileOperations;
using SharpAESCrypt;

namespace zadanie1
{
    public partial class Form1 : Form
    {
        FileClass FileOps = new FileClass();
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
                try
                {
                    switch (task.type)
                    {
                        case "encrypt":
                            threads[threadCount] = new Thread(() => debugOutput(FileOps.Encryption(task.source, task.title, task.verify)));
                            threads[threadCount].IsBackground = true;
                            break;
                        case "decrypt":
                            threads[threadCount] = new Thread(() => debugOutput(FileOps.Decryption(task.source, task.title)));
                            break;
                        case "compress":
                            threads[threadCount] = new Thread(() => debugOutput(FileOps.Compress(task.source, task.title, task.verify)));
                            threads[threadCount].IsBackground = true;
                            break;
                        case "decompress":
                            threads[threadCount] = new Thread(() => debugOutput(FileOps.Decompress(task.source, task.title)));
                            break;
                        case "copy":
                            threads[threadCount] = new Thread(() => debugOutput(FileOps.Copy(task.source, task.title)));
                            break;
                        case "delete":
                            threads[threadCount] = new Thread(() => debugOutput(FileOps.Delete(task.source)));
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
                    debugOutput($"\n - name: {i.task.type}");
                    debugOutput($"\n - source: {i.task.source}");
                    UseFunctionality(jsonQuery);
                    //UseFunctionality(jsonQuery);
                    debugOutput($"Rozpoczęto zadanie {i.task.title}\n\n");
                }
                debugOutput(jsonQuery.tasks.Length.ToString());
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
