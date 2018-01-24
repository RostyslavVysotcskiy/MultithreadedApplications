namespace Multithreaded_Applications
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.path_to_folder = new System.Windows.Forms.TextBox();
            this.select_folder = new System.Windows.Forms.Button();
            this.extensions = new System.Windows.Forms.ComboBox();
            this.search = new System.Windows.Forms.Button();
            this.list_files = new System.Windows.Forms.ListBox();
            this.count_files = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.en = new System.Windows.Forms.ToolStripMenuItem();
            this.ru = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.SuspendLayout();
            // 
            // path_to_folder
            // 
            resources.ApplyResources(this.path_to_folder, "path_to_folder");
            this.path_to_folder.ForeColor = System.Drawing.Color.Black;
            this.path_to_folder.Name = "path_to_folder";
            // 
            // select_folder
            // 
            resources.ApplyResources(this.select_folder, "select_folder");
            this.select_folder.Name = "select_folder";
            this.select_folder.UseVisualStyleBackColor = true;
            this.select_folder.Click += new System.EventHandler(this.select_folder_Click);
            // 
            // extensions
            // 
            resources.ApplyResources(this.extensions, "extensions");
            this.extensions.FormattingEnabled = true;
            this.extensions.Items.AddRange(new object[] {
            resources.GetString("extensions.Items"),
            resources.GetString("extensions.Items1"),
            resources.GetString("extensions.Items2"),
            resources.GetString("extensions.Items3"),
            resources.GetString("extensions.Items4")});
            this.extensions.Name = "extensions";
            // 
            // search
            // 
            resources.ApplyResources(this.search, "search");
            this.search.Name = "search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // list_files
            // 
            resources.ApplyResources(this.list_files, "list_files");
            this.list_files.FormattingEnabled = true;
            this.list_files.Name = "list_files";
            // 
            // count_files
            // 
            resources.ApplyResources(this.count_files, "count_files");
            this.count_files.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.count_files.Name = "count_files";
            // 
            // stop
            // 
            resources.ApplyResources(this.stop, "stop");
            this.stop.Name = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // en
            // 
            this.en.Name = "en";
            resources.ApplyResources(this.en, "en");
            // 
            // ru
            // 
            this.ru.Name = "ru";
            resources.ApplyResources(this.ru, "ru");
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            resources.ApplyResources(this.toolStripComboBox1, "toolStripComboBox1");
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.stop);
            this.Controls.Add(this.count_files);
            this.Controls.Add(this.list_files);
            this.Controls.Add(this.search);
            this.Controls.Add(this.extensions);
            this.Controls.Add(this.select_folder);
            this.Controls.Add(this.path_to_folder);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox path_to_folder;
        private System.Windows.Forms.ComboBox extensions;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.ListBox list_files;
        private System.Windows.Forms.Label count_files;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button select_folder;
        private System.Windows.Forms.ToolStripMenuItem en;
        private System.Windows.Forms.ToolStripMenuItem ru;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}

