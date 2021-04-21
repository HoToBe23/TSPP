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
    public partial class AddBooksForm : Form
    {
        public AddBooksForm()
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

            SurnameAuthorField.BackColor = ButtonBackground;
            SurnameAuthorField.ForeColor = TextAndBorderColor;

            YearCreateField.BackColor = ButtonBackground;
            YearCreateField.ForeColor = TextAndBorderColor;

            PlaceField.BackColor = ButtonBackground;
            PlaceField.ForeColor = TextAndBorderColor;

            label1.ForeColor = TextAndBorderColor;
            label2.ForeColor = TextAndBorderColor;
            label3.ForeColor = TextAndBorderColor;
            label4.ForeColor = TextAndBorderColor;
            label5.ForeColor = TextAndBorderColor;
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void NameBookField_TextChanged(object sender, EventArgs e)
        {

        }

        //Кнопка скасувати
        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        //Кнопка ОК
        private void button2_Click(object sender, EventArgs e) 
        {
            if(NameBookField.Text == "")
            {
                MessageBox.Show("Не введено дані");
                return;
            }
            else if (SurnameAuthorField.Text == "")
            {
                MessageBox.Show("Не введено дані");
                return;
            }
            else if (YearCreateField.Text == "")
            {
                MessageBox.Show("Не введено дані");
                return;
            }
            else if (PlaceField.Text == "")
            {
                MessageBox.Show("Не введено дані");
                return;
            }

            string UserName, UserSurname;
            int UserYear, UserPlace;

            UserName = NameBookField.Text;
            UserSurname = SurnameAuthorField.Text;
            UserYear = Convert.ToInt32(YearCreateField.Text);
            UserPlace = Convert.ToInt32(PlaceField.Text);

            if (!isUniqueNameBook(UserName) && !isUniqueSurnameAuthor(UserSurname))
            {
                MessageBox.Show("Автор та назва такої книги уже є в базі даних");
                return;
            }
            else if(!isCorrectInput(UserYear, UserPlace))
            {
                MessageBox.Show("Неправильно введений рік видання або місце розташування книги");
                return;
            }
            else if (!isFreePlace(UserPlace))
            {
                MessageBox.Show("Це місце вже зайнято");
                return;
            }

            MySQL mysql = new MySQL();

            mysql.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //MySqlCommand count = new MySqlCommand("SELECT COUNT(*) as count FROM `bookslibrarytable`", mysql.getConnection());

            //int AmountBooksInLibrary = (int)count.ExecuteScalar();

            //if (AmountBooksInLibrary >= 250)
            //{
            //    MessageBox.Show("В базі даних уже 250 книг, більше не можна");
            //    return;
            //}

            MySqlCommand command = new MySqlCommand("INSERT INTO `bookslibrarytable` (`id`, `surname`, `name`, `year`, `place`) VALUES (NULL, @uS, @uN, @uY, @uP);", mysql.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = UserName;
            command.Parameters.Add("@uS", MySqlDbType.VarChar).Value = UserSurname;
            command.Parameters.Add("@uY", MySqlDbType.Int32).Value = UserYear;
            command.Parameters.Add("@uP", MySqlDbType.Int32).Value = UserPlace;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            MessageBox.Show("Дані успішно занесені до бази даних");

            BookLibrary bookLibrary = new BookLibrary();
            //bookLibrary.BooksAtLibraryAtTheMoment = AmountBooksInLibrary + 1;

            ClearTextBox();

            mysql.closeConnection();

        }

        //Кнопка повернутися
        private void button3_Click(object sender, EventArgs e)
        {
            //MySQL mysql = new MySQL();

            //mysql.openConnection();

            //DataTable table = new DataTable();

            //MySqlDataAdapter adapter = new MySqlDataAdapter();

            //MySqlCommand count = new MySqlCommand("SELECT COUNT(*) as count FROM `bookslibrarytable`", mysql.getConnection());

            

            //int AmountBooksInLibrary = (int)count.ExecuteScalar();

            //if (AmountBooksInLibrary < 10)
            //{
            //    MessageBox.Show("В базі даних менше 10 книг");
            //    return;
            //}
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете повернутися в головне меню?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                StartMenuAfterAutorizationForm SwitchStartMenu = new StartMenuAfterAutorizationForm();
                SwitchStartMenu.Show();
            }

            //mysql.closeConnection();
        }

        //Кнопка показати всі книги
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете побачити всі книги?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                BooksOutputForm booksOutputForm = new BooksOutputForm();
                booksOutputForm.Show();
            }

        }

        //Проверка на уникальность фамилии автора
        public Boolean isUniqueSurnameAuthor(string _surname)
        {
            MySQL mysql = new MySQL();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bookslibrarytable` WHERE `surname` = @uS", mysql.getConnection());
            command.Parameters.Add("@uS", MySqlDbType.VarChar).Value = _surname;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Проверка на уникальность название книги
        public Boolean isUniqueNameBook(string _name)
        {
            MySQL mysql = new MySQL();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bookslibrarytable` WHERE `name` = @uN", mysql.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = _name;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Проверка на правильность введения года и места
        public Boolean isCorrectInput(int _year, int _place)
        {
            if(_year > 2020 || _year < 1950)
            {
                return false;
            }
            else if(_place <= 0 || _place > 9999)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Проверка на доступность места в библиотеке
        public Boolean isFreePlace(int _place)
        {
            MySQL mysql = new MySQL();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bookslibrarytable` WHERE `place` = @uP", mysql.getConnection());
            command.Parameters.Add("@uP", MySqlDbType.Int32).Value = _place;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Очистка полей
        public void ClearTextBox()
        {
            NameBookField.Text = "";
            SurnameAuthorField.Text = "";
            YearCreateField.Text = "";
            PlaceField.Text = "";
        }

    }
}
