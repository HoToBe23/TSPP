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
    public partial class BooksOutputForm : Form
    {
        public BooksOutputForm()
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

            listBox1.BackColor = ButtonBackground;
            listBox1.ForeColor = TextAndBorderColor;

            label1.ForeColor = TextAndBorderColor;

            ShowBooks();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Кнопка ОК
        private void button1_Click(object sender, EventArgs e)
        {

            Autorization autorization = new Autorization();

            if (!autorization.CheckAutorization())
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


        public void ShowBooks()
        {
            MySQL mysql = new MySQL();

            mysql.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT name FROM `bookslibrarytable`", mysql.getConnection());
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["name"]);
            }

            dr.Close();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            mysql.closeConnection();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BooksOutputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
