namespace WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxFileTemplate = new System.Windows.Forms.TextBox();
            this.TextBoxKeyWords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonDirectory = new System.Windows.Forms.Button();
            this.ButtonStartSearch = new System.Windows.Forms.Button();
            this.TreeViewResult = new System.Windows.Forms.TreeView();
            this.LabelCurrentTime = new System.Windows.Forms.Label();
            this.LabelCurrentFile = new System.Windows.Forms.Label();
            this.LabelNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start directory";
            // 
            // TextBoxDirectory
            // 
            this.TextBoxDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDirectory.Location = new System.Drawing.Point(90, 10);
            this.TextBoxDirectory.Name = "TextBoxDirectory";
            this.TextBoxDirectory.Size = new System.Drawing.Size(265, 20);
            this.TextBoxDirectory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File template";
            // 
            // TextBoxFileTemplate
            // 
            this.TextBoxFileTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxFileTemplate.Location = new System.Drawing.Point(90, 39);
            this.TextBoxFileTemplate.Name = "TextBoxFileTemplate";
            this.TextBoxFileTemplate.Size = new System.Drawing.Size(265, 20);
            this.TextBoxFileTemplate.TabIndex = 3;
            // 
            // TextBoxKeyWords
            // 
            this.TextBoxKeyWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxKeyWords.Location = new System.Drawing.Point(90, 70);
            this.TextBoxKeyWords.Name = "TextBoxKeyWords";
            this.TextBoxKeyWords.Size = new System.Drawing.Size(265, 20);
            this.TextBoxKeyWords.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Text";
            // 
            // ButtonDirectory
            // 
            this.ButtonDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDirectory.Location = new System.Drawing.Point(343, 10);
            this.ButtonDirectory.Name = "ButtonDirectory";
            this.ButtonDirectory.Size = new System.Drawing.Size(13, 20);
            this.ButtonDirectory.TabIndex = 6;
            this.ButtonDirectory.Text = "*";
            this.ButtonDirectory.UseVisualStyleBackColor = true;
            // 
            // ButtonStartSearch
            // 
            this.ButtonStartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStartSearch.Location = new System.Drawing.Point(129, 99);
            this.ButtonStartSearch.Name = "ButtonStartSearch";
            this.ButtonStartSearch.Size = new System.Drawing.Size(83, 23);
            this.ButtonStartSearch.TabIndex = 8;
            this.ButtonStartSearch.Text = "Start";
            this.ButtonStartSearch.UseVisualStyleBackColor = true;
            // 
            // TreeViewResult
            // 
            this.TreeViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewResult.Location = new System.Drawing.Point(15, 158);
            this.TreeViewResult.Name = "TreeViewResult";
            this.TreeViewResult.Size = new System.Drawing.Size(341, 150);
            this.TreeViewResult.TabIndex = 10;
            // 
            // LabelCurrentTime
            // 
            this.LabelCurrentTime.AutoSize = true;
            this.LabelCurrentTime.Location = new System.Drawing.Point(15, 127);
            this.LabelCurrentTime.Name = "LabelCurrentTime";
            this.LabelCurrentTime.Size = new System.Drawing.Size(36, 13);
            this.LabelCurrentTime.TabIndex = 11;
            this.LabelCurrentTime.Text = "Time: ";
            // 
            // LabelCurrentFile
            // 
            this.LabelCurrentFile.AutoSize = true;
            this.LabelCurrentFile.Location = new System.Drawing.Point(15, 142);
            this.LabelCurrentFile.Name = "LabelCurrentFile";
            this.LabelCurrentFile.Size = new System.Drawing.Size(65, 13);
            this.LabelCurrentFile.TabIndex = 12;
            this.LabelCurrentFile.Text = "Processing: ";
            // 
            // LabelNumber
            // 
            this.LabelNumber.AutoSize = true;
            this.LabelNumber.Location = new System.Drawing.Point(237, 127);
            this.LabelNumber.Name = "LabelNumber";
            this.LabelNumber.Size = new System.Drawing.Size(60, 13);
            this.LabelNumber.TabIndex = 13;
            this.LabelNumber.Text = "Processed:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 320);
            this.Controls.Add(this.LabelNumber);
            this.Controls.Add(this.LabelCurrentFile);
            this.Controls.Add(this.LabelCurrentTime);
            this.Controls.Add(this.TreeViewResult);
            this.Controls.Add(this.ButtonStartSearch);
            this.Controls.Add(this.ButtonDirectory);
            this.Controls.Add(this.TextBoxKeyWords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBoxFileTemplate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxDirectory);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxFileTemplate;
        private System.Windows.Forms.TextBox TextBoxKeyWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonDirectory;
        private System.Windows.Forms.Button ButtonStartSearch;
        private System.Windows.Forms.TreeView TreeViewResult;
        private System.Windows.Forms.Label LabelCurrentTime;
        private System.Windows.Forms.Label LabelCurrentFile;
        private System.Windows.Forms.Label LabelNumber;
    }
}

