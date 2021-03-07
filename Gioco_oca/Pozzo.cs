using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gioco_oca
{
    class Pozzo:Speciale
    {
        private int aspetta;
        public Pozzo(int i, string msg, string type, string image): base(i, msg, type, image)
        {
            aspetta = 2;
        }

        public override void azione(Giocatore player, Casella[] caselle, int pos, int turno)
        {
            base.azione(player, caselle, pos, turno);
            pos = player.get_pos();
            MessageBox.Show(caselle[pos].get_mex());
            caselle[pos].attiva_casella();
            player.set_Text(caselle);
            player.set_fermo();
            if (aspetta == 0)
            {
                MessageBox.Show("ATTESA FINITA VAI!");
                player.azzera_Text(caselle);
                caselle[pos].disattiva_casella();
                player.disattiva_fermo();
                player.calcola_pos();
                player.controlla_pos();
                if (player.get_vincita() == false)
                {
                    MessageBox.Show("RAGGIUNGI CASELLA " + player.get_pos());
                    pos = player.get_pos();
                    caselle[pos].attiva_casella();
                    player.controlla_colore(caselle);
                    player.set_Text(caselle);
                    aspetta = 2;
                }
            }
            else
            {
                MessageBox.Show("BLOCCATO!");
                aspetta--;
            }
        }
    }
}
