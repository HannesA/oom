using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;



namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var m = new massnahme[3];
            m[0] = new Programm(12);
            Projekt p = new Projekt(1, "Hugo");
            Console.WriteLine("Projekt " + p.Projektname + " hat Nummer:" + p.Projektnummer);
            p.Projektname = "Franz";
            p.Projektbudget = 27.23;
            m[1] = new Projekt(1, "Hallo");
            m[2] = p;
            for(int i = 0; i<m.Length; i++)
            {
                try { m[i].printBudget();}
                catch(Exception e) { throw e; }
            }

            p.verdoppleBudget();
            Console.WriteLine("Projekt " + p.Projektname + " hat Nummer:" + p.Projektnummer + " und nun Budget: " + p.Projektbudget);

            //File
            try
            {
                var towrite = new Projekt(27, "Test");
                string y = "Err";
                string s = JsonConvert.SerializeObject(towrite);
                Console.WriteLine(s);
                if (!File.Exists("test.txt")) { File.WriteAllText(@"C:\test.txt", s); }
                if (File.Exists("test.txt")) { y = File.ReadAllText(@"C:\test.txt"); }
                var x = JsonConvert.DeserializeObject<Projekt>(y);
                Console.WriteLine(x.Projektname + " == " + towrite.Projektname + " ?");
            }catch(Exception ei) { throw ei; }
        }
    }
    public interface massnahme
    {
        void printBudget();

    }
    class Programm : massnahme
    {
        private double prog_budget;
        private int prog_id;

        public int Programmnummer { get;}
        
        public Programm(int newProgrammnummer)
        {
            if (newProgrammnummer <= 0) throw new ArgumentOutOfRangeException("Negative Programmnummer unzulaessig");
            prog_id = newProgrammnummer;
        }
        public double Programmbudget
        {
            get { return prog_budget; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Negativer Betrag"); 
                if (value <= 40000) throw new ArgumentOutOfRangeException("Budgetbetrag zu gering fuer ein Programm");
                prog_budget = value;
            }
        }
        public void printBudget()
        {
            
            Console.WriteLine("Programm " + prog_id + " hat Budget: " + prog_budget);
        }
    }
    
    class Projekt : massnahme
    {
        private int my_projektnummer;
        private String my_projektname;
        private double my_budget;

        public int Projektnummer
        {
            get
            {
                return my_projektnummer;
            }
            set
            {
                if (value <= 0) throw new Exception("Negative Nummer nicht erlaubt");
                my_projektnummer = value;
            }
        } 
            
        public double Projektbudget
        {
            get { return my_budget; }
            set { my_budget = value; }
        }
        public String Projektname
        {
            get
            {
                return my_projektname;
            }

            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException("Leerer Name unzulaessig");

                my_projektname = value;
            }
        }
        //Konstruktor
        public Projekt(int projektnummer, String projektname)
        {
            Projektnummer = projektnummer;
            Projektname = projektname;
        }
        //Methode
        public void verdoppleBudget()
        {
            Projektbudget *= 2;
        }
        public void printBudget()
        {
            Console.WriteLine("Projekt " + my_projektname + " hat Budget: " + my_budget);
        }

    }
}
