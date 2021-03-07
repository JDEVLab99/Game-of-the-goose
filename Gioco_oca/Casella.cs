using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Gioco_oca
{
    class Casella:System.Windows.Forms.Button
    {
        protected string tipo;
        protected string mex;

        public Casella(string type, string msg)
        {
            set_tipo(type);
            set_mex(msg);
        }

        public virtual void crea_casella(int i)
        {
            this.Name = i.ToString();
            this.Text = i.ToString();
            this.Enabled = false;
            this.Visible = true;
            this.Width = 85;
            this.Height = 96;
            this.Tag = i;
            this.BackColor = Color.Gold;
            this.ForeColor = Color.Black;
            this.Font = new Font(FontFamily.GenericSansSerif,12.0F, FontStyle.Bold);
        }

        public void attiva_casella()
        {
            this.Enabled = true;
        }

        public void disattiva_casella()
        {
            this.Enabled = false;
        }

        public string get_tipo()
        {
            return tipo;
        }

        public void set_tipo(string type)
        {
            tipo = type;
        }

        public void set_mex(string msg)
        {
            mex = msg;
        }

        public string get_mex()
        {
            return mex;
        }

        public virtual void azione(Giocatore player, Casella[] caselle, int pos, int turno)
        {
        }

    }
}
