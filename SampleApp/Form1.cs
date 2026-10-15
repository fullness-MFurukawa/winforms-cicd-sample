using SampleApp.Samples;

namespace SampleApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "アプリケーションを終了しますか？", "cicd-sample",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);   // 既定を「いいえ」にして誤操作を防ぐ

            if (result == DialogResult.Yes)
                Close();
        }

        private void grettBtn_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                var result = Greeting.Build(this.textBox1.Text);
                MessageBox.Show(result);
            }
        }
    }
}
