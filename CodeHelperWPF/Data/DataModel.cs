using System;
using System.Data.SQLite;
using System.Windows;

namespace CodeHelperWPF.Data
{
    class DataModel
    {
        public object Language { get; set; }

        private static SQLiteConnection _db = new SQLiteConnection("Data Source=codesnp.db3; version=3");

        /// <summary>Метод GetLanguages() открывает соединения с БД. Посредством команд <see cref="F:System.Data.SQLite"/> формируется строка запроса.
        /// Если в таблице имеются записи то создаются экземпляры объекта DataModel, в авто-свойтва экземпляров присваиваются получаемые данные</summary>
        /// <returns>Возвращает коллекцию объектов пользовательского типа DataModel</returns>
        public DataModel[] GetLanguages()
        {
            OpenConnection();

            var result = new DataModel[GetEntriesCount()];

            SQLiteCommand CMD = _db.CreateCommand();
            CMD.CommandText = "SELECT DISTINCT languages FROM Library WHERE languages IS NOT NULL";
            SQLiteDataReader SQL = CMD.ExecuteReader();

            if (SQL.HasRows)
            {
                int counter = 0;

                while (SQL.Read())
                {
                    result[counter] = new DataModel() { Language = SQL["languages"] };
                    counter++;
                }
            }

            CloseConnection();

            return result;
        }
        /// <summary>Метод GetEntriesCount()</summary>
        /// <returns>Возвращает количество записей в таблице Languages</returns>
        private static int GetEntriesCount()
        {
            SQLiteCommand CMD = _db.CreateCommand();
            CMD.CommandText = "SELECT COUNT(DISTINCT languages) FROM Library";
            return Convert.ToInt32(CMD.ExecuteScalar());
        }
        /// <summary>Метод OpenSQLite() открывает соединение с БД</summary>
        /// <returns>Ничего не возвращает</returns>
        private static void OpenConnection()
        {
            _db.Open();                  
        }
        /// <summary>Метод OpenSQLite() закрывает соединение с БД</summary>
        /// <returns>Ничего не возвращает</returns>
        private static void CloseConnection()
        {
            _db.Close();
        }       
        //TODO: Реализовать метод добавления записей в базу данных и привязку через VIEW-MODEL.
        private void Add()
        {
            //if (tbName.Text != "" && tbLastName.Text != "")
            //{
            //    SQLiteCommand CMD = _db.CreateCommand();
            //    CMD.CommandText = "insert into Users(Firstname, Lastname) values(@fname, @lname)";
            //    CMD.Parameters.Add("@fname", System.DataModel.DbType.String).Value = tbName.Text.ToUpper();
            //    CMD.Parameters.Add("@lname", System.Data.DbType.String).Value = tbLastName.Text.ToUpper();
            //    CMD.ExecuteNonQuery();
            //}
        }
    }
}

