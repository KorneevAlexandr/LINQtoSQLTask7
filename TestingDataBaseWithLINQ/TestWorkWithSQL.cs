using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQtoSQL;
using System.Data.Linq;
using System.Linq;

namespace TestingDataBaseWithLINQ
{
	/// <summary>
	/// Test class for testing crud, create reports
	/// </summary>
	[TestClass]
	public class TestWorkWithSQL
	{
		/// <summary>
		/// String connection
		/// </summary>
		private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Учеба\Training\LINQtoSQLTask7\LINQtoSQL\Database.mdf;Integrated Security=True";

		/// <summary>
		/// Testing add and delete new examiner in table database
		/// </summary>
		[TestMethod]
		public void TestAddDeleteToDatabaseExaminer()
		{
			Examiner examiner = new Examiner
			{
				Id = 5,
				Name = "Илья",
				SurName = "Шутов",
				Patronymic = "Борисович",
				Examen = "Математика",
				Examen_2 = "Информатика"
			};

			AddToDataBase add = new AddToDataBase();
			add.AddNewExaminer(examiner);

			DataContext db = new DataContext(connectionString);
			Examiner ex = db.GetTable<Examiner>().OrderByDescending(u => u.Id).FirstOrDefault();

			var except_EndElement = true;
			var actual_EndElement = examiner.Equals(ex);

			DeleteToDataBase del = new DeleteToDataBase();
			del.DeleteEndExaminer();

			ex = db.GetTable<Examiner>().OrderByDescending(u => u.Id).FirstOrDefault();

			var except_EndElement_2 = false;
			var actual_EndElement_2 = examiner.Equals(ex);

			Assert.AreEqual(except_EndElement, actual_EndElement);
			Assert.AreEqual(except_EndElement_2, actual_EndElement_2);
		}

		/// <summary>
		/// Test add and delete new specialty in table database
		/// </summary>
		[TestMethod]
		public void TestAddDeleteToDatabaseSpecialty()
		{
			Specialty spec = new Specialty()
			{
				Id = 1,
				SpecName = "Машино- и приборостроение",
				NameGroup = "МТ-21",
				NameGroup_2 = "МТ-22"
			};

			AddToDataBase add = new AddToDataBase();
			add.AddNewSpecialty(spec);

			DataContext db = new DataContext(connectionString);
			Specialty sp = db.GetTable<Specialty>().OrderByDescending(u => u.Id).FirstOrDefault();

			var except_EndElement = true;
			var actual_EndElement = spec.Equals(sp);

			DeleteToDataBase del = new DeleteToDataBase();
			del.DeleteSpecialty();

			sp = db.GetTable<Specialty>().OrderByDescending(u => u.Id).FirstOrDefault();

			var except_EndElement_2 = false;
			var actual_EndElement_2 = spec.Equals(sp);

			Assert.AreEqual(except_EndElement, actual_EndElement);
			Assert.AreEqual(except_EndElement_2, actual_EndElement_2);
		}

		/// <summary>
		/// Test add and delete new student in table database
		/// </summary>
		[TestMethod]
		public void TestAddDeleteToDatabaseStudent()
		{
			Student student = new Student()
			{
				Id = 12,
				Name = "Юрий",
				SurName = "Корнеев",
				Patronymic = "Олегович",
				DateBr = new DateTime(2002, 4, 2),
				Sex = "Муж",
				Group = "ИТП-21",
				ExamName_1 = "ООП", 
				ExamName_2 = "КС",
				ExamName_3 = "Экономика",
				ExamDate_1 = new DateTime(2021, 1, 12),
				ExamDate_2 = new DateTime(2021, 1, 14),
				ExamDate_3 = new DateTime(2021, 1, 16),
				Mark_1 = 7, Mark_2 = 8, Mark_3 = 6
			};

			AddToDataBase add = new AddToDataBase();
			add.AddNewStudent(student);
			DataContext db = new DataContext(connectionString);
			Student st = db.GetTable<Student>().OrderByDescending(u => u.Id).FirstOrDefault();

			var except_EndElement = true;
			var actual_EndElement = student.Equals(st);

			DeleteToDataBase del = new DeleteToDataBase();
			del.DeleteEndStudent();
			st = db.GetTable<Student>().OrderByDescending(u => u.Id).FirstOrDefault();

			var except_EndElement_2 = false;
			var actual_EndElement_2 = student.Equals(st);

			Assert.AreEqual(except_EndElement, actual_EndElement);
			Assert.AreEqual(except_EndElement_2, actual_EndElement_2);
		}

		/// <summary>
		/// Testing update first line (examiner)
		/// </summary>
		[TestMethod]
		public void TestingUpdateDatabase()
		{
			string new_ex = "ОС";
			Examiner ex = new Examiner()
			{
				Id = 1,
				Name = "Константин",
				SurName = "Курочка", 
				Patronymic = "Сергеевич", 
				Examen = "ООП", 
				Examen_2 = new_ex
			};

			UpdateDataBase update = new UpdateDataBase();
			update.UpdateFirstExaminer(ex);

			DataContext db = new DataContext(connectionString);
			Examiner res = db.GetTable<Examiner>().FirstOrDefault();

			var except = true;
			var actual = ex.Equals(res);

			// возврат начальных значений
			ex.Examen_2 = "КС";
			update.UpdateFirstExaminer(ex);

			Assert.AreEqual(except, actual);
		}

		/// <summary>
		/// Test create report about out student
		/// </summary>
		[TestMethod]
		public void TestListOutStudents()
		{
			string[] mas = CreateList.OutStudents();
			string string_student = "Крышнев Марат Витальевич";

			var except = true;
			var actual = false;
			
			for (int i = 0; i < mas.Length; i++)
				if (mas[i].Trim() == string_student)
					actual = true;

			Assert.AreEqual(except, actual);
		}

		/// <summary>
		/// Test create report about middle grades by specialty
		/// </summary>
		[TestMethod]
		public void TestMiddleBySpecialty()
		{
			string spec = "Информатика и технологии программирования";
			int[,] grades = new int[6, 3]
			{ { 7, 6, 6 }, { 6, 7, 5 }, { 2, 2, 2 },
				{ 3, 2, 2 }, { 7, 7, 8 }, { 4, 4, 4 } };

			double except = 0;
			for (int i = 0; i < 6; i++)
				except += (grades[i, 0] + grades[i, 1] + grades[i, 2] ) / 3;

			except = Math.Round(except / 6, 2);

			string[] mas = CreateList.SpecialtyGrades();

			double actual = 0;
			for (int i = 0; i < mas.Length; i++)
				if (mas[i].Trim() == spec)
					actual = Convert.ToDouble(mas[i + 1]);

			Assert.AreEqual(except, actual);
		}

		/// <summary>
		/// Test create report about middle grades by specialty
		/// </summary>
		[TestMethod]
		public void TestMiddleByExaminer()
		{
			string examiner = "Астраханцев Сергей Евгеньевич";
			int[] grades = new int[6] { 6, 7, 2, 2, 7, 4 };

			double except = 0;
			for (int i = 0; i < grades.Length; i++)
				except += grades[i];
			except = Math.Round(except / 6, 2);

			string[] mas = CreateList.ExaminerGrades();

			double actual = 0;
			for (int i = 0; i < mas.Length; i++)
				if (mas[i].Trim() == examiner)
					actual = Convert.ToDouble(mas[i + 1]);

			Assert.AreEqual(except, actual);
		}

	}
}
