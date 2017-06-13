using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;



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
            for (int i = 0; i < m.Length; i++)
            {
                try { m[i].printBudget(); }
                catch (Exception e) { throw e; }
            }

            p.verdoppleBudget();
            Console.WriteLine("Projekt " + p.Projektname + " hat Nummer:" + p.Projektnummer + " und nun Budget: " + p.Projektbudget);
            var arr = new massnahme[]{
            new Projekt(1, "1"),
            new Programm(2),
            new Projekt(3, "3")
            };
            //File & JSON
            try
            {

                string y = "Err";
                var backupSettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
                File.WriteAllText(@"c:\Users\Hannes\oom\tasks\Task3\text.json", JsonConvert.SerializeObject(arr, backupSettings));
                if (File.Exists(@"c:\Users\Hannes\oom\tasks\Task3\text.json")) { y = File.ReadAllText(@"c:\Users\Hannes\oom\tasks\Task3\text.json"); }
                Console.WriteLine(y);
                var x = JsonConvert.DeserializeObject<massnahme[]>(y, backupSettings);
                for (int i = 0; i < 3; i++)
                {
                    x[i].printBudget();
                }
            } catch (Exception ei) { throw ei; }

            //Task 6 und 7 

            int verzw = 7;

            var sub = new Subject<Programm>();
            
            sub
                .Where(Programm => Programm.Programmnummer > 10)
                .Subscribe(Programm =>
                { Console.WriteLine(Programm.Programmnummer + " hat Budget: " + Programm.Programmbudget); }
                );

            sub.OnNext(new Programm(1));
            sub.OnNext(new Programm(17));
            sub.OnNext(new Programm(12));
            sub.OnNext(new Programm(4));
            sub.OnNext(new Programm(10));
            sub.OnNext(new Programm(5));
            sub.OnNext(new Programm(176));
            sub.OnNext(new Programm(90));
            sub.OnNext(new Programm(7));

            
            sub.Dispose();
        }
    }
    public interface massnahme
    {
        void printBudget();

    }
    class Programm : massnahme
    {
        private double programmbudget;
        private int my_programmnummer;

        public int Programmnummer
        {
            get
            {
                return my_programmnummer;
            }
            set
            {
                if (value < 0) throw new Exception("Negative Nummer nicht erlaubt");
                my_programmnummer = value;
            }
        }

        public Programm(int programmnummer)
        {
            
            Programmnummer = programmnummer;
        }
        public double Programmbudget
        {
            get { return programmbudget; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Negativer Betrag"); 
               // if (value <= 40000) throw new ArgumentOutOfRangeException("Budgetbetrag zu gering fuer ein Programm");
                programmbudget = value;
            }
        }
        public void printBudget()
        {
            
            Console.WriteLine("Programm " + my_programmnummer + " hat Budget: " + programmbudget);
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
