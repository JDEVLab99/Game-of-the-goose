using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Gioco_oca
{
    class Giocatore
    {
        private int pos;
        private int casuale;
        private string name_player;
        private bool fermo;
        private bool vincita;

        public Giocatore()
        {
            pos = 1;
            casuale = 0;
            fermo = false;
            vincita = false;
        }
        public void set_pos(int val)
        {
            pos = val;
        }

        public void calcola_pos()
        {
            pos = pos + casuale;
        }

        public int get_pos()
        {
            return pos;
        }

        public int get_casuale()
        {
            return casuale;
        }

        public void set_fermo()
        {
            fermo = true;
        }

        public void disattiva_fermo()
        {
            fermo = false;
        }

        public bool get_fermo()
        {
            return fermo;
        }

        public void visualizza()
        {
            MessageBox.Show("DADI LANCIATI: " + get_casuale());
            MessageBox.Show("RAGGIUNGI CASELLA: " + get_pos());
        }

        public void set_name_player(string name)
        {
            name_player = name;
        }

        public string get_name_player()
        {
            return name_player;
        }

        public void set_Text(Casella[] casella)
        {
            casella[pos].Text = get_name_player();
        }

        public void azzera_Text(Casella[] casella)
        {
            casella[pos].Text = pos.ToString();
        }

        public void set_random()
        {
            Random dadi = new Random();
            casuale = dadi.Next(1,12);
        }

        public void controlla_pos()
        {
            int n = 0;
            if (pos > 63)
            {
                n = pos - 63;
                pos = 63 - n;
            }
            else if (pos == 63)
                vincita = true;
        }

        public bool get_vincita()
        {
            return vincita;
        }

        public void set_vincita()
        {
            vincita = false;
        }

        public void controlla_colore(Casella[] caselle)
        {
            if (name_player == "player1")
            {
                caselle[pos].ForeColor = Color.DarkBlue;
            }
            else if (name_player == "player2")
            {
                caselle[pos].ForeColor = Color.Fuchsia;
            }
            else if (caselle[pos].Text == "player1/player2")
            {
                caselle[pos].ForeColor = Color.WhiteSmoke;
            }
        }

    }
}
