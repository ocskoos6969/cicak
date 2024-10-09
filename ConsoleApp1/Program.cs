using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Szine { Zold, Rozsa, Feher, Lila, Fekete}
    enum Neme { Fiu, Lany}
    class Cica
    {
        public int ID { get; set; }
        public string Neve { get; set; }
        public Szine Szine { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public Neme Neme { get; set; }
        public int Suly { get; set; }
        public int Kor => DateTime.Now.Year - SzuletesiDatum.Year;

        public override string ToString()
        {
            return $"{ID,-5}{Neve,-15}{Szine,-10}{SzuletesiDatum.ToString("yyy.MM.dd"),-15}{Neme,-10}{Suly,-5}{Kor}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>()
            {
                new Cica()
                {
                    ID=1,
                    Neme=Neme.Fiu,
                    Neve="Megatron",
                    Suly=10,
                    Szine=Szine.Fekete,
                    SzuletesiDatum=new DateTime(2018,08,13),
                },
                new Cica()
                {
                    ID=2,
                    Neme=Neme.Lany,
                    Neve="Pizsama",
                    Suly=4,
                    Szine=Szine.Rozsa,
                    SzuletesiDatum=new DateTime(2022,05,11),
                },
                new Cica()
                {
                    ID=3,
                    Neme=Neme.Fiu,
                    Neve="Radics",
                    Suly=8,
                    Szine=Szine.Feher,
                    SzuletesiDatum=new DateTime(2017,02,21),
                },
                new Cica()
                {
                    ID=4,
                    Neme=Neme.Fiu,
                    Neve="Attila",
                    Suly=6,
                    Szine=Szine.Fekete,
                    SzuletesiDatum=new DateTime(2019,11,17),
                },
                new Cica()
                {
                    ID=5,
                    Neme=Neme.Lany,
                    Neve="Kokusz",
                    Suly=5,
                    Szine=Szine.Feher,
                    SzuletesiDatum=new DateTime(2021,06,23),
                },
                new Cica()
                {
                    ID=6,
                    Neme=Neme.Fiu,
                    Neve="Rombolo",
                    Suly=11,
                    Szine=Szine.Lila,
                    SzuletesiDatum=new DateTime(2015,03,27),
                },
            };

            Cica elsoCica = cicak.First();
            Console.WriteLine(elsoCica);

            Cica utolsoCica = cicak.Last();
            Console.WriteLine(utolsoCica);

            int osszSuly = cicak.Sum(x => x.Suly);
            Console.WriteLine($"Össz súly: {osszSuly} kg");

            double atlagKor = cicak.Average(x => x.Kor);
            Console.WriteLine($"Átlag életkor: {atlagKor:0.00}");

            int lanyDb = cicak.Count(x => x.Neme == Neme.Lany);
            Console.WriteLine($"Lány cicák: {lanyDb}");

            int legveznabbMacska = cicak.Min(x => x.Suly);
            Console.WriteLine($"{legveznabbMacska} kg");

            cicak.Where(x => x.Kor > 3)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Neve));

            cicak.Where(x => x.Szine == Szine.Fekete)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Neve));

            Console.ReadKey();
        }
    }
}
