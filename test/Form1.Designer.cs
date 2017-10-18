namespace test
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
            this.items = new System.Windows.Forms.ListBox();
            this.btnGetir = new System.Windows.Forms.Button();
            this.memberInfo = new System.Windows.Forms.ListBox();
            this.btnMember = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // items
            // 
            this.items.FormattingEnabled = true;
            this.items.ItemHeight = 16;
            this.items.Location = new System.Drawing.Point(28, 12);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(1349, 372);
            this.items.TabIndex = 0;
            // 
            // btnGetir
            // 
            this.btnGetir.Location = new System.Drawing.Point(215, 428);
            this.btnGetir.Name = "btnGetir";
            this.btnGetir.Size = new System.Drawing.Size(75, 23);
            this.btnGetir.TabIndex = 1;
            this.btnGetir.Text = "LIST";
            this.btnGetir.UseVisualStyleBackColor = true;
            this.btnGetir.Click += new System.EventHandler(this.btnGetir_Click);
            // 
            // memberInfo
            // 
            this.memberInfo.FormattingEnabled = true;
            this.memberInfo.ItemHeight = 16;
            this.memberInfo.Location = new System.Drawing.Point(41, 470);
            this.memberInfo.Name = "memberInfo";
            this.memberInfo.Size = new System.Drawing.Size(397, 84);
            this.memberInfo.TabIndex = 2;
            // 
            // btnMember
            // 
            this.btnMember.Location = new System.Drawing.Point(509, 489);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(75, 39);
            this.btnMember.TabIndex = 3;
            this.btnMember.Text = "Display";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 582);
            this.Controls.Add(this.btnMember);
            this.Controls.Add(this.memberInfo);
            this.Controls.Add(this.btnGetir);
            this.Controls.Add(this.items);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox items;
        private System.Windows.Forms.Button btnGetir;
        private System.Windows.Forms.ListBox memberInfo;
        private System.Windows.Forms.Button btnMember;
    }
}

