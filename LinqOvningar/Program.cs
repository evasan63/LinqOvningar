using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqOvningar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exempeldata
            List<Student> studenter = new List<Student>
            {
                     new Student { Id = 1, Namn = "Anna", Alder = 19, Klass = "A", Poang = 85 },
                     new Student { Id = 2, Namn = "Bertil", Alder = 22, Klass = "B", Poang = 72 },
                     new Student { Id = 3, Namn = "Cecilia", Alder = 20, Klass = "A", Poang = 91 },
                     new Student { Id = 4, Namn = "David", Alder = 24, Klass = "C", Poang = 64 },
                     new Student { Id = 5, Namn = "Eva", Alder = 19, Klass = "B", Poang = 85 },
                     new Student { Id = 6, Namn = "Felix", Alder = 21, Klass = "A", Poang = 77 },
                     new Student { Id = 7, Namn = "Gustav", Alder = 23, Klass = "C", Poang = 58 },
                     new Student { Id = 8, Namn = "Hanna", Alder = 20, Klass = "B", Poang = 95 }
            };
            Console.WriteLine("LINQ-ÖVNINGAR MED STUDENTER\n");

            //************************
            // Where övningar
            //************************
            Console.WriteLine("--- Hämta alla studenter som är äldre än 20 ---"); 

            //var result= (from s in studenter
            //             where s.Alder > 20
            //             orderby s.Namn
            //             select s)
            //            .ToList();

            var result = studenter.Where(s => s.Alder > 20);

            foreach (var student in result)
            {
                Console.WriteLine($"Namn: {student.Namn}, Ålder: {student.Alder}");
            }
            Console.WriteLine();
            Console.WriteLine("--- Hämta alla studenter som har mer än 80 poäng. ---");

            var result2 = studenter.Where(s => s.Poang > 80);

            foreach (var student in result2)
            {
                Console.WriteLine($"Namn: {student.Namn}, Poäng: {student.Poang}");
            }
            Console.WriteLine();

            //************************
            // Select övningar
            //************************
            Console.WriteLine();
            Console.WriteLine("--- Visa bara namnen på alla studenter ---");
            var namn = studenter.Select(s => s.Namn);

            foreach (var n in namn)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            var namn2 = from s in studenter
                       select s.Namn;

            foreach (var n in namn2)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            Console.WriteLine("--- Visa namn och poäng i en ny anonym typ ---");
            var namnPoang = from s in studenter
                           select new
                           {
                               s.Namn,
                               s.Poang
                           };

            foreach (var student in namnPoang)
            {
                Console.WriteLine($"Namn: {student.Namn}, Poäng: {student.Poang}");
            }

            Console.WriteLine();
            var namnPoang2 = studenter.Select(s => new
            {
                s.Namn,
                s.Poang
            });

            foreach (var student in namnPoang2)
            {
                Console.WriteLine($"Namn: {student.Namn}, Poäng: {student.Poang}");
            }

            //************************
            // OrderBy övningar
            //************************
            Console.WriteLine();
            Console.WriteLine("--- Sortera studenter efter ålder ---");
            var alder = (from s in studenter
                           orderby s.Alder
                           select s)
                          .ToList();

            foreach (var student in alder)
            {
                Console.WriteLine($"Namn: {student.Namn}, Ålder: {student.Alder}");
            }

            Console.WriteLine();
            Console.WriteLine("--- Sortera studenter efter poäng, högst först ---");
            var poang = (from s in studenter
                          orderby s.Poang descending
                          select s)
                          .ToList();

            foreach (var student in poang)
            {
                Console.WriteLine($"Namn: {student.Namn}, Poäng: {student.Poang}");
            }

            Console.WriteLine();
            Console.WriteLine("--- Sortera studenter efter poäng, högst först, lamda ---");
            var poang2 = studenter.OrderByDescending(s => s.Poang);

            foreach (var student in poang2)
            {
                Console.WriteLine($"Namn: {student.Namn}, Poäng: {student.Poang}");
            }

            //************************
            // Count övningar
            //************************
            Console.WriteLine();
            Console.WriteLine("--- Räkna hur många studenter som finns ---");

            var count = (from s in studenter
                         select s).Count();

            Console.WriteLine($"Antal studenter: {count}");

            Console.WriteLine();
            Console.WriteLine("--- Räkna hur många som går i klass A ---");

            //var countA = (from s in studenter
            //              where s.Klass == "A"
            //              select s).Count();

            var countA = studenter.Count(s => s.Klass == "A");

            Console.WriteLine($"Antal studenter i klass A: {countA}");

            //************************
            // Take övningar
            //************************
            Console.WriteLine();
            Console.WriteLine("--- Ta ut de tre första studenterna ---");

            //var treForsta = (from s in studenter
            //                 select s).Take(3);

            var treForsta = studenter.Take(3);

            foreach (var student in treForsta)
            {
                Console.WriteLine($"Namn: {student.Namn} Ålder: {student.Alder} Klass: {student.Klass} Poäng: {student.Poang}");
            }

            Console.WriteLine();
            Console.WriteLine("--- Ta ut de två bästa poängen efter sortering. ---");
            //var takeBasta2 = (from s in studenter
            //                  orderby s.Poang descending
            //                  select s).Take(2);

            var takeBasta2 = studenter.OrderByDescending(s => s.Poang).Take(2);

            foreach (var s in takeBasta2)
            {
                Console.WriteLine($"Namn: {s.Namn} Poäng: {s.Poang}");
            }


            //************************
            // Distinct övningar
            //************************
            Console.WriteLine();  
            Console.WriteLine("--- Visa alla unika klassnamn ---");
            //var unikaNamn = (from s in studenter
            //                 select s.Namn).Distinct();

            var unikaNamn = studenter.Select(s => s.Namn).Distinct();

            foreach (var s in unikaNamn)
            {
                Console.WriteLine(s);
                //Console.WriteLine($"Namn: {s.Namn} Poäng: {s.Poang}");
            }

            Console.WriteLine();
            Console.WriteLine("--- Visa alla unika åldrar. ---");
            //var unikaAlder = (from s in studenter
            //                 select s.Alder).Distinct();

            var unikaAlder = studenter.Select(s => s.Alder).Distinct();

            foreach (var s in unikaAlder)
            {
                Console.WriteLine(s);
                //Console.WriteLine($"Namn: {s.Namn} Ålder: {s.Alder}");
            }

            //************************
            // Any/All övningar
            //************************
            Console.WriteLine();
            Console.WriteLine("--- Finns det någon student med 100 poäng? ---");

            bool any = (from s in studenter
                       where s.Poang >100
                       select s).Any();
            Console.WriteLine(any);

            bool any2 = studenter.Any(s => s.Poang > 100);
            Console.WriteLine(any2);

            Console.WriteLine();
            Console.WriteLine("--- Har alla studenter minst 50 poäng? ---");

            //bool all = (from s in studenter
            //            where s.Poang > 49
            //            select s).All(); ????
            //Console.WriteLine(all);

            bool all2 = studenter.All(s => s.Poang > 49);
            Console.WriteLine(all2);

            //*************************************
            // FirstOrDefault/Last/Single övningar
            //*************************************
            Console.WriteLine();
            Console.WriteLine("--- Hämta första studenten i klass B ---");

            //var studentB = (from s in studenter
            //              where s.Klass == "B"
            //              select s).FirstOrDefault();

            //Console.WriteLine($"Namn: {studentB.Namn} Klass: {studentB.Klass}");

            var studentB1 = studenter.FirstOrDefault(s => s.Klass == "B");
            Console.WriteLine($"Namn: {studentB1.Namn} Klass: {studentB1.Klass}");

            Console.WriteLine();
            Console.WriteLine("--- Hämta sista studenten i listan ---");

            var studentLast = studenter.Last();
            Console.WriteLine($"Namn: {studentLast.Namn} Klass: {studentLast.Klass}");

            Console.WriteLine();
            Console.WriteLine("--- Hämta studenten med ett visst Id ---");

            var id = studenter.Single(s => s.Id == 4);
            Console.WriteLine($"Namn: {id.Namn} Id: {id.Id}");

            //*************************************
            // GroupBy övningar
            //*************************************
            Console.WriteLine();
            Console.WriteLine("--- Gruppera studenter per klass ---");

            var grupper = studenter.GroupBy(s => s.Klass);

            foreach (var grupp in grupper)
            {
                Console.WriteLine("Klass:" + grupp.Key);
                Console.WriteLine("---------");

                foreach (var student in grupp)
                {
                    Console.WriteLine(student.Namn);     
                }
            }

            //*************************************
            // Sum/Average/Min/Max övningar
            //*************************************
            Console.WriteLine();
            Console.WriteLine("--- Summera alla poäng ---");

            var sum = studenter.Sum(s => s.Poang);
            Console.WriteLine($"Summa poäng: {sum}");

            Console.WriteLine();
            Console.WriteLine("--- Räkna ut medelpoäng ---");

            var average = (from s in studenter
                           select s.Poang).Average();

            //var average = studenter.Average(s => s.Poang);
            Console.WriteLine($"Medelpoäng: {average}");

            Console.WriteLine();
            Console.WriteLine("--- Hitta lägsta och högsta poäng ---");

            var min = (from s in studenter
                       select s.Poang).Min();
            Console.WriteLine($"Max poäng: {min}");

            var max = studenter.Max(s => s.Poang);
            Console.WriteLine($"Max poäng: {max}");


        }
    }
}
