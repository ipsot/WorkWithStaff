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

    public partial class FullInformationForm : Form
    {
        private MySqlConnection mySqlConnection;
        private MySqlCommand mySqlCommand;

        List<Work> work;
        List<Information> information;
        int idRole = 0;
        public FullInformationForm()
        {
            InitializeComponent();
        }
        private void LoadWork()
        {
            string connectinString = "Server=127.0.0.1;Port=3306;Database=databaseforworkwithstaff;User=root;Password=1234";
            mySqlConnection = new MySqlConnection(connectinString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.CommandText = $"Select *from `workname`";
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            work = new List<Work>();
            while (reader.Read())
            {
                int id = reader.GetInt32("Id");
                string nameWork = reader.GetString("Name");

                work.Add(new Work()
                {
                    Id = id,
                    Name = nameWork
                });

            }
            reader.Close();
        }

        private void dataGridViewWorkWithFullInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FullInformationForm_Load(object sender, EventArgs e)
        {
            string connectinString = "Server=127.0.0.1;Port=3306;Database=databaseforworkwithstaff;User=root;Password=1234";
            mySqlConnection = new MySqlConnection(connectinString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;


            mySqlCommand.CommandText = $"Select *from `fullinformation` as fi join `workname` as wn on fi.idPost=wn.Id where 0={Global.Information.Id}";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

           
            //int idWork = ((Work)(comboBoxPost.SelectedItem)).Id;

            information =new List<Information>();

            textBoxName.Text = Global.Information.Name;
            textBoxSecondName.Text = Global.Information.SecondName;
            textBoxAddPatronymic.Text = Global.Information.Patronymic;
            maskedTextBoxTelephone.Text = Global.Information.Telephone;


            LoadWork();
            List<Work> newWork = new List<Work>();
            


            for (int i = 0; i < Global.Information.IdPost; i++)
            {
                for (int j = 0; j < work.Count; j++)
                {
                    if (Global.Information.IdPost == work[j].Id)
                    {
                        newWork.Add(work[j]);
                        int idRole = work[j].Id;
                        comboBoxPost.DataSource = work;// или newWork но при этом выводится только работа которой он обладает, и все элементы ей равны
                        comboBoxPost.DisplayMember = "Name";
                        //int idRole = Global.Work.Id;
                        comboBoxPost.SelectedIndex = idRole-1;
                    }
                    else
                    {
                        comboBoxPost.DataSource = work;// или newWork но при этом выводится только работа которой он обладает, и все элементы ей равны
                        comboBoxPost.DisplayMember = "Name";
                    }
                }
            }



            //foreach (int item in Global.Information.IdPost.ToString())
            //{

            //    for (int i = 0; i < item; i++)
            //    {
            //        for (int j = 0; j < work.Count; j++)
            //        {
            //            if (item == work[i])
            //            {
            //                ////comboBoxPost.DataSource = work;
            //                //comboBoxPost.Text = Global.Work.Name.ToString();
            //                comboBoxPost.DataSource = work;
            //                comboBoxPost.DisplayMember = "Name";
            //            }
            //        }
            //    }


            //}

            //comboBoxPost.DataSource = information;
            //comboBoxPost.DisplayMember = $"{Global.Information.IdPost}";//найти способ как передать туда название професии
            //comboBoxPost.DataSource = information;
            //comboBoxPost.DisplayMember = $"idPost";
            //comboBoxPost.SelectedItem = $"{Global.Information.IdPost}";
            //comboBoxPost.DisplayMember = $"{Global.Information.IdPost}";


            textBoxAddLaborCost.Text = Global.Information.LaborCost.ToString();
            textBoxAddPlaceOfResidence.Text = Global.Information.PlaceOfResidence;
            textBoxAddAge.Text = Global.Information.Age.ToString();
            dateTimePickerInvite.Value = Global.Information.InviteDate;
            maskedTextBoxSNILS.Text = Global.Information.NumberSNILS;
            maskedTextBoxHealthIns.Text = Global.Information.NumberHealthInsurance;
            textBoxDescription.Text = Global.Information.DescriptionAboutPassport;
            dateTimePicker1.Value = Global.Information.Date;
            maskedTextBoxSerialPassport.Text = Global.Information.SerialPassport;
            maskedTextBoxNumberPassport.Text = Global.Information.NumberPassport;


           

            //textBoxName.Clear();
            //textBoxSecondName.Clear();
            //textBoxAddPatronymic.Clear();
            //maskedTextBoxTelephone.Clear();
            //comboBoxPost.DataSource=null;
            //textBoxAddLaborCost.Clear();
            //textBoxAddPlaceOfResidence.Clear();
            //textBoxAddAge.Clear();
            //textBoxAddWorkExperience.Clear();
            //maskedTextBoxSNILS.Clear();
            //maskedTextBoxHealthIns.Clear();
            //textBoxDescription.Clear();
            ////dateTimePicker1.Value=null;
            //maskedTextBoxSerialPassport.Clear();
            //maskedTextBoxNumberPassport.Clear();

            //while (reader.Read())
            //{
            //int id = reader.GetInt32(0);
            //string name = reader.GetString("Name");
            //string secondName = reader.GetString("SecondName");
            //string patronymic = reader.GetString("Patronymic");
            //string telephone = reader.GetString("Telephone");
            //int idPost = reader.GetInt32("idPost");
            //string post = reader.GetString(17);
            //int laborCost = reader.GetInt32("LaborCost");
            //string placeOfResidende = reader.GetString("PlaceOfResidence");
            //int age = reader.GetInt32("Age");
            //int workExperience = reader.GetInt32("WorkExperience");
            //string numberSNILS = reader.GetString("numberSNILS");
            //string numberHealthInsurance = reader.GetString("numberHealthInsurance");
            //string descriptopn = reader.GetString("descriptionAboutPassport");
            //DateTime releaseDate = reader.GetDateTime("releaseDate");
            //string serial = reader.GetString("serialPassport");
            //string numberPassport = reader.GetString("numberPassport");


            //DateTime date = dateTimePickerReleaseDate.Value;
            //DateTime dateTime = new DateTime(releaseDate.Year, releaseDate.Month, releaseDate.Day, 0, 0, 0);
            //string dt = dateTime.ToString("yyyy-MM-dd H:mm:ss");

            //textBoxName.Text = name;
            //textBoxSecondName.Text = secondName;
            //textBoxAddPatronymic.Text = patronymic;
            //maskedTextBoxTelephone.Text = telephone;
            //comboBoxPost.SelectedItem = post;
            //textBoxAddLaborCost.Text = laborCost.ToString();
            //textBoxAddPlaceOfResidence.Text = placeOfResidende;
            //textBoxAddAge.Text = age.ToString();
            //textBoxAddWorkExperience.Text = workExperience.ToString();
            //maskedTextBoxSNILS.Text = numberSNILS;
            //maskedTextBoxHealthIns.Text = numberHealthInsurance;
            //textBoxDescription.Text = descriptopn;
            //dateTimePicker1.Value = dateTime;
            //maskedTextBoxSerialPassport.Text = serial;
            //maskedTextBoxNumberPassport.Text = numberPassport;


            //}
            //reader.Close();
        }

        private void FullInformationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void buttonBackToTheEnd_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void buttonAddFullInformation_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FullInformation.AddForm().Show();
        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {

        }

        //private void buttonSearchFullInformation_Click(object sender, EventArgs e)
        //{
        //    string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

        //    mySqlConnection = new MySqlConnection(connectionString);
        //    mySqlConnection.Open();

        //    mySqlCommand = new MySqlCommand();
        //    mySqlCommand.Connection = mySqlConnection;

        //    string searchPerson = textBoxSearch.Text;

        //    if (searchPerson.Length == 0)
        //    {
        //        mySqlCommand.CommandText = $"Select *from `fullinformation` ";
        //    }
        //    else
        //    {
        //        mySqlCommand.CommandText = $"Select *from `fullinformation` where (`Name`='{searchPerson}' or `SecondName`='{searchPerson}' or `Patronymic`='{searchPerson}' or `Telephone`='{searchPerson}' or `PostInCompany`='{searchPerson}' or `LaborCost`={searchPerson} or `PlaceOfResidence`='{searchPerson}' or `Age`={searchPerson} or `WorkExperience`={searchPerson})";
        //    }


        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();

        //    dataGridViewWorkWithFullInformation.Rows.Clear();

        //    while (reader.Read())
        //    {
        //        dataGridViewWorkWithFullInformation.Rows.Add(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetString("SecondName"), reader.GetString("Patronymic"), reader.GetString("Telephone"), reader.GetString("PostInCompany"), reader.GetInt32("LaborCost"), reader.GetString("PlaceOfResidence"), reader.GetInt32("Age"), reader.GetInt32("WorkExperience"));
        //    }

        //    reader.Close();
        //}

        private void buttonUpdateFullInformation_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;User=root;Password=1234;Database=databaseforworkwithstaff";

            mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();

            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlConnection;


            DateTime date = dateTimePicker1.Value;
            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            string dt = dateTime.ToString("yyyy-MM-dd H:mm:ss");

            DateTime inviteDate = dateTimePickerInvite.Value;
            DateTime dateTimeInvite = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            string dtInvite = dateTimeInvite.ToString("yyyy-MM-dd H:mm:ss");

            int idRole = ((Work)(comboBoxPost.SelectedItem)).Id;

            mySqlCommand.CommandText = $"Update `fullinformation` set  `Name`='{textBoxName.Text}', `SecondName`='{textBoxSecondName.Text}', `Patronymic`='{textBoxAddPatronymic.Text}', `Telephone`='{maskedTextBoxTelephone.Text}', `idPost`='{idRole}',`LaborCost`={textBoxAddLaborCost.Text},`PlaceOfResidence`='{textBoxAddPlaceOfResidence.Text}', `Age`={textBoxAddAge.Text}, `InviteDate`='{dtInvite}', `numberSNILS`='{maskedTextBoxSNILS.Text}',`numberHealthInsurance`='{maskedTextBoxHealthIns.Text}', `descriptionAboutPassport`='{textBoxDescription.Text}', `releaseDate`='{dt}', `serialPassport`='{maskedTextBoxSerialPassport.Text}', `numberPassport`='{maskedTextBoxNumberPassport.Text}' where Id={Global.Information.Id}";
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            reader.Close();

            MessageBox.Show("Данные о работнике успешно обновлены");
            this.Hide();
            new Form1().Show();
        }

        private void buttonCancelInAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void comboBoxPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idRole = ((Work)(comboBoxPost.SelectedItem)).Id;
            comboBoxPost.DataSource = work;
            comboBoxPost.DisplayMember = "Name";
        }
    }
}
