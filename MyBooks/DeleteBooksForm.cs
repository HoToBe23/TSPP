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
    public partial class DeleteBooksForm : Form
    {
        public DeleteBooksForm()
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
            
            button4.BackColor = ButtonBackground;
            button4.ForeColor = TextAndBorderColor;


            NameBookField.BackColor = ButtonBackground;
            NameBookField.ForeColor = TextAndBorderColor;

            label1.ForeColor = TextAndBorderColor;
            label2.ForeColor = TextAndBorderColor;
        }

        private void DeleteBooksForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Кнопка видалити книгу
        private void button2_Click(object sender, EventArgs e)
        {
            if (NameBookField.Text == "")
            {
                MessageBox.Show("Не введено дані");
                return;
            }

            string UserName;

            UserName = NameBookField.Text;

            if (!isBookInTable(UserName))
            {
                MessageBox.Show("Такої книги немає в базі даних");
                ClearTextBox();
                return;
            }

            MySQL mysql = new MySQL();

            mysql.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `bookslibrarytable` WHERE `bookslibrarytable`.`name` = @uN", mysql.getConnection());
            command.Parameters.AddWithValue("@uN", UserName);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            MessageBox.Show("Книга успішно видалена з бази даних");

            ClearTextBox();

            mysql.closeConnection();
        }

        //Проверка есть ли книга в базе данных
        public Boolean isBookInTable(string _name)
        {
            MySQL mysql = new MySQL();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bookslibrarytable` WHERE `name` = @uN", mysql.getConnection());
            command.Parameters.AddWithValue("@uN", _name);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearTextBox()
        {
            NameBookField.Text = "";
        }

        //Кнопка скасувати
        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        //Кнопка показати всі книги
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BooksOutputForm booksOutputForm = new BooksOutputForm();
            booksOutputForm.Show();
        }

        //Кнопка повернутися
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете повернутися в головне меню?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                StartMenuAfterAutorizationForm SwitchStartMenu = new StartMenuAfterAutorizationForm();
                SwitchStartMenu.Show();
            }
        }
    }
}
