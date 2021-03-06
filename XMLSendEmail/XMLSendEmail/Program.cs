using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml;

namespace XMLSendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            // GET XML DATA
            string from = "";
            string to = "";
            string mail = "";
            string subject = "";
            var xmlObj = XmlReader.Create(@"C:\Users\ChristianLehnert\Downloads\chsharp_stuff\XMLSendEmail\XMLSendEmail\mail.xml");
            
            // read mail
            while (xmlObj.Read())
            {
                if (xmlObj.NodeType == XmlNodeType.Element)
                {
                    switch (xmlObj.Name)
                    {
                        case "from":
                            from = xmlObj.ReadString();
                            break;
                        case "to":
                            to = xmlObj.ReadString();
                            break;
                        case "message":
                            mail = xmlObj.ReadString();
                            break;
                        case "subject":
                            subject = xmlObj.ReadString();
                            break;
                    }
                }
            }
            
            // Get Names
            string fromName = "";
            string ToName = "";

            var R = new Regex("([^@]+)");

            fromName = R.Match(from).Value;
            ToName = R.Match(to).Value;

            if (fromName.Length > 0|| ToName.Length > 0)
            {
                var fromAddress = new MailAddress(from, fromName);
                var toAddress = new MailAddress(to, ToName);
                
                // get password
                Console.WriteLine("Enter a Password");
                var pass = string.Empty;
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        Console.Write("\b \b");
                        pass = pass[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        pass += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, pass)
                };

                using var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = mail
                };
                smtp.Send(message);
            }
        }
    }
}