using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Projekt p = new Projekt(1, "Hugo");
            Console.WriteLine("Projekt" + p.Projektname + " hat Nummer:" + p.Projektnummer);
            p.Projektname = "Franz";
            p.Projektbudget = 27.23;
            Console.WriteLine("Projekt" + p.Projektname + " hat Nummer:" + p.Projektnummer + " und Budget: "+p.Projektbudget);
            p.verdoppleBudget();
            Console.WriteLine("Projekt" + p.Projektname + " hat Nummer:" + p.Projektnummer + " und nun Budget: " + p.Projektbudget);

        }
    }
    public class Projekt
    {
        private int my_projektnummer;
        private String my_projektname;
        private double my_budget;

        public int Projektnummer => my_projektnummer;
        public double Projektbudget {
            get { return my_budget; }
            set { my_budget = value; }
        }
        public String Projektname {
            get{
                return my_projektname;
            }

            set
            {
                if (value == "") throw new ArgumentOutOfRangeException("Leerer Name unzulaessig");
                my_projektname = value;
            }
        }
        //Konstruktor
        public Projekt(int newProjektnummer, String newProjektname)
        {
            if (newProjektnummer <= 0) throw new ArgumentOutOfRangeException("Negative Projektnummer unzulaessig");
            my_projektnummer = newProjektnummer;

            Projektname = newProjektname;
            
            
        }
        //Methode
        public void verdoppleBudget()
        {
            Projektbudget *= 2;
        }
        
        
    }
}
/*
 *1 Konstruktor
 * 2 public properties
 * 1 public method
 * 1 private field
 * 
 * Code in main der instanzen erzeugt, new operator
 * properties der Objecte ausgibt
 * methoden der Objekte aufruft und den Effekt auf der Konsole ausgibt
 * 
 * Push nach git 
 */