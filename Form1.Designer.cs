namespace DatabaseModelCreator
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TablesList = new System.Windows.Forms.CheckedListBox();
            this.lblTables = new System.Windows.Forms.Label();
            this.lbloutDir = new System.Windows.Forms.Label();
            this.txtoutDir = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblViews = new System.Windows.Forms.Label();
            this.ViewsList = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Connection String";
            // 
            // txtConnString
            // 
            this.txtConnString.Location = new System.Drawing.Point(212, 32);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(557, 26);
            this.txtConnString.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Fetch Tables";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TablesList
            // 
            this.TablesList.FormattingEnabled = true;
            this.TablesList.Location = new System.Drawing.Point(96, 165);
            this.TablesList.Name = "TablesList";
            this.TablesList.Size = new System.Drawing.Size(262, 193);
            this.TablesList.TabIndex = 3;
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(16, 165);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(56, 20);
            this.lblTables.TabIndex = 4;
            this.lblTables.Text = "Tables";
            // 
            // lbloutDir
            // 
            this.lbloutDir.AutoSize = true;
            this.lbloutDir.Location = new System.Drawing.Point(20, 424);
            this.lbloutDir.Name = "lbloutDir";
            this.lbloutDir.Size = new System.Drawing.Size(168, 20);
            this.lbloutDir.TabIndex = 5;
            this.lbloutDir.Text = "Enter Output Directory";
            // 
            // txtoutDir
            // 
            this.txtoutDir.Location = new System.Drawing.Point(212, 424);
            this.txtoutDir.Name = "txtoutDir";
            this.txtoutDir.Size = new System.Drawing.Size(557, 26);
            this.txtoutDir.TabIndex = 6;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(322, 495);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(143, 37);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate Models";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(541, 84);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(143, 37);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Location = new System.Drawing.Point(403, 165);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(51, 20);
            this.lblViews.TabIndex = 9;
            this.lblViews.Text = "Views";
            // 
            // ViewsList
            // 
            this.ViewsList.FormattingEnabled = true;
            this.ViewsList.Location = new System.Drawing.Point(498, 165);
            this.ViewsList.Name = "ViewsList";
            this.ViewsList.Size = new System.Drawing.Size(262, 193);
            this.ViewsList.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 592);
            this.Controls.Add(this.ViewsList);
            this.Controls.Add(this.lblViews);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtoutDir);
            this.Controls.Add(this.lbloutDir);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.TablesList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtConnString);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.CheckedListBox TablesList;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtoutDir;
        private System.Windows.Forms.Label lbloutDir;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckedListBox ViewsList;
        private System.Windows.Forms.Label lblViews;
    }
}

