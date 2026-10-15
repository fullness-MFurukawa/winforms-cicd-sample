namespace SampleApp
{
    partial class MainForm
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            closeBtn = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            grettBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(621, 147);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Info;
            label1.Dock = DockStyle.Fill;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(621, 147);
            label1.TabIndex = 0;
            label1.Text = "GitHub Actions CI/CD 実験用サンプル\nテスト → 署名 → インストーラー作成 → GitHub Releases 公開\nの流れを確認するための最小アプリです。\n下のボタンを押すとダイアログが表示されます。";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(grettBtn);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            panel2.Location = new Point(0, 147);
            panel2.Name = "panel2";
            panel2.Size = new Size(621, 160);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(closeBtn);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 245);
            panel3.Name = "panel3";
            panel3.Size = new Size(621, 62);
            panel3.TabIndex = 2;
            // 
            // closeBtn
            // 
            closeBtn.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            closeBtn.Location = new Point(515, 12);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(94, 38);
            closeBtn.TabIndex = 0;
            closeBtn.Text = "閉じる";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 37);
            label2.Name = "label2";
            label2.Size = new Size(52, 28);
            label2.TabIndex = 0;
            label2.Text = "名前";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(176, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 34);
            textBox1.TabIndex = 1;
            // 
            // grettBtn
            // 
            grettBtn.Location = new Point(408, 37);
            grettBtn.Name = "grettBtn";
            grettBtn.Size = new Size(94, 34);
            grettBtn.TabIndex = 2;
            grettBtn.Text = "挨拶";
            grettBtn.UseVisualStyleBackColor = true;
            grettBtn.Click += grettBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 307);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CI/CDサンプル";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Button closeBtn;
        private Button grettBtn;
        private TextBox textBox1;
        private Label label2;
    }
}
