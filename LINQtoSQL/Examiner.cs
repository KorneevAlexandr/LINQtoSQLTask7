using System
using System.Data.Linq.Mapping;

namespace LINQtoSQL
{
	/// <summary>
	/// Class description examiner
	/// </summary>
	[Table(Name = "Examiner")]
	public class Examiner
	{
		/// <summary>
		/// Id examiner
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id { get; set; }
		/// <summary>
		/// Surname examiner
		/// </summary>
		[Column(Name = "SurName")]
		public string SurName { get; set; }
		/// <summary>
		/// Name examiner
		/// </summary>
		[Column(Name = "EName")]
		public string Name { get; set; }
		/// <summary>
		/// Patronymic examiner
		/// </summary>
		[Column(Name = "Patronymic")]
		public string Patronymic { get; set; }
		/// <summary>
		/// Exam number 1 examiner
		/// </summary>
		[Column(Name = "Exam")]
		public string Examen { get; set; }
		/// <summary>
		/// Exam number 2 examiner
		/// </summary>
		[Column(Name = "Exam_2")]
		public string Examen_2 { get; set; }

		/// <summary>
		/// Method for compare two object
		/// </summary>
		/// <param name="obj">Object</param>
		/// <returns>True or false</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Examiner ex = (Examiner)obj;

			if (Id != ex.Id || Name != ex.Name || SurName != ex.SurName || Patronymic != ex.Patronymic
				|| Examen != ex.Examen || Examen_2 != ex.Examen_2)
				return false;
			return true;
		}

		/// <summary>
		/// Method ToString()
		/// </summary>
		/// <returns>String</returns>
		public override string ToString()
		{
			return String.Concat(Id.ToString(), " ", Name, " ", SurName, " ", Patronymic, " ",
				Examen, " ", Examen_2);
		}

		/// <summary>
		/// Hash-func
		/// </summary>
		/// <returns>-codeHas</returns>
		public override int GetHashCode()
		{
			Type myType = typeof(Examiner);
			return myType.GetProperties().Length;
		}


	}
}
