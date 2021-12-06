using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

// Verrechne 2 Zahlen miteinader und Convertiere Dual zu Decimal

namespace DualRechner
{
    public partial class Form1 : Form
    {
        // Diese Variabeln werden die Zahlen zum Rechnen sein
          private enum Ops
        {
            MUL, MINUS, ADD, NONE
        }

        private string a = "";
        private string b = "";
        private bool lockA = false;
        private bool lockB = false;
        private Ops op = Ops.NONE;
        
              public Form1()
        {
            InitializeComponent();
            errorLabel.Text = "";
            resultText.Text = "";
            label4.Text = "";
        }

        // helper
        int binAdd(int a, int b)
        {
            // die Zahl die geshiftet werden muss
            int c;

            while (b != 0)
            {
                // gibt mir die zahlen die 1 sind und zieht ne 0 auf die rechte seite
                c = (a & b) << 1;
                
                // finde mir die summe 
                a = a ^ b;

                // mach weiter wenn nicht 0
                b = c;
            }

            return a;

            // Beispiel: a = 1, b = 1,

            // 1. b != 0 | True
            // 2. C = (a&b) << 1 | 10
            // 3. a = a ^ b; | 1;
            // 4. b = c | 10

            // next round
            // 5.b != 0 | True
            // 6.C = (a&b) << 1 | 0;
            // 7. a = a ^ b | 10;
            // 8. b = c | 0;

            // Fertig;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var testing = "";
            string s = textBox1.Text.Trim();

            if (lockA == false)
            {
                // setze test string
                testing = s;
            } else
            {
                testing = s;
            }
          

            // Number pruefen 
            // Mit Regex wird geschaut ob der Input mit 01 startet und auch so endet.
            // Dies sorgt dafuer das nur korekte 01 Pattern gehen
            if (!Regex.IsMatch(testing, "^[01]+$")) {
                errorLabel.Text = "Input is not valid";
            } else
            {
                // wird wieder leer
                errorLabel.Text = "";
                
                // checkt welche number gesetzt werden muss
                if (lockA == false)
                {
                    a = s;
                } else
                {
                    b = s;
                }
            }
 }
        
        // Hier wird der Input zu Dezimal gemacht
        private void button1_Click(object sender, EventArgs e)
        {
            // checke ob etwas gesetzt ist
            if (a.Length > 0)
            {
                label4.Text = Convert.ToInt32(a, 2).ToString();
                // reset a
                a = "";
                
                // reset labels und die Textbox
                textBox1.Text = "";
                errorLabel.Text = "";
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (a.Length > 0)
            {
                // a ist gesetzt, also wird es jetzt gelocked (wie so ein Mutex)
                lockA = true;
                textBox1.Text = "";
                errorLabel.Text = "";


                // set operation
                op = Ops.ADD;
            } else
            {
                errorLabel.Text = "You must first enter a number before doing a operation";
            }
        }

        // berechnet alles und gibt das Ergebnis aus 
        private void eq_Click(object sender, EventArgs e)
        {
           
            if (a.Length > 0 && b.Length > 0 && op != Ops.NONE)
            {
                errorLabel.Text = "";
                // String in zahleln umwandeln
                // check das der Nutzer keine zu groesse Zahl macht.
                int inta = 0;
                int intb = 0;
                try
                {
                    // wird zu einem Int 32 umgewandelt
                    inta = Convert.ToInt32(a, 2);
                    // wird zu einem Int 32 umgewandelt
                    intb = Convert.ToInt32(b, 2);
                } catch
                {
                    // Error Anzeigen
                    errorLabel.Text = "Inpur to large.";
                    // clear text box, sonst muss der Nutzer den Text manuel cleanen
                    textBox1.Text = "";
                    // Beenden
                    return;
                }

                // checke welche operation verwendet wird
                if (op == Ops.ADD)
                {
                    // addiere die Zahlen
                    resultText.Text = Convert.ToString(binAdd(inta, intb), 2);
                } else if (op == Ops.MINUS)
                {
                    // Dieser Teil tut eigendlich genau das gleiche wie BinAdd()
                    int carr;
                    int tempB = Convert.ToInt32(b, 2);
                    int tempa = Convert.ToInt32(a, 2);

                    // hier wird die Zahl b negiert also not
                    // man koennte sagen die zahl wird umgedreht.
                    tempB = binAdd(~tempB, 1);

                    // die schleife macht das gleiche wie in BinAdd()
                    while (tempB != 0)
                    {
                        carr = (tempa & tempB) << 1;
                        tempa = tempa ^ tempB;
                        tempB = carr;
                    }

                    resultText.Text = Convert.ToString(tempa, 2);
                } else if (op == Ops.MUL)
                {

                    resultText.Text = Convert.ToString(inta * intb, 2);
                }

                // reset all
                textBox1.Text = "";
                errorLabel.Text = "";
                a = "";
                b = "";
                op = Ops.NONE;

                // stop locks
                lockA = lockB = false;
            } else
            {
                errorLabel.Text = "Please start a calculation";
            }
        }
        
        // minus
        private void button2_Click(object sender, EventArgs e)
        {
            if (a.Length > 0)
            {
                // a ist gesetzt, also wird es jetzt gelocked (wie so ein Mutex)
                lockA = true;
                textBox1.Text = "";
                errorLabel.Text = "";


                // set operation
                op = Ops.MINUS;
            }
            else
            {
                errorLabel.Text = "You must first enter a number before doing a operation";
            }
        }
        
        // Multiply
        private void mul_Click(object sender, EventArgs e)
        {
            if (a.Length > 0)
            {
                // a ist gesetzt, also wird es jetzt gelocked (wie so ein Mutex)
                lockA = true;
                textBox1.Text = "";
                errorLabel.Text = "";


                // set operation
                op = Ops.MUL;
            }
            else
            {
                errorLabel.Text = "You must first enter a number before doing a operation";
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void errorLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
