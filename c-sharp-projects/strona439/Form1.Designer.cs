
namespace strona439
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.addLumberjack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.crispy = new System.Windows.Forms.RadioButton();
            this.soggy = new System.Windows.Forms.RadioButton();
            this.browned = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.howMany = new System.Windows.Forms.NumericUpDown();
            this.addFlapjacks = new System.Windows.Forms.Button();
            this.nextInLine = new System.Windows.Forms.TextBox();
            this.nextLumberjack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię drwala";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(96, 12);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(119, 23);
            this.name.TabIndex = 1;
            // 
            // addLumberjack
            // 
            this.addLumberjack.Location = new System.Drawing.Point(12, 41);
            this.addLumberjack.Name = "addLumberjack";
            this.addLumberjack.Size = new System.Drawing.Size(203, 23);
            this.addLumberjack.TabIndex = 2;
            this.addLumberjack.Text = "Dodaj drwala";
            this.addLumberjack.UseVisualStyleBackColor = true;
            this.addLumberjack.Click += new System.EventHandler(this.addLumberjack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kolejka do śniadania";
            // 
            // line
            // 
            this.line.FormattingEnabled = true;
            this.line.ItemHeight = 15;
            this.line.Location = new System.Drawing.Point(13, 100);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(114, 259);
            this.line.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nakarm drwala";
            // 
            // crispy
            // 
            this.crispy.AutoSize = true;
            this.crispy.Location = new System.Drawing.Point(146, 141);
            this.crispy.Name = "crispy";
            this.crispy.Size = new System.Drawing.Size(87, 19);
            this.crispy.TabIndex = 6;
            this.crispy.TabStop = true;
            this.crispy.Text = "Chrupkiego";
            this.crispy.UseVisualStyleBackColor = true;
            // 
            // soggy
            // 
            this.soggy.AutoSize = true;
            this.soggy.Location = new System.Drawing.Point(146, 167);
            this.soggy.Name = "soggy";
            this.soggy.Size = new System.Drawing.Size(87, 19);
            this.soggy.TabIndex = 7;
            this.soggy.TabStop = true;
            this.soggy.Text = "Wilgotnego";
            this.soggy.UseVisualStyleBackColor = true;
            // 
            // browned
            // 
            this.browned.AutoSize = true;
            this.browned.Location = new System.Drawing.Point(146, 193);
            this.browned.Name = "browned";
            this.browned.Size = new System.Drawing.Size(86, 19);
            this.browned.TabIndex = 8;
            this.browned.TabStop = true;
            this.browned.Text = "Rumianego";
            this.browned.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(146, 219);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(94, 19);
            this.radioButton4.TabIndex = 9;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Bananowego";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // howMany
            // 
            this.howMany.Location = new System.Drawing.Point(146, 100);
            this.howMany.Name = "howMany";
            this.howMany.Size = new System.Drawing.Size(94, 23);
            this.howMany.TabIndex = 10;
            this.howMany.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // addFlapjacks
            // 
            this.addFlapjacks.Location = new System.Drawing.Point(146, 244);
            this.addFlapjacks.Name = "addFlapjacks";
            this.addFlapjacks.Size = new System.Drawing.Size(125, 23);
            this.addFlapjacks.TabIndex = 11;
            this.addFlapjacks.Text = "Dodaj naleśniki";
            this.addFlapjacks.UseVisualStyleBackColor = true;
            this.addFlapjacks.Click += new System.EventHandler(this.addFlapjacks_Click);
            // 
            // nextInLine
            // 
            this.nextInLine.Location = new System.Drawing.Point(146, 274);
            this.nextInLine.Multiline = true;
            this.nextInLine.Name = "nextInLine";
            this.nextInLine.ReadOnly = true;
            this.nextInLine.Size = new System.Drawing.Size(125, 56);
            this.nextInLine.TabIndex = 12;
            // 
            // nextLumberjack
            // 
            this.nextLumberjack.Location = new System.Drawing.Point(146, 337);
            this.nextLumberjack.Name = "nextLumberjack";
            this.nextLumberjack.Size = new System.Drawing.Size(125, 23);
            this.nextLumberjack.TabIndex = 13;
            this.nextLumberjack.Text = "Następny drwal";
            this.nextLumberjack.UseVisualStyleBackColor = true;
            this.nextLumberjack.Click += new System.EventHandler(this.nextLumberjack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 372);
            this.Controls.Add(this.nextLumberjack);
            this.Controls.Add(this.nextInLine);
            this.Controls.Add(this.addFlapjacks);
            this.Controls.Add(this.howMany);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.browned);
            this.Controls.Add(this.soggy);
            this.Controls.Add(this.crispy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.line);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addLumberjack);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.howMany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button addLumberjack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox line;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton crispy;
        private System.Windows.Forms.RadioButton soggy;
        private System.Windows.Forms.RadioButton browned;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.NumericUpDown howMany;
        private System.Windows.Forms.Button addFlapjacks;
        private System.Windows.Forms.TextBox nextInLine;
        private System.Windows.Forms.Button nextLumberjack;
    }
}

