using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace tiff2ecw
{
    public partial class logReport : Form
    {
        private DataSet ds = new DataSet();
        public logReport()
        {
            InitializeComponent();
        }

        private void showlogsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Execute your time-intensive hashing code here...

            string connectionString = Properties.Settings.Default.connString;
            string sql = "";
            sql="SELECT [LOG_ID],[USER_NAME],[LOG_EVENT_TYPE] , [LOG_EVENT_TIME] ,[PHOTO_ID],[EXTENT]  FROM [ISSS].[dbo].[USER_LOG] where cast([LOG_EVENT_TIME] as date)>= cast('" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' as date) and cast([LOG_EVENT_TIME] as date) <=cast('" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' as date);";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);

            connection.Open();
            ds.Clear();
          
            dataadapter.Fill(ds, "Log_table");
            connection.Close();

            ds.Tables.Add(new System.Data.DataTable());


            if (!ds.Tables[0].Columns.Contains("RANK"))
            {
                ds.Tables[0].Columns.Add("RANK", typeof(string));
                ds.Tables[0].Columns.Add("ENGLISH_NAME", typeof(string));
                ds.Tables[0].Columns.Add("POSTID", typeof(string));
                ds.Tables[0].Columns.Add("OFFICE", typeof(string));
                ds.Tables[0].Columns.Add("UNIT", typeof(string));
            }
            System.Data.DataTable dt = new System.Data.DataTable();
          
                var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Properties.Settings.Default.acldbPath);
                con.Open();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string users = row[1].ToString();
                    dt.Clear();
                    var query = "SELECT RANK ,ENGLISH_NAME, POSTID, OFFICE, UNIT from ACL where UID = '" + users + "'";
                    var adapter = new OleDbDataAdapter(query, con);
                    OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dt);
                    con.Close();
                    row["RANK"] = dt.Rows.Count == 0 ? "UNKNOWN" : dt.Rows[0]["RANK"];
                    row["ENGLISH_NAME"] = dt.Rows.Count == 0 ? "UNKNOWN" : dt.Rows[0]["ENGLISH_NAME"];
                    row["POSTID"] = dt.Rows.Count == 0 ? "UNKNOWN" : dt.Rows[0]["POSTID"];
                    row["OFFICE"] = dt.Rows.Count == 0 ? "UNKNOWN" : dt.Rows[0]["OFFICE"];
                    row["UNIT"] = dt.Rows.Count == 0 ? "UNKNOWN" : dt.Rows[0]["UNIT"];
                    row.EndEdit();
                    ds.Tables[0].AcceptChanges();
                    ds.Tables[0].Columns[6].SetOrdinal(2);
                    ds.Tables[0].Columns[7].SetOrdinal(3);
                    ds.Tables[0].Columns[8].SetOrdinal(4);
                    ds.Tables[0].Columns[9].SetOrdinal(5);
                    ds.Tables[0].Columns[10].SetOrdinal(6);
                }


                //return bandlist[0][1].ToString();

                logsDatagridview.DataSource = ds;
                logsDatagridview.DataMember = "Log_table";

                exportBtn.Enabled = true;
                exportByNameBtn.Enabled = true;
                exportByOfficeBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "Export Excel File To";

            saveFileDialog.ShowDialog();

            String exportExcelFile = saveFileDialog.FileName;

           ExportForDataGridview(logsDatagridview, exportExcelFile, true);


        }

        public static bool ExportForDataGridview(DataGridView gridView, string fileName, bool isShowExcle)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (app == null)
                {
                    return false;
                }

                app.Visible = isShowExcle;
                Workbooks workbooks = app.Workbooks;
                _Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Sheets sheets = workbook.Worksheets;
                _Worksheet worksheet = (_Worksheet)sheets.get_Item(1);
                if (worksheet == null)
                {
                    return false;
                }
                string sLen = "";
                //取得最后一列列名
                char H = (char)(64 + gridView.ColumnCount / 26);
                char L = (char)(64 + gridView.ColumnCount % 26);
                if (gridView.ColumnCount < 26)
                {
                    sLen = L.ToString();
                }
                else
                {
                    sLen = H.ToString() + L.ToString();
                }


                //标题
                string sTmp = sLen + "1";
                Range ranCaption = worksheet.get_Range(sTmp, "A1");
                string[] asCaption = new string[gridView.ColumnCount];
                for (int i = 0; i < gridView.ColumnCount; i++)
                {
                    asCaption[i] = gridView.Columns[i].HeaderText;
                }
                ranCaption.Value2 = asCaption;
                ranCaption.Columns.AutoFit();
                ranCaption.Columns.Font.Bold = true;
                //数据
                object[] obj = new object[gridView.Columns.Count];
                int rr = 0;
                for (int r = 0; r < gridView.RowCount - 1; r++)
                {
                    if (gridView.Rows[r].Cells["LOG_EVENT_TYPE"].Value.ToString() != "Browse")
                    {
                        for (int l = 0; l < gridView.Columns.Count; l++)
                        {

                            if (gridView[l, r].ValueType == typeof(DateTime))
                            {
                                obj[l] = gridView[l, r].Value.ToString();
                            }
                            else
                            {
                                obj[l] = gridView[l, r].Value;
                            }

                        }

                        string cell1 = sLen + ((int)(rr + 2)).ToString();
                        string cell2 = "A" + ((int)(rr + 2)).ToString();
                        Range ran = worksheet.get_Range(cell1, cell2);
                        ran.Value2 = obj;
                        rr++;
                    }
                }
                //保存
                workbook.SaveCopyAs(fileName);
                workbook.Saved = true;
                MessageBox.Show("System logs have been exported!");
            }
            catch (Exception ex2) { MessageBox.Show(ex2.Message); }
            finally
            {
                //关闭
                app.UserControl = false;
                app.Quit();
            }
            return true;

        }

        private void exportByNameBtn_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "Export Excel File To";
            saveFileDialog.ShowDialog();
          

            String exportExcelFile = saveFileDialog.FileName;
            if (exportExcelFile.Length > 1)
            { 

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            try
            {

                app.Visible = false;
                Workbooks workbooks = app.Workbooks;
                _Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Sheets sheets = workbook.Worksheets;
                _Worksheet worksheet = (_Worksheet)sheets.get_Item(1);

             
                string sLen = "";
                char L = (char)(64 + 7 % 26);
                sLen = L.ToString();


                string daterange = "ISSS user report from  " + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy") + " to " + dateTimePicker2.Value.Date.ToString("dd/MM/yyyy");

                Range ran1 = worksheet.get_Range("A1");
                worksheet.Range["A1"].Value2 = daterange;
                worksheet.Range["A1"].Columns.Font.Bold = true;
                worksheet.Range["A1"].Columns.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Range["A1", "G1"].Merge();

                
                worksheet.Range["A2"].Value2 = "Name";
                worksheet.Range["B2"].Value2 = "Browse DAP";
                worksheet.Range["C2"].Value2 = "Download DAP(Tiff)";
                worksheet.Range["D2"].Value2 = "Download DAP (ECW)";
                worksheet.Range["E2"].Value2 = "Clipping DAP (Tiff)";
                worksheet.Range["F2"].Value2 = "Clipping DAP (ECW)";
                worksheet.Range["G2"].Value2 = "Clipping DAP (JPEG2000)";


                worksheet.Range["A2","G2"].Columns.AutoFit();
                worksheet.Range["A2", "G2"].Columns.Font.Bold = true;


                System.Data.DataTable byNameTabel = new System.Data.DataTable();

                byNameTabel.Columns.Add("USER_NAME", typeof(String));
                byNameTabel.Columns.Add("Browse DAP", typeof(int));
                byNameTabel.Columns.Add("Download DAP(Tiff)", typeof(int));
                byNameTabel.Columns.Add("Download DAP (ECW)", typeof(int));
                byNameTabel.Columns.Add("Clipping DAP (Tiff)", typeof(int));
                byNameTabel.Columns.Add("Clipping DAP (ECW)", typeof(int));
                byNameTabel.Columns.Add("Clipping DAP (JPEG2000)", typeof(int));

                String tempName="";

                foreach (System.Data.DataRow row in ds.Tables[0].Rows)
                {

                    DataRow newRow = byNameTabel.NewRow();
                    string EventType=row["LOG_EVENT_TYPE"].ToString();

                    if (!tempName.Contains(row["USER_NAME"].ToString()))
                    {
                        newRow[0] = row["USER_NAME"];
                        tempName += row["USER_NAME"] + ",";
                        newRow[1] = 0;
                        newRow[2] = 0;
                        newRow[3] = 0;
                        newRow[4] = 0;
                        newRow[5] = 0;
                        newRow[6] = 0;
                        if (EventType == "Browse")
                            newRow[1] = 1;
                        if (EventType.Contains("Clip to ECW"))
                            newRow[2] = 1;
                        if (EventType.Contains("Clip to GeoTIFF"))
                            newRow[3] = 1;
                        if (EventType.Contains("Entire RAW TIFF"))
                            newRow[4] = 1;
                        if (EventType.Contains("Entire RAW ECW"))
                            newRow[5] = 1;
                        if (EventType.Contains("Clip to JPEG2000"))
                            newRow[6] = 1;
                        byNameTabel.Rows.Add(newRow);
                    }
                    else {
                        string tempusername = row["USER_NAME"].ToString();
                        DataRow[] evetRow = byNameTabel.Select("USER_NAME = '" + tempusername + "'");
                        evetRow[0][1] = evetRow[0][1];
                        evetRow[0][2] = evetRow[0][2];
                        evetRow[0][3] = evetRow[0][3];
                        evetRow[0][4] = evetRow[0][4];
                        evetRow[0][5] = evetRow[0][5];
                        evetRow[0][6] = evetRow[0][6];
                        if (EventType == "Browse")
                            evetRow[0][1] = int.Parse(evetRow[0][1].ToString()) + 1;
                        if (EventType == "Entire RAW TIFF")
                            evetRow[0][2] = int.Parse(evetRow[0][2].ToString()) + 1;
                        if (EventType == "Entire RAW ECW")
                            evetRow[0][3] = int.Parse(evetRow[0][3].ToString()) + 1;
                        if (EventType == "Clip to GeoTIFF")
                            evetRow[0][4] = int.Parse(evetRow[0][4].ToString()) + 1;
                        if (EventType == "Clip to ECW")
                            evetRow[0][5] = int.Parse(evetRow[0][5].ToString()) + 1;
                        if (EventType == "Clip to JPEG2000")
                            evetRow[0][6] = int.Parse(evetRow[0][6].ToString()) + 1;
                        byNameTabel.Select("USER_NAME = '" + tempusername + "'")[0].AcceptChanges();

                    }
                    
                }

             //   MessageBox.Show(byNameTabel.Rows.Count.ToString());
                object[] obj = new object[byNameTabel.Columns.Count];
                //
                for (int r = 0; r < byNameTabel.Rows.Count ; r++)
                {
                    for (int l = 0; l < byNameTabel.Columns.Count; l++)
                    {

                        obj[l] = byNameTabel.Rows[r][l];
                       // MessageBox.Show(byNameTabel.Rows[r][l].ToString());
                        
                    }
                    string cell1 = sLen + ((int)(r + 3)).ToString();
                    string cell2 = "A" + ((int)(r + 3)).ToString();
                    Range ran = worksheet.get_Range(cell1, cell2);
                    ran.Value2 = obj;
                }



                //保存
                workbook.SaveCopyAs(exportExcelFile);
                workbook.Saved = true;
                MessageBox.Show("System logs have been exported!");
            }
            catch (Exception ex3) { MessageBox.Show(ex3.Message); }
            finally
            {
                //关闭
                app.UserControl = false;
                app.Quit();
            }

              }

        }

        private void exportByOfficeBtn_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "Export Excel File To";
            saveFileDialog.ShowDialog();


            String exportExcelFile = saveFileDialog.FileName;
            if (exportExcelFile.Length > 1)
            {

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                try
                {

                    app.Visible = false;
                    Workbooks workbooks = app.Workbooks;
                    _Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    Sheets sheets = workbook.Worksheets;
                    _Worksheet worksheet = (_Worksheet)sheets.get_Item(1);


                    string sLen = "";
                    char L = (char)(64 + 7 % 26);
                    sLen = L.ToString();


                    string daterange = "ISSS user report from  " + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy") + " to " + dateTimePicker2.Value.Date.ToString("dd/MM/yyyy") + " By Offices";

                    Range ran1 = worksheet.get_Range("A1");
                    worksheet.Range["A1"].Value2 = daterange;
                    worksheet.Range["A1"].Columns.Font.Bold = true;
                    worksheet.Range["A1"].Columns.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Range["A1", "G1"].Merge();


                    worksheet.Range["A2"].Value2 = "Name";
                    worksheet.Range["B2"].Value2 = "Browse DAP";
                    worksheet.Range["C2"].Value2 = "Download DAP(Tiff)";
                    worksheet.Range["D2"].Value2 = "Download DAP (ECW)";
                    worksheet.Range["E2"].Value2 = "Clipping DAP (Tiff)";
                    worksheet.Range["F2"].Value2 = "Clipping DAP (ECW)";
                    worksheet.Range["G2"].Value2 = "Clipping DAP (JPEG2000)";


                    worksheet.Range["A2", "G2"].Columns.AutoFit();
                    worksheet.Range["A2", "G2"].Columns.Font.Bold = true;


                    System.Data.DataTable byNameTabel = new System.Data.DataTable();

                    byNameTabel.Columns.Add("OFFICE", typeof(String));
                    byNameTabel.Columns.Add("Browse DAP", typeof(int));
                    byNameTabel.Columns.Add("Download DAP(Tiff)", typeof(int));
                    byNameTabel.Columns.Add("Download DAP (ECW)", typeof(int));
                    byNameTabel.Columns.Add("Clipping DAP (Tiff)", typeof(int));
                    byNameTabel.Columns.Add("Clipping DAP (ECW)", typeof(int));
                    byNameTabel.Columns.Add("Clipping DAP (JPEG2000)", typeof(int));

                    String tempName = "";

                    foreach (System.Data.DataRow row in ds.Tables[0].Rows)
                    {

                        DataRow newRow = byNameTabel.NewRow();
                        string EventType = row["LOG_EVENT_TYPE"].ToString();

                        if (!tempName.Contains(row["OFFICE"].ToString()))
                        {
                            newRow[0] = row["OFFICE"];
                            tempName += row["OFFICE"] + ",";
                            newRow[1] = 0;
                            newRow[2] = 0;
                            newRow[3] = 0;
                            newRow[4] = 0;
                            newRow[5] = 0;
                            newRow[6] = 0;
                            if (EventType == "Browse")
                                newRow[1] = 1;
                            if (EventType.Contains("Clip to ECW"))
                                newRow[2] = 1;
                            if (EventType.Contains("Clip to GeoTIFF"))
                                newRow[3] = 1;
                            if (EventType.Contains("Entire RAW TIFF"))
                                newRow[4] = 1;
                            if (EventType.Contains("Entire RAW ECW"))
                                newRow[5] = 1;
                            if (EventType.Contains("Clip to JPEG2000"))
                                newRow[6] = 1;
                            byNameTabel.Rows.Add(newRow);
                        }
                        else
                        {
                            string tempusername = row["OFFICE"].ToString();
                            DataRow[] evetRow = byNameTabel.Select("OFFICE = '" + tempusername + "'");
                            evetRow[0][1] = evetRow[0][1];
                            evetRow[0][2] = evetRow[0][2];
                            evetRow[0][3] = evetRow[0][3];
                            evetRow[0][4] = evetRow[0][4];
                            evetRow[0][5] = evetRow[0][5];
                            evetRow[0][6] = evetRow[0][6];
                            if (EventType == "Browse")
                                evetRow[0][1] = int.Parse(evetRow[0][1].ToString()) + 1;
                            if (EventType == "Entire RAW TIFF")
                                evetRow[0][2] = int.Parse(evetRow[0][2].ToString()) + 1;
                            if (EventType == "Entire RAW ECW")
                                evetRow[0][3] = int.Parse(evetRow[0][3].ToString()) + 1;
                            if (EventType == "Clip to GeoTIFF")
                                evetRow[0][4] = int.Parse(evetRow[0][4].ToString()) + 1;
                            if (EventType == "Clip to ECW")
                                evetRow[0][5] = int.Parse(evetRow[0][5].ToString()) + 1;
                            if (EventType == "Clip to JPEG2000")
                                evetRow[0][6] = int.Parse(evetRow[0][6].ToString()) + 1;
                            byNameTabel.Select("OFFICE = '" + tempusername + "'")[0].AcceptChanges();

                        }

                    }

                    //   MessageBox.Show(byNameTabel.Rows.Count.ToString());
                    object[] obj = new object[byNameTabel.Columns.Count];
                    //
                    for (int r = 0; r < byNameTabel.Rows.Count; r++)
                    {
                        for (int l = 0; l < byNameTabel.Columns.Count; l++)
                        {

                            obj[l] = byNameTabel.Rows[r][l];
                            // MessageBox.Show(byNameTabel.Rows[r][l].ToString());

                        }
                        string cell1 = sLen + ((int)(r + 3)).ToString();
                        string cell2 = "A" + ((int)(r + 3)).ToString();
                        Range ran = worksheet.get_Range(cell1, cell2);
                        ran.Value2 = obj;
                    }



                    //保存
                    workbook.SaveCopyAs(exportExcelFile);
                    workbook.Saved = true;
                    MessageBox.Show("System logs have been exported!");
                }
                catch (Exception ex3) { MessageBox.Show(ex3.Message); }
           
                finally
                {
                    //关闭
                    app.UserControl = false;
                    app.Quit();
                }

            }

        }

    }
}
