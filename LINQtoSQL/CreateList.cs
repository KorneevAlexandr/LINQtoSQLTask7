using System;
using System.Collections.Generic;
using System.Data.Linq;

namespace LINQtoSQL
{
	/// <summary>
	/// Static class for create reports
	/// </summary>
	public static class CreateList
	{
		/// <summary>
		/// String connection
		/// </summary>
		private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Training\LINQtoSQLTask7\LINQtoSQL\Database.mdf;Integrated Security=True";
		/// <summary>
		/// Context object
		/// </summary>
		private static DataContext db;

		/// <summary>
		/// Table Students
		/// </summary>
		private static Table<Student> Students;
		/// <summary>
		/// Table specialtys
		/// </summary>
		private static Table<Specialty> Specialtys;
		/// <summary>
		/// Table Examiners
		/// </summary>
		private static Table<Examiner> Examiners;

		/// <summary>
		/// Inicialize tables
		/// </summary>
		static CreateList()
		{
			db = new DataContext(connectionString);
			Students = db.GetTable<Student>();
			Specialtys = db.GetTable<Specialty>();
			Examiners = db.GetTable<Examiner>();
		}

		/// <summary>
		/// Create report about grades by specialtys
		/// </summary>
		/// <returns>String array</returns>
		public static string[] SpecialtyGrades()
		{
			List<string> NamesSpec = new List<string>()
			{ "Специальность", "Средняя оценка" };

			double sum;
			int numbers;
			foreach (var Sp in Specialtys)
			{
				NamesSpec.Add(Sp.SpecName);

				sum = 0;
				numbers = 0;
				foreach (var S in Students)
				{
					if (S.Group.Trim() == Sp.NameGroup.Trim() || S.Group.Trim() == Sp.NameGroup_2.Trim())
					{
						sum += (S.Mark_1 + S.Mark_2 + S.Mark_3) / 3;
						numbers++;
					}
				}
				NamesSpec.Add(Math.Round(sum / numbers, 2).ToString());
			}

			return NamesSpec.ToArray();
		}

		/// <summary>
		/// Create report about grades by examiners
		/// </summary>
		/// <returns>String array</returns>
		public static string[] ExaminerGrades()
		{
			List<string> NamesSpec = new List<string>()
			{ "Экзаменатор", "Средняя оценка" };

			double sum;
			int numbers;
			foreach (var E in Examiners)
			{
				NamesSpec.Add(String.Concat(E.SurName, " ", E.Name, " ", E.Patronymic));

				sum = 0;
				numbers = 0;
				foreach (var S in Students)
				{
					if (S.ExamName_1.Trim() == E.Examen.Trim() || S.ExamName_2.Trim() == E.Examen.Trim()
						|| S.ExamName_3.Trim() == E.Examen.Trim() || S.ExamName_1.Trim() == E.Examen_2.Trim() 
						|| S.ExamName_2.Trim() == E.Examen_2.Trim() || S.ExamName_3.Trim() == E.Examen_2.Trim())
					{
						sum += (S.Mark_1 + S.Mark_2 + S.Mark_3) / 3;
						numbers++;
					}
				}
				NamesSpec.Add(Math.Round(sum / numbers, 2).ToString());
			}

			return NamesSpec.ToArray();
		}

		/// <summary>
		/// Create report about min/middle/max grades by group
		/// </summary>
		/// <returns>String array</returns>
		public static string[] MiddleGrades()
		{
			List<string> Groups = new List<string>();
			foreach (var g in Students)
				if (!Groups.Contains(g.Group))
					Groups.Add(g.Group.Trim());

			List<string> Result = new List<string>()
			{ "Группа", "Мин оценка", "Средн оценка", "Макс оценка"};

			double min, max, sum;
			int numerous;
			for (int i = 0; i < Groups.Count; i++)
			{
				min = 10;
				max = 0;
				sum = 0;
				numerous = 0;
				foreach (Student S in Students)
				{
					if (S.Group.Trim() == Groups[i].Trim())
					{
						double midd = (S.Mark_1 + S.Mark_2 + S.Mark_3) / 3;
						sum += midd;
						numerous++;

						if (min > midd) min = midd;
						if (max < midd) max = midd;
					}
				}

				Result.Add(Groups[i]);
				Result.Add(min.ToString());
				Result.Add(Math.Round(sum / numerous, 2).ToString());
				Result.Add(max.ToString());
			}

			return Result.ToArray();
		}

		/// <summary>
		/// Create report about execute student
		/// </summary>
		/// <returns>String array</returns>
		public static string[] OutStudents()
		{
			List<string> Out = new List<string>()
			{ "Студент", "Группа"};

			foreach (var S in Students)
			{
				if (S.Mark_1 < 4 && S.Mark_2 < 4 && S.Mark_3 < 4)
				{
					Out.Add(String.Concat(S.SurName, " ", S.Name, " ", S.Patronymic));
					Out.Add(S.Group);
				}
			}
			return Out.ToArray();
		}

		/// <summary>
		/// Create report about result session be groups
		/// </summary>
		/// <returns>String array</returns>
		public static string[] ResultSession()
		{
			List<string> Groups = new List<string>();
			foreach (var g in Students)
				if (!Groups.Contains(g.Group))
					Groups.Add(g.Group.Trim());

			List<string> Result = new List<string>()
			{
				"Студент", "Группа", "1-я оценка", "2-я оценка", "3-я оценка"
			};

			for (int i = 0; i < Groups.Count; i++)
			{
				foreach (var S in Students)
				{
					if (S.Group.Trim() == Groups[i].Trim())
					{
						Result.Add(String.Concat(S.SurName, " ", S.Name, " ", S.Patronymic));
						Result.Add(S.Group);
						Result.Add(S.Mark_1.ToString());
						Result.Add(S.Mark_2.ToString());
						Result.Add(S.Mark_3.ToString());
					}
				}
			}
			return Result.ToArray();
		}

	}
}
