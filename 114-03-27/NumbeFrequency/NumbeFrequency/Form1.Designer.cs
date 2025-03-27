namespace NumbeFrequency
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
            numberTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // numberTextBox
            // 
            numberTextBox.Font = new Font("Microsoft JhengHei UI", 18F);
            numberTextBox.Location = new Point(54, 46);
            numberTextBox.Name = "numberTextBox";
            numberTextBox.Size = new Size(143, 38);
            numberTextBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(88, 115);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "出現次數";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 182);
            Controls.Add(button1);
            Controls.Add(numberTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox numberTextBox;
        private Button button1;
    }
}
