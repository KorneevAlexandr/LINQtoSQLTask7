using System;
using System.Data.Linq.Mapping;

namespace LINQtoSQL
{
	/// <summary>
	/// Class for specialty and linq-read database
	/// </summary>
	[Table(Name = "Specialty")]
	public class Specialty
	{
		/// <summary>
		/// Id specialty
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id { get; set; }
		/// <summary>
		/// Name specialty
		/// </summary>
		[Column(Name = "NameSpecialty")]
		public string SpecName { get; set; }
		/// <summary>
		/// Name group specialty
		/// </summary>
		[Column(Name = "NameGroup")]
		public string NameGroup { get; set; }
		/// <summary>
		/// Two group specialty
		/// </summary>
		[Column(Name = "NameGroup_2")]
		public string NameGroup_2 { get; set; }

		/// <summary>
		/// Method ToString()
		/// </summary>
		/// <returns>String</returns>
		public override string ToString()
		{
			return String.Concat(Id.ToString(), " ", SpecName, " ", NameGroup, " ", NameGroup_2);
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

			Specialty spec = (Specialty)obj;
			if (spec.Id != Id || spec.SpecName != SpecName || spec.NameGroup != NameGroup || spec.NameGroup_2 != NameGroup_2)
				return false;
			return true;
		}

		/// <summary>
		/// Hash-func
		/// </summary>
		/// <returns>-codeHas</returns>
		public override int GetHashCode()
		{
			Type myType = typeof(Specialty);
			return myType.GetProperties().Length;
		}

	}
}
