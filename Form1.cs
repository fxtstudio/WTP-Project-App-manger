using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            tr = false;
        }


        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]

        public class myClass
        {
            public int Test(int a, int b)
            {
                //System.Windows.Forms.MessageBox.Show("alert:JS回调成功");

                int c = a * b;
                return c;
                //System.Windows.Forms.MessageBox.Show("JS回调值alert:"+c);
            }

        }


       

            private void Form1_Load(object sender, EventArgs e)
        {
            webKitBrowser1.Navigate("url");
            this.webKitBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webKitBrowser1_DocumentCompleted);
           

            webKitBrowser1.Navigate("http://fxtstudios.gitee.io/web/download");
           
            string[] dataaaa = File.ReadAllLines("config\\saves\\setting.ini");
            this.Text = dataaaa[11].ToString();
            if (dataaaa[0] != "Using Fcl2.config")
            {
                MessageBox.Show("这台机器上的manger程序没有正常配置，请从新下载");
                Application.Exit();
            }
            if (dataaaa[1] != "is.dev.user")
            {
                if (dataaaa[2] == "0")
                {
                    MessageBox.Show("这台机器上的manger程序是开发版本，您不是开发者!");
                    Application.Exit();
                }
                
            }
            
            if(dataaaa[15] == "false")
            {
                panel1.BackColor = Color.FromName("Highlight");
                panel4.BackColor = Color.FromName("ScrollBar");
                this.BackColor = Color.FromName("ActiveCaption");
                panel3.BackColor = Color.FromName("ActiveCaption");
                button1.ForeColor = Color.FromName("ControlDarkDark");
                button1.BackColor = Color.FromName("Control");
                button13.ForeColor = Color.FromName("ControlDarkDark");
                button13.BackColor = Color.FromName("Control");
               // button14.ForeColor = Color.FromName("ControlDarkDark");
           //     button14.BackColor = Color.FromName("Control");
                button4.ForeColor = Color.FromName("ControlDarkDark");
                button4.BackColor = Color.FromName("Control");
                button2.ForeColor = Color.FromName("ControlDarkDark");
                button2.BackColor = Color.FromName("Control");
                button3.ForeColor = Color.FromName("ControlDarkDark");
                button3.BackColor = Color.FromName("Control");
                button10.ForeColor = Color.FromName("ControlDarkDark");
                button10.BackColor = Color.FromName("Control");
                button15.ForeColor = Color.FromName("ControlDarkDark");
                button15.BackColor = Color.FromName("Control");
                button16.ForeColor = Color.FromName("ControlDarkDark");
                button16.BackColor = Color.FromName("Control");
                button6.ForeColor = Color.FromName("ControlDarkDark");
                button6.BackColor = Color.FromName("Control");
                button7.ForeColor = Color.FromName("ControlDarkDark");
                button7.BackColor = Color.FromName("Control");
                button8.ForeColor = Color.FromName("ControlDarkDark");
                button8.BackColor = Color.FromName("Control");

            }
            
            panel1.Visible = true;
            if (dataaaa[9] == "on")
            {
                ison = true;
            }
            else
            {
                if (dataaaa[13] == "false")
                {

                }
                else
                {
                   
                }
            }
            
            
                if (dataaaa[3] == "language.is.not.ch")
                {
                    MessageBox.Show("This vision of manger is chinese language!");

                }
            
           
            this.BackColor = Color.FromName(dataaaa[5]);
            this.ForeColor = Color.FromName(dataaaa[6]);
            Control.CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();

            
          
            label5.Text = "Control 控制器";
          

        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wparam, int lparam);

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键
            {
                Capture = false;//释放鼠标，使能够手动操作
                SendMessage(Handle, 0x00A1, 2, 0);//拖动窗体
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tr = true;
        }
        public bool tr = false;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; ; i++)
            {

                if (tr == true)
                {
                    panel2.Location = this.PointToClient(MousePosition);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tr = false;
        }

        private void panel4_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("a");
        }
        public int aa = 0;

        public void webKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string dom = webKitBrowser1.DocumentText;//获取页面html 
                                                     
            

        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (aa % 2 == 0)
            {
                panel2.Dock = DockStyle.Top;
                panel2.Height = this.Height / 2;
                aa++;
            }
            else
            {
                aa++;
                panel2.Dock = DockStyle.None;
                panel2.Height = 600;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = richTextBox1.Text + " " + textBox1.Text + "\n";
            if (textBox1.Text == "c.clear")
            {
                richTextBox1.Text = "FxTStudio Commandline C# Vision!" + "\n" + "var 2.03" + "\n" + "/commandline/input>";

            }
            if (textBox1.Text.Contains("c.zip.install."))
            {
                string c1;

                c1 = textBox1.Text.Replace("c.zip.install.", "");
                MessageBox.Show(c1);
                System.Diagnostics.Process.Start("config\\Manger_old\\setup.exe", c1);
                richTextBox1.Text = richTextBox1.Text + "[App_Manger_debug]is open..." + "\n" + "/commandline/input>";
            }
            if (textBox1.Text.Contains("c.app.install."))
            {
                string tSt;

                tSt = textBox1.Text.Replace("c.app.install.", "");
                MessageBox.Show(tSt);
                System.Diagnostics.Process.Start("config\\Manger\\manger.exe", tSt);
                richTextBox1.Text = richTextBox1.Text + "[App_Manger_debug]is open..." + "\n" + "/commandline/input>";
            }
            if (textBox1.Text.Contains("c.show.dir/"))
            {
                string aaaaa;
                aaaaa = textBox1.Text.Replace("c.show.dir/", "");
                String path = aaaaa;

                DirectoryInfo folder = new DirectoryInfo(path);

                foreach (FileInfo file in folder.GetFiles("*.*"))
                {
                    Console.WriteLine(file.FullName);
                }



            }
            if (textBox1.Text == "c.manger.vision")
            {
                richTextBox1.Text = richTextBox1.Text + "beta vision: var 3.0beta" + "\n" + "/commandline/input>";
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text + "Error Command!" + "\n" + "/commandline/input>";
            }
            string[] datak = File.ReadAllLines("config\\FCL1\\ExE.Fcl");
            for (int i = 0; i <= int.Parse(File.ReadAllText("config\\FCL1\\ex.Fcl")); i++)
            {
                if (textBox1.Text == datak[i])
                {
                    richTextBox1.Text = richTextBox1.Text + datak[i + 1] + "\n" + "/commandline/input>";
                    System.Diagnostics.Process.Start(datak[i + 2]);
                }
            }
            textBox1.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "App install File|*.Zip";
            f.FileName = "";
            if (f.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("config\\Manger\\manger.exe", f.FileName+" "+"App_install");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("config\\downloader"))
            {
                System.Diagnostics.Process.Start("config\\downloader\\dwn1.exe");
            }
            else
            {
                MessageBox.Show("没有下载哦!", "Error 错误");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            打包 db = new 打包();

            db.Show();
        }
        public int dadada = 0;
        private void button11_Click(object sender, EventArgs e)
        {
            if (dadada % 2 == 1)
            {
                panel4.Visible = true;
                dadada++;
            }
            else
            {
                panel4.Visible = false;
                dadada++;
            }
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
           
        }
        public bool ison = false;
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            
        }
       
        private void panel4_Click(object sender, EventArgs e)
        {
            tr = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.fxtstudio.epizy.com/%e5%ba%94%e7%94%a8%e5%95%86%e5%ba%97/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            set s = new set();
            s.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void webKitBrowser1_Load(object sender, EventArgs e)
        {

        }

        private void webKitBrowser1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
