using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace control
{
    public partial class set : Form
    {
        public set()
        {
            InitializeComponent();
        }
        public int datan1 = 0;
        public string[] datan2;
        private void set_Load(object sender, EventArgs e)
        {
            string[] data1 = File.ReadAllLines("config\\config.Fcl");
            datan2 = data1;
            if(data1[1] == "Use dark.mode")
            {
                label2.Text = "On";
                datan1 = 1;
            }else
            {
                label2.Text = "Off";
                datan1 = 0;
            }
            richTextBox1.Text = File.ReadAllText("config\\introduce.Fcl", Encoding.Default);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(datan1 == 0)
            {
                label2.Text = "On";
                datan2[1] = "Use dark.mode";
                File.WriteAllLines("config\\config.Fcl", datan2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (datan1 == 1)
            {
                label2.Text = "Off";
                datan2[1] = "Use dark.mode.off";
                File.WriteAllLines("config\\config.Fcl", datan2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("controler 控制器 \n 版本 var 2.5 beta \n WTP的一员! \n our website 地址:http:\\fxtstudio.epizy.com");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string [] new1 = File.ReadAllLines("config\\saves\\setting.ini");
            new1[15] = "true";
            File.WriteAllLines("config\\saves\\setting.ini", new1);
            MessageBox.Show("完成了,即将重启App", "Done 完成");
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] new1 = File.ReadAllLines("config\\saves\\setting.ini");
            new1[15] = "false";
            File.WriteAllLines("config\\saves\\setting.ini", new1);
            MessageBox.Show("完成了,即将重启App", "Done 完成");
            Application.Restart();
        }
    }
}
