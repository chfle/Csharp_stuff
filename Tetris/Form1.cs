using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

// Christian Lehnert 2021

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // init db
            string cs = @"server=192.168.55.8;user id=tetris;password=pqjerPCgChu2wvyJvYuXkZxxjHv6RbfE7mqebecz33mURUEv8K!123;database=tetris";


             try
            {
                conn = new MySqlConnection(cs);
                cmd = new MySqlCommand();

                cmd.Connection = conn;

                conn.Open();
            } catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong\n Error: {ex.Message}");
                return;
            }

             // Set name
            username = GetName();

            InitializeComponent();
            CmdLinks.Text = "◄";
            CmdRechts.Text = "►";
            CmdUnten.Text = "▼";

            // Score
            score.Text = "0";
            
            // set show name
            name.Text = $"{username}";

        }

        // Mysql stuff
        MySqlConnection conn = null;
        MySqlCommand cmd = null;
       
        /* Username */
        string username = "";

        /* Form2 */
        Form2 form2 = null;

        /* Score */
        int scoreValue = 0;

        /* Index des aktuellen Panels */
        private int PX;

        /* Spielfeld inkl. Randfelder */
        private readonly int[,] F = new int[15, 10];

        /* Zeile und Spalte des akt. Panels */
        private int PZ, PS;

        /* Schwierigkeitsstufe */
        private int Stufe;            

        /* Eine zunächst leere Liste von Spiel-Panels */
        private readonly List<Panel> PL = new List<Panel>();

        /* Ein Feld von Farben für die Panels */
        private readonly Color[] FarbenFeld = {Color.Red, Color.Yellow,
            Color.Green, Color.Blue, Color.Cyan,
            Color.Magenta, Color.Black, Color.White};

        /* Konstanten für Status eines Feldpunktes */
        private const int Leer = -1;
        private const int Rand = -2;

        /* Zufallsgenerator erzeugen und initialisieren */
        private readonly Random r = new Random();

        /* Ask user for a name */
        private string GetName()
        {
            Form promt = new Form();
            promt.Width = 500;
            promt.Height = 200;
            promt.Text = "User";
            Label textLabel = new Label { Left = 50, Top = 20, Text = "Enter your Name" };
            TextBox textBox = new TextBox { Left = 50, Top = 50, Width = 400, Text=""};
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };


            confirmation.Click += (sender, e) => {
                var n = textBox.Text;
                if (n.Trim().Length > 0)
                {
                   promt.Close();
                }
            };

            // add stuff
            promt.Controls.Add(confirmation);
            promt.Controls.Add(textLabel);
            promt.Controls.Add(textBox);

            promt.ShowDialog();

            var name = textBox.Text;

            return name;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Feld besetzen */
            for (int Z = 1; Z < 14; Z++)
            {
                F[Z, 0] = Rand;
                for (int S = 1; S < 9; S++)
                    F[Z, S] = Leer;
                F[Z, 9] = Rand;
            }

            for (int S = 0; S < 10; S++)
                F[14, S] = Rand;

            /* Initialisierung */
            Stufe = 1;
            NaechstesPanel();
        }

        private void NaechstesPanel()
        {
            int Farbe;
            Panel p = new Panel();

            /* Neues Panel zur generischen Liste hinzufügen */
            PL.Add(p);

            /* Neues Panel platzieren */
            p.Location = new Point(105, 77);
            p.Size = new Size(20, 20);

            /* Farbauswahl für neues Panel */
            Farbe = r.Next(0, 8);
            p.BackColor = FarbenFeld[Farbe];

            /* Neues Panel zum Formular hinzufügen */
            Controls.Add(p);

            /* Index für spaeteren Zugriff ermitteln */
            PX = PL.Count - 1;

            /* Aktuelle Zeile, Spalte */
            PZ = 1;
            PS = 5;
        }

        private void TimTetris_Tick(object sender, EventArgs e)
        {
            /* Falls es nicht mehr weiter geht */
            if (F[PZ + 1, PS] != Leer)
            {
                /* Oberste Zeile erreicht */
                if (PZ == 1)
                {
                    TimTetris.Enabled = false;
                    CmdPause.Visible = false;
                  

                    // Ask user if he wanna save his score
                    DialogResult result = MessageBox.Show("Game Over! Do you wanna save your score?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // try to add user 
                        try
                        {
                            cmd.CommandText = $"INSERT INTO score (Name,Score) Values('{username}', {scoreValue});";
                            cmd.ExecuteNonQuery();
                        } catch
                        {
                            MessageBox.Show("User exists! Updating score...");
                            try
                            {
                                // update user if
                                cmd.CommandText = $"SELECT * FROM score where Name='{username}';";

                                var reader = cmd.ExecuteReader();

                                reader.Read();

                                var value = Int64.Parse(reader["Score"].ToString());

                                reader.Close();

                                // update score if higher
                                if (scoreValue > value)
                                {
                                    cmd.CommandText = $"Update score SET Score = {scoreValue} where Name='{username}'";
                                    cmd.ExecuteNonQuery();
                                }

                            } catch (Exception ex)
                            {
                                MessageBox.Show("Cant read user" + ex.Message);
                            }
                        }
                    }

                    return;
                }

                F[PZ, PS] = PX;       // Belegen
                AllePruefen();
                NaechstesPanel();
            }
            else
            {
                /* Falls es noch weiter geht */
                PL[PX].Location = new Point(
                    PL[PX].Location.X, PL[PX].Location.Y + 20);
                PZ += 1;
            }
        }

        private void AllePruefen()
        {
            bool Neben = false, Ueber = false;

            /* Drei gleiche Panel nebeneinander ? */
            for (int Z = 13; Z > 0; Z--)
            {
                for (int S = 1; S < 7; S++)
                {
                    Neben = NebenPruefen(Z, S);
                    if (Neben) break;
                }
                if (Neben) break;
            }

            /* Drei gleiche Panel übereinander ? */
            for (int Z = 13; Z > 2; Z--)
            {
                for (int S = 1; S < 9; S++)
                {
                    Ueber = UeberPruefen(Z, S);
                    if (Ueber) break;
                }
                if (Ueber) break;
            }

            if (Neben || Ueber)
            {
                /* Schneller */
                Stufe += 1;
                TimTetris.Interval = 5000 / (Stufe + 9);

                // score setzen
                scoreValue++;

                // score anzeigen
                score.Text = $"{scoreValue}";


                /* Eventuell kann jetzt noch eine Reihe
                   entfernt werden */
                AllePruefen();
            }
        }

        /* Falls 3 Felder nebeneinander besetzt */
        private bool NebenPruefen(int Z, int S)
        {
            bool ergebnis = false;

            if (F[Z, S] != Leer && F[Z, S + 1] != Leer &&
                    F[Z, S + 2] != Leer)
            {
                /* Falls drei Farben gleich */
                if (PL[F[Z, S]].BackColor == PL[F[Z, S + 1]].BackColor &&
                        PL[F[Z, S]].BackColor == PL[F[Z, S + 2]].BackColor)
                {

             
                    for (int SX = S; SX < S + 3; SX++)
                    {
                        /* PL aus dem Formular löschen */
                        Controls.Remove(PL[F[Z, SX]]);

                        /* Feld leeren */
                        F[Z, SX] = Leer;

                        /* Panels oberhalb des entladenen
                           Panels absenken */
                        int ZX = Z - 1;
                        while (F[ZX, SX] != Leer)
                        {
                            PL[F[ZX, SX]].Location = new Point(
                                PL[F[ZX, SX]].Location.X,
                                PL[F[ZX, SX]].Location.Y + 20);

                            /* Feld neu besetzen */
                            F[ZX + 1, SX] = F[ZX, SX];
                            F[ZX, SX] = Leer;
                            ZX -= 1;
                        }

                    }
                    ergebnis = true;
                }
            }
            return ergebnis;
        }

        /* Falls drei Felder übereinander besetzt */
        private bool UeberPruefen(int Z, int S)
        {
            bool ergebnis = false;

            if (F[Z, S] != Leer && F[Z - 1, S] != Leer &&
                    F[Z - 2, S] != Leer)
            {
                /* Falls drei Farben gleich */
                if (PL[F[Z, S]].BackColor == PL[F[Z - 1, S]].BackColor &&
                        PL[F[Z, S]].BackColor == PL[F[Z - 2, S]].BackColor)
                {

                    /* 3 Panels entladen */
                    for (int ZX = Z; ZX > Z - 3; ZX--)
                    {
                        /* PL aus dem Formular löschen */
                        Controls.Remove(PL[F[ZX, S]]);

                        /* Feld leeren */
                        F[ZX, S] = Leer;
                    }
                    ergebnis = true;
                }
            }
            return ergebnis;
        }

        private void CmdLinks_Click(object sender, EventArgs e)
        {
            if (F[PZ, PS - 1] == Leer)
            {
                PL[PX].Location = new Point(
                    PL[PX].Location.X - 20, PL[PX].Location.Y);
                PS -= 1;
            }
        }

        private void CmdRechts_Click(object sender, EventArgs e)
        {
            if (F[PZ, PS + 1] == Leer)
            {
                PL[PX].Location = new Point(
                    PL[PX].Location.X + 20, PL[PX].Location.Y);
                PS += 1;
            }
        }

        private void CmdUnten_Click(object sender, EventArgs e)
        {
            while (F[PZ + 1, PS] == Leer)
            {
                PL[PX].Location = new Point(
                    PL[PX].Location.X, PL[PX].Location.Y + 20);
                PZ += 1;
            }
            F[PZ, PS] = PX;       // Belegen
            AllePruefen();
            NaechstesPanel();
        }

        private void scoreOpen_Click(object sender, EventArgs e)
        {
            if (form2 != null && !form2.IsDisposed)
            {
                return;
            }

            if (form2 == null) {
                form2 = new Form2();
            } else if (form2.IsDisposed)
            {
                form2 = new Form2();
            }

            form2.Show();
        }

        private void CmdPause_Click(object sender, EventArgs e)
        {
            TimTetris.Enabled = !TimTetris.Enabled;

            if (TimTetris.Enabled)
            {
                CmdPause.Text = "Pause";
            } else
            {
                CmdPause.Text = "Weiter";
            }
        }
    }
}
