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
    public partial class StartMenuForm : Form
    {
        public StartMenuForm()
        {
            InitializeComponent();
        //    this.WindowState = FormWindowState.Maximized;
            this.Text = "MyBooks";
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

            label1.ForeColor = TextAndBorderColor;
            label2.ForeColor = TextAndBorderColor;



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете побачити всі книги?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                BooksOutputForm booksOutputForm = new BooksOutputForm();
                booksOutputForm.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете запустити цей процес?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                SearchXYVariantForm searchXYVariantForm = new SearchXYVariantForm();
                searchXYVariantForm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете запустити цей процес?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                SearchXXVariantForm searchXXVariantForm = new SearchXXVariantForm();
                searchXXVariantForm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult ChooseYesNo = MessageBox.Show("Впевнені що хочете авторизуватися?", "MyBooks", MessageBoxButtons.YesNo);
            if (ChooseYesNo == DialogResult.Yes)
            {
                this.Hide();
                AutorizationForm autorizationForm = new AutorizationForm();
                autorizationForm.Show();
            }
        }
    }
}
