using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BatEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int rs = 10000;
        public string pt;
        public int fg = 1;

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }

            pt = openFileDialog1.FileName;
            Text = "MethodBox BatEditor  *" + pt;

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Text = "MethodBox BatEditor";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string key = "net";
            Regex reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            MatchCollection mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            key = "start";
            reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            key = "goto";
            reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            key = "shutdown";
            reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            key = "regsvr32";
            reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            key = "sfc";
            reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            key = "netstat";
            reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            key = "ping";
            reg = new Regex(@"(?i)\b" + Regex.Escape(key) + @"\b");
            mc = reg.Matches(richTextBox1.Text);
            foreach (Match m in mc)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            progressBar1.Value = 100;

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            染色速度ToolStripMenuItem.Text = "染色速度" + (rs / 1000).ToString() + "秒每次";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rs = rs + 5000;
            染色速度ToolStripMenuItem.Text = "染色速度" + (rs / 1000).ToString() + "秒每次";
            timer1.Interval = rs;
        }

        private void 减5秒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rs > 5000)
            {
                rs = rs - 5000;
                染色速度ToolStripMenuItem.Text = "染色速度" + (rs / 1000).ToString() + "秒每次";
                timer1.Interval = rs;
            }
            else
            {
                MessageBox.Show("不能再减小了！","达到最大速度",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //进度条
            try
            {
                progressBar1.Value = progressBar1.Value - rs / 1000;
            }
            catch
            {
                progressBar1.Value = 12;
            }
        }

        private void 调试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test(pt);
        }

        public string test(string str)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            p.StandardInput.WriteLine(str + "&exit");
            p.StandardInput.AutoFlush = true;
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            richTextBox1.Text = richTextBox1.Text + "\n\n\n\n调试结果:\n\n" + output;
            return output;
        }


        private void 夜空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = BackColor = Color.Black;
            menuStrip1.BackColor = Color.Gray;
            label1.ForeColor = Color.White;
            richTextBox1.ForeColor = Color.White;
        }

        private void 白日ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.BackColor = BackColor = Color.White;
            menuStrip1.BackColor = Color.Gray;
            label1.ForeColor = Color.Black;
            richTextBox1.ForeColor = Color.Black;
        }
    }
}
