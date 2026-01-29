using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition
{
    internal class Menu
    {
        private ArtifactManager manager;

        public Menu(ArtifactManager manager)
        {
            this.manager = manager;
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("<------Space Expedition Menu ------>");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. Add New Artifact");
                Console.WriteLine("3. Save and Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.ShowAll();
                        break;

                    case "2":
                        manager.AddArtifact();
                        break;

                    case "3":
                        manager.SaveToFile();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option."); 
                        break;
                }
            }
        }
    }
}
