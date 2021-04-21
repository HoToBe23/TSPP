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
    public partial class SearchXYVariantForm : Form
    {
        public SearchXYVariantForm()
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

            textBox2.BackColor = ButtonBackground;
            textBox2.ForeColor = TextAndBorderColor;

            label1.ForeColor = TextAndBorderColor;
            label2.ForeColor = TextAndBorderColor;
            label3.ForeColor = TextAndBorderColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Кнопка Знайти
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Не введено дані");
                return;
            }
            BookLibrary bookLibrary = new BookLibrary();
            MyBooks.BookLibrary.NameForSearch = textBox1.Text;
            MyBooks.BookLibrary.SurnameForSearch = textBox2.Text;
            MyBooks.BookLibrary.VariantForSearch = 1;

            this.Hide();
            SearchResultForm searchResultForm = new SearchResultForm();
            searchResultForm.Show();
        }

        //Кнопка Скасувати
        private void button2_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        //Очистка полей
        public void ClearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
