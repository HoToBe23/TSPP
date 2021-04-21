using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBooks
{
    public partial class AutorizationForm : Form
    {
        public AutorizationForm()
        {
            InitializeComponent();

            Color WindowBackground = new Color();
            WindowBackground = Color.FromArgb(27, 30, 31);
            this.BackColor = WindowBackground;

            Color ButtonBackground = new Color();
            ButtonBackground = Color.FromArgb(43, 61, 64);

            Color TextAndBorderColor = new Color();
            TextAndBorderColor = Color.FromArgb(21, 218, 232);

            button1.BackColor = ButtonBackground;
            button1.ForeColor = TextAndBorderColor;

            button2.BackColor = ButtonBackground;
            button2.ForeColor = TextAndBorderColor;

            button3.BackColor = ButtonBackground;
            button3.ForeColor = TextAndBorderColor;

            textBox1.BackColor = ButtonBackground;
            textBox1.ForeColor = TextAndBorderColor;

            textBox2.BackColor = ButtonBackground;
            textBox2.ForeColor = TextAndBorderColor;

            label1.ForeColor = TextAndBorderColor;
            label2.ForeColor = TextAndBorderColor;
            label3.ForeColor = TextAndBorderColor;

        }

        private void Autorization_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Кнопка повернутися
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете повернутися в головне меню?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                StartMenuForm SwitchStartMenu = new StartMenuForm();
                SwitchStartMenu.Show();
            }

        }

        //Kнопка ОК
        private void button2_Click(object sender, EventArgs e)
        {
            string UserLogin, UserPassword;
            if(textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Не введено дані!");
                return;
            }

            UserLogin = textBox1.Text;
            UserPassword = textBox2.Text;

            Autorization autorization = new Autorization();

            if(!autorization.CheckLoginAndPassword(UserLogin, UserPassword))
            {
                MessageBox.Show("Введені дані не співпадають з даними адміністратора");
                return;
            }
            else
            {
                MessageBox.Show("Успішно ввійшли в систему як адміністратор");
                autorization.EditStatusAutorization(true);
                this.Hide();
                StartMenuAfterAutorizationForm SwitchStartMenu = new StartMenuAfterAutorizationForm();
                SwitchStartMenu.Show();

            }

        }

        //Кнопка скасувати
        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        //Очистка полей
        public void ClearTextBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
