using Jeff.Weibo;
using Microsoft.Office.Interop.Word;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        Jeff.Weibo.SinaWeibo sina = null;

        private void btnLoginSinaWeibo_Click(object sender, EventArgs e)
        {
            sina = new Jeff.Weibo.SinaWeibo("4140231521", "f52aeab2417234cc731c6b5fddca5257");

            bool ret = sina.Login("fzz727@sina.com", "anj2lear");

            if (ret)
            {
                MessageBox.Show("Login Success!");
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        private void btnPublishSinaWeibo_Click(object sender, EventArgs e)
        {
            if (sina.Connected)
            {
                bool ret = sina.PostWeibo("再来一个看看。看到的依旧忽略之....");

                if (ret)
                {
                    MessageBox.Show("Post Success!");
                }
                else
                {
                    MessageBox.Show("Post Failed");
                }
            }
            else
            {
                MessageBox.Show("Not Login");
            }
        }

        private void btnPublishSinaPicWeibo_Click(object sender, EventArgs e)
        {
            if (sina.Connected)
            {
                byte[] b = System.IO.File.ReadAllBytes("D:\\01.png");
                //再来一个图片的看看。看到的依旧忽略之....
                bool ret = sina.PostPicWeibo("", b);

                if (ret)
                {
                    MessageBox.Show("Post Success!");
                }
                else
                {
                    MessageBox.Show("Post Failed");
                }
            }
            else
            {
                MessageBox.Show("Not Login");
            }
        }


        private void btnLoginTencentWeibo_Click(object sender, EventArgs e)
        {

        }


        private void btnConvertDocToJpg_Click(object sender, EventArgs e)
        {

        }

        public bool ConvertDocToPng(String file, String targetPng)
        {
            List<Image> images = new List<Image>();

            Microsoft.Office.Interop.Word._Application wordApp = new Microsoft.Office.Interop.Word.Application();
            _Document doc = null;

            object objectMissing = Missing.Value;

            try
            {
                object fileName = file;
                FileStream fs = new FileStream(fileName.ToString(), FileMode.Open, FileAccess.Read);
                Byte[] data = new Byte[fs.Length];
                fs.Read(data, 0, data.Length);

                doc = wordApp.Documents.Open(ref fileName, ref objectMissing, ref objectMissing, ref objectMissing, ref objectMissing, ref objectMissing, ref objectMissing,
                                       ref objectMissing, ref objectMissing, ref objectMissing, ref objectMissing, ref objectMissing, ref objectMissing,
                                       ref objectMissing, ref objectMissing, ref objectMissing);

                foreach (Microsoft.Office.Interop.Word.Window window in doc.Windows)
                {
                    foreach (Microsoft.Office.Interop.Word.Pane pane in window.Panes)
                    {

                        for (int i = 1; i <= pane.Pages.Count; i++)
                        {
                            Page page = null; //

                            for (int k = 0; k < 2; k++)
                            {
                                try
                                {
                                    page = pane.Pages[i];
                                    break;
                                }
                                catch (Exception)
                                {

                                }
                            }

                            var bits = page.EnhMetaFileBits;

                            try
                            {
                                using (var ms = new MemoryStream((byte[])(bits)))
                                {
                                    Image image = System.Drawing.Image.FromStream(ms);

                                    Bitmap bitmap = ImageUtilities.ResizeImage(image, 1200, image.Height * 1200 / image.Width);

                                    bitmap = ImageUtilities.CutMarginImage(bitmap, 150, 150, 150, 150);

                                    images.Add(bitmap);
                                }
                            }
                            catch (System.Exception)
                            {
                            }
                        }

                    }
                }

                doc.Close();
                doc = null;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                }
                wordApp.Quit(ref objectMissing, ref objectMissing, ref objectMissing);
            }

            if (images.Count > 0)
            {
                Image img = ImageUtilities.CombinePic(images);

                String target = targetPng; // Path.Combine("D:\\test", "01");

                String pngTarget = Path.ChangeExtension(target, "png");

                img.Save(pngTarget, ImageFormat.Png);

                return true;
            }
            else
            {
                return false;
            }
        }

        bool start = false;

        private void btnLoginTencentWeibo2_Click(object sender, EventArgs e)
        {
            TencentWeibo weibo = new TencentWeibo();

            byte[] b = System.IO.File.ReadAllBytes("D:\\01.jpg");

            bool ret1 = weibo.PostPicWeibo("第二个", b);

            MessageBox.Show(ret1.ToString());
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image src = System.Drawing.Image.FromFile("D:\\Projects\\a.png");
            src = ImageUtilities.CutBottomBlank(src);

            src.Save("D:\\Projects\\b.png", ImageFormat.Png);
        }

        private void btnRegEx_Click(object sender, EventArgs e)
        {
            String s1 = "aaaaddf{0:yyyyMMddHH}sdf_{0:dd}_sdf";
            String s2 = String.Format(s1, DateTime.Now.AddDays(-20));
            MessageBox.Show(s2);
            return;

            String src = "abcdefghidilsklj\r\nkcmlo\r\niwermlfksd;f";
            String tar = "f.+?d";

            MessageBox.Show(src);

            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(tar, System.Text.RegularExpressions.RegexOptions.Multiline);

            System.Text.RegularExpressions.MatchCollection matchs = regEx.Matches(src, 10);

            foreach (System.Text.RegularExpressions.Match match in matchs)
            {
                MessageBox.Show(match.Index.ToString() + " " + match.Length + " " + match.Value);
            }
        }
    }
}
