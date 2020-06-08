using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.SQLiteFrameWork
{
	public static class Connection
	{
		public static SQLiteConnection GetConnection()
		{
			string DatabaseName = "TDDB";

			SQLiteConnection connect = new SQLiteConnection($"Data Source={DatabaseName}.db;Version=3;New=True;");
			return connect;
		}

		public static SQLiteConnection CreateConnection()
		{
			SQLiteConnection con = GetConnection();

			con.Open();
			return con;
		}
	}
}
