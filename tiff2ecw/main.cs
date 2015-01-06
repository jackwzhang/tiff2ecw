using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using BitMiracle.LibTiff.Classic;
using EGIS.ShapeFileLib;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Threading;  

namespace tiff2ecw
{
    public partial class Tiff2ECW : Form
    {
        public Tiff2ECW()
        {
            InitializeComponent();
        }

        public string dbconnstring;
        string outputPath ="c:\\";
        double angleHude = Math.PI / 180;
        List<string> filelist;
        List<string> processlist;
        List<int> isprocesslist;
        List<PointD[]> xys;


        public static List<string> GetFiles1(DirectoryInfo directory, string pattern)
        {

            List<string> result = new List<string>();
            int num = 0;

            try
            {
                foreach (FileInfo info in directory.GetFiles())
                {
                    if (info.Name.ToLower().IndexOf(".tif") - info.Name.Length + 4 == 0 && info.Name.ToLower().Contains(".tif"))
                    {
                        result.Add(info.FullName.ToString());
                    }
                    num++;
                }
            }
            catch
            { }


            //foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            //{

            //    try
            //    {
            //       result.AddRange(GetFiles1(subDirectory, pattern));

            //    }
            //    catch
            //    { }



            //}

            return result;
        }

        public static List<string> GetFiles2(DirectoryInfo directory, string pattern)
        {

            List<string> result = new List<string>();
            int num = 0;

            try
            {
                foreach (FileInfo info in directory.GetFiles())
                {
                    if (info.Name.IndexOf(pattern) - info.Name.Length + 4 == 0 && info.Name.Contains(pattern))
                    {
                        result.Add(info.FullName.ToString());
                    }
                    num++;
                }
            }
            catch
            { }


            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {

                try
                {
                    result.AddRange(GetFiles2(subDirectory, pattern));

                }
                catch
                { }



            }

            return result;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (tiffListBox != null)
                tiffListBox.Items.Clear();
            if (processlist != null)
            { processlist.Clear(); isprocesslist.Clear(); }

            gridSelectData.Rows.Clear();

            if (selectInputFolderDialog.ShowDialog() == DialogResult.OK)
            {



                filelist = GetFiles1(new DirectoryInfo(selectInputFolderDialog.SelectedPath), ".tif");

                int ii = 0;
                foreach (string file in filelist)
                {
                    tiffListBox.Items.Add(filelist[ii++]);
                }

                label3.Text = selectInputFolderDialog.SelectedPath + " has " + filelist.Count + " tiff files pending processing";
                if (filelist.Count > 0)
                    //databaseSettingBtn.Enabled = true;
                    queryDatabaseBtn.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label3.Text = folderBrowserDialog1.SelectedPath;
            outputPath = folderBrowserDialog1.SelectedPath;
            //setImaginePathBtn.Enabled = true;
            generateThumbnails.Enabled = true;
            generateBatBtn.Enabled = true;

            //StreamReader imagepathreader = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"\\config.txt");


            // if(imagepathreader!=null)
            //   imagecommandpath = imagepathreader.ReadLine();
            imagecommandpath = Properties.Settings.Default.imaginePath;
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void button5_Click(object sender, EventArgs e)
        {
            processlist = new List<string>();
            isprocesslist = new List<int>();

            //StreamReader connstringreader = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\config.txt");
            //dbconnstring = connstringreader.ReadLine();
            // dbconnstring = connstringreader.ReadLine();
            dbconnstring = Properties.Settings.Default.connString;
            //MessageBox.Show(dbconnstring);
            using (SqlConnection connection = new SqlConnection(dbconnstring))
            {
                connection.Open();

                int missedPhotoNumber = 0;
                int j = 0;
                xys = new List<PointD[]>();
                foreach (string file in filelist)
                {
                    string filepath = file.Substring(0, file.LastIndexOf("\\") + 1);
                    string filename = file.Substring(file.LastIndexOf("\\") + 1);
                    filename = filename.Substring(0, filename.IndexOf(".tif"));

                    string queryString = "SELECT CONVERT(FLOAT,[PHOTOSCALE_AS]),[EASTING_PH],[NORTHING_PH],[PHOTO_ROTATION],CONVERT(FLOAT, [HEIGHT_PH])   FROM [mapd] WHERE  [PHOTO_SCANNED] ='" + filename + "';";

                    SqlCommand myCommand = new SqlCommand(queryString, connection);

                    SqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        double gsd = 0; double a = 0; double b = 0; double c = 0; double d = 0; double ee = 0; double f = 0;
                        double scale = reader.GetDouble(0); double angle = 0;

                        gsd = double.Parse(gsdbox.Text) * (1 + double.Parse(marginbox.Text) / 100) * scale * 0.000001;
                        //  if (reader.GetDouble(3)>0)
                        angle = reader.GetDouble(3);



                        Tiff image = Tiff.Open(file, "r");

                        FieldValue[] value = image.GetField(TiffTag.IMAGEWIDTH);
                        int width = value[0].ToInt() / 2;

                        value = image.GetField(TiffTag.IMAGELENGTH);
                        int height = value[0].ToInt() / 2;



                        //MessageBox.Show(string.Format("Width = {0}, Height = {1}",              width, height), "TIFF properties");
                        //double filmsize = 9 * 0.0254;
                        //double flength = reader.GetDouble(5)/1000;
                        //double flightheight = reader.GetDouble(4) ;


                        a = gsd * Math.Cos((angle) * angleHude);
                        b = gsd * Math.Sin((angle) * angleHude) * (-1);
                        c = gsd * Math.Sin((angle) * angleHude) * (-1);
                        d = gsd * Math.Cos((angle) * angleHude) * (-1);


                        ee = -width * gsd * Math.Cos(angleHude * angle) + height * gsd * Math.Sin(angleHude * angle) + reader.GetDouble(1);
                        f = width * gsd * Math.Sin(angleHude * angle) + height * gsd * Math.Cos(angleHude * angle) + reader.GetDouble(2);
                        


                        double[] xy1 = new double[2];
                        double[] xy2 = new double[2];
                        double[] xy3 = new double[2];
                        double[] xy4 = new double[2];


                        double x2 = width * gsd * Math.Cos(angleHude * angle) - height * gsd * Math.Sin(angleHude * angle) + reader.GetDouble(1);
                        double y2 = -width * gsd * Math.Sin(angleHude * angle) - height * gsd * Math.Cos(angleHude * angle) + reader.GetDouble(2);
                        double x3 = width * gsd * Math.Cos(angleHude * angle) + height * gsd * Math.Sin(angleHude * angle) + reader.GetDouble(1);
                        double y3 = -width * gsd * Math.Sin(angleHude * angle) + height * gsd * Math.Cos(angleHude * angle) + reader.GetDouble(2);
                        double x4 = -width * gsd * Math.Cos(angleHude * angle) - height * gsd * Math.Sin(angleHude * angle) + reader.GetDouble(1);
                        double y4 = width * gsd * Math.Sin(angleHude * angle) - height * gsd * Math.Cos(angleHude * angle) + reader.GetDouble(2);


                        gridSelectData.Rows.Add(false, reader.GetDouble(0), gsd, angle, file, a.ToString("0.00000"), b.ToString("0.00000"), c.ToString("0.00000"), d.ToString("0.00000"), ee.ToString("0.00000"), f.ToString("0.00000"));

                        processlist.Add(file);


                        if (angle < 1||angle>359)
                            isprocesslist.Add(2);
                        else if (scale > 10 && height > 3)
                        {
                            isprocesslist.Add(0);
                        }
                        else
                        {
                            isprocesslist.Add(1); missedPhotoNumber++;
                        }



                        createTFWBtun.Enabled = true;


                        List<double[]> lxy = new List<double[]>();
                        lxy.Add(xy1);
                        lxy.Add(xy2);
                        lxy.Add(xy3);
                        lxy.Add(xy4);
                        PointD p1 = new PointD(ee, f);
                        PointD p2 = new PointD(x2, y2);
                        PointD p3 = new PointD(x3, y3);
                        PointD p4 = new PointD(x4, y4);
                        PointD[] ps = new PointD[4];
                        ps[0] = p1;
                        ps[1] = p4;
                        ps[2] = p2;
                        ps[3] = p3;
                        xys.Add(ps);


                    }

                    label3.Text = processlist.Count + " file found in DB, " + (filelist.Count - processlist.Count) + " files not found in Database, " + missedPhotoNumber + " images  ignored due to abnormal Flying Height and Scale ";

                    reader.Close();
                }

                if (missedPhotoNumber > 0)
                    MessageBox.Show(missedPhotoNumber + " images have ignored due to abnormal Flying Height and Scale");

                connection.Close();
                queryDatabaseBtn.Enabled = true;

                generateThumbnails.Enabled = true;
                setOutputBtn.Enabled = true;


            }

        }


        private void button2_Click(object sender, EventArgs e)
        {


            int n = 0;
            foreach (string path in processlist)
            {
                ShapeFileWriter sfw;
                DbfFieldDesc[] fieldDescs = new DbfFieldDesc[2];
                fieldDescs[0].FieldName = "id";
                fieldDescs[1].FieldName = "PhotoNo";
                fieldDescs[0].FieldType = DbfFieldType.Number;
                fieldDescs[1].FieldType = DbfFieldType.Character;

                string filepath = path.Substring(0, path.LastIndexOf("\\") + 1);
                string filename = path.Substring(path.LastIndexOf("\\") + 1);
                filename = filename.Substring(0, filename.IndexOf(".tif"));

                sfw = ShapeFileWriter.CreateWriter(filepath, filename, ShapeType.Polygon, fieldDescs);
                try
                {
                    string[] fd = new string[2];
                    fd[0] = "2";
                    fd[1] = "sss";
                    sfw.AddRecord(xys[n], 4, fd);

                }
                finally
                {
                    //close the shapefile, shapefilewriter and dbfreader
                    sfw.Close();
                }


                using (TextWriter writer = File.CreateText(path.Replace(".tif", ".tfw")))
                {
                    DataGridViewRow r = gridSelectData.Rows[n];
                    for (int m = 5; m < r.Cells.Count; m++)
                    {
                        writer.WriteLine(r.Cells[m].Value);
                    }
                    writer.Close();

                }
                n++;
            }
            setOutputBtn.Enabled = true;

        }



        private void button6_Click(object sender, EventArgs e)
        {
            dbproperty f1 = new dbproperty();

            f1.ReturnValue = new dbproperty.returnvalue(showvalue);
            f1.Show();


        }
        private void showvalue(string i)
        {

            dbconnstring = i;
            queryDatabaseBtn.Enabled = true;


        }

        public string tiff2ecwBat;
        public string tiff2ecwBatpath;
        private void button7_Click(object sender, EventArgs e)
        {

            tiff2ecwBat = "";
            List<string> scripts = new List<string>();
            int n = 0;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Batch files (*.bat)|*.bat";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    tiff2ecwBatpath = sfd.FileName;
                }
            }

            //string logfilename = tiff2ecwBatpath.Substring(tiff2ecwBatpath.LastIndexOf("\\") + 1);
            int n2 = processlist.Count;
            int n3 = 0;
            tiff2ecwBat += "@echo off" + "\n";
            tiff2ecwBat += "set imageCMD=\"" + imagecommandpath + "\\bin\\win32release\\imagecommand.exe\" \n";
            tiff2ecwBat += "set ECWexporter=\"" + imagecommandpath + "\\bin\\x64URelease\\exportecw.exe\" \n";
            tiff2ecwBat += "echo %DATE% %TIME% Start Converting & ECHO %DATE% %TIME% : Start Converting " + n2 + " tif images to ECW  >" + tiff2ecwBatpath + "_log.txt \n";
            string spacer = "ECHO ************************************************ & @ECHO ************************************************ >>" + tiff2ecwBatpath + "_log.txt \n";

            List<string> missedphotolist = new List<string>();
            foreach (string path in processlist)
            {

                string filename = path.Substring(path.LastIndexOf("\\") + 1);
                if (isprocesslist[n] == 1)
                {
                    missedphotolist.Add(filename.Replace(".tif", ".ecw")); n++;
                }
                else
                {
                    tiff2ecwBat += spacer;
                    tiff2ecwBat += "ECHO %DATE% %TIME% : Start Converting \"" + filename.Replace(".tif", ".ecw") + "\" , please wait... & ECHO %DATE% %TIME% : Start Converting \"" + filename.Replace(".tif", ".ecw") + "\" >>" + tiff2ecwBatpath + "_log.txt \n";

                    tiff2ecwBat += "%ECWexporter% -inputfilename '" + path + "' -outputfilename '" + outputPath + @"\" + filename.Replace(".tif", ".ecw") + ((photointerpComboBox.SelectedItem.ToString().Equals("RGB")) ? "' -bands 1 2 3 -photointerp RGB " : "' -photointerp Grayscale ") + "-blocksize 256  -compratio 10 -ecwversion 2 " + ((isprocesslist[n] == 2) ? "" : "-orienttomap") + " -vecfile '" + path.Replace(".tif", ".shp") + "'\n";

                    //  tiff2ecwBat += "%ECWexporter% -inputfilename '" + path + "' -outputfilename '" + outputPath + @"\" + filename.Replace(".tif", ".ecw") + ((photointerpComboBox.SelectedItem.ToString().Equals("RGB")) ? "' -bands 1 2 3 -photointerp RGB " : "' -photointerp Grayscale ") + "-blocksize 256  -compratio 10 -ecwversion 2 -orienttomap -vecfile '" + path.Replace(".tif", ".shp") + "'\n";

                    tiff2ecwBat += "%imageCMD% '" + outputPath + @"\" + filename.Replace(".tif", ".ecw") + "' -projection '" + imagecommandpath + "\\etc\\projections\\epsg.plb' 'Hong Kong 1980 Grid System (2326)' -meter imagecommand\n";

                    tiff2ecwBat += "del " + path.Replace(".tif", ".cpg") + " & del " + path.Replace(".tif", ".dbf") + " & del " + path.Replace(".tif", ".shp") + " & del " + path.Replace(".tif", ".tfw") + " & del " + path.Replace(".tif", ".shx") + " & del " + outputPath + @"\" + filename.Replace(".tif", "_mask_1.ecw") + "\n";

                    tiff2ecwBat += "ECHO %DATE% %TIME% : " + (n3 + 1) + " of " + n2 + " images , " + filename.Replace(".tif", ".ecw") + " Converted Successfully & ECHO %DATE% %TIME% : " + (n + 1) + " of " + n2 + " images , " + filename.Replace(".tif", ".ecw") + " Converted Successfully >>" + tiff2ecwBatpath + "_log.txt \n";
                    n++;
                    n3++;
                    tiff2ecwBat += spacer;
                }
            }
            tiff2ecwBat += "ECHO %DATE% %TIME% : " + n3 + " images processed , " + (n - n3) + " missed & ECHO %DATE% %TIME% : " + n3 + " images processed, " + (n - n3) + " missed >>" + tiff2ecwBatpath + "_log.txt \n";

            tiff2ecwBat += spacer;
            tiff2ecwBat += "ECHO MISSED Images are listed below:>>" + tiff2ecwBatpath + "_log.txt \n";

            tiff2ecwBat += spacer;
            foreach (string missedfilename in missedphotolist)
            {
                tiff2ecwBat += "ECHO " + missedfilename + ">>" + tiff2ecwBatpath + "_log.txt \n";

            }
            tiff2ecwBat += "start notepad " + tiff2ecwBatpath + "_log.txt \n";
            tiff2ecwBat += "exit";

            File.WriteAllText(tiff2ecwBatpath, tiff2ecwBat);

            runBtn.Enabled = true;
            runScriptBtn.Enabled = true;

        }

        DateTime t1;
        string tf2ecwpt;
        private void button8_Click(object sender, EventArgs e)
        {

            int n = 0;
            //   progressBar1.Visible = true;
            //   progressBar1.Maximum = processlist.Count;


            int selectedRow = gridSelectData.SelectedRows[0].Index;

            Process p = new Process();
            Process p2 = new Process();
            string path = processlist[selectedRow];

            string filename = path.Substring(path.LastIndexOf("\\") + 1);

            p.StartInfo.FileName = imagecommandpath + "\\bin\\x64URelease\\exportecw.exe";
            String param = "-inputfilename " + path + " -outputfilename " + outputPath + @"\" + filename.Replace(".tif", ".ecw") + ((photointerpComboBox.SelectedItem.ToString().Equals("RGB")) ? " -bands 1 2 3 -photointerp RGB " : " -photointerp Grayscale ") + "-blocksize 256  -compratio 10 -ecwversion 2 -orienttomap -vecfile " + path.Replace(".tif", ".shp") + "";

            p.StartInfo.Arguments = param;//启动参数       
            p.Start();//启动     

            p.WaitForExit();
            String param2 = outputPath + @"\" + filename.Replace(".tif", ".ecw") + "' -projection '" + imagecommandpath + "\\etc\\projections\\epsg.plb' 'Hong Kong 1980 Grid System (2326)' -meter imagecommand\n";
            p2.StartInfo.FileName = imagecommandpath + "\\bin\\win32release\\imagecommand.exe";
            p2.StartInfo.Arguments = param;//启动参数       
            p2.Start();//启动  
            p2.WaitForExit();
            MessageBox.Show("finished");


            //foreach (string path in processlist)
            //{

            //    Process p = new Process();
            //    Process p2 = new Process();
            //    label3.Text = "Converting " + n + " of " + processlist.Count + " images";
            //    string filename = path.Substring(path.LastIndexOf("\\") + 1);
            //    p.StartInfo.FileName = imagecommandpath + "\\bin\\x64URelease\\exportecw.exe";  
            //    String param = "-inputfilename " + path + " -outputfilename " + outputPath + @"\" + filename.Replace(".tif", ".ecw") + ((photointerpComboBox.SelectedItem.ToString().Equals("RGB")) ? " -bands 1 2 3 -photointerp RGB " : " -photointerp Grayscale ") + "-blocksize 256  -compratio 10 -ecwversion 2 -orienttomap -vecfile " + path.Replace(".tif", ".shp") + "";

            //    p.StartInfo.Arguments = param;//启动参数       
            //    p.Start();//启动     
            //    while (!p.HasExited)
            //    {

            //    }
            //    String param2 = outputPath + @"\" + filename.Replace(".tif", ".ecw") + "' -projection '" + imagecommandpath + "\\etc\\projections\\epsg.plb' 'Hong Kong 1980 Grid System (2326)' -meter imagecommand\n";
            //    p2.StartInfo.FileName = imagecommandpath + "\\bin\\win32release\\imagecommand.exe";
            //    p2.StartInfo.Arguments = param;//启动参数       
            //    p2.Start();//启动  
            //    p2.WaitForExit(3000);
            // //   progressBar1.Value++;
            //    n++;

            //}



        }

        void RunWithRedirect(string cmdPath)
        {

            var proc = new Process();
            proc.StartInfo.FileName = cmdPath;
            proc.StartInfo.WorkingDirectory = cmdPath.Substring(0, cmdPath.LastIndexOf("\\") + 1); ;
            // set up output redirection
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.EnableRaisingEvents = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            // see below for output handler
            proc.ErrorDataReceived += proc_DataReceived;
            proc.OutputDataReceived += proc_DataReceived;

            proc.Start();

            proc.BeginErrorReadLine();
            proc.BeginOutputReadLine();

            proc.WaitForExit();

        }

        int processed = 2;
        TimeSpan processingTime;
        string label3text;
        void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data.IndexOf("Converted Successfully") > 0)
            {
                processingTime = DateTime.Now - t1;
                t1 = DateTime.Now;
                TimeSpan left = TimeSpan.FromTicks(processingTime.Ticks * (progressBar1.Maximum - processed + 1));
                label3text = processed + " of " + progressBar1.Maximum + " is being processing, About " + left.Hours.ToString() + "Hours " + left.Minutes.ToString() + "Minutes " + left.Seconds.ToString() + "sec left";

                //label3.Text = label3text;
                //progressBar1.Value = processed - 1;
                processed++;
            }
        }

        public string exportecwpath;
        public string imagecommandpath;

        private void button10_Click(object sender, EventArgs e)
        {
            if (selectInputFolderDialog.ShowDialog() == DialogResult.OK)
            {
                imagecommandpath = selectInputFolderDialog.SelectedPath;
                generateBatBtn.Enabled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabControl1.Visible = true;

        }

        private void runNowBtn_Click(object sender, EventArgs e)
        {
            //  int exitCode;
            ProcessStartInfo processInfo;
            Process process;
            if (tiff2ecwBatpath != null)
            {
                processInfo = new ProcessStartInfo("cmd.exe", "/c " + tiff2ecwBatpath);
                processInfo.CreateNoWindow = false;
                processInfo.UseShellExecute = false;
                // *** Redirect the output ***
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;

                //  runScriptBtn.Text = "Running";
                // Cursor = Cursors.WaitCursor;

                process = Process.Start(processInfo);
                // process.WaitForExit();

                // *** Read the streams ***
                //string output = process.StandardOutput.ReadToEnd();
                //string error = process.StandardError.ReadToEnd();

                //exitCode = process.ExitCode;

                //label3.Text = ("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
                //label3.Text = ("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
                //label3.Text = ("ExitCode: " + exitCode.ToString());
                //process.Close();

                // runScriptBtn.Text = "Run Script Now";
                tabControl1.Visible = false;

            }

        }

        private void runAtBtn_Click(object sender, EventArgs e)
        {


            if (tiff2ecwBatpath != null)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                p.StandardInput.AutoFlush = true;
                p.StandardInput.WriteLine("at " + timeH.Value + ":" + timeM.Value + " /interactive cmd /c \"cd\\&" + tiff2ecwBatpath + "\"");
                // p.WaitForExit();
                p.Close();
                MessageBox.Show("Job was schedule to run at " + timeH.Value + ":" + timeM.Value + " today!");
                tabControl1.Visible = false;

            }


        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbproperty f1 = new dbproperty();

            // f1.ReturnValue = new dbproperty.returnvalue(showvalue);
            f1.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void v105ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String changeLog = "";
            changeLog += "2014 - 4 - 2 build 2\n 1. Remove function scan sub-directory \n 2. added settings panel, Database connection string and Imagine Path can be setted at toolbar\n";
            //changeLog += "2014 - 4 - 2 \n 1. Remove function scan sub-directory \n 2. added settings panel, Database connection string and Imagine Path can be setted at toolbar\n";
            changeLog += "2014 - 4 - 4 build 4 \n 1. Ingore photos which photoscale and height under 10 in Database.\n";

            changeLog += "2014 - 4 - 7 build 5 \n 1. Fix bug in selecting abnormal images.\n";
            changeLog += "2014 - 4 - 10 build 6 \n 1. detect 0 rotation photos.\n 2. ingore images without center coordinates\n";
            changeLog += "2014 - 4 - 25 build 7 \n 1. add button to generate Thumnails\n";
            changeLog += "2014 - 5 - 5 build 8 \n 1. add button update ECW and Thumnails into database.\n";
            changeLog += "2014 - 5 - 12 build 10 \n 1. fixed bugs for images with rotation less than 1degree and larger than 359 degree.\n";
            changeLog += "2014 - 5 - 28 build 13 \n 1. fixed bugs for generation of thumnails.\n";
            changeLog += "2014 - 6 - 25 build 14 \n 1. thumnails and URL will updated after ECW path updated.\n";
            changeLog += "2014 - 9 - 25 build 15 \n 1. System log report function has added\n";
            changeLog += "2014 - 11 - 21 build 15 \n 1. System log report function has added\n";
            MessageBox.Show(changeLog);

        }

        private void generateThumnail_Click(object sender, EventArgs e)
        {

           
            ArrayList iProcesslist = new ArrayList();
            for (int n = 0; n < processlist.Count; n++)
            {
                DataGridViewRow r = gridSelectData.Rows[n];
                iProcesslist.Add(new String[] { processlist[n], r.Cells[3].Value.ToString() });
            
            }
            Thread myThread = new Thread(convertThumnailsWorker);
            myThread.IsBackground = false;
            myThread.Start(iProcesslist); //线程开始
            generateThumbnails.Enabled = false;

        }

        private delegate void myUICallBack(string myStr, Control ctl);
        private void myUI(string myStr, Control ctl)
        {
            if (this.InvokeRequired)
            {
                myUICallBack myUpdate = new myUICallBack(myUI);
                this.Invoke(myUpdate, myStr, ctl);
            }
            else
            {
                ctl.Text = myStr;
                if (myStr.Contains("Thumnails conversion Finished")) generateThumbnails.Enabled = true;
            }
        }

        private void convertThumnailsWorker(object iProcesslist)
        {
            int n=0;
            dbconnstring = Properties.Settings.Default.connString;
            using (SqlConnection connection = new SqlConnection(dbconnstring))
            {
                try
                {
                    connection.Open();

                    foreach (string[] path in (ArrayList)iProcesslist)
                    {
                        Image image = System.Drawing.Image.FromFile(path[0]);
                        Image thumbnailImage = image.GetThumbnailImage(Properties.Settings.Default.thumbnailSize, Properties.Settings.Default.thumbnailSize, null, new IntPtr());
                        string filename = path[0].Substring(path[0].LastIndexOf("\\") + 1);
                        filename = filename.Substring(0, filename.IndexOf(".tif"));
                        float angle = float.Parse(path[1]);
                       // thumbnailImage = RotateImg(new Bitmap(thumbnailImage), angle, Color.White);
                        thumbnailImage.Save(outputPath + "\\" + filename + "_.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Image image2 = System.Drawing.Image.FromFile(outputPath + "\\" + filename + "_.jpg");
                        Image image2r = RotateImg(new Bitmap(image2), angle, Color.White);
                        image2r.Save(outputPath + "\\" + filename + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        try
                        {
                            File.Delete(outputPath + "\\" + filename + "_.jpg");
                        }
                        catch (Exception e1) { }
                           n++;
                        myUI(n+" Thumbnails Converted",label3);
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.ToString());
                }
                myUI("Thumnails conversion Finished", label3);
                MessageBox.Show(n + " thumbnail images generated!");
                connection.Close();

            }
        }



        public bool ThumbnailCallback()
        {
            return true;
        }


        public static Bitmap RotateImg(Bitmap bmp, float angle, Color bkColor)
        {
            int w = bmp.Width;
            int h = bmp.Height;
            PixelFormat pf = default(PixelFormat);
            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }

            Bitmap tempImg = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tempImg);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            //Using System.Drawing.Drawing2D.Matrix class 
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);
            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf);
            g = Graphics.FromImage(newImg);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tempImg, 0, 0);
            g.Dispose();
            tempImg.Dispose();
            return newImg;
        }

        private void updateDatabseBtn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog selectECW = new FolderBrowserDialog();
            if (selectECW.ShowDialog() == DialogResult.OK)
            {


                filelist = GetFiles2(new DirectoryInfo(selectECW.SelectedPath), ".ecw");
                if (MessageBox.Show("Upgrade " + filelist.Count + " ECW's path to database?", "Update ECW path to database", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {

                    dbconnstring = Properties.Settings.Default.connString;
                    using (SqlConnection connection = new SqlConnection(dbconnstring))
                    {
                       
                            connection.Open();

                            foreach (string file in filelist)
                            {
                                string filename = file.Substring(file.LastIndexOf("\\") + 1);
                                filename = filename.Substring(0, filename.IndexOf(".ecw"));
                                SqlCommand updateDbCmd = new SqlCommand("UPDATE mapd set PATH_ECW_PH = '" + file + "' WHERE PHOTO_SCANNED = '" + filename + "';", connection);
                                updateDbCmd.ExecuteNonQuery();
                                SqlCommand updateDbCmd2 = new SqlCommand(@"update MAPD set ECW_URL = CONCAT('/APOLLO-Catalog/DAP',(REPLACE(SUBSTRING(PATH_ECW_PH,charindex('\',PATH_ECW_PH,charindex('\',PATH_ECW_PH,4)+1),1000),'\','/'))) WHERE PHOTO_SCANNED ='" + filename + "';UPDATE MAPD SET PATH_THUMBNAIL=REPLACE(CONCAT('/thumbnail/',substring(ecw_url,21,1000)),'ecw','jpg') WHERE PHOTO_SCANNED ='" + filename + "';", connection);
                                updateDbCmd2.ExecuteNonQuery();
                       

                            }

       
                        MessageBox.Show("ECW Path, Thumnails Path and ECW_URL updated!\nPlease make sure Thumnails were placed to E:/ERDAS APOLLO/Thumbnails/[YYYY]/[BOXNO]/[PHOTONO].jpg\n");

                        connection.Close();

                    }




                }
            }





            
        }

        private void subsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OpenFileDialog selectRaster = new OpenFileDialog();

            // Set filter options and filter index.
            selectRaster.Filter = "Text Files (.tif)|*.tif|All Files (*.*)|*.*";
            selectRaster.FilterIndex = 1;

            selectRaster.Multiselect = false;

            if (selectRaster.ShowDialog() == DialogResult.OK)
            {

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = true;
                startInfo.FileName = @"C:\Program Files\GDAL\gdal_translate.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = "-projwin 817125.43321 809035.694865 817961.71125 808444.273007 -of HFA " + selectRaster.FileName+ " D:/Users/jack/Desktop/temp/T3.ecw";

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                        MessageBox.Show("finished");
                    }
                }
                catch
                {
                    // Log error.
                }

            
            
            
            
            }


        }

        private void updateMAPDBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcelFileDialog = new OpenFileDialog();
            openExcelFileDialog.Filter = "Excel 2007 (.Xls)|*.xls|Excel 2010+ (.Xlsx)|*.xlsx|All Files (*.*)|*.*";
            openExcelFileDialog.FilterIndex = 1;

            openExcelFileDialog.Multiselect = false;
            if (openExcelFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelToDS(openExcelFileDialog.FileName);
            }
        }



        public DataTable ExcelToDS(string Path)
        {
            string strConn = "Provider = Microsoft.ACE.OLEDB.12.0;Persist Security Info=True; Data Source =" + Path + ";Extended Properties ='Excel 12.0;HDR=YES;'";
            OleDbConnection connExcel = new OleDbConnection(strConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT PHOTO_SCANNED,PHOTO_FLIGHT_INDEX_AS,FORMAT([DATE_FLIGHT_AS], 'MM/dd/yyyy') as DATE_FLIGHT_AS,LOCATION_AS,LOCATION_CHIN_AS,SHEET_NO_AS,PHOTOSCALE_AS,OBLIQUE_AS,[L/R_AS],HEADING_AS,CAMERA_OPERATOR_AS,FLIGHT_MISSION_AS,SORTIE_NO_AS,BOX_NO_AS,FRAME_COUNTER_NO_AS,CAMERA_AS,SPECTRAL_BAND_AS,FILM_TYPE_NUMBER_AS,FLENGTH_AS,APPROX_EASTING_AS,APPROX_NORTHING_AS,APPROX_FLYING_HT_AS,APPROX_TILT_AS,APPROX_SWING_AS,APPROX_AZIMUTH_AS,RESTRICTED_AS,SINGLE_AS,IN_FLIGHT_INDEX_AS,VALIDITY_AS,SCANNER_PH,SCAN_RESOLUTION_MICROMETER_PH,FORMAT([SCAN_DATE_PH], 'MM/dd/yyyy') as SCAN_DATE_PH,DAP_MEAS_PH,DAMAGED_PH,SCRATCHED_PH,REDUCED_FILM_PH,DUPLICATED_FILM_PH,PARTIAL_FILM_PH,MISSING_FIDUCIAL_MARKS_PH,DOUBLE_EXPOSURE_PH,PATH_HI_RES_PH,ARCHIVE_PATH_HI_RES_PH,ARCHIVE_TAPE_NO_PH,CALIBRATED_FOCAL_LENGTH_PH,FORMAT([DATE_OF_CALIBRATION_PH], 'MM/dd/yyyy') as DATE_OF_CALIBRATION_PH,EASTING_PH,NORTHING_PH,HEIGHT_PH,OMEGA_PH,PHI_PH,KAPPA_PH,CF_PH,AMENDMENT,AMENDMENT_HISTORY,REMARKS_AS,REMARKS_PH,PHOTO_ROTATION From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            string cmdText1 = @"INSERT into isss.dbo.mapd ([PHOTO_SCANNED],[PHOTO_FLIGHT_INDEX_AS],[DATE_FLIGHT_AS],[LOCATION_AS],[LOCATION_CHIN_AS] ,[SHEET_NO] ,[PHOTOSCALE_AS] ,[OBLIQUE_AS] ,[LR_AS] ,[HEADING_AS] ,[CAMERA_OPERATOR_AS] ,[FLIGHT_MISSION_AS] ,[SORTIE_NO_AS] ,[BOX_NO_AS] ,[FRAME_COUNTER_NO_AS] ,[CAMERA_AS] ,[SPECTRAL_BAND_AS] ,[FILM_TYPE_NUMBER_AS] ,[FLENGTH_AS] ,[APPROX_EASTING_AS] ,[APPROX_NORTHING_AS] ,[APPROX_FLYING_HT_AS] ,[APPROX_TILT_AS] ,[APPROX_SWING_AS] ,[APPROX_AZIMUTH_AS] ,[RESTRICTED_AS] ,[SINGLE_AS] ,[IN_FLIGHT_INDEX_AS] ,[VALIDITY_AS] ,[SCANNER_PH] ,[SCAN_RESOLUTION_MICROMETER_PH] ,[SCAN_DATE_PH] ,[DAP_MEAS_PH] ,[DAMAGED_PH] ,[SCRATCHED_PH] ,[REDUCED_FILM_PH] ,[DUPLICATED_FILM_PH] ,[PARTIAL_FILM_PH] ,[MISSING_FIDUCIAL_MARKS_PH] ,[DOUBLE_EXPOSURE_PH] ,[PATH_HI_RES_PH] ,[ARCHIVE_PATH_HI_RES_PH] ,[ARCHIVE_TAPE_NO_PH] ,[CALIBRATED_FOCAL_LENGTH_PH] ,[DATE_OF_CALIBRATION_PH]  ,[OMEGA_PH] ,[PHI_PH] ,[KAPPA_PH] ,[CF_PH] ,[AMENDMENT] ,[AMENDMENT_HISTORY] ,[REMARKS_AS] ,[REMARKS_PH],[PHOTO_ROTATION],[YEAROFFLIGHT] ,[EXTENT_GEOM] ,[CENTER_GEOM],[INFRARED],[EASTING_PH] ,[NORTHING_PH] ,[HEIGHT_PH],[HEIGHT_PH_FEET]) VALUES (";
            string cmdText2 = @"@PHOTO_SCANNED,@PHOTO_FLIGHT_INDEX_AS,@DATE_FLIGHT_AS,@LOCATION_AS,@LOCATION_CHIN_AS,@SHEET_NO,@PHOTOSCALE_AS,@OBLIQUE_AS,@LR_AS,@HEADING_AS,@CAMERA_OPERATOR_AS,@FLIGHT_MISSION_AS,@SORTIE_NO_AS,@BOX_NO_AS,@FRAME_COUNTER_NO_AS,@CAMERA_AS,@SPECTRAL_BAND_AS,@FILM_TYPE_NUMBER_AS,@FLENGTH_AS,@APPROX_EASTING_AS,@APPROX_NORTHING_AS,@APPROX_FLYING_HT_AS,@APPROX_TILT_AS,@APPROX_SWING_AS,@APPROX_AZIMUTH_AS,@RESTRICTED_AS,@SINGLE_AS,@IN_FLIGHT_INDEX_AS,@VALIDITY_AS,@SCANNER_PH,@SCAN_RESOLUTION_MICROMETER_PH,@SCAN_DATE_PH,@DAP_MEAS_PH,@DAMAGED_PH,@SCRATCHED_PH,@REDUCED_FILM_PH,@DUPLICATED_FILM_PH,@PARTIAL_FILM_PH,@MISSING_FIDUCIAL_MARKS_PH,@DOUBLE_EXPOSURE_PH,@PATH_HI_RES_PH,@ARCHIVE_PATH_HI_RES_PH,@ARCHIVE_TAPE_NO_PH,@CALIBRATED_FOCAL_LENGTH_PH,@DATE_OF_CALIBRATION_PH,@EASTING_PH,@NORTHING_PH,@HEIGHT_PH,@OMEGA_PH,@PHI_PH,@KAPPA_PH,@CF_PH,@AMENDMENT,@AMENDMENT_HISTORY,@REMARKS_AS,@REMARKS_PH,@PATH_ECW_PH,@PASS_ONLY,@GIH_ONLY,@YEAROFFLIGHT,@EXTENT_GEOM,@CENTER_GEOM,@PHOTO_ID,@INFRARED,@PATH_THUMBNAIL,@ECW_URL,@HEIGHT_PH_FEET)";

            double ix = 0;
            double iy = 0;
            double iscale = 0;
            string iNIR = "0";
            string cmdText3 = "";
            string iyear="" ;
            string igeomtext="";
            string iheight = "";
            double iangle=0;
            ArrayList insertstr = new ArrayList();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Path.GetTempPath()+"tempSQL.sql"))
            {
                
                int srow = 0;
                foreach (DataRow row in dt.Rows)
                {
                    cmdText2 = "";
                    cmdText3 = "";
                    iNIR = "0";
                        foreach (DataColumn col in dt.Columns)
                        {
                            string currentCell = dt.Rows[srow][col].ToString();
                            currentCell = currentCell.Replace("'", "''");

                            if (currentCell.Length < 5)
                            {
                                currentCell = currentCell.Replace("Yes", "1");
                                currentCell = currentCell.Replace("No", "0");
                            }

                           
                            if (col.ColumnName.Equals("DATE_FLIGHT_AS"))
                            {
                                DateTime dateflight = Convert.ToDateTime(currentCell);
                                iyear=dateflight.Year.ToString();
                                
                            }

                            if (col.ColumnName.Contains("PHOTOSCALE"))
                            {
                                iscale = Double.Parse(currentCell);
                            }
                            if (col.ColumnName.Contains("APPROX_EASTING"))
                            {
                                ix = Double.Parse(currentCell);
                            }
                            if (col.ColumnName.Contains("APPROX_NORTHING"))
                            {
                                iy = Double.Parse(currentCell);
                            }
                             if (col.ColumnName.Contains("HEADING"))
                            {
                                iangle = Double.Parse(currentCell);
                            }

                             if (col.ColumnName.Contains("APPROX_FLYING_HT"))
                             {
                                 iheight =currentCell;
                             }


                             if (col.ColumnName.Contains("PHOTO_SCANNED")&&currentCell.Substring(0,1)=="R")
                             {
                                 iNIR = "1";
                             }
                             
                              if (col.ColumnName == ("HEIGHT_PH") || col.ColumnName == ("EASTING_PH") || col.ColumnName == ("NORTHING_PH"))
                            {
                                cmdText2 += "";
                            }
                            else if (currentCell.Length == 0)
                                cmdText2 += "null,";
                            else if (col.ColumnName.Contains("LOCATION_CHIN"))
                            {
                                cmdText2 += "N'" + currentCell + "',";
                            }
                            //else if (col.ColumnName.Contains("DATE"))
                              //{
                                  //MessageBox.Show(currentCell);// 62333130, anderson 
                                  //cmdText2 += currentCell.ToString("yyyy/MM/dd");
                                  //double dtvalue = double.Parse(dt.Rows[srow][col]);
                                 // DateTime dateInfo = DateTime.FromOADate(dtvalue);
                                  //cmdText2 += "'" + dateInfo.ToString("YYYY/MM/DD") + "',";
                          //    }
                            else
                                cmdText2 += "'" + currentCell + "',";

                           

                        }


                        double width=0.2286;
                        double height=0.2286;
                        double gsd=  iscale ;
                        double x1 = -width * gsd * Math.Cos(angleHude * iangle) + height * gsd * Math.Sin(angleHude * iangle) + ix;
                        double y1 = width * gsd * Math.Sin(angleHude * iangle) + height * gsd * Math.Cos(angleHude * iangle) + iy;
                        double x2 = width * gsd * Math.Cos(angleHude * iangle) - height * gsd * Math.Sin(angleHude * iangle) + ix;
                        double y2 = -width * gsd * Math.Sin(angleHude * iangle) - height * gsd * Math.Cos(angleHude * iangle) + iy;
                        double x3 = width * gsd * Math.Cos(angleHude * iangle) + height * gsd * Math.Sin(angleHude * iangle) +ix;
                        double y3 = -width * gsd * Math.Sin(angleHude * iangle) + height * gsd * Math.Cos(angleHude * iangle) + iy;
                        double x4 = -width * gsd * Math.Cos(angleHude * iangle) - height * gsd * Math.Sin(angleHude * iangle) + ix;
                        double y4 = width * gsd * Math.Sin(angleHude * iangle) - height * gsd * Math.Cos(angleHude * iangle) + iy;


                        igeomtext = "POLYGON ((" + x1 + " " + y1 + ", " + x3 + " " + y3 + ", " + x2 + " " + y2 + ", " + x4 + " " + y4 + ", " + x1 + " " + y1 + "))";
                        string icenter = "'POINT("+ix+" "+iy+")'";

                        cmdText3 = cmdText1 + cmdText2 + "'" + iyear + "',geometry::STGeomFromText('" + igeomtext + "', 0),geometry::STGeomFromText(" + icenter + ", 0),'" + iNIR + "','" + ix + "','" + iy + "','" + Double.Parse(iheight) * 0.3048 + "','" + iheight + "');";
                        insertstr.Add(cmdText3);
                        //MessageBox.Show(cmdText3);
                        file.WriteLine(cmdText3);
                  
                    srow++;

                }
                

                DialogResult dialogResult = MessageBox.Show("Are you sure to update "+dt.Rows.Count+" records to ISSS now?","Confirmation to submit to ISSS", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;            // <== lacking
                            command.CommandType = CommandType.Text;
                            
                            connection.Open();
                            foreach (String row in insertstr)
                            {
                                command.CommandText = row;
                                command.ExecuteNonQuery();
                            }
                            }
                            connection.Close();
                        }
                    MessageBox.Show("Database updated, "+dt.Rows.Count+" records inserted!");
                    }

                else if (dialogResult == DialogResult.No)
                {
                    Process.Start("notepad.exe", System.IO.Path.GetTempPath() + "tempSQL.sql");
                }

            }



            

            return dt;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void systemLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logReport lr = new logReport();
            lr.ShowDialog();
        }

        private void v11ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
         
        private void button2_Click_3(object sender, EventArgs e)
        {

           List<string> thumnails_list= new List<string>();
           if (selectInputFolderDialog.ShowDialog() == DialogResult.OK)
           {

               thumnails_list = GetFiles2(new DirectoryInfo(selectInputFolderDialog.SelectedPath), ".png");
               int n = 0;
               foreach (string path in thumnails_list)
               {
                   Image image = System.Drawing.Image.FromFile(path);
                   Image thumbnailImage = image.GetThumbnailImage(Properties.Settings.Default.thumbnailSize, Properties.Settings.Default.thumbnailSize, null, new IntPtr());
                   string filename = path.Substring(path.LastIndexOf("\\") + 1);
                   filename = filename.Substring(0, filename.IndexOf(".png"));
                   var newImage = new Bitmap(150, 150);
                  using (var graphics = Graphics.FromImage(newImage))
                  {
                      graphics.SmoothingMode = SmoothingMode.AntiAlias;
                      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                      graphics.Clear(Color.White);
                      graphics.DrawImage(image, new Rectangle(0, 0, 150, 150));
                      newImage.Save(path.Substring(0, path.LastIndexOf("\\") + 1) + "\\" + filename + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                  }

                   n++;
                   //myUI(n + " Thumbnails Converted", label3);
               }
               MessageBox.Show(n+" PNG Images to JPEG convert finihsed");
           }

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thumnails now output as JPG in 150x150 size");



        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

       
    }
}
