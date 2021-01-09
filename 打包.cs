using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control
{
    public partial class 打包 : Form
    {
        public 打包()
        {
            InitializeComponent();
        }

        public string name = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox1.Text == ""||textBox1.Text == " ")
            {
                MessageBox.Show("名字不能为空或者无名字", "Message 信息");

            }else
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory("config\\package\\" + textBox1.Text);
                Directory.CreateDirectory("config\\package\\" + textBox1.Text + "\\install");
                Directory.CreateDirectory("config\\package\\" + textBox1.Text + "\\afterdo");
                ZipFile.CreateFromDirectory(f.SelectedPath, "config\\package\\" + textBox1.Text + "\\install\\install.App");
                panel2.Visible = false;
                panel3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            System.Diagnostics.Process.Start("explorer.exe", "config\\package\\" + textBox1.Text + "\\afterdo\\");
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] datac = { "", "", "", "", "", "" };
            datac[0] = textBox2.Text;
            datac[1] = textBox3.Text;
            datac[2] = textBox4.Text;
            datac[3] = textBox5.Text;
            datac[4] = textBox6.Text;
            datac[5] = textBox7.Text;
            File.WriteAllLines("config\\package\\" + textBox1.Text + "\\install.Fcl",datac, Encoding.Default);
            panel4.Visible = false;
            panel5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.FileName = "";
                sd.Filter = "zip安装文件|*.zip";
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    ZipFile.CreateFromDirectory("config\\package\\" + textBox1.Text+"\\",sd.FileName);
                    MessageBox.Show("成功生成!", "done 完成");
                    panel5.Visible = false;
                    panel1.Visible = true;
                }
            }
        }
    }
}
