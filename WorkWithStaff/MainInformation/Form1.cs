using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WorkWithStaff.FullInformation;

namespace WorkWithStaff
{
    public partial class Form1 : Form
    {
        private MySqlCommand mySqlCommand;
        private MySqlConnection mySqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void FillDataGridView()
        {
            try
            {
                mySqlCommand.CommandText = "Select *from `fullinformation` as fi join `workname` as wn on fi.idPost=wn.Id";

                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                dataGridViewWorkWithMainInformation.Rows.Clear();

                while (reader.Read())
                {
                    string id = reader.GetString("Id");
                    string name = reader.GetString("Name");
                    string secondName = reader.GetString("SecondName");
                    string patronymic = reader.GetString("Patronymic");
                    string telephone = reader.GetString("Telephone");
                    //int idPost = reader.GetInt32("idPost");
                    string post = reader.GetString(17);
                    int age = reader.GetInt32("Age");
                    DateTime dateInvite = reader.GetDateTime("InviteDate");

                    dataGridViewWorkWithMainInformation.Rows.Add(reader.GetString("Id"), reader.GetString("Name"), reader.GetString("SecondName"), reader.GetString("Patronymic"), reader.GetString("Telephone"), post, age, dateInvite);
                }
                reader.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Произошла ошибка в загрузке");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;

            FillDataGridView();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddForm().Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;



            int selectedId = int.Parse(dataGridViewWorkWithMainInformation.SelectedRows[0].Cells[0].Value.ToString());

            mySqlCommand.CommandText = $"Delete from `fullinformation` where `Id`={selectedId}";
            mySqlCommand.ExecuteNonQuery();

            MessageBox.Show("Сотрудник уволен");


            FillDataGridView();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;
            try
            {
                int idSelectedId = int.Parse(dataGridViewWorkWithMainInformation.SelectedRows[0].Cells[0].Value.ToString());

                mySqlCommand.CommandText = $"Select* from `fullinformation` where `Id`={idSelectedId}";
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Пожайлуста выберите работника");
                    return;
                }
                else
                {
                    reader.Read();
                    Global.Information = new Information()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        SecondName = reader.GetString("SecondName"),
                        Patronymic = reader.GetString("Patronymic"),
                        Telephone = reader.GetString("Telephone"),
                        IdPost = reader.GetInt32("idPost"),
                        LaborCost = reader.GetInt32("LaborCost"),
                        PlaceOfResidence = reader.GetString("PlaceOfResidence"),
                        Age = reader.GetInt32("Age"),
                        InviteDate = reader.GetDateTime("InviteDate"),
                        NumberSNILS = reader.GetString("numberSNILS"),
                        NumberHealthInsurance = reader.GetString("numberHealthInsurance"),
                        DescriptionAboutPassport = reader.GetString("descriptionAboutPassport"),
                        Date = reader.GetDateTime("releaseDate"),
                        SerialPassport = reader.GetString("serialPassport"),
                        NumberPassport = reader.GetString("numberPassport")
                    };
                    reader.Close();

                    this.Hide();
                    new FullInformationForm().Show();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при выборе сотрудника");
                return;
            }
           
        }

        private void buttonMoreInformation_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;
            try
            {
                int idSelectedId = int.Parse(dataGridViewWorkWithMainInformation.SelectedRows[0].Cells[0].Value.ToString());

                mySqlCommand.CommandText = $"Select* from `fullinformation` where `Id`={idSelectedId}";
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Пожайлуста выберите работника");
                    return;
                }
                else
                {
                    reader.Read();
                    Global.Information = new Information()
                    {
                        Id = reader.GetInt32("Id"),
                        Name = reader.GetString("Name"),
                        SecondName = reader.GetString("SecondName"),
                        Patronymic = reader.GetString("Patronymic"),
                        Telephone = reader.GetString("Telephone"),
                        IdPost = reader.GetInt32("idPost"),
                        LaborCost = reader.GetInt32("LaborCost"),
                        PlaceOfResidence = reader.GetString("PlaceOfResidence"),
                        Age = reader.GetInt32("Age"),
                        InviteDate = reader.GetDateTime("InviteDate"),
                        NumberSNILS = reader.GetString("numberSNILS"),
                        NumberHealthInsurance = reader.GetString("numberHealthInsurance"),
                        DescriptionAboutPassport = reader.GetString("descriptionAboutPassport"),
                        Date = reader.GetDateTime("releaseDate"),
                        SerialPassport = reader.GetString("serialPassport"),
                        NumberPassport = reader.GetString("numberPassport")
                    };
                    reader.Close();

                    this.Hide();
                    new FullInformationForm().Show();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при выборе сотрудника");
                return;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;

            string searchPerson = textBoxForSearch.Text;

            if (searchPerson.Length == 0)
            {
                mySqlCommand.CommandText = $"Select *from `fullinformation` as fi join `workname` as wn on fi.idPost=wn.Id";
            }
            else
            {
                mySqlCommand.CommandText = $"Select *from `fullinformation` as fi join `workname` as wn on fi.idPost=wn.Id where fi.Name like '%{searchPerson}%' or fi.SecondName like '%{searchPerson}%' or fi.Patronymic like'%{searchPerson}%' or fi.Telephone like'%{searchPerson}%' or wn.Name like'%{searchPerson}%'";
            }

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            dataGridViewWorkWithMainInformation.Rows.Clear();

            while (reader.Read())
            {
                dataGridViewWorkWithMainInformation.Rows.Add(reader.GetString("Id"), reader.GetString("Name"), reader.GetString("SecondName"), reader.GetString("Patronymic"), reader.GetString("Telephone"), reader.GetString("PostInCompany"));
            }

            reader.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
