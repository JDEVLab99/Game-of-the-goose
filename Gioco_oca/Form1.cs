using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Gioco_oca
{
    public partial class Form1 : Form
    {
        int i = 1,turno=1;
        bool uguale = false;
        Casella[] caselle = new Casella[64];
        Giocatore player1 = new Giocatore();
        Giocatore player2 = new Giocatore();

        public Form1()
        {
            InitializeComponent();
        }

        private void crea_caselle(FlowLayoutPanel temp, int quante)
        {
            int s = 0;
            //CREA CASELLE E LE AGGIUNGE AL PANEL IN BASE AL NUMERO CHE VOGLIO IO PASSATO COME PARAMETRO
            while(s < quante)
            {
                if (i == 5 || i==9 || i==14 || i==18 || i==23 || i==27 || i==32 || i==36 || i==41 || i==45 || i==50 || i==54 || i==59)
                {
                    caselle[i] = new Oca(i, "OCA", "SEI FINITO SU CASELLA OCA!", "oca1.png");
                }
                else if (i == 6)
                {
                    caselle[i] = new Ponte(i, "PONTE", "SEI FINITO SU CASELLA PONTE!", "ponte.jpg");
                }
                else if(i==19)
                {
                    caselle[i] = new Casa(i, "CASA", "SEI FINITO SU CASELLA CASA!", "casa.gif");
                }
                else if(i==31)
                {
                    caselle[i] = new Pozzo(i, "POZZO", "SEI FINITO SU CASELLA POZZO!", "pozzo.gif");
                }
                else if(i==42)
                {
                    caselle[i] = new Labirinto(i, "LABIRINTO", "SEI FINITO SU CASELLA LABIRINTO!", "labirinto.jpg");
                    
                }
                else if(i==52)
                {
                    caselle[i] = new Prigione(i, "PRIGIONE", "SEI FINITO SU CASELLA PRIGIONE!", "prigione.png");
                }
                else if (i == 58)
                {
                    caselle[i] = new Scheletro(i, "SCHELETRO", "SEI FINITO SU CASELLA SCHELETRO!", "scheletro.jpg");
                }
                else
                {
                    Numero num = new Numero(i,"NUMERO","SEI FINITO SU CASELLA NUMERO!");
                    num.crea_casella(i);
                    caselle[i] = num;
                    
                }
                temp.Controls.Add(caselle[i]);
                i++;
                s++;
            }
        }

        private void crea_label(FlowLayoutPanel temp)
        {
            Label arrivo = new Label();
            arrivo.Name = "arrivo";
            arrivo.Enabled = true;
            arrivo.Visible = true;
            arrivo.Width = 700;
            arrivo.Height = 50;
            arrivo.Image = Image.FromFile("sei_arrivato.jpg");
            temp.Controls.Add(arrivo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            crea_caselle(flowLayoutPanel1,13);
            crea_caselle(flowLayoutPanel2,6);
            crea_caselle(flowLayoutPanel3,12);
            crea_caselle(flowLayoutPanel4,5);
            crea_caselle(flowLayoutPanel5,11);
            crea_caselle(flowLayoutPanel6,3);
            crea_caselle(flowLayoutPanel7,10);
            crea_caselle(flowLayoutPanel8,1);
            crea_caselle(flowLayoutPanel9,2);
            crea_label(flowLayoutPanel11);
        }

        private void gioca(Giocatore player, string name, Giocatore avversario)
        {
            int pos = player.get_pos();
            player.set_name_player(name);
            player.controlla_colore(caselle);
            
            if (player.get_fermo() == false)
            {
                //AZZERA LA VECCHIA CASELLA 
                if (uguale == false)
                {
                    player.azzera_Text(caselle);
                    caselle[pos].disattiva_casella();
                }
                    
                //CALCOLA LA NUOVA CASELLA
                uguale = false;
                player.set_random();
                player.calcola_pos();
                player.controlla_pos();
                player.controlla_colore(caselle);

                if (player.get_vincita() == false)
                {
                    player.visualizza();

                    //CONTROLLA STESSA POSIZIONE
                    if (player.get_pos() == avversario.get_pos())
                    {
                        caselle[player.get_pos()].Text = "player1/player2";
                        MessageBox.Show("GIOCATORI NELLA STESSA POSIZIONE");
                        player.controlla_colore(caselle);
                        uguale = true;
                    }
                    else
                    {
                        //ATTIVA NUOVA CASELLA
                        player.set_Text(caselle);

                        pos = player.get_pos();//pos = numero random calcolato
                        caselle[pos].attiva_casella();
                        player.controlla_colore(caselle);
                    }

                    while ((caselle[player.get_pos()].get_tipo() == "OCA" || caselle[player.get_pos()].get_tipo() == "PONTE" || caselle[player.get_pos()].get_tipo() == "SCHELETRO" || caselle[player.get_pos()].get_tipo() == "LABIRINTO" || ((caselle[player.get_pos()].get_tipo() == "PRIGIONE" || caselle[player.get_pos()].get_tipo() == "CASA" || caselle[player.get_pos()].get_tipo() == "POZZO") && player.get_fermo() == false)) && player.get_vincita() == false)
                    {
                        caselle[player.get_pos()].azione(player, caselle, pos, turno);
                    }
                }
            }
            else
            {
                if (player.get_vincita() == false)
                {
                    //LO ESEGUE UNA VOLTA PER DECREMENTARE IL CONTATORE ASPETTA 
                    caselle[player.get_pos()].azione(player, caselle, pos, turno);
                    if (player.get_fermo() == false)
                    {
                        while ((caselle[player.get_pos()].get_tipo() == "OCA" || caselle[player.get_pos()].get_tipo() == "PONTE" || caselle[player.get_pos()].get_tipo() == "SCHELETRO" || caselle[player.get_pos()].get_tipo() == "LABIRINTO" || ((caselle[player.get_pos()].get_tipo() == "PRIGIONE" || caselle[player.get_pos()].get_tipo() == "CASA" || caselle[player.get_pos()].get_tipo() == "POZZO") && player.get_fermo() == false)) && player.get_vincita() == false)
                        {
                            caselle[player.get_pos()].azione(player, caselle, pos, turno);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (turno % 2 != 0)
            {
              gioca(player1, "player1", player2);
              if (player1.get_fermo() == true)
                 turno--;
              else
                 turno++;
             }
             else
             {
              gioca(player2, "player2", player1);
              if (player2.get_fermo() == true)
                 turno--;
              else
                 turno++;
             }
         
            if (player1.get_vincita() == true || player2.get_vincita() == true)
            {
                MessageBox.Show("CASELLA 63 RAGGIUNTA!");
                if (player1.get_vincita() == true)
                {
                    MessageBox.Show("HA VINTO IL PLAYER1!");
                }
                else
                    MessageBox.Show("HA VINTO IL PLAYER2!");
                resetta_tutto(player1);
                resetta_tutto(player2);
            }
        }

        private void resetta_tutto(Giocatore player)
        {
            player.azzera_Text(caselle);
            caselle[player.get_pos()].disattiva_casella();
            player.set_vincita();
            player.set_pos(1);
            caselle[player.get_pos()].attiva_casella();
            caselle[player.get_pos()].Text = "player1/player2";
            turno = 1;
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
