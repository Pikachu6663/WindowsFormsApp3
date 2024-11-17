using System;
using System.Linq;
using System.Text;
using WindowsFormsApp3.UsersСlasses;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxEmail.Text = "elka6454@mail.ru";
            textBoxName.Text = "Богначев Артём";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text) || 
                string.IsNullOrEmpty(textBoxName.Text) || 
                string.IsNullOrEmpty(textBoxSubject.Text) ||
                string.IsNullOrEmpty(textBoxBody.Text))
            {
                MessageBox.Show("Заполните имя поля!");
                return;
            }
            string smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("elka6454@mail.ry", "Богначёв Артём");
            string password = "Пароль";

            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n " +
                $"{Dns.GetHostName()} \n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                $"{textBoxBody.Text}";
            InfoEmailSending info = new InfoEmailSending(smtp, fromInfo, toInfo, subject, body);
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();
            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";

        }
    }
}
