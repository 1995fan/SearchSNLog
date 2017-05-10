using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;

namespace SearchSNLog.ViewModel
{
    public class SearchSNLogViewModel: NotificationObject 
    {
        string LogFileName = string.Empty;

        private bool _isWaiting;
        public bool IsWaiting
        {
            get { return _isWaiting; }
            set
            {
                _isWaiting = value;
                RaisePropertyChanged("IsWaiting");
            }
        }

        private string _targetFileName;
        /// <summary>
        /// 被查询CSV文件名
        /// </summary>
        public string TargetFileName
        {
            get { return _targetFileName; }
            set 
            {
                _targetFileName = value;
                RaisePropertyChanged("TargetFileName");
            }
        }

        private string _SNFileName;
        /// <summary>
        /// SN文件名
        /// </summary>
        public string SNFileName
        {
            get { return _SNFileName; }
            set 
            {
                _SNFileName = value;
                RaisePropertyChanged("SNFileName");
            }
        }

        private string _resultDir;
        /// <summary>
        /// 生成文件目录
        /// </summary>
        public string ResultDir
        {
            get { return _resultDir; }
            set 
            { 
                _resultDir = value;
                RaisePropertyChanged("ResultDir");
            }
        }

        private string _SNTextBox;
        /// <summary>
        /// SN文本
        /// </summary>
        public string SNTextBox
        {
            get { return _SNTextBox; }
            set 
            {
                _SNTextBox = value;
                RaisePropertyChanged("SNTextBox");
            }
        }

        private string _TargetFileError;
        /// <summary>
        /// 
        /// </summary>
        public string TargetFileError
        {
            get { return _TargetFileError; }
            set 
            {
                _TargetFileError = value;
                RaisePropertyChanged("TargetFileError");
            }
        }

        private string _SNError;
        /// <summary>
        /// 
        /// </summary>
        public string SNError
        {
            get { return _SNError; }
            set
            {
                _SNError = value;
                RaisePropertyChanged("SNError");
            }
        }

        private string _ResultStr;
        /// <summary>
        /// 
        /// </summary>
        public string ResultStr
        {
            get { return _ResultStr; }
            set
            {
                _ResultStr = value;
                RaisePropertyChanged("ResultStr");
            }
        }
        
        

        public SearchSNLogViewModel()
        {
            if (ResultDir ==null)
            {
                ResultDir = AppDomain.CurrentDomain.BaseDirectory + @"Log";
                if (!Directory.Exists(ResultDir))
                {
                    Directory.CreateDirectory(ResultDir);
                }
            }
            IsWaiting = false;

        }
       


        public string WaitingContent { get { return "程序处理中，请耐心等待..."; } }

        public ICommand SetTargetFileNameCommand { get { return new DelegateCommand(SetTargetFileName); } }
        public ICommand SetSNFileNameCommand { get { return new DelegateCommand(SetSNFileName); } }
        public ICommand SetResultLogDirCommand { get { return new DelegateCommand(SetResultLogDir); } }
        public ICommand SearchSNLogCommand { get { return new DelegateCommand(SearchSNLog); } }


        private void SetTargetFileName(object param)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.SupportMultiDottedExtensions = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                TargetFileName = null;
                foreach (string fileName in fileDialog.FileNames)
                {
                    TargetFileName += fileName + ";";
                }
            }
        }

        private void SetSNFileName(object param)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SNTextBox = null;
                SNFileName = fileDialog.FileName;
            }
        }
        

        private void SetResultLogDir(object param)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                ResultDir = folderBrowser.SelectedPath;
            }
        }

        private void SearchSNLog(object param)
        {
            IsWaiting = true;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                TargetFileError = null;
                SNError = null;
                ResultStr = null;
                GetSNcsv();
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                IsWaiting = false;
                if (File.Exists(LogFileName))
                {
                    System.Diagnostics.Process.Start(LogFileName);
                }
            };
            worker.RunWorkerAsync();
        }

        private bool GetSNcsv()
        {
            LogFileName = ResultDir + "\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            bool isFirstCsv = true;
            if (TargetFileName == null)
            {
                TargetFileError = "请选择目标文件！";
                return false;
            }
            foreach (string fileName in TargetFileName.Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries))
	        {
                if (!File.Exists(fileName))
                {
                    TargetFileError = "目标文件不存在，请重新选择！";
                    return false;
                }
                FileInfo fileNameInfo = new FileInfo(fileName);
                if (fileNameInfo.Extension != ".csv")
                {
                    TargetFileError = "目标文件不正确，请选择.csv文件！";
                    return false;
                }
                //标示是否读取到所需的行
                bool isDataLine = false;
		        using (StreamReader sr=new StreamReader(fileName,Encoding.UTF8))
                {
                    //记录每次读取的一行记录
                    string strLine = string.Empty;
                    //记录每行记录中的各字段内容
                    string[] aryLine = null;
                    string[] tableHead = null;
                    //标示列数
                    int columnCount = 0;
                    //逐行读取CSV中的数据
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        if (strLine.ToUpper().Contains("SERIALNUMBER") && isFirstCsv)
                        {
                            sb.AppendLine(strLine);
                            tableHead = strLine.Split(',');
                            //创建列
                            for (int i = 0; i < tableHead.Length; i++)
                            {
                                tableHead[i] = tableHead[i].Replace("\"", "");
                                DataColumn dc = new DataColumn(tableHead[i]);
                                dt.Columns.Add(dc);
                            }
                        }
                        else
                        {
                            if (isDataLine == true)
                            {
                                aryLine = strLine.Split(',');
                                columnCount = aryLine.Length;
                                int differences = columnCount - dt.Columns.Count;
                                if (differences > 0)
                                {
                                    for (int i = 0; i < differences; i++)
                                    {
                                        DataColumn dc = new DataColumn();
                                        dt.Columns.Add(dc);
                                    }
                                    dt.Rows.Add(aryLine);
                                    continue;
                                }
                                DataRow dr = dt.NewRow();
                                for (int j = 0; j < columnCount; j++)
                                {
                                    dr[j] = aryLine[j].Replace("\"", "");
                                }
                                dt.Rows.Add(dr);
                            }
                            else if (isFirstCsv)
                            {
                                sb.AppendLine(strLine);
                            }
                            if (strLine.ToUpper().Contains("LOWER LIMIT----->"))
                            {
                                isFirstCsv = false;
                                isDataLine = true;
                            }
                        }
                    }
                }
	        }

            //DataTable dt1 = dt.Clone();

            if (SNTextBox == null||SNTextBox == string.Empty)
            {
                if (SNFileName == null)
                {
                    SNError = "请选择SN文件或双击输入SN！";
                    return false;
                }
                if (!File.Exists(SNFileName))
                {
                    SNError = "SN文件不存在，请重新选择！";
                    return false;
                }
                using (StreamReader sr = new StreamReader(SNFileName))
                {
                    string content = sr.ReadToEnd();
                    string[] sns = Regex.Split(content, "\r\n", RegexOptions.IgnoreCase);
                    //sn = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    string rowFilter = string.Empty;
                    int a = 0;
                    foreach (string sn in sns)
                    {
                        a++;
                        rowFilter += "SerialNumber='" + sn + "'";
                        if (sns.Length != a)
                        {
                            rowFilter += " or ";
                        }
                    }

                    //rowFilter = "SerialNumber='Z73R7Q01HP193ZY9'";
                    //DataRow[] getRows = dt.Select(rowFilter);

                    //foreach (DataRow row in getRows)
                    //{
                    //    dt1.Rows.Add(row.ItemArray);
                    //}

                    dt.DefaultView.RowFilter = rowFilter;
                    //dt.DefaultView.Sort = "";
                }
            }
            else
            {
                string[] sns = Regex.Split(SNTextBox, "\r\n", RegexOptions.IgnoreCase);
                //sn = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string rowFilter = string.Empty;
                int a = 0;
                foreach (string sn in sns)
                {
                    a++;
                    rowFilter += "SerialNumber='" + sn + "'";
                    if (sns.Length != a)
                    {
                        rowFilter += " or ";
                    }
                }

                dt.DefaultView.RowFilter = rowFilter;
            }


            DataTable dtView = dt.DefaultView.ToTable();

            ResultStr = string.Format("共{0}条记录", dtView.Rows.Count);

            if (dtView.Rows.Count ==0)
            {
                return false;
            }

            for (int i = 0; i < dtView.Rows.Count; i++) //写入各行数据  
            {
                string data = string.Empty;
                for (int j = 0; j < dtView.Columns.Count; j++)
                {
                    string str = dtView.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号  
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中  
                    {
                        str = string.Format("\"{0}\"", str);
                    }
                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sb.AppendLine(data);
            }

            using (StreamWriter sw = new StreamWriter(LogFileName))
            {
                sw.WriteLine(sb.ToString());
            }
            
            return true;
        }
    }
}
