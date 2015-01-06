using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace tiff2ecw
{
    public partial class dbproperty : Form
    {
        public string dbconnstring;
        public dbproperty()
        {
            InitializeComponent();
            dbPassword.PasswordChar = '*';
            acldbpathLabel.Text = Properties.Settings.Default.acldbPath;
            imaginePathLabel.Text = Properties.Settings.Default.imaginePath;
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            

           

            string id = dbUsername.Text;
            string password = dbPassword.Text;
            string serverurl = dbHost.Text;
            string database = dbName.Text;
            dbconnstring=@"Data Source="+dbHost.Text+@"\"+dbInstance.Text+","+dbPort.Text+";Initial Catalog="+dbName.Text+";Integrated Security=false;User ID="+dbUsername.Text+";Password="+dbPassword.Text+";";


            SqlConnection myConn = new SqlConnection(dbconnstring);

            try
            {
                myConn.Open();
                submitBtn.Enabled = true;

                myConn.Close();
            }
            catch (SqlException sqle)
            {
                MessageBox.Show(sqle.Message);

            }




        }

        public delegate void returnvalue(string dbconstring);
        public returnvalue ReturnValue;

        private void submitBtn_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.connString = dbconnstring;
            Properties.Settings.Default.Save();

            //if (ReturnValue != null)
            //    ReturnValue(dbconnstring);
            //this.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            imaginePathLabel.Text=folderBrowserDialog1.SelectedPath;
            //label3.Text = folderBrowserDialog1.SelectedPath;
            //outputPath = folderBrowserDialog1.SelectedPath;
            //setImaginePathBtn.Enabled = true;
           // generateBatBtn.Enabled = true;

            //StreamReader imagepathreader = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"\\config.txt");


            // if(imagepathreader!=null)
            //   imagecommandpath = imagepathreader.ReadLine();
            Properties.Settings.Default.imaginePath = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.Save();
        }

        private void dbproperty_Load(object sender, EventArgs e)
        {





        }

        private void setACLDBBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "ACL Database (.mdb)|*.mdb|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;


            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.acldbPath = openFileDialog1.FileName;
                Properties.Settings.Default.Save();
                acldbpathLabel.Text = Properties.Settings.Default.acldbPath;

            }
        }
    }
}