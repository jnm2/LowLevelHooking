namespace WinForms
{
    partial class MainView
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
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hotstringDisableButton = new System.Windows.Forms.RadioButton();
            this.hotstringEnableButton = new System.Windows.Forms.RadioButton();
            this.hotstringReplacementTextBox = new System.Windows.Forms.TextBox();
            this.hotstringSearchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(12, 196);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(772, 254);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.Text = "Log:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.hotstringDisableButton);
            this.groupBox1.Controls.Add(this.hotstringEnableButton);
            this.groupBox1.Controls.Add(this.hotstringReplacementTextBox);
            this.groupBox1.Controls.Add(this.hotstringSearchTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotstring";
            // 
            // hotstringDisableButton
            // 
            this.hotstringDisableButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.hotstringDisableButton.Checked = true;
            this.hotstringDisableButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hotstringDisableButton.Location = new System.Drawing.Point(181, 113);
            this.hotstringDisableButton.Name = "hotstringDisableButton";
            this.hotstringDisableButton.Size = new System.Drawing.Size(76, 36);
            this.hotstringDisableButton.TabIndex = 2;
            this.hotstringDisableButton.TabStop = true;
            this.hotstringDisableButton.Text = "Disable";
            this.hotstringDisableButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hotstringDisableButton.UseVisualStyleBackColor = true;
            // 
            // hotstringEnableButton
            // 
            this.hotstringEnableButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.hotstringEnableButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hotstringEnableButton.Location = new System.Drawing.Point(99, 113);
            this.hotstringEnableButton.Name = "hotstringEnableButton";
            this.hotstringEnableButton.Size = new System.Drawing.Size(76, 36);
            this.hotstringEnableButton.TabIndex = 2;
            this.hotstringEnableButton.Text = "Enable";
            this.hotstringEnableButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hotstringEnableButton.UseVisualStyleBackColor = true;
            this.hotstringEnableButton.CheckedChanged += new System.EventHandler(this.hotstringEnableButton_CheckedChanged);
            // 
            // hotstringReplacementTextBox
            // 
            this.hotstringReplacementTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotstringReplacementTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.hotstringReplacementTextBox.Location = new System.Drawing.Point(99, 73);
            this.hotstringReplacementTextBox.Name = "hotstringReplacementTextBox";
            this.hotstringReplacementTextBox.ReadOnly = true;
            this.hotstringReplacementTextBox.Size = new System.Drawing.Size(636, 27);
            this.hotstringReplacementTextBox.TabIndex = 1;
            // 
            // hotstringSearchTextBox
            // 
            this.hotstringSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotstringSearchTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.hotstringSearchTextBox.Location = new System.Drawing.Point(99, 38);
            this.hotstringSearchTextBox.Name = "hotstringSearchTextBox";
            this.hotstringSearchTextBox.ReadOnly = true;
            this.hotstringSearchTextBox.Size = new System.Drawing.Size(636, 27);
            this.hotstringSearchTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(30, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "With:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Replace:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 463);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainView";
            this.Text = "Keyboard hook sample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox hotstringReplacementTextBox;
        private System.Windows.Forms.TextBox hotstringSearchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton hotstringDisableButton;
        private System.Windows.Forms.RadioButton hotstringEnableButton;
    }
}

