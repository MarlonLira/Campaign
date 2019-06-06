using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Dispatch.Helpers {
    public class SendMail {

        // Dados Servidor
        String Host = "smtplw.com.br";
        Int32 Port = 587;
        String User = "vitoriag1";
        String Pass = "AcYNvtHU9360";
        String From = "mailing@hiacademia.com.br";
        
        // Dados Remetente
         String Nome = "Hi Academia";
         String Email = "mailing@hiacademia.com.br";
         String Email_Contato = "contato@hiacademia.com.br";
         String Subject = "";

        //Dados Destinatario
        String Destinatario_Nome = "";
        String Destinatario_Email = "";

        public void Init(DataTable Table, String Msg, String Subject) {
            Int32 ContAux = 0;

            String[] Operadores = new string[] { "Marlon|marlonlira2@gmail.com", "Ricardo|lrop@hotmail.com", "Newton|newtonvvf@hotmail.com" };
		    this.Subject = Subject;

            foreach (String Email in Operadores) {
                String [] Part = Email.Split('|');
                Destinatario_Nome = Part[0];
                Destinatario_Email = Part[1];

                SendEmail(Msg);

                Thread.Sleep(3000);
            }

            if (ContAux < 1 ) {
                for (int Cont = 0; Cont <= Table.Rows.Count; Cont++) {
                    Destinatario_Nome = Table.Rows[Cont]["nome"].ToString();
                    Destinatario_Email = Table.Rows[Cont]["email"].ToString();
                    
                    SendEmail(Msg);

                    Thread.Sleep(3000);
                }
            } else {
                for (int Cont = ContAux; Cont <= Table.Rows.Count; Cont++) {
                    Destinatario_Nome = Table.Rows[Cont]["nome"].ToString();
                    Destinatario_Email = Table.Rows[Cont]["email"].ToString();

                    SendEmail(Msg);

                    Thread.Sleep(3000);
                }
            }
        }

        public void SendEmail(String Msg) {

            Hlp Hlp = new Hlp();
            try {
                using (SmtpClient Smtp = new SmtpClient()) {
                    String Body = "";
                    DataTable Table = new DataTable();

                    //Config Servidor Email
                    Smtp.Host = Host;
                    Smtp.Port = Port;
                    Smtp.EnableSsl = true;
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new NetworkCredential(User, Pass);

                    Body = Hlp.MsgFormat(Msg, Destinatario_Nome, Email_Contato);

                    using (MailMessage Mail = new MailMessage()) {
                        //Armazenamento dos dados
                        Mail.From = new MailAddress(From);
                        Mail.To.Add(new MailAddress(Destinatario_Email));
                        //Mail.To.Add(new MailAddress("marlon.lira@hiacademia.com.br"));
                        Mail.Subject = Subject;
                        Mail.IsBodyHtml = true;
                        Mail.Body = Body;

                        Smtp.Send(Mail);

                        //Table.Rows.Add(Destinatario.Nome, "ENVIADO", Destinatario.Email, Obs);
                        Mail.Dispose();
                        Smtp.Dispose();
                    }


                }
            } catch (Exception Err) {
                
            }
        }
    }
}