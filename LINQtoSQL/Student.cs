using System;
using System.Data.Linq.Mapping;

namespace LINQtoSQL
{
	/// <summary>
	/// Class description student
	/// </summary>
	[Table(Name = "Students")]
	public class Student
	{
		/// <summary>
		/// Id student
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id { get; set; }
		/// <summary>
		/// Surname student
		/// </summary>
		[Column(Name = "SurName")]
		public string SurName { get; set; }
		/// <summary>
		/// Name student
		/// </summary>
		[Column(Name = "StudentName")]
		public string Name { get; set; }
		/// <summary>
		/// Patronymic student
		/// </summary>
		[Column(Name = "Patronymic")]
		public string Patronymic { get; set; }
		/// <summary>
		/// Sex student
		/// </summary>
		[Column(Name = "Sex")]
		public string Sex { get; set; }
		/// <summary>
		/// Date birthday student
		/// </summary>
		[Column(Name = "DateBirth")]
		public DateTime DateBr { get; set; }
		/// <summary>
		/// Group student
		/// </summary>
		[Column(Name = "StudentGroup")]
		public string Group { get; set; }
		/// <summary>
		/// Name exam 1
		/// </summary>
		[Column(Name = "ExamenName_1")]
		public string ExamName_1 { get; set; }
		/// <summary>
		/// Date exam 1
		/// </summary>
		[Column(Name = "DateExamen_1")]
		public DateTime ExamDate_1 { get; set; }
		/// <summary>
		/// Mark by exam 1
		/// </summary>
		[Column(Name = "Mark_1")]
		public int Mark_1 { get; set; }
		/// <summary>
		/// Name exam 2
		/// </summary>
		[Column(Name = "ExamenName_2")]
		public string ExamName_2 { get; set; }
		/// <summary>
		/// Date exam 2
		/// </summary>
		[Column(Name = "DateExamen_2")]
		public DateTime ExamDate_2 { get; set; }
		/// <summary>
		/// Mark by exam 2
		/// </summary>
		[Column(Name = "Mark_2")]
		public int Mark_2 { get; set; }
		/// <summary>
		/// Name exam 3
		/// </summary>
		[Column(Name = "ExamenName_3")]
		public string ExamName_3 { get; set; }
		/// <summary>
		/// Date exam 3
		/// </summary>
		[Column(Name = "DateExamen_3")]
		public DateTime ExamDate_3 { get; set; }
		/// <summary>
		/// Mark by exam 3
		/// </summary>
		[Column(Name = "Mark_3")]
		public int Mark_3 { get; set; }

		/// <summary>
		/// Method for compare two object
		/// </summary>
		/// <param name="obj">Object</param>
		/// <returns>True or false</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Student st = (Student)obj;

			if (Id != st.Id || Name != st.Name || SurName != st.SurName || Patronymic != st.Patronymic
				|| Sex != st.Sex || DateBr != st.DateBr || Group != st.Group
				|| ExamName_1 != st.ExamName_1 || ExamName_2 != st.ExamName_2 || ExamName_3 != st.ExamName_3
				|| ExamDate_1 != st.ExamDate_1 || ExamDate_2 != st.ExamDate_2 || ExamDate_3 != st.ExamDate_3
				|| Mark_1 != st.Mark_1 || Mark_2 != st.Mark_2 || Mark_3 != st.Mark_3)
				return false;
			return true;
		}

		/// <summary>
		/// Method ToString()
		/// </summary>
		/// <returns>String</returns>
		public override string ToString()
		{
			return String.Concat(Id.ToString(), " ", SurName, " ", Name, " ", Patronymic, " ",
				Sex, " ", DateBr.ToShortDateString(), " ", Group);
		}

		/// <summary>
		/// Hash-func
		/// </summary>
		/// <returns>-codeHas</returns>
		public override int GetHashCode()
		{
			Type myType = typeof(Student);
			return myType.GetProperties().Length;
		}


	}
}
