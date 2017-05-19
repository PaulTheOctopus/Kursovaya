using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_korobka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView2.DataSource = GetDataAvto();
            dataGridView1.DataSource = GetDataKlient();
            dataGridView3.DataSource = GetDataRemont();
            dataGridView4.DataSource = GetDataOtremontirovano();
            dataGridView5.DataSource = GetDataMaster();
        }
        private DataTable GetDataKlient() //Выборка из базы клиентов
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM klient";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        private void insertDataKlient() // Добавление данных в таблицу клиентов
        {
            string conStr = "server=127.0.0.1;user=root;" +
            "database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO klient (familiya, imya, otchestvo, adres, nomer_tel, nomer_pas)" +
                    "VALUES (@familiya, @imya, @otchestvo, @adres, @nomer_tel, @nomer_pas)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@familiya", textBox1.Text);
                    cmd.Parameters.AddWithValue("@imya", textBox2.Text);
                    cmd.Parameters.AddWithValue("@otchestvo", textBox3.Text);
                    cmd.Parameters.AddWithValue("@adres", textBox4.Text);
                    cmd.Parameters.AddWithValue("@nomer_tel", textBox5.Text);
                    cmd.Parameters.AddWithValue("@nomer_pas", textBox6.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        private void DeleteRowKlient(string nomer_pas) //Удаление строки из базы данных
        {
            string conStr = "server=127.0.0.1;user=root;database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    //параметризованный запрос
                    string sql = "DELETE FROM klient WHERE nomer_pas = @nomer_pas";
                    //открываем соединение с базой данных
                    con.Open();
                    //создаём команду
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    //создаем параметр и добавляем его в коллекцию
                    cmd.Parameters.AddWithValue("@nomer_pas", nomer_pas);
                    //выполняем sql запрос
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        //.........AVTO
        private DataTable GetDataAvto() //Выборка из базы клиентов
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM avto";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        private void insertDataAvto() // Добавление данных в таблицу клиентов
        {
            string conStr = "server=127.0.0.1;user=root;" +
            "database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO avto (proizvoditel,model,nomer_avto,data_vipuska,nomer_pas) VALUES (@proizvoditel,@model,@nomer_avto,@data_vipuska,@nomer_pas)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@proizvoditel", textBox12.Text);
                    cmd.Parameters.AddWithValue("@model", textBox11.Text);
                    cmd.Parameters.AddWithValue("@nomer_avto", textBox10.Text);
                    cmd.Parameters.AddWithValue("@nomer_pas", textBox9.Text);
                    cmd.Parameters.AddWithValue("@data_vipuska", textBox8.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        private void DeleteRowAvto(string nomer_avto) //Удаление строки из базы данных
        {
            string conStr = "server=127.0.0.1;user=root;database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    //параметризованный запрос
                    string sql = "DELETE FROM klient WHERE nomer_avto = @nomer_avto";
                    //открываем соединение с базой данных
                    con.Open();
                    //создаём команду
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    //создаем параметр и добавляем его в коллекцию
                    cmd.Parameters.AddWithValue("@nomer_avto", nomer_avto);
                    //выполняем sql запрос
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        //...Remont
        private DataTable GetDataRemont() //Выборка из базы клиентов
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM Remont";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        private void insertDataRemont() // Добавление данных в таблицу клиентов
        {
            string conStr = "server=127.0.0.1;user=root;" +
            "database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO Remont (Opisanie_rabot, Data_ustraneniya, nomer_avto, stoimost) VALUES (@Opisanie_rabot, @Data_ustraneniya, @nomer_avto, @stoimost)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Opisanie_rabot", textBox19.Text);
                    cmd.Parameters.AddWithValue("@Data_ustraneniya", textBox18.Text);
                    cmd.Parameters.AddWithValue("@nomer_avto", textBox17.Text);
                    cmd.Parameters.AddWithValue("@stoimost", textBox32.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        private void DeleteRowRemont(string kod_raboti) //Удаление строки из базы данных
        {
            string conStr = "server=127.0.0.1;user=root;database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    //параметризованный запрос
                    string sql = "DELETE FROM Remont WHERE Kod_raboti = @Kod_raboti";
                    //открываем соединение с базой данных
                    con.Open();
                    //создаём команду
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    //создаем параметр и добавляем его в коллекцию
                    cmd.Parameters.AddWithValue("@Kod_raboti", kod_raboti);
                    //выполняем sql запрос
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        //...Закончено работ
        private DataTable GetDataOtremontirovano() //Выборка из базы клиентов
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM Otremontirovano";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        private void insertDataOtremontirovano() // Добавление данных в таблицу клиентов
        {
            string conStr = "server=127.0.0.1;user=root;" +
            "database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO Otremontirovano (Kod_raboti, nomer_mastera, status) VALUES (@Kod_raboti, @nomer_mastera, @status)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Kod_raboti", textBox21.Text);
                    cmd.Parameters.AddWithValue("@nomer_mastera", textBox16.Text);
                    cmd.Parameters.AddWithValue("@status", textBox29.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        private void DeleteRowOtremontirovano(string Kod_raboti) //Удаление строки из базы данных
        {
            string conStr = "server=127.0.0.1;user=root;database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    //параметризованный запрос
                    string sql = "DELETE FROM Otremontirovano WHERE Kod_raboti = @Kod_raboti";
                    //открываем соединение с базой данных
                    con.Open();
                    //создаём команду
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    //создаем параметр и добавляем его в коллекцию
                    cmd.Parameters.AddWithValue("@Kod_raboti", Kod_raboti);
                    //выполняем sql запрос
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        //...Работники
        private DataTable GetDataMaster() //Выборка из базы клиентов
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM master";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        private void insertDataMaster() // Добавление данных в таблицу клиентов
        {
            string conStr = "server=127.0.0.1;user=root;" +
            "database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO master (familiya, imya, otchestvo,nomer_pas,nomer_tel) VALUES (@familiya, @imya, @otchestvo,@nomer_pas,@nomer_tel)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@familiya", textBox23.Text);
                    cmd.Parameters.AddWithValue("@imya", textBox22.Text);
                    cmd.Parameters.AddWithValue("@otchestvo", textBox25.Text);
                    cmd.Parameters.AddWithValue("@nomer_pas", textBox26.Text);
                    cmd.Parameters.AddWithValue("@nomer_tel", textBox24.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        private void DeleteRowMaster(string nomer_mastera) //Удаление строки из базы данных
        {
            string conStr = "server=127.0.0.1;user=root;database=STO;password=;";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    //параметризованный запрос
                    string sql = "DELETE FROM Otremontirovano WHERE Kod_raboti = @Kod_raboti";
                    //открываем соединение с базой данных
                    con.Open();
                    //создаём команду
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    //создаем параметр и добавляем его в коллекцию
                    cmd.Parameters.AddWithValue("@nomer_mastera", nomer_mastera);
                    //выполняем sql запрос
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }
        //Поиск
        private DataTable GetDataNaryad(string nomer_pas) //Список авто клиента
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT avto.nomer_avto, avto.proizvoditel, avto.model, klient.familiya, klient.imya, klient.otchestvo, klient.adres, klient.nomer_pas 
            FROM klient INNER JOIN avto on klient.nomer_pas = avto.nomer_pas WHERE avto.nomer_pas = @nomer_pas";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@nomer_pas", nomer_pas);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        //
        private DataTable GetDataDate() //Поикс работ из диапозона дат
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT Remont.* FROM Remont WHERE Remont.Data_ustraneniya BETWEEN @Data_ustraneniya AND @Data_ustraneniya2";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@Data_ustraneniya", textBox28.Text);
                com.Parameters.AddWithValue("@Data_ustraneniya2", textBox34.Text);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        //Поиск
        private DataTable GetDataPolomki(string nomer_avto) //Список авто клиента
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT avto.nomer_avto, avto.proizvoditel, avto.model, Remont.* FROM Remont INNER JOIN avto on Remont.nomer_avto = avto.nomer_avto 
            WHERE avto.nomer_avto = @nomer_avto";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@nomer_avto", nomer_avto);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        //Поиск
        private DataTable GetDataMasterPoisk(string nomer_mastera) //Список авто клиента
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT master.*, Remont.*, Otremontirovano.* FROM master INNER JOIN Otremontirovano on master.nomer_mastera = Otremontirovano.nomer_mastera 
            INNER JOIN Remont on Otremontirovano.Kod_raboti = Remont.Kod_raboti WHERE Otremontirovano.nomer_mastera = @nomer_mastera";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@nomer_mastera", nomer_mastera);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }

        private DataTable GetDataDanieKlient(string nomer_pas) //Выборка из базы клиентов
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM klient WHERE nomer_pas = @nomer_pas";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@nomer_pas", nomer_pas);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        private DataTable GetDataSpisokAvto(string nomer_pas) 
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM avto WHERE nomer_pas = @nomer_pas";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@nomer_pas", nomer_pas);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }
        private DataTable GetDataSpisokRemont() 
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT *
            FROM Remont WHERE nomer_avto = @nomer_avto AND Remont.Data_ustraneniya BETWEEN @Data_ustraneniya AND @Data_ustraneniya2";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@nomer_avto", textBox37.Text);
                com.Parameters.AddWithValue("@Data_ustraneniya", textBox41.Text);
                com.Parameters.AddWithValue("@Data_ustraneniya2", textBox42.Text);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                double sum = 0;
                foreach (DataRow row in dt.Rows)
                    sum += (double)row["stoimost"];

                textBox40.Text = "" + sum;
                con.Close();
            }
            return dt;
        }
        private DataTable GetDataSpisokRabot() 
        {
            DataTable dt = new DataTable();
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "STO";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            string queryString = @"SELECT Remont.Kod_raboti, Remont.Opisanie_rabot, Remont.Data_ustraneniya, Remont.nomer_avto, Otremontirovano.nomer_mastera, Otremontirovano.status
            FROM Otremontirovano INNER JOIN Remont WHERE nomer_mastera = @nomer_mastera AND 
            Remont.Kod_raboti = Otremontirovano.Kod_raboti AND Remont.Data_ustraneniya BETWEEN @Data_ustraneniya AND @Data_ustraneniya2";
            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);
                com.Parameters.AddWithValue("@nomer_mastera", textBox38.Text);
                com.Parameters.AddWithValue("@Data_ustraneniya", textBox44.Text);
                com.Parameters.AddWithValue("@Data_ustraneniya2", textBox43.Text);
                try
                {
                    con.Open();
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataKlient();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            insertDataKlient();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox7.Text))
            {
                DeleteRowKlient(textBox7.Text);
            }
        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            insertDataAvto();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = GetDataAvto();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox13.Text))
            {
                DeleteRowKlient(textBox13.Text);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox14.Text))
            {
                DeleteRowRemont(textBox14.Text);
            }
        }

        private void textBox14_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = GetDataRemont();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            insertDataRemont();
        }

        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label25_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox15.Text))
            {
                DeleteRowOtremontirovano(textBox15.Text);
            }
        }

        private void textBox15_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = GetDataOtremontirovano();
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            insertDataOtremontirovano();
        }

        private void textBox16_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox20.Text))
            {
                DeleteRowMaster(textBox20.Text);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = GetDataMaster();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            insertDataMaster();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox27.Text))
            {
                dataGridView6.DataSource = GetDataNaryad(textBox27.Text);
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
                dataGridView6.DataSource = GetDataDate();
        }
        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox30.Text))
            {
                dataGridView6.DataSource = GetDataPolomki(textBox30.Text);
            }
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox33.Text))
            {
                dataGridView6.DataSource = GetDataMasterPoisk(textBox33.Text);
            }
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox35.Text))
            {
                dataGridView7.DataSource = GetDataDanieKlient(textBox35.Text);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox36.Text))
            {
                dataGridView8.DataSource = GetDataSpisokAvto(textBox36.Text);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
                dataGridView9.DataSource = GetDataSpisokRemont();
        }

        private void button23_Click(object sender, EventArgs e)
        {
                dataGridView10.DataSource = GetDataSpisokRabot();
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
