using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data;

namespace LINQtoSQL
{
	/// <summary>
	/// Class for delete first line 
	/// </summary>
	public class DeleteToDataBase
	{
		/// <summary>
		/// String for connection
		/// </summary>
		private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Training\LINQtoSQLTask7\LINQtoSQL\Database.mdf;Integrated Security=True";
		/// <summary>
		/// Context object
		/// </summary>
		private DataContext db;

		/// <summary>
		/// Inicialize object
		/// </summary>
		public DeleteToDataBase()
		{
			db = new DataContext(connectionString);
		}

		/// <summary>
		/// Delete first student in a table
		/// </summary>
		public void DeleteEndStudent()
		{
			var st = db.GetTable<Student>().OrderByDescending(u => u.Id).FirstOrDefault();
			db.GetTable<Student>().DeleteOnSubmit(st);
			db.SubmitChanges();
		}

		/// <summary>
		/// Delete first examiner in a table
		/// </summary>
		public void DeleteEndExaminer()
		{
			var ex = db.GetTable<Examiner>().OrderByDescending(u => u.Id).FirstOrDefault();
			db.GetTable<Examiner>().DeleteOnSubmit(ex);
			db.SubmitChanges();
		}

		/// <summary>
		/// Delete first specialty in a table
		/// </summary>
		public void DeleteSpecialty()
		{
			var spec = db.GetTable<Specialty>().OrderByDescending(u => u.Id).FirstOrDefault();
			db.GetTable<Specialty>().DeleteOnSubmit(spec);
			db.SubmitChanges();
		}

		/// <summary>
		/// Method ToString
		/// </summary>
		/// <returns>Connection string</returns>
		public override string ToString()
		{
			return connectionString;
		}

		/// <summary>
		/// Method for compare two object
		/// </summary>
		/// <param name="obj">Object</param>
		/// <returns>True or false</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			DeleteToDataBase del = (DeleteToDataBase)obj;
			if (connectionString == del.connectionString && db == del.db)
				return true;
			return false;
		}

		/// <summary>
		/// Hash-func
		/// </summary>
		/// <returns>Hash</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

	}
}
