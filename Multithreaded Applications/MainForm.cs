using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multithreaded_Applications
{
    struct InputeData
    {
        public string pach;
        public string exp;
    }

    public partial class MainForm : Form
    {
        static private BackgroundWorker BackgroundWorker = null;  
        static int file_count = 0;

        public MainForm()
        {
            InitializeComponent();         
        }

        private void select_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selecting_folder = new FolderBrowserDialog();
            selecting_folder.Description = "Выберите папку для поиска файлов.";
            if (selecting_folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {               
                path_to_folder.Text = selecting_folder.SelectedPath;
            }
        }

        public static void EnumerateAllFiles(string pach, string exp, BackgroundWorker bw, DoWorkEventArgs e)
        {
            try
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    IEnumerable<string> files = null;
                    try { files = Directory.EnumerateFiles(pach, exp); }
                    catch { }

                    if (files != null)
                    {
                        foreach (string file in files)
                        {
                            file_count++;
                            BackgroundWorker.ReportProgress(file_count, file);
                        }
                    }
                    IEnumerable<string> directories = null;
                    try { directories = Directory.EnumerateDirectories(pach); }
                    catch { }

                    if (directories != null)
                    {
                        foreach (var file in directories)
                        {
                            EnumerateAllFiles(file, exp, bw, e);
                        }
                    }
                    e.Result = file_count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            const string caption = "Ошибка ввода данных файла!";
            if (path_to_folder.Text.Length == 0)
            {
                string message = "Путь не задан.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Directory.Exists(path_to_folder.Text))
            {
                string message = "Заданная папка не существует.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (extensions.Text.Length == 0)
            {
                string message = "Не задан тип файлов.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                file_count = 0;
                list_files.Items.Clear();
                search.Enabled = false;
                InputeData IdDt;
                IdDt.pach = path_to_folder.Text;
                IdDt.exp = "*." + extensions.Text;

                BackgroundWorker = new BackgroundWorker();
                BackgroundWorker.WorkerReportsProgress = true;
                BackgroundWorker.WorkerSupportsCancellation = true;
                BackgroundWorker.DoWork += backgroundWorker1_DoWork;
                BackgroundWorker.ProgressChanged += backgroundWorker1_ProgressChanged;
                BackgroundWorker.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
                BackgroundWorker.RunWorkerAsync(IdDt);
            }
        }
       
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            InputeData value = (InputeData)e.Argument;
            EnumerateAllFiles(value.pach, value.exp, bw, e);                 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message_list = "Поиск завершон!";
            if (e.Cancelled)
            {
                string message = "Поиск остановлен.";
                MessageBox.Show(message, "Собщение!", MessageBoxButtons.OK, MessageBoxIcon.Stop);;
            }
            else if (e.Error != null)
            {
                string message = "Ошибка выполнения: " + e.Error;
                MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);      
            }
            else
            {
                string message = "Поиск закончен успешно. Найденных файлов - " + e.Result + ". ";
                MessageBox.Show(message, "Собщение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            list_files.Items.Add(message_list);
            FindMyString(message_list);
            search.Enabled = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            count_files.Text = "Количество найденных файлов: "+ e.ProgressPercentage.ToString();
            list_files.Items.Add(e.UserState as String);
            FindMyString(e.UserState as String);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (BackgroundWorker.IsBusy)
            {
                BackgroundWorker.CancelAsync();
            }
        }

        private void FindMyString(string searchString)
        {
            if (searchString != string.Empty)
            {
                int index = list_files.FindString(searchString);
                if (index != -1)
                {
                    list_files.SetSelected(index, true);
                }
            }
        }
    }
}
