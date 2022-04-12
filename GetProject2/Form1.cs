using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetProject2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void JsonSil (int id)
        {
            var url = "http://localhost:3000/text/"+id;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "DELETE";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public List<JsonModel> JsonListe()
        {
            List<JsonModel> JsonModelList = null;
            
            try
            {

                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                String JsonText = client.DownloadString(@"http://localhost:3000/text");

                JsonModelList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JsonModel>>(JsonText);
            }
            catch (Exception)
            {
                JsonModelList = null;
            }
            return JsonModelList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CMDCalistir("node", @"C:\Users\220\Desktop\record-server-example", "server.js", ProcessWindowStyle.Hidden);
            CMDCalistir("json-server", @"C:\Users\220\Desktop\record-server-example\public", "db.json", ProcessWindowStyle.Hidden);
            KayitGetir();
        }

        public void CMDCalistir(string fileName, string workingDirectory, string arguments, ProcessWindowStyle style)
        {
            var p2 = new Process
            {
                StartInfo =
                 {
                     FileName = fileName,
                     WorkingDirectory = workingDirectory,
                     Arguments = arguments,
                     WindowStyle = style
                 }
            }.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Array.ForEach(Process.GetProcessesByName("node"), x => x.Kill());
        }

        public void DapperInsert(List<JsonModel> AktarilacakListe)
        {
            try
            {
                SqlConnection myConn = new SqlConnection("Data Source=U220\\SQLEXPRESS;Initial Catalog=SpeechToText;Integrated Security=True;");

                using (SqlConnection sqlConnect = new SqlConnection(myConn.ConnectionString))
                {
                    WindowsIdentity windowsAdi = WindowsIdentity.GetCurrent();
                    string WindowsAdi = windowsAdi.Name;
                    int idNew;
                    foreach (JsonModel satir in AktarilacakListe)
                    {
                        satir.WindowsAdi = WindowsAdi.ToString();
                        idNew = Convert.ToInt32(satir.id);
                        sqlConnect.Query<JsonModel>(@"INSERT INTO [dbo].[TextTable]
                                                                                       ([WindowsAdi]
                                                                                       ,[Tarih]
                                                                                       ,[Ses]
                                                                                       ,[Yolu])
                                                                                 VALUES
                                                                                       (@WindowsAdi
                                                                                       ,@Tarih
                                                                                       ,@Ses
                                                                                       ,@Yolu)", satir);
                        JsonSil(idNew);
                    }
                }
                KayitGetir();
                MessageBox.Show("Veritabanına kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            List<JsonModel> aktarilacakListe = JsonListe();
            if(aktarilacakListe.Count > 0)
                DapperInsert(aktarilacakListe);
        }

        public void KayitGetir()
        {
            try
            {
                SqlConnection myConn = new SqlConnection("Data Source=U220\\SQLEXPRESS;Initial Catalog=SpeechToText;Integrated Security=True");
                string kayit = "SELECT * FROM TextTable ORDER BY Tarih ASC";
                SqlCommand komut = new SqlCommand(kayit, myConn);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                dgvVeriTabani.DataSource = dt;
                myConn.Close();

                dgvVeriTabani.Columns[0].Width = 50;
                dgvVeriTabani.Columns[1].Width = 100;
                dgvVeriTabani.Columns[2].Width = 150;
                dgvVeriTabani.Columns[3].Width = 650;
                dgvVeriTabani.Columns[4].Width = 475;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLocalhost_Click(object sender, EventArgs e)
        {
            if(Directory.Exists("C:/Program Files/Google/Chrome/Application") == true)
            {
                System.Diagnostics.Process.Start("chrome.exe", "http://localhost:3545/");
                Thread.Sleep(1000);
                SendKeys.SendWait("{F11}");
            }
            else if (Directory.Exists("C:\\Program Files (x86)\\Microsoft\\Edge\\Application") == true)
            {
                System.Diagnostics.Process.Start("msedge.exe", "http://localhost:3545/");
                Thread.Sleep(1000);
                SendKeys.SendWait("{F11}");
            }
            else if(Directory.Exists("C:/Program Files/Google/Chrome/Application") != true)
            {
                MessageBox.Show("Uyumlu tarayıcınız bulunmamaktadır. Chrome kurulumu başlıyor.");
                CMDCalistir("ChromeSetup.exe", @"\\192.168.100.17\Ses_Dosyalari", null, ProcessWindowStyle.Hidden);
            }
        }

    }
}