using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSecurity
{
    public partial class Form1 : Form
    {
        private string FileDirectory = "";
        private byte[] fileInfo;

        public Form1()
        {
            InitializeComponent();

            textBox4.PasswordChar = '*';
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
        
                FileDirectory = textBox1.Text = openFileDialog1.FileName;
                fileInfo = ReadFile();
                ShowFileText(fileInfo);
            }
        }

        public byte[] ReadFile()
        {
            byte[] fileInfo = new byte[0];
            if (File.Exists(FileDirectory))
                fileInfo = File.ReadAllBytes(FileDirectory);
            else
                MessageBox.Show("Wrong file location.");
            return fileInfo;
        }
        public void ShowFileText(byte[] file)
        {
            string Text = ASCIIEncoding.Default.GetString(file);
            textBox2.Clear();
            textBox2.AppendText(Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Select(0, 0);
            textBox2.ScrollToCaret();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileInfo == null)
            {
                MessageBox.Show("Please select the file.");
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.Title = "Save File";
            dialog.FileName = "file.dat";
            dialog.DefaultExt = "txt";
            dialog.Filter = "Text files (*.txt)|*.txt|Data files (*.dat)|*.dat*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var SaveDirectory = dialog.FileName;
               
                textBox3.Text = SaveDirectory;
                if (SaveDirectory.EndsWith(".dat") || SaveDirectory.EndsWith(".txt"))
                {
                    File.WriteAllBytes(SaveDirectory, fileInfo);
                    return;
                }
                else
                {
                    switch (dialog.FilterIndex)
                    {
                        case 1://.txt
                            {
                                SaveDirectory = SaveDirectory.Split('.')[0];
                                SaveDirectory += ".txt";
                                File.WriteAllBytes(SaveDirectory, fileInfo);
                                break;
                            }
                        case 2://.dat
                            {
                                SaveDirectory = SaveDirectory.Split('.')[0];
                                SaveDirectory += ".dat";
                                File.WriteAllBytes(SaveDirectory, fileInfo);
                                break;
                            }
                        default:
                            {
                                File.WriteAllBytes(SaveDirectory, fileInfo);
                                break;
                            }
                    }
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fileInfo == null)
            {
                MessageBox.Show("Please select the file.");
                return;
            }
            var passord = textBox4.Text;
            var key = KeyExchange.ProcessPassword(ASCIIEncoding.Default.GetBytes(passord));

            Crypto crypt = new Crypto(key);
            crypt.Encrypt(fileInfo);
            ShowFileText(fileInfo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fileInfo == null)
            {
                MessageBox.Show("Please select the file.");
                return;
            }
            var passord = textBox4.Text;
            var key = KeyExchange.ProcessPassword(ASCIIEncoding.Default.GetBytes(passord));

            Crypto crypt = new Crypto(key);
            crypt.Decrypt(fileInfo);
            ShowFileText(fileInfo);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fileInfo = ReadFile();
            ShowFileText(fileInfo);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
