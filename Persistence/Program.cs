using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //sa folosesti chestii din baza de date cu entity fw trebe adaugate in testmodel2.edmx, sau faceti altu numit mai frumos idgaf
            //x2 click de edmx se deschide in designer click dreapta si update model from database pt adaugat tabele/viewuri/proceduri noi
            //entity isi genereaza clase 1 to 1 pt tabelele alese, trebe apoi facute clase de-a noastre manual 

            Repository.RepoUserDB repou = new Repository.RepoUserDB();

            repou.GetAll().ForEach(x => { Console.WriteLine(x.IdUser+": "+x.Name); });
            Console.WriteLine("------------------");

            repou.Add(new Model.User(1111, "sfanta", "racla", "parascheva", "biserica", "mnezo@church.holy", true, "jesus.holy"));

            repou.GetAll().ForEach(x => { Console.WriteLine(x.IdUser + ": " + x.Name); });
            Console.WriteLine("------------------");

            repou.Remove(10);

            repou.GetAll().ForEach(x => { Console.WriteLine(x.IdUser + ": " + x.Name); });
            Console.WriteLine("------------------");


            /*
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach (Conference c in context.Conferences)
                {
                    Console.WriteLine(c.Name);
                }

                context.insertUser("fml", "aeroplan", "fml", "@@", "##", ".com");
            }
            */


            return;
        }
    }
}
