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

namespace WorkWithStaff.FullInformation
{
    public partial class AddForm : Form
    {
        private MySqlCommand mySqlCommand;
        private MySqlConnection mySqlConnection;
        List<Work> works;
        List<Information> information;
        public AddForm()
        {
            InitializeComponent();
        }

        //private void LoadWork(int idSelectedWork)
        //{
        //    mySqlCommand.CommandText = "Select* from `workname`";
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        int id = reader.GetInt32("id");
        //        string name = reader.GetString("name");

        //        works.Add(new Work()
        //        {
        //            Id = id,
        //            Name = name
        //        });

        //    }
        //    reader.Close();
        //}

        private void LoadWork()
        {
            string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;

            mySqlCommand.CommandText = $"Select* from `workname`";
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            works = new List<Work>();

            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");

                works.Add(new Work()
                {
                    Id = id,
                    Name = name
                });

            }
            reader.Close();

            //comboBoxPostInCompany.DataSource = works;
            //comboBoxPostInCompany.DisplayMember = "Name";

        }


        private void AddForm_Load(object sender, EventArgs e)
        {

            works = new List<Work>();
            try
            {
                MessageBox.Show("Введите данные о новом сотруднике");

                //string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

                //mySqlConnection = new MySqlConnection(connectionString);
                //mySqlConnection.Open();

                //mySqlCommand = new MySqlCommand();
                //mySqlCommand.Connection = mySqlConnection;


                LoadWork();
                comboBoxPostInCompany.DataSource = works;
                comboBoxPostInCompany.DisplayMember = "Name";

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }

        }


        private void buttonAddNewFullInformation_Click(object sender, EventArgs e)
        {

            try
            {

                DateTime date = dateTimePickerReleaseDate.Value;
            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            string dt = dateTime.ToString("yyyy-MM-dd H:mm:ss");

                DateTime inviteDate = dateTimePickerInvite.Value;
                DateTime dateTimeInvite = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                string dtInvite = dateTimeInvite.ToString("yyyy-MM-dd H:mm:ss");

                if (textBoxName.Text == null || textBoxSecondName.Text == null || textBoxAddPatronymic.Text == null || maskedTextBoxTelephone.Text == null || comboBoxPostInCompany.SelectedIndex == 0 || textBoxAddLaborCost.Text == null || textBoxAddPlaceOfResidence.Text == null || textBoxAddAge.TextLength == 0 || maskedTextBoxSNILS.Text == null || maskedTextBoxHealthInsurance.Text == null || textBoxDescriptionAboutPassport.Text == null || maskedTextBoxNumber.Text == null || maskedTextBoxSeries.Text == null) //|| laborcostFromTextBox == null || residenceFromTextBox == null || residenceFromTextBox == null || ageFromTextBox == null || experienceFromTextBox == null)
                {
                    MessageBox.Show("Пожайлуста заполните все поля");
                    return;
                }

                int idWork = ((Work)(comboBoxPostInCompany.SelectedItem)).Id;

                mySqlCommand.CommandText = $"insert into `fullinformation` (`Id`,`Name`, `SecondName`, `Patronymic`, `Telephone`, `idPost`,`LaborCost`,`PlaceOfResidence`,`Age`,`InviteDate`,`numberSNILS`,`numberHealthInsurance`,`descriptionAboutPassport`,`releaseDate`,`serialPassport`,`numberPassport`) values (0,'{textBoxName.Text}','{textBoxSecondName.Text}','{textBoxAddPatronymic.Text}', '{maskedTextBoxTelephone.Text}','{idWork}', '{textBoxAddLaborCost.Text}', '{textBoxAddPlaceOfResidence.Text}',{textBoxAddAge.Text},'{dtInvite}','{maskedTextBoxSNILS.Text}','{maskedTextBoxHealthInsurance.Text}','{textBoxDescriptionAboutPassport.Text}','{dt}',{maskedTextBoxSeries.Text},{maskedTextBoxNumber.Text})";
                mySqlCommand.ExecuteNonQuery();

                //mySqlConnection = new MySqlConnection(connectionString);
                //mySqlConnection.Open();

                //mySqlCommand = new MySqlCommand();
                //mySqlCommand.Connection = mySqlConnection;

                //mySqlCommand.CommandText = $"insert into `fullinformation` (`Name`, `SecondName, `Patronymic`, `Telephone`, `PostInCompany`,`LaborCost`,`PlaceOfResidence`,`Age`,`WorkExperience`) values ('{textBoxName}','{textBoxSecondName}','{textBoxAddPatronymic}', '{textBoxAddTelephone}', '{textBoxAddPosition}','{textBoxAddLaborCost}','{textBoxAddPlaceOfResidence}','{textBoxAddAge}','{textBoxAddWorkExperience}')";
                //mySqlCommand.ExecuteNonQuery();


                this.Hide();
                new Form1().Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при добавлении");
            }


        }

        private void buttonCancelInAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
