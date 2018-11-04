namespace FileDistance
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_richTxtCompareResult = new System.Windows.Forms.RichTextBox();
            this.m_btnChooseSourceFile = new System.Windows.Forms.Button();
            this.m_txtSourceFile = new System.Windows.Forms.TextBox();
            this.m_txtTargetFile = new System.Windows.Forms.TextBox();
            this.m_btnChooseTargetFile = new System.Windows.Forms.Button();
            this.m_btnCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_richTxtCompareResult
            // 
            this.m_richTxtCompareResult.Location = new System.Drawing.Point(29, 31);
            this.m_richTxtCompareResult.Name = "m_richTxtCompareResult";
            this.m_richTxtCompareResult.ReadOnly = true;
            this.m_richTxtCompareResult.Size = new System.Drawing.Size(817, 451);
            this.m_richTxtCompareResult.TabIndex = 0;
            this.m_richTxtCompareResult.Text = "";
            // 
            // m_btnChooseSourceFile
            // 
            this.m_btnChooseSourceFile.Location = new System.Drawing.Point(223, 505);
            this.m_btnChooseSourceFile.Name = "m_btnChooseSourceFile";
            this.m_btnChooseSourceFile.Size = new System.Drawing.Size(132, 23);
            this.m_btnChooseSourceFile.TabIndex = 1;
            this.m_btnChooseSourceFile.Text = "Choose source file";
            this.m_btnChooseSourceFile.UseVisualStyleBackColor = true;
            this.m_btnChooseSourceFile.Click += new System.EventHandler(this.m_btnChooseSourceFile_Click);
            // 
            // m_txtSourceFile
            // 
            this.m_txtSourceFile.Location = new System.Drawing.Point(29, 505);
            this.m_txtSourceFile.Name = "m_txtSourceFile";
            this.m_txtSourceFile.Size = new System.Drawing.Size(185, 21);
            this.m_txtSourceFile.TabIndex = 2;
            // 
            // m_txtTargetFile
            // 
            this.m_txtTargetFile.Location = new System.Drawing.Point(386, 505);
            this.m_txtTargetFile.Name = "m_txtTargetFile";
            this.m_txtTargetFile.Size = new System.Drawing.Size(171, 21);
            this.m_txtTargetFile.TabIndex = 3;
            // 
            // m_btnChooseTargetFile
            // 
            this.m_btnChooseTargetFile.Location = new System.Drawing.Point(564, 505);
            this.m_btnChooseTargetFile.Name = "m_btnChooseTargetFile";
            this.m_btnChooseTargetFile.Size = new System.Drawing.Size(135, 23);
            this.m_btnChooseTargetFile.TabIndex = 4;
            this.m_btnChooseTargetFile.Text = "Choose target file";
            this.m_btnChooseTargetFile.UseVisualStyleBackColor = true;
            this.m_btnChooseTargetFile.Click += new System.EventHandler(this.m_btnChooseTargetFile_Click);
            // 
            // m_btnCompare
            // 
            this.m_btnCompare.Location = new System.Drawing.Point(760, 505);
            this.m_btnCompare.Name = "m_btnCompare";
            this.m_btnCompare.Size = new System.Drawing.Size(75, 23);
            this.m_btnCompare.TabIndex = 5;
            this.m_btnCompare.Text = "Compare";
            this.m_btnCompare.UseVisualStyleBackColor = true;
            this.m_btnCompare.Click += new System.EventHandler(this.m_btnCompare_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 540);
            this.Controls.Add(this.m_btnCompare);
            this.Controls.Add(this.m_btnChooseTargetFile);
            this.Controls.Add(this.m_txtTargetFile);
            this.Controls.Add(this.m_txtSourceFile);
            this.Controls.Add(this.m_btnChooseSourceFile);
            this.Controls.Add(this.m_richTxtCompareResult);
            this.Name = "MainWindow";
            this.Text = "File Difference";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox m_richTxtCompareResult;
        private System.Windows.Forms.Button m_btnChooseSourceFile;
        private System.Windows.Forms.TextBox m_txtSourceFile;
        private System.Windows.Forms.TextBox m_txtTargetFile;
        private System.Windows.Forms.Button m_btnChooseTargetFile;
        private System.Windows.Forms.Button m_btnCompare;
    }
}

