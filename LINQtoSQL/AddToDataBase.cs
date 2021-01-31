using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace LINQtoSQL
{
	/// <summary>
	/// Class for add new object (row) in database
	/// </summary>
	public class AddToDataBase
	{
		/// <summary>
		/// String for connection with database
		/// </summary>
		private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Training\LINQtoSQLTask7\LINQtoSQL\Database.mdf;Integrated Security=True";
		/// <summary>
		/// Object context table in database
		/// </summary>
		private DataContext db;

		/// <summary>
		/// Inicialization object
		/// </summary>
		public AddToDataBase()
		{
			db = new DataContext(connectionString);
		}

		/// <summary>
		/// Add new student (line) in table database
		/// </summary>
		/// <param name="student">Object student for add</param>
		public void AddNewStudent(Student student)
		{
			db.GetTable<Student>().InsertOnSubmit(student);
			db.SubmitChanges();
		}

		/// <summary>
		/// Add new examiner (line) in table database
		/// </summary>
		/// <param name="examiner">Object examiner for add</param>
		public void AddNewExaminer(Examiner examiner)
		{
			db.GetTable<Examiner>().InsertOnSubmit(examiner);
			db.SubmitChanges();
		}

		/// <summary>
		/// Add new specialty (line) in table database
		/// </summary>
		/// <param name="specialty">Object specialty for add</param>
		public void AddNewSpecialty(Specialty specialty)
		{
			db.GetTable<Specialty>().InsertOnSubmit(specialty);
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

			AddToDataBase add = (AddToDataBase)obj;
			if (connectionString == add.connectionString && db == add.db)
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
