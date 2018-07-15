using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Lib.Common;

namespace InnovativeTool
{
    public partial class Form1 : Form
    {
        #region Costanti
        private const string NEW_ORDER_DIRNAME = "Orders";
        private const string PROCESSED_ORDER_DIRNAME = "Scaricati";

        private const string TEST_FOLDER = "../../_test_";
        #endregion

        #region Proprietà
        #endregion

        #region Delegati
        #endregion

        #region Membri privati
        static private int DirLevel = 0;
        #endregion

        #region Membri statici
        #endregion

        #region Costruttori
        public Form1()
        {
            InitializeComponent();

            string path = Directory.GetCurrentDirectory();

            /* fill order list */
            List<string> orderList;
            ListDir(Path.Combine(TEST_FOLDER, NEW_ORDER_DIRNAME),out orderList);
            foreach(string s in orderList)
            {
                string dirName = Path.GetFileName(s);
                checkedListBoxOrder.Items.Add(dirName);
            }
        }
        #endregion

        #region Metodi privati
        private void ListDir(string searchDirectory, out List<string> dirList)
        {
            dirList = new List<string>();

            try
            {
                foreach (string d in Directory.GetDirectories(searchDirectory))
                {
                    dirList.Add(d);
                }
            }
            catch (System.Exception excpt)
            {
                textBoxLog.Text = excpt.Message;
            }
                   
            return;
        }
#if true
        private void ListFiles(string searchDirectory, out List<string> fileList)
        {
            fileList = new List<string>();

            try
            {
                foreach (string filename in Directory.GetFiles(searchDirectory))
                {
                    fileList.Add(filename);
                }
            }
            catch (System.Exception excpt)
            {
                textBoxLog.Text = excpt.Message;
            }

            return;
        }
#endif

#if false
        private void DirSearch(string sDir)
        {
#if true
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {                   
                    if (d.Contains(NEW_ORDER_DIRNAME) == false)
                    {
                        /* nothing to do */
                    }
                    else
                    {
                        string s1 = Path.GetFileName(d);


                        foreach (string f in Directory.GetFiles(d))
                        {
#if false
                            Console.WriteLine(f);

                            //string s2 = Path.GetFileName(d);
                            //checkedListBox1.Items.Add(s2);

                            //listBox1.Items.Add(s2);
                            //listBox1.Items.Add(DirLevel);
                            // checkedl
#endif
                        }
                    }
                }            
            }
            catch (System.Exception excpt)
            {
                textBoxLog.Text = excpt.Message;
            }
#else
                        foreach (string file in Directory.EnumerateFiles(sDir, "*.*", SearchOption.AllDirectories))
            {
                Console.WriteLine(file);
            }
#endif
        }
#endif
        #endregion

        #region Metodi pubblici
        #endregion

        #region Eventi
        private void buttonConnect_Click(object sender, EventArgs e)
        {
#if true
            FtpClient ftpClient = new FtpClient("ftp://speedtest.tele2.net", "anonymous", "");
            string[] dirList = ftpClient.directoryListDetailed("");
#elif false
#endif
        }
        private void buttonProcess_Click(object sender, EventArgs e)
        {

        }
        private void checkedListBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = checkedListBoxOrder.SelectedItem.ToString();

            List<string> fileList;
            ListFiles(Path.Combine(TEST_FOLDER, NEW_ORDER_DIRNAME, item),out fileList);
        }
#endregion

#region Membri Background worker
#endregion

#region Timers
#endregion

#region Callbacks
#endregion
    }
}
