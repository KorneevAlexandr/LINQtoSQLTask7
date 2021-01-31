using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQtoSQL;

namespace TestingDataBaseWithLINQ
{
	/// <summary>
	/// Testing classes for storing tables from databases
	/// </summary>
	[TestClass]
	public class TestinStudent_Examiner_Specialty
	{
		/// <summary>
		/// Testing overrides method Student
		/// </summary>
		[TestMethod]
		public void TestStudent()
		{
			Student student = new Student()
			{
				Id = 1,
				Name = "Александр",
				SurName = "Корнеев",
				Patronymic = "Олегович",
				DateBr = new DateTime(2002, 4, 2),
				Sex = "Муж", 
				Group = "ИТП-21"
			};

			Student student2 = new Student()
			{
				Id = 2,
				Name = "Александр",
				SurName = "Касьян",
				Patronymic = "Сергеевич",
				Sex = "Муж",
				Group = "ИТП-21"
			};

			string except = "1 Корнеев Александр Олегович Муж 02.04.2002 ИТП-21";
			int except_properties = 16;

			Assert.IsFalse(student.Equals(student2));
			Assert.AreEqual(except, student.ToString());
			Assert.AreEqual(except_properties, student.GetHashCode());
		}

		/// <summary>
		/// Testing overrides method Examiner
		/// </summary>
		[TestMethod]
		public void TestExaminer()
		{
			Examiner examiner = new Examiner()
			{
				Id = 1,
				Name = "Илья",
				SurName = "Шутов",
				Patronymic = "Борисович",
				Examen = "Математика",
				Examen_2 = "Информатика"
			};

			Examiner examiner2 = new Examiner()
			{
				Id = 1,
				Name = "Илья",
				SurName = "Шутов",
				Patronymic = "Борисович",
				Examen = "Математика",
				Examen_2 = "Информатика"
			};

			string except = "1 Шутов Илья Борисович Математика Информатика";
			int except_properties = 6;

			Assert.IsTrue(examiner.Equals(examiner2));
			Assert.AreEqual(except, examiner.ToString());
			Assert.AreEqual(except_properties, examiner.GetHashCode());
		}

		/// <summary>
		/// Testing overrides method Specialty
		/// </summary>
		[TestMethod]
		public void TestSpecialty()
		{
			Specialty spec = new Specialty()
			{
				Id = 1, 
				SpecName = "Информатика и технологии программирования",
				NameGroup = "ИС-21", 
				NameGroup_2 = "ИС-22"
			};

			string except = "1 Информатика и технологии программирования ИС-21 ИС-22";
			int except_properties = 4;

			Assert.IsFalse(spec.Equals(null));
			Assert.AreEqual(except, spec.ToString());
			Assert.AreEqual(except_properties, spec.GetHashCode());
		}

	}
}
