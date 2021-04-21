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
    public partial class SearchResultForm : Form
    {
        public SearchResultForm()
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

            listBox1.BackColor = ButtonBackground;
            listBox1.ForeColor = TextAndBorderColor;

            label1.ForeColor = TextAndBorderColor;

            if(MyBooks.BookLibrary.VariantForSearch == 1)
            {
                ShowResultFirstVariant();
            }
            else
            {
                ShowResultSecondVariant();
            }
            
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SearchResultForm_Load(object sender, EventArgs e)
        {

        }

        //Кнопка Повернутися
        private void button1_Click(object sender, EventArgs e)
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

        //Кнопка Для cформування MS Word File
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Відображення пошуку принципу ХУ
        public void ShowResultFirstVariant()
        {
            string UserName = MyBooks.BookLibrary.NameForSearch;
            string UserSurname = MyBooks.BookLibrary.SurnameForSearch;

            MySQL mysql = new MySQL();

            mysql.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand commandPlace = new MySqlCommand("SELECT place FROM `bookslibrarytable` WHERE name = @uN AND surname = @uS", mysql.getConnection());
            commandPlace.Parameters.Add("@uN", MySqlDbType.VarChar).Value = UserName;
            commandPlace.Parameters.Add("@uS", MySqlDbType.VarChar).Value = UserSurname;
            MySqlDataReader place = commandPlace.ExecuteReader();

            while (place.Read())
            {
                string value = "Місце розташування - " + place[0].ToString();
                listBox1.Items.Add(value);
            }

            place.Close();

            adapter.SelectCommand = commandPlace;
            adapter.Fill(table);

            MessageBox.Show("Дані успішно відображені у відповідному вікні");

            mysql.closeConnection();
        }

        //Відображення пошуку принципу ХХ
        public void ShowResultSecondVariant()
        {
            int UserYear = MyBooks.BookLibrary.YearForSearch;
            string d = UserYear.ToString();
            MessageBox.Show(d);

            MySQL mysql = new MySQL();

            mysql.openConnection();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand commandName = new MySqlCommand("SELECT name FROM `bookslibrarytable` WHERE year = @uY;", mysql.getConnection());
            commandName.Parameters.Add("@uY", MySqlDbType.Int32).Value = UserYear;
            MySqlDataReader name = commandName.ExecuteReader();

            while (name.Read())
            {
                string value = name[0].ToString();
                listBox1.Items.Add(value);
            }

            name.Close();

            adapter.SelectCommand = commandName;
            adapter.Fill(table);

            MessageBox.Show("Дані успішно відображені у відповідному вікні");

            mysql.closeConnection();
        }
    }
}
