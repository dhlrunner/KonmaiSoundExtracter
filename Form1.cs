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
using NAudio;

namespace KonmaiSoundExtracter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isdeffileexist = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
        void load_s3p(string path)
        {

            bool isdef = false;
            isdeffileexist = isdef;
            string[] def = null;
            try
            {
                def = File.ReadAllLines(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + ".def");
                isdef = true;
                isdeffileexist = isdef;
            }
            catch(FileNotFoundException)
            {
                toolStripStatusLabel1.Text = "def file is not exist.";
            }
            catch
            {
                toolStripStatusLabel1.Text = "def file load failed.";
            }
            using (BinaryReader s3preader = new BinaryReader(File.OpenRead(path)))
            {
                listView1.Items.Clear();
                string sig = Encoding.ASCII.GetString(s3preader.ReadBytes(4));
                if(sig != "S3P0")
                {
                    MessageBox.Show("Not Vaild s3p.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                uint wmvcount = s3preader.ReadUInt32();
                uint s3p0headersize = s3preader.ReadUInt32();
                s3preader.BaseStream.Seek(s3p0headersize, SeekOrigin.Begin);
                if(s3preader.ReadUInt32() != 810955603)// check sig "S3V0"
                {
                    MessageBox.Show("Not Vaild s3p.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }                
                for(int i=0; i<wmvcount; i++)
                {
                    uint s3v0headersize = s3preader.ReadUInt32();
                    uint wmasize = s3preader.ReadUInt32();
                    s3preader.BaseStream.Seek((s3v0headersize+wmasize)-8,SeekOrigin.Current);
                    string wmaname = "-";
                    if (isdef)
                    {
                        for (int k = 0; k < def.Length; k++)
                        {
                            if (def[k].Split().Count() >= 2)
                            {
                                int index = int.Parse(def[k].Split()[2]);
                                string name = def[k].Split()[1];
                                if (index == i)
                                    wmaname = name;
                            }
                        }
                    }                  
                    listView1.Items.Add(new ListViewItem(new string[] { i.ToString(),wmaname,"wma",wmasize.ToString() })) ;
                }
                extractbutton.Enabled = true;
            }
        }

        private void openaudiobutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                load_s3p(openFileDialog1.FileName);
                filepathtextBox.Text = openFileDialog1.FileName;
            }
        }

        private void extractbutton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Path.GetDirectoryName(filepathtextBox.Text);
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] argument = new string[] { filepathtextBox.Text, folderBrowserDialog1.SelectedPath };
                backgroundWorker1.RunWorkerAsync(argument);
            }
        }
        void extract_s3p (string infilepath,string outfilepath,bool isdef)
        {
            extractbutton.Enabled = false;
            string path = infilepath;
            string[] def = null;
            if (isdef)
            {
                def = File.ReadAllLines(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + ".def");
            }

            using (BinaryReader s3preader = new BinaryReader(File.OpenRead(path)))
            {
                string sig = Encoding.ASCII.GetString(s3preader.ReadBytes(4));
                if (sig != "S3P0")
                {
                    MessageBox.Show("Not Vaild s3p.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                uint wmacount = s3preader.ReadUInt32();
                uint s3p0headersize = s3preader.ReadUInt32();
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Maximum = (int)wmacount;
                s3preader.BaseStream.Seek(s3p0headersize, SeekOrigin.Begin);              
                for (int i = 0; i < wmacount; i++)
                {
                    if (s3preader.ReadUInt32() != 810955603) // check sig "S3V0"
                    {
                        MessageBox.Show("Not Vaild s3p.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    uint s3v0headersize = s3preader.ReadUInt32();
                    uint wmasize = s3preader.ReadUInt32();
                    //s3preader.BaseStream.Seek((s3v0headersize + wmasize) - 8, SeekOrigin.Current);
                    string wmaname = i.ToString() + ".wma";
                    if (isdef)
                    {
                        for (int k = 0; k < def.Length; k++)
                        {
                            if (def[k].Split().Count() >= 2)
                            {
                                int index = int.Parse(def[k].Split()[2]);
                                string name = def[k].Split()[1];
                                if (index == i)
                                    wmaname = name+".wma";
                            }
                        }
                    }
                    using (BinaryWriter wmawriter = new BinaryWriter(File.Create(outfilepath+"\\"+wmaname)))
                    {
                        s3preader.BaseStream.Seek(s3v0headersize-12, SeekOrigin.Current);
                        wmawriter.Write(s3preader.ReadBytes((int)wmasize));
                    }
                    toolStripProgressBar1.Value = i+1;

                }
                toolStripStatusLabel1.Text = "Completed!";
                extractbutton.Enabled = true;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] arg = (string[])e.Argument;
            extract_s3p(arg[0], arg[1], isdeffileexist);
        }
    }
}
