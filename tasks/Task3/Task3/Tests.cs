using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3
{
    [TestFixture]
    public class Tests
    {
        
        [Test]
        public void createProject()
        {
            Projekt x = new Projekt(1, "Hugo");
        }
        [Test]
        public void nameProject()
        {
            Projekt y = new Projekt(1, "Hugo");
            y.Projektname.Equals("Hugo"); 
        }
        public void budget_Project()
        {
            int s = 2;
            Projekt z = new Projekt(1, "Hugo");
            z.Projektbudget = s;
            s *= 2;
            z.verdoppleBudget();
            if(z.Projektbudget == s) { }
        }
        [Test]
        public void fail_createProject()
        {
           Assert.Catch(() => { var g = new Projekt(1, ""); });
           
        }
        [Test]
        public void second_fail_createProject()
        {
            
            Assert.Catch(() => { var g = new Projekt(-1, "Horst"); });

        }


        [Test]
        public void createProgramm()
        {
            Programm x = new Programm(1);
        }
        [Test]
        public void create_budget_Programm()
        {
            Programm s = new Programm(1);
            s.Programmbudget = 2000000;
            if(s.Programmbudget== 2000000) { }
        }
        [Test]
        public void fail_createProgramm()
        {
            Assert.Catch(() => { var g = new Programm(-1); });
            
        }
        [Test]
        public void fail_budget_Programm()
        {
            Assert.Catch(() => {
                Programm e = new Programm(2);
                e.Programmbudget = -1;
            });

        }
        [Test]
        public void second_fail_budget_Programm()
        {
            Assert.Catch(() => {
                Programm t = new Programm(3);
                t.Programmbudget = 10000;
            });

        }
    }
}
