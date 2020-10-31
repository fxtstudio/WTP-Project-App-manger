using IWshRuntimeLibrary;
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
using File = System.IO.File;

namespace installFiles
{
    public partial class Form1 : Form
    {
        string[] args = null;
        public Form1()
        {
            InitializeComponent();
        }

        public string[] data1;
        public Form1(string[] args)
        {
            InitializeComponent();
            this.args = args;
            data1 = args;
        }
    
        public string filepath = "";
        public string sc = "";
        public string sc1 = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            
            button5_Click(sender,e);
            string data2 = data1[0];
            MessageBox.Show(data2);
            ZipFile.ExtractToDirectory(data2, "config\\data\\");
            string[] data3 = File.ReadAllLines("config\\data\\install.Fcl", Encoding.Default);

           label1.Text = data3[0];
            label2.Text = data3[1];
            this.Text = data3[2];
            richTextBox1.Text = data3[3];
            sc = data3[4];
            sc1 = data3[5];
            string[] disks = Directory.GetLogicalDrives();
            for (int i = 0; i < disks.Length; i++)
            {
                //循环添加到列表中
                comboBox1.Items.Add(disks[i]);
                //设置属性默认选择第1个
                comboBox1.SelectedIndex = 0;
            }

        }

        public string drive = "C:";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Height = this.Height*2;
            button2.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            drive = comboBox1.SelectedItem.ToString();
            MessageBox.Show("成功选择磁盘分区!", "Done 完成");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            this.Height = this.Height / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(drive + @"\\App"))
            {
                ZipFile.ExtractToDirectory("config\\data\\install\\install.App", drive + "\\App\\");
                System.Diagnostics.Process.Start(drive + "\\App\\" + sc + "\\" + sc1 + ".exe");
                string DesktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);//得到桌面文件夹
                IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();



                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(DesktopPath + "\\"+sc1+".lnk");
                shortcut.TargetPath = drive + "\\App\\" + sc + "\\" + sc1 + ".exe";
                shortcut.Arguments = "";// 参数
                shortcut.Description = "Applications";
                shortcut.WorkingDirectory = drive + "\\App\\" + sc ;//程序所在文件夹，在快捷方式图标点击右键可以看到此属性
                shortcut.IconLocation = drive + "\\App\\" + sc + "\\" + sc1 + ".exe" + ",0";//图标
                shortcut.Hotkey = "";//热键
                shortcut.WindowStyle = 1;
                shortcut.Save();

                shortcut.Save();//保存快捷方式
                MessageBox.Show("安装成功", "Done 完成");
            }
            else
            {
                Directory.CreateDirectory(drive + @"\\App");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.Delete("config\\data\\install\\install.App");
            File.Delete("config\\data\\afterdo\\config.bat");
            File.Delete("config\\data\\install.Fcl");
            Directory.Delete("config\\data\\install");
            Directory.Delete("config\\data\\afterdo");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
