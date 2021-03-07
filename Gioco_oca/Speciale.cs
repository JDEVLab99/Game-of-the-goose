using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Gioco_oca
{
    class Speciale:Numero
    {
        protected string img;

        public Speciale(int i,string msg, string type, string image):base(i,msg,type)
        {
            set_img(image);
            crea_casella(i);
        }

        public override void crea_casella(int i)
        {
            this.Name = i.ToString();
            this.Text = i.ToString();
            this.Enabled = false;
            this.Visible = true;
            this.Width = 85;
            this.Height = 96;
            this.Tag = i;
            this.BackgroundImage = Image.FromFile(img);
            this.ForeColor = Color.Red;
            this.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);
        }

        public void set_img(string image)
        {
            img = image;
        }

    }
}
