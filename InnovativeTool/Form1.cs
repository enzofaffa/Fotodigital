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
using System.Xml;
using System.Net;
using System.Net.Mail;

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
        private string OrderId;
        private string OrderDateTime;
        private string ShipId;
        private string OrderItemProductCode;
        private string OrderItemDescription;
        private string OrderItemQuantity;
        private string OrderItemThemeOptions;
        private string OrderItemPrice;
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
                listBoxOrderList.Items.Add(dirName);
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
        private void ParseXml(string xmlFileToParse)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFileToParse);

            foreach (XmlNode mainNode in doc.DocumentElement.ChildNodes)
            {
                string mainNodeName = mainNode.Name.ToLower();

                if(mainNodeName == "order_info")
                {
                    foreach (XmlNode locNode in mainNode)
                    {
                        string val = locNode.InnerText;
                        switch(locNode.Name.ToLower())
                        {
                            case "order_id":
                                OrderId = val;
                                break;

                            case "order_datetime":
                                OrderDateTime = val;
                                break;

                            default:
                                break;
                        }
                    }
                }
                else if (mainNodeName == "ship_to_info")
                {
                    foreach (XmlNode locNode in mainNode)
                    {
                        string val = locNode.InnerText;
                        switch (locNode.Name.ToLower())
                        {
                            case "ship_id":
                                ShipId = val;
                                break;
                                
                            default:
                                break;
                        }
                    }
                }
                else if (mainNodeName == "order_item")
                {
                    foreach (XmlNode locNode in mainNode)
                    {
                        string val = locNode.InnerText;

                        if(val == "")
                        {
                            val = "N.A.";
                        }
                        switch (locNode.Name.ToLower())
                        {
                            case "order_item_product_code":
                                OrderItemProductCode = val;
                                break;

                            case "order_item_description":
                                OrderItemDescription = val;
                                break;

                            case "order_item_quantity":
                                OrderItemQuantity = val;
                                break;

                            case "order_item_theme_options":
                                OrderItemThemeOptions = val;
                                break;

                            case "order_item_price":
                                OrderItemPrice = val;
                                break;

                            default:
                                break;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        private void FillInfoBox()
        {
            richTextBoxOrderInfo.Text = "";
            richTextBoxOrderInfo.DeselectAll();

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("ID" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(OrderId + Environment.NewLine);

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("Date and time" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(OrderDateTime + Environment.NewLine);

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("Shop code" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(ShipId + Environment.NewLine);

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("Cod" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(OrderItemProductCode + Environment.NewLine);

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("Description" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(OrderItemDescription + Environment.NewLine);

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("Quantity" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(OrderItemQuantity + Environment.NewLine);

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("Options" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(OrderItemThemeOptions + Environment.NewLine);

            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Bold);
            richTextBoxOrderInfo.AppendText("Price" + Environment.NewLine);
            richTextBoxOrderInfo.SelectionFont = new System.Drawing.Font(richTextBoxOrderInfo.SelectionFont, System.Drawing.FontStyle.Regular);
            richTextBoxOrderInfo.AppendText(OrderItemPrice + Environment.NewLine);
        }
        private void InitValue()
        {
            //OrderId = "N.A.";
            //OrderDateTime = "N.A.";
            //ShipId = "N.A.";
            //OrderItemProductCode = "N.A.";
            //OrderItemDescription = "N.A.";
            //OrderItemQuantity = "N.A.";
            //OrderItemThemeOptions = "N.A.";
            //OrderItemPrice = "N.A.";
        }
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
        private void listBoxOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = listBoxOrderList.SelectedItem.ToString();

            InitValue();

            ListFiles(Path.Combine(TEST_FOLDER, NEW_ORDER_DIRNAME, item), out List<string> fileList);

            foreach (string filePath in fileList)
            {
                if (Path.GetExtension(filePath).ToLower() == ".xml")
                {
                    ParseXml(filePath);
                    break;
                }
            }

            FillInfoBox();
        }
        private void buttonSendMail_Click(object sender, EventArgs e)
        {
            try
            {
#if false
                MailMessage mail = new MailMessage("timbri@innovativegroupsrl.it", "efaffa@gmail.com");
                SmtpClient client = new SmtpClient();
                client.Port = /*25*/465;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtps.aruba.it";
                mail.Subject = "Timbri ordine: " + OrderItemProductCode;
                mail.Body = "this is my test email body";
                client.Send(mail);
#elif false
                SmtpClient client = new SmtpClient();
                client.Port = 465;
                client.Host = "smtps.aruba.it";
                client.EnableSsl = true;
                client.Timeout = 30000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("timbri@innovativegroupsrl.it", "Mb04031962");

                MailMessage mm = new MailMessage("timbri@innovativegroupsrl.it", "efaffa@gmail.com", "Timbri", "this is my test email body");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
#elif false
                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 465;
                client.Host = "smtps.aruba.it";
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential("timbri@innovativegroupsrl.it", "Mb04031962");
                objeto_mail.From = new MailAddress("timbri@innovativegroupsrl.it");
                objeto_mail.To.Add(new MailAddress("efaffa@gmail.com"));
                objeto_mail.Subject = "Password Recover";
                objeto_mail.Body = "Message";
                client.Send(objeto_mail);
#elif false
                var fromAddress = new MailAddress("montedelbosco@gmail.com", "From ENZO");
                var toAddress = new MailAddress("efaffa@gmail.com", "To ENZO");
                const string fromPassword = "mdbmdb2012";
                const string subject = "Subject";
                const string body = "Body";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
#elif true
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("http://smtp.gmail.com");

                mail.From = new MailAddress("montedelbosco@gmail.com");
                mail.To.Add("montedelbosco@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("montedelbosco@gmail.com", "mdbmdb2012");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
#endif
            }
            catch (Exception ex)
            {
                textBoxLog.Text = ex.Message;
            }
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
