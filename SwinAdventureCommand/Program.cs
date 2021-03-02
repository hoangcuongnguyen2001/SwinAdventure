using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SwinAdventure;

namespace SecondSwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to Swin-Adventure!");
            Console.WriteLine();

            Console.WriteLine("This is the first version of the game that is created by me. Enjoy the adventure in the game world!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("How can you describe yourself(for example, a mighty programmer)?");
            string description = Console.ReadLine();
            Console.WriteLine("Let's begin your adventure today!");
            Player newPlayer = new Player(name, description);
            bool StayingOpen = true;

            // adding items and bag
            Item Itm1 = new Item(new string[] { "golden", "ring" }, "ring", "This is a golden ring for you");
            Item Itm2 = new Item(new string[] { "yellow", "small", "box" }, "box", "This is a small yellow box for you");
            Item Itm3 = new Item(new string[] { "purple", "ball" }, "ball", "That is a small and purple ball");
            Item Itm4 = new Item(new string[] { "green", "table" }, "table", "This is a dining table. Be careful with it!");
            Item Itm5 = new Item(new string[] { "orange" }, "orange", "This is an orange for you.");
            Bag Bag1 = new Bag(new string[] { "red", "bag" }, "bag", "This is a large and red bag");

            // adding locations
            Location Loc1 = new Location("coffee house", " where you could go to coffee house each day");
            Location Loc2 = new Location("palace", "where the duke worked and lived");
            Location Loc3 = new Location("old fort", "where we could see the port");
            Location Loc4 = new Location("small house", "where an old family lives");
            Location Loc5 = new Location("museum", "which is quite niche");
            Location Loc6 = new Location("stable", "where people raise their finest horses");


            // adding paths 
            Path path1 = new Path(new string[] { "north" }, "a trail", " which is where people go every day", Loc1, Loc2);
            Path path2 = new Path(new string[] { "west" }, "main road", " where traders move and go", Loc1, Loc6);
            Path path3 = new Path(new string[] { "east" }, "river bank", " where the weather is quite sunny.", Loc1, Loc3);
            Path path4 = new Path(new string[] { "south" }, "small grove", " near a tiny lake", Loc1, Loc4);
            Path path5 = new Path(new string[] { "northwest" }, "a creek", " where a plan was laid out", Loc1, Loc5);
            Path path6 = new Path(new string[] { "southwest" }, "big street", "near the center of the city", Loc2, Loc3);
            Path path7 = new Path(new string[] { "northeast" }, "a corridor", "near a forest", Loc2, Loc4);
            Path path8 = new Path(new string[] { "southeast" }, "a bridge", "through the great river", Loc2, Loc5);
            Path path9 = new Path(new string[] { "gate" }, "new gate", "leads to stable", Loc2, Loc6);

            //add path to locations.
            Loc1.AddPath(path1);
            Loc1.AddPath(path2);
            Loc1.AddPath(path3);
            Loc1.AddPath(path4);
            Loc1.AddPath(path5);
            Loc2.AddPath(path6);
            Loc2.AddPath(path7);
            Loc2.AddPath(path8);
            Loc2.AddPath(path9);

            Loc1.Inventory.Put(Itm4);
            newPlayer.Location = Loc1;
            newPlayer.Inventory.Put(Itm1);
            newPlayer.Inventory.Put(Itm2);
            newPlayer.Inventory.Put(Itm5);
            newPlayer.Inventory.Put(Bag1);
            Bag1.Inventory.Put(Itm3);

            //handling Command Processor.
            CommandProcessor newCommand = new CommandProcessor();
            TakeCommand Take = new TakeCommand();
            newCommand.AddCommand(Take);
            LookCommand Look = new LookCommand();
            newCommand.AddCommand(Look);
            MoveCommand Move = new MoveCommand();
            newCommand.AddCommand(Move);
            PutCommand Put = new PutCommand();
            newCommand.AddCommand(Put);



            while (StayingOpen)
            {
                Console.WriteLine("Please enter command:");
                string _input = Console.ReadLine();
                string[] Command = _input.Split();// get help from Charlotte Pierce in HelpDesk.

                if (Command[0] == "quit")
                {
                    Console.WriteLine("Bye.");
                    Thread.Sleep(2000);
                    StayingOpen = false;
                }
                else
                {

                    Console.WriteLine(newCommand.Execute(newPlayer, Command));
                }
            }

        }
    }
}
