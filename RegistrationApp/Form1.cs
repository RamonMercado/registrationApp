using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Npgsql;

namespace RegistrationApp
{
    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
            diableBtn();
        }

        private void diableBtn()
        {
            if (passwordTxtBox.Text.Length == 0 && emailTxtBox.Text.Length == 0 && confirmPasswordTxtBox.Text.Length == 0)
            {
                registerBtn.Enabled = false;
            }

        } 
        private void registerBtn_Click(object sender, EventArgs e)
        {

            //  SqlConnection con = new SqlConnection(@"Dsn=PostGreVS;uid=postgres");

            emailTxtBox.Focus();
            string email = emailTxtBox.Text;
            string password = passwordTxtBox.Text;
            string confirmPassword = confirmPasswordTxtBox.Text;
            string acceptTerms;
            if (acceptTermscheckBox.Checked == true)
            {
                acceptTerms = "Y";
            }
            else
            {
                acceptTerms = "N";
            }
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Password: " + password);
            Console.WriteLine("Confirm Password: " + confirmPassword);
            Console.WriteLine("Accepted Terms: " + acceptTerms);
            //TestConnection();
            insertData(email, password, acceptTerms);
            this.Close();

        }

        private static void insertData(string email, string password, string acceptTerms)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"insert into userregistration values ('" + email + "','" + password + "', '" + acceptTerms + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Record Inserted");
                }
            }
        }
        private static void TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connected");
               
                    ;
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }
        }
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432; User Id=postgres; Password = 123456; Database=Users;");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Close(object sender, MouseEventArgs e)
        {
            this.Close();  //”this” refers to the form
        }

        private void confirmPassword(object sender, EventArgs e)
        {
            if(passwordTxtBox.Text == confirmPasswordTxtBox.Text && passwordTxtBox.Text.Length != 0)
            {
                registerBtn.Enabled=true;
            }
            else
            {
                registerBtn.Enabled = false;
            }
        }
    }
}
