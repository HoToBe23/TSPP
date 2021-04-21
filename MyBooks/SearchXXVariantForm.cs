using MySql.Data.MySqlClient;
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
    public partial class SearchXXVariantForm : Form
    {
        public SearchXXVariantForm()
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

            textBox1.BackColor = ButtonBackground;
            textBox1.ForeColor = TextAndBorderColor;

            label1.ForeColor = TextAndBorderColor;
            label2.ForeColor = TextAndBorderColor;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SearchXXVariantForm_Load(object sender, EventArgs e)
        {

        }

        //Кнопка скасувати
        private void button2_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        //Кнопка знайти
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не введено дані");
                return;
            }
            BookLibrary bookLibrary = new BookLibrary();
            MyBooks.BookLibrary.YearForSearch = Convert.ToInt32(textBox1.Text);
            MyBooks.BookLibrary.VariantForSearch = 2;

            this.Hide();
            SearchResultForm searchResultForm = new SearchResultForm();
            searchResultForm.Show();
        }

        //Кнопка Повернутися
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете повернутися в головне меню?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                Autorization autorization = new Autorization();

                if (autorization.CheckAutorization())
                {
                    this.Hide();
                    StartMenuAfterAutorizationForm SwitchStartMenu = new StartMenuAfterAutorizationForm();
                    SwitchStartMenu.Show();
                }
                else
                {
                    this.Hide();
                    StartMenuForm SwitchStartMenu = new StartMenuForm();
                    SwitchStartMenu.Show();
                }
            }
        }

        //Кнопка очистка поля
        public void ClearText()
        {
            textBox1.Text = "";
        }
    }
}
