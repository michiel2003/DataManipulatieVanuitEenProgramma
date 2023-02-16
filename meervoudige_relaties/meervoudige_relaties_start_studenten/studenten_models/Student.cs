using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Transactions;

namespace studenten_models
{
	public class Student
	{
		private String _department;

		public String Department
		{
			get { return _department; }
			set { _department = value; }
		}
		private String _studentNaam;

		public String StudentNaam
		{
			get { return _studentNaam; }
			set { _studentNaam = value; }
		}

		private String _studentNummer;

		public String StudentNummer
		{
			get { return _studentNummer; }
			set { _studentNummer = value; }
		}

		public override string ToString()
		{
			String toStrr = $"{this.StudentNaam}";
			return toStrr;
		}

		public virtual String MaakDetail()
		{
			String detail = $"{this.StudentNummer}    {this.StudentNaam}";
			return detail;
		}

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   StudentNummer == student.StudentNummer;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StudentNummer);
        }

        public Student(string studentNummer, string studentNaam)
        {
            StudentNummer = studentNummer;
            StudentNaam = studentNaam;
        }
    }
}
