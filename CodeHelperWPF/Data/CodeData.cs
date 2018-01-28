using System;
using System.Data.SQLite;

namespace CodeHelperWPF.Data
{
    class CodeData
    {
        public object Language { get; set; }

        private static SQLiteConnection _db = new SQLiteConnection("Data Source=codelsm.db3; version=3");

        /// <summary>Метод GetLanguages() открывает соединения с БД. Посредством команд <see cref="F:System.Data.SQLite"/> формируется строка запроса.
        /// Если в таблице имеются записи то создаются экземпляры объекта CodeData, в авто-свойтва экземпляров присваиваются получаемые данные</summary>
        /// <returns>Возвращает коллекцию объектов пользовательского типа CodeData</returns>
        public CodeData[] GetLanguages()
        {
            OpenSQLite();

            var result = new CodeData[GetEntriesCount()];

            SQLiteCommand CMD = _db.CreateCommand();
            CMD.CommandText = "select Language from Languages";
            SQLiteDataReader SQL = CMD.ExecuteReader();

            if (SQL.HasRows)
            {
                int counter = 0;

                while (SQL.Read())
                {
                    result[counter] = new CodeData() { Language = SQL["Language"] };
                    counter++;
                }
            }

            CloseSQLite();

            return result;
        }
        /// <summary>Метод GetEntriesCount()</summary>
        /// <returns>Возвращает количество записей в таблице Languages</returns>
        private static int GetEntriesCount()
        {
            SQLiteCommand CMD = _db.CreateCommand();
            CMD.CommandText = "select count(*) from Languages";
            return Convert.ToInt32(CMD.ExecuteScalar());
        }

        /// <summary>Метод OpenSQLite() открывает соединение с БД</summary>
        /// <returns>Ничего не возвращает</returns>
        private static void OpenSQLite()
        {
            _db.Open();
        }
        /// <summary>Метод OpenSQLite() закрывает соединение с БД</summary>
        /// <returns>Ничего не возвращает</returns>
        private static void CloseSQLite()
        {
            _db.Close();
        }
        
        //TODO: Реализовать метод добавления записей в базу данных и привязку через VIEW-MODEL.
        private void Add()
        {
            /*
                if (tbName.Text != "" && tbLastName.Text != "")
                {
                    SQLiteCommand CMD = _db.CreateCommand();
                    CMD.CommandText = "insert into Users(Firstname, Lastname) values(@fname, @lname)";
                    CMD.Parameters.Add("@fname", System.CodeData.DbType.String).Value = tbName.Text.ToUpper();
                    CMD.Parameters.Add("@lname", System.Data.DbType.String).Value = tbLastName.Text.ToUpper();
                    CMD.ExecuteNonQuery();
                }
            */
        }
    }
}

