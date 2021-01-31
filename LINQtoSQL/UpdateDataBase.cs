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
	/// Class for update database
	/// </summary>
	public class UpdateDataBase
	{
		/// <summary>
		/// String connection
		/// </summary>
		private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Training\LINQtoSQLTask7\LINQtoSQL\Database.mdf;Integrated Security=True";
		/// <summary>
		/// Context object
		/// </summary>
		private DataContext db;

		/// <summary>
		/// Inicialize object
		/// </summary>
		public UpdateDataBase()
		{
			db = new DataContext(connectionString);
		}

		/// <summary>
		/// Update first object in a table
		/// </summary>
		/// <param name="student">Object for example</param>
		public void UpdateFirstSudent(Student student)
		{
			Student st = db.GetTable<Student>().FirstOrDefault();

			st.Name = student.Name;
			st.SurName = student.SurName;
			st.Patronymic = student.Patronymic;
			st.Sex = student.Sex;
			st.DateBr = student.DateBr;
			st.Group = student.Group;
			st.Id = st.Id;
			st.ExamName_1 = student.ExamName_1;
			st.ExamName_2 = student.ExamName_2;
			st.ExamName_3 = student.ExamName_3;
			st.ExamDate_1 = student.ExamDate_1;
			st.ExamDate_2 = student.ExamDate_2;
			st.ExamDate_3 = student.ExamDate_3;
			st.Mark_1 = student.Mark_1;
			st.Mark_2 = student.Mark_2; 
			st.Mark_3 = student.Mark_3;

			db.SubmitChanges();
		}

		/// <summary>
		/// Update first object in a table
		/// </summary>
		/// <param name="examiner">Object for example</param>
		public void UpdateFirstExaminer(Examiner examiner)
		{
			Examiner ex = db.GetTable<Examiner>().FirstOrDefault();

			ex.Id = examiner.Id;
			ex.Name = examiner.Name;
			ex.SurName = examiner.SurName;
			ex.Patronymic = examiner.Patronymic;
			ex.Examen = examiner.Examen;
			ex.Examen_2 = examiner.Examen_2;

			db.SubmitChanges();
		}

		/// <summary>
		/// Update first object in a table
		/// </summary>
		/// <param name="specialty">Object for example</param>
		public void UpdateFirstSpecialty(Specialty specialty)
		{
			Specialty sp = db.GetTable<Specialty>().FirstOrDefault();

			sp.Id = specialty.Id;
			sp.SpecName = specialty.SpecName;
			sp.NameGroup = specialty.NameGroup;
			sp.NameGroup_2 = specialty.NameGroup_2;

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

			UpdateDataBase up = (UpdateDataBase)obj;
			if (connectionString == up.connectionString && db == up.db)
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
