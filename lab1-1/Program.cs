using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            Circus circus = new Circus();

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.Clear();
                switch (cki.Key)
                {
                    case ConsoleKey.P:
                        Console.WriteLine(circus.Show());
                        break;
                    case ConsoleKey.I:
                        Console.WriteLine(circus.AnimalsIntroduction());
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine(zoo.Sounds());
                        break;
                    case ConsoleKey.Z:
                        Console.WriteLine(zoo.Animals.FirstOrDefault(x => !(x.Name == null)).Name);
                        break;
                    case ConsoleKey.C:
                        circus.Animals.ForEach(x => Console.WriteLine(x.Name));
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Finishing...");
                        return;
                    default:
                        Console.WriteLine("Use P I S Z C");
                        break;
                }
            }
        }
    }

    public abstract class Animal
    {

        public string Name { get; set; }
        public float Weight { get; set; }
        public bool HaveFur { get; set; }

        public abstract int CountLegs();

        public abstract string Sound();

        public abstract string Trick();

    }

    public class Circus : ICircus
    {
        public List<Animal> Animals { get; set; }
        public string Name { get; set; }

        public Circus()
        {
            Animals = new List<Animal>();

            Animals.Add(new Giraffe() { Name = "burek" });
            Animals.Add(new Giraffe() { Name = "szarik" });
            Animals.Add(new Elephant() { Name = "azor" });
            Animals.Add(new Elephant() { Name = "misiek" });
            Animals.Add(new Ant() { Name = "burek" });
            Animals.Add(new Ant() { Name = "burek" });
            Animals.Add(new Cat() { Name = "burek" });
            Animals.Add(new Cat() { Name = "burek" });
            Animals.Add(new Pony() { Name = "burek" });
            Animals.Add(new Pony() { Name = "burek" });
        }

        public string AnimalsIntroduction()
        {
            return Animals.Select(anim => anim.Sound()).Aggregate("", (prev, next) => prev + " " + next);
        }

        public int Patter(int howMuch)
        {
            int feet = Animals.Select(anim => anim.CountLegs()).Aggregate(0, (prev, next) => prev + next);

            return feet * howMuch;
        }

        public string Show()
        {
            return Animals.Select(anim => anim.Trick()).Aggregate((prev, next) => prev + " " + next);
        }
    }

    public class Zoo : IZoo
    {
        public List<Animal> Animals { get; set; }
        public String Name { get; set; }

        public Zoo()
        {
            Animals = new List<Animal>();

            Animals.Add(new Giraffe() { Name = "burek" });
            Animals.Add(new Pony() { Name = "szarik" });
            Animals.Add(new Elephant() { Name = "azor" });
        }

        public string Sounds()
        {
            return Animals.Select(anim => anim.Sound()).Aggregate((prev, next) => prev + next);
        }
    }

    public class Cat : Animal
    {
        public string Color { get; set; }

        public override int CountLegs()
        {
            return 4;
        }

        public override string Sound()
        {
            return "meeeow";
        }

        public override string Trick()
        {
            return "i always fall on 4 feet";
        }
    }

    public class Pony : Animal
    {
        public override int CountLegs()
        {
            return 4;
        }

        public bool IsMagic { get; set; }

        public override string Sound()
        {
            return "yeeeeha";
        }

        public override string Trick()
        {
            return "i'm amazing";
        }
    }

    public class Ant : Animal
    {
        public override int CountLegs()
        {
            return 6;
        }

        public bool IsQueen { get; set; }

        public override string Sound()
        {
            return "have you ever seen an talking ant?";
        }

        public override string Trick()
        {
            return "i can scare everyone";
        }
    }

    public class Elephant : Animal
    {
        public override int CountLegs()
        {
            return 4;
        }

        public override string Sound()
        {
            return "trab trab";
        }

        public override string Trick()
        {
            return "i can make a shower rain with my trunk";
        }
    }

    public class Giraffe : Animal
    {
        public override int CountLegs()
        {
            return 4;
        }

        public override string Sound()
        {
            return "im busy eating, cant talk";
        }

        public override string Trick()
        {
            return "well, i can eat";
        }
    }


    public interface ICircus
    {
        string AnimalsIntroduction();
        string Show();
        int Patter(int howMuch);
    }

    public interface IZoo
    {
        string Sounds();
    }
}
