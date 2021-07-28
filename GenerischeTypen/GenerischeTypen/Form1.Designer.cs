namespace GenerischeTypen
{
    partial class Form1
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
            this.CmdListString = new System.Windows.Forms.Button();
            this.LstAusgabe = new System.Windows.Forms.ListBox();
            this.CmdListLand = new System.Windows.Forms.Button();
            this.CmdDictionary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdListString
            // 
            this.CmdListString.Location = new System.Drawing.Point(12, 12);
            this.CmdListString.Name = "CmdListString";
            this.CmdListString.Size = new System.Drawing.Size(75, 23);
            this.CmdListString.TabIndex = 1;
            this.CmdListString.Text = "List String";
            this.CmdListString.UseVisualStyleBackColor = true;
            this.CmdListString.Click += new System.EventHandler(this.CmdListString_Click);
            // 
            // LstAusgabe
            // 
            this.LstAusgabe.FormattingEnabled = true;
            this.LstAusgabe.ItemHeight = 25;
            this.LstAusgabe.Location = new System.Drawing.Point(12, 41);
            this.LstAusgabe.Name = "LstAusgabe";
            this.LstAusgabe.Size = new System.Drawing.Size(339, 129);
            this.LstAusgabe.TabIndex = 2;
            // 
            // CmdListLand
            // 
            this.CmdListLand.Location = new System.Drawing.Point(93, 12);
            this.CmdListLand.Name = "CmdListLand";
            this.CmdListLand.Size = new System.Drawing.Size(75, 23);
            this.CmdListLand.TabIndex = 3;
            this.CmdListLand.Text = "List Land";
            this.CmdListLand.UseVisualStyleBackColor = true;
            this.CmdListLand.Click += new System.EventHandler(this.CmdListLand_Click);
            // 
            // CmdDictionary
            // 
            this.CmdDictionary.Location = new System.Drawing.Point(174, 12);
            this.CmdDictionary.Name = "CmdDictionary";
            this.CmdDictionary.Size = new System.Drawing.Size(75, 23);
            this.CmdDictionary.TabIndex = 4;
            this.CmdDictionary.Text = "Dictionary String Land";
            this.CmdDictionary.UseVisualStyleBackColor = true;
            this.CmdDictionary.Click += new System.EventHandler(this.CmdDictionary_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(488, 258);
            this.Controls.Add(this.CmdDictionary);
            this.Controls.Add(this.CmdListLand);
            this.Controls.Add(this.LstAusgabe);
            this.Controls.Add(this.CmdListString);
            this.Name = "Form1";
            this.Text = "Gnerische Typen";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CmdListString;
        private System.Windows.Forms.ListBox LstAusgabe;
        private System.Windows.Forms.Button CmdListLand;
        private System.Windows.Forms.Button CmdDictionary;
    }
}

