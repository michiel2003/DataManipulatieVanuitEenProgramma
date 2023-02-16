using System;
using System.Collections.Generic;
using System.Text;

namespace studenten_models
{
    public class Klas
    {

        List<Student> Students = new List<Student>();

		private String _klasNaam;

		public String KlasNaam
		{
			get { return _klasNaam; }
			set { _klasNaam = value; }
		}

        public Klas(string klasNaam)
        {
            KlasNaam = klasNaam;
        }

        public void VoegStudentToe(Student s)
        {
            if (Students.Contains(s))
            {
                throw new Exception("Deze student is reeds toegevoegd");
            }
            Students.Add(s);
        }

        public String MaakLijst()
        {
            String text = $"Namenlijst van {KlasNaam}";
            Students.ForEach(student => text += $"\n{student.ToString()}");
            return text;
        }

        public String MaakUitGebreideLijst()
        {
            String text = $"Namenlijist van {KlasNaam}";
            Students.ForEach(student => text += $"\n{student.MaakDetail()}");
            return text;
        }
}
    }
