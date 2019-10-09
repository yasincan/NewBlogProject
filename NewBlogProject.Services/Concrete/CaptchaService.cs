using NewBlogProject.Services.Abstract;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace NewBlogProject.Services.Concrete
{
    public class CaptchaService : ICaptchaService
    {

        private string text;
        private int width;
        private int height;
        private string familyName;
        private Bitmap image;
        private Color? backgroundColor;
        private Color? textColor;

        private Random random = new Random();

        public bool Verify(string type, string str)
        {
            var ctx = HttpContext.Current;
            if (ctx == null || ctx.Session == null || ctx.Session[type.ToString()] == null) return false;
            var cstr = ctx.Session[type.ToString()].ToString();
            ctx.Session.Remove(type.ToString());
            return cstr == str;
        }

        public void DisplayCaptcha(string type)
        {
            var context = HttpContext.Current;
            var cstr = RandomString(5);
            context.Session[type.ToString()] = cstr;
            context.Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            context.Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            context.Response.AppendHeader("Expires", "0"); // Proxies.
            context.Response.ContentType = "image/png";

            CreateCaptcha(cstr, 150, 50, "Geneva", Color.White, Color.Black);
            image.Save(context.Response.OutputStream, ImageFormat.Png);
            context.Response.End();
        }

        private void CreateCaptcha(string str, int width, int height, string font, Color bgColor, Color txtColor)
        {

            text = str;
            SetDimensions(width, height);
            SetFamilyName(font);
            backgroundColor = bgColor;
            textColor = txtColor;
            GenerateImage();
        }
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SetDimensions(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.");
            this.width = width;
            this.height = height;
        }

        private void SetFamilyName(string familyName)
        {
            try
            {
                Font font = new Font(this.familyName, 12F);
                this.familyName = familyName;
                font.Dispose();
            }
            catch
            {
                this.familyName = System.Drawing.FontFamily.GenericSerif.Name;
            }
        }

        private void GenerateImage()
        {
            Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.width, this.height);

            g.FillRectangle(new SolidBrush(this.backgroundColor ?? Color.LightBlue), rect);

            using (Font font = new Font(this.familyName, 22, FontStyle.Bold))
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                {
                    float i = 0;
                    var spacing = (int)((this.width / (text.Length + 1)) * 0.70);

                    foreach (var c in this.text)
                    {
                        GraphicsPath path = new GraphicsPath();
                        var r = new Rectangle(0, 0, spacing, spacing);
                        path.AddString(c.ToString(), font.FontFamily, (int)font.Style, font.Size, r, format);
                        var mx = new Matrix();
                        mx.Translate((i + 0.5f) * (int)(spacing + spacing * 0.70), random.Next(0, height / 3));
                        mx.RotateAt(this.random.Next(-80, 40), new PointF(spacing / 2, spacing / 2));
                        //mx.Rotate(this.random.Next(-30, 30));                    
                        path.Transform(mx);
                        g.FillPath(new SolidBrush(this.textColor ?? Color.Gray), path);
                        i++;

                    }
                }

                var colors = new Color[] { Color.LightCoral, Color.LightCyan, Color.Blue, Color.Beige, Color.Violet, Color.Yellow, Color.LightBlue };
                int m = Math.Max(rect.Width, rect.Height);
                for (int i = 0; i < (int)(rect.Width * rect.Height / 2F); i++)
                {
                    var randomColor = colors[i % colors.Length];
                    var hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, randomColor, Color.DarkGray);

                    int x = this.random.Next(rect.Width);
                    int y = this.random.Next(rect.Height);
                    int w = this.random.Next(m / 50);
                    int h = this.random.Next(m / 50);

                    g.FillEllipse(hatchBrush, x, y, w, h);
                }
            }
            g.Dispose();

            this.image = bitmap;
        }
    }
}
