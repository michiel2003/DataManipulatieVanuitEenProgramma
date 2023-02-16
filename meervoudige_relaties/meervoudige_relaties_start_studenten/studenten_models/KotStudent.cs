using System;
using System.Collections.Generic;
using System.Text;

namespace studenten_models
{
    public class KotStudent : Student
    {

        private String _kotAdress;

        public String KotAdress
        {
            get { return _kotAdress; }
            set { _kotAdress = value; }
        }

        private String _kotBaas;
        public String KotBaas
        {
            get { return _kotBaas; }
            set { _kotBaas = value; }
        }

        public override string ToString()
        {
            String tostr = $"{base.ToString()} (kotstudent)";
            return tostr;
        }

        public override String MaakDetail()
        {
            String detail = $"{base.MaakDetail()}\n      {ToString().PadLeft(10)}          kotadress: {this.KotAdress} (Eigenaar: {this.KotBaas})";
            return detail;
        }

        public KotStudent(String studentNummer, String studentNaam, String kotbaas, String kotadress): base(studentNummer, studentNaam)
        {
            KotBaas = kotbaas;
            KotAdress = kotadress;  
        }
    }
}
