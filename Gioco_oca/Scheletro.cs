using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gioco_oca
{
    class Scheletro:Speciale
    {
        public Scheletro(int i, string msg, string type, string image): base(i, msg, type, image)
        {
        }

        public override void azione(Giocatore player, Casella[] caselle,int pos, int turno)
        {
            base.azione(player, caselle, pos, turno);
            pos = player.get_pos();
            MessageBox.Show(caselle[pos].get_mex());
            caselle[pos].attiva_casella();
            player.set_Text(caselle);
            player.azzera_Text(caselle);
            player.set_pos(1);
            if (player.get_vincita() == false)
            {
                MessageBox.Show("RAGGIUNGI CASELLA " + player.get_pos());
                caselle[pos].disattiva_casella();
                pos = player.get_pos();
                caselle[pos].attiva_casella();
                player.controlla_colore(caselle);
                player.set_Text(caselle);
            }
        }
    }
}
