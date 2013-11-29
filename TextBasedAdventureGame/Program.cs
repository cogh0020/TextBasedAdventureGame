using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBasedAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            Game theGame = new Game();
            theGame.reset();
            Console.WriteLine("Fail Corp Presents....");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            Console.Beep(200, 400);
            Console.Beep(100, 400);
            Console.Beep(400, 900);
            
            Console.WriteLine(" _______  _______ _________ _ ");
            Console.WriteLine("|  ____ \\(  ___  )\\__   __/( \\");
            Console.WriteLine("| (    \\/| (   ) |   ) (   | (");
            Console.WriteLine("| (__    | (___) |   | |   | | ");
            Console.WriteLine("|  __)   |  ___  |   | |   | |");
            Console.WriteLine("| (      | (   ) |   | |   | |  ");
            Console.WriteLine("| )      | )   ( |___) (___| (____/\\");
            Console.WriteLine("|/       |/     \\|\\_______/(_______/");

            System.Threading.Thread.Sleep(500);

            Console.WriteLine(" _______           _______  _______ _________");
            Console.WriteLine("(  ___  )|\\     /|(  ____ \\(  ____ \\__   __/");
            Console.WriteLine("| (   ) || )   ( || (    \\/| (    \\/   ) (   ");
            Console.WriteLine("| |   | || |   | || (__    | (_____    | |  ");
            Console.WriteLine("| |   | || |   | ||  __)   (_____  )   | |  ");
            Console.WriteLine("| | /\\| || |   | || (            ) |   | |  ");
            Console.WriteLine("| (_\\ \\ || (___) || (____/\\/\\____) |   | |  ");
            Console.WriteLine("(____\\/_)(_______)(_______/\\_______)   )_(  ");
            Console.Beep(200, 400);
            Console.Beep(100, 400);
            Console.Beep(400, 900);

            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Made by Joel Cright, Nikolai Morin Cull, Andy Lovett, and Greg Coghill");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            while (playing == true)
            {
                theGame.checkIfValid(Console.ReadLine());
            }
        }
    }

    public class Game
    {
        bool beenHereWater = false;
        bool lookedAround = false;
        List<string> inventory = new List<string>();

        public void reset()
        {
            inventory.Add("EndOfInv");

            beenHereWater = false;
            lookedAround = false;
        }

        public void checkIfValid(string toCheck)
        {
            whereTo(toCheck);
        }

        private void whereTo(string toHere)
        {
            switch (toHere)
            {
                case "Tavern":
                    theTavern();
                    break;

                case "Water":
                    waterStuff();
                    break;

                case "Quarry":
                    theQuarry();
                    break;

                case "Look around":
                    LookAround();
                    break;

                case "Test Inventory":
                    testInventory();
                    break;

                case "Inventory":
                    printInventory();
                    break;

                default:
                    Console.WriteLine("That command is invalid. Please try again\n");
                    break;
            }
        }

        private void gameOver()
        {
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("======= You have died =======");
            Console.WriteLine("         _,.-------.,_");
            Console.WriteLine("     ,;~'             '~;,");
            Console.WriteLine("   ,;                     ;,");
            Console.WriteLine("  ;                         ;");
            Console.WriteLine(" ,'                         ',");
            Console.WriteLine(",;                           ;,");
            Console.WriteLine("; ;      .           .      ; ;");
            Console.WriteLine("| ;   ______       ______   ; |");
            Console.WriteLine("|  `/~*     ~* . *~     *~\\'  |");
            Console.WriteLine("|  ~  ,-~~~^~, | ,~^~~~-,  ~  |");
            Console.WriteLine(" |   |        }:{        |   |");
            Console.WriteLine(" |   l       / | \\       !   |");
            Console.WriteLine(" .~  (__,.--* .^. *--.,__)  ~.");
            Console.WriteLine(" |     ---;' / | \\ `;---     |");
            Console.WriteLine("  \\__.       \\/^\\/       .__/");
            Console.WriteLine("   V| \\                 / |V");
            Console.WriteLine("    | |T~\\___!___!___/~T| |");
            Console.WriteLine("    | |`IIII_I_I_I_IIII'| |");
            Console.WriteLine("    |  \\,III I I I III,/  |");
            Console.WriteLine("     \\   `~~~~~~~~~~'    /");
            Console.WriteLine("       \\   .       .   /   ");
            Console.WriteLine("         \\.    ^    ./");
            Console.WriteLine("           ^~~~^~~~^");
            Console.Beep(300, 300);
            Console.Beep(200, 300);
            Console.Beep(100, 800);
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            reset();
        }

        private void printInventory()
        {
            foreach (string inventoryItem in inventory)
            {
                Console.WriteLine(inventoryItem);
            }
        }

        private void waterStuff()
        {
            foreach(string inventoryItem in inventory)
            {
                if (inventoryItem == "Rope")
                {
                    Console.WriteLine("You look around warily, fearing the rapids. You look around your bag for something to assist in crossing, and find a rope. It takes a coupld of tries, but you manage to hook the rope on a tough rock, and cross safely");
                    beenHereWater = true;
                    inventory.Remove("Rope");
                    return;
                }
                else
                {
                    continue;
                }
            }
            if (beenHereWater == true)
            {
                Console.WriteLine("Having been here already, you cockily attempt to traverse the rapids. Your quick steps lead to your downfall");
                reset();
            }
            else
            {
                Console.WriteLine("You gaze around in wonder. Having never seen such quick rapids before, so you take your time crossing. Unfortunately, taking your time means you were in the way when a tree came down, knocking you into the wtaer, where you freeze/drown/get clubbed by a tree to death.");
            }
        }

        private void testInventory()
        {
            for (int i = 0; i < 3; i++)
            {
                inventory.Add("Item " + i);
            }
        }

        private void inventoryFull(string itemToGet)
        {
            Console.WriteLine("Your inventory is full. You'll have to drop an item to pick up that " + itemToGet + ".");
            foreach (string inventoryItem in inventory)
            {
                Console.WriteLine(inventoryItem);
            }

            string thingToDrop = Console.ReadLine();

            foreach (string inventoryItem in inventory)
            {
                if (inventoryItem == thingToDrop)
                {
                    inventory.Remove(thingToDrop);
                    inventory.TrimExcess();
                }
                else
                {
                    continue;
                }
            }
        }

        public void theQuarry()
        {
            bool inQuarry = true;
            bool pickaxe = false;
            bool menDead = false;
            Console.Clear();
            Console.WriteLine("You arrive at the quarry. It is very rocky. You see to quarry workers playing with some rocks, and a man standing over a pulley.\n There is a pickaxe on the ground");

            while (inQuarry == true)
            {
                Console.WriteLine("\nWhat will you do?\n");

                Console.WriteLine("Talk to Workers");
                Console.WriteLine("Talk to Man");
                Console.WriteLine("Search Rocks");
                Console.WriteLine("Take pickaxe");
                Console.WriteLine("Leave");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Talk to Workers":
                        {
                            if (menDead == true)
                            {
                                Console.WriteLine("The men are dead. This makes it difficult to talk to them.");
                            }
                            else
                            {
                                Console.WriteLine("You approach the working men.\nThey ignore you and maintain their focus on the rocks.");
                            }
                            break;
                        }

                    case "Talk to Man":
                        {
                            if (pickaxe == true)
                            {
                                Console.WriteLine("You approach the strange man...");
                                Console.WriteLine("He sees the pickaxe you are carrying and panics.\n He cuts the pulley and runs,dropping a hammer as he flees.\nThe pulley drops a boudler on the working men, crushing them.\nYou take the hammer");
                                pickaxe = false;
                                menDead = true;
                            }
                            else
                            {
                                Console.WriteLine("You approach the strange man...");
                                Console.WriteLine("He looks over your puny form and chuckles to himself. \nYou are no threat to him. He ignores you.");
                            }
                            break;
                        }
                    case "Search Rocks":
                        {
                            Console.WriteLine("You search through a pile of rocks. \nFoolishly, you disrupt a much larger pile, which is actually a small part\n of an even bigger pile. They tumble onto you, crushing you.");
                            System.Threading.Thread.Sleep(3000);
                            inQuarry = false;
                            gameOver();
                            break;
                        }

                    case "Take pickaxe":
                        {
                            Console.WriteLine("You take the pickaxe. It is rather hefty, considering you are so weak and puny.");
                            System.Threading.Thread.Sleep(4000);
                            pickaxe = true;
                            break;
                        }

                    case "Leave":
                        {
                            Console.WriteLine("You exit the quarry. On your way back across the river, you lose your rope.");
                            System.Threading.Thread.Sleep(4000);
                            inQuarry = false;
                            Console.Clear();
                            break;
                        }
                    default:
                        Console.WriteLine("Thy does not compute. Try again");
                        break;
                }
            }
        }

        public void theTavern()
        {
            int broseph = 0;
            bool inTavern = true;
            //Required bools
            //TODO: Item from drunk man
            Console.WriteLine("You walk into a tavern. You see many patrons and wenches. You notice a large man at the bar\n");

            while (inTavern == true)
            {
                Console.WriteLine("What will you do?\n");

                Console.WriteLine("Fight Man");
                Console.WriteLine("Talk to Man");
                Console.WriteLine("Drink with Man");
                Console.WriteLine("Leave");
                Console.WriteLine(": ");
                string input = Console.ReadLine();
               
                switch (input)
                {
                    case "Fight Man":
                        {
                            Console.WriteLine("You point to the man and challenge his manliness.He immediately gets up,\nbrandishes an large axe, and removes your head from your shoulders.");
                            System.Threading.Thread.Sleep(3000);
                            inTavern = false;
                            gameOver();
                            break;
                        }
                    case "Talk to Man":
                        {
                            Console.WriteLine("You approach the man and attempt to initiate a meaningful conversation...\n");
                            if (broseph > 1)
                            {
                                Console.Beep(300, 300);
                                Console.Beep(200, 300);
                                Console.Beep(300, 800);
                                Console.WriteLine("After a few minutes of chatting about wenches and alcohol.");
                                Console.WriteLine("He then passes out and falls to the ground.\n A key falls from his pocket. You take it.");
                                //Shit happens. Aw yiss
                                break;
                            }
                            else
                            {
                                Console.WriteLine("He scoffs at your scrawny form and turns his attention to something in the room that isn't as puny as you.\n");
                                //Nothing happens. Must be more bro-like
                                break;
                            }
                        }
                    case "Drink with Man":
                        {
                            Console.WriteLine("You walk up to the bar and order a drink for the man with the fine,\n sculpted muscles. He gives you a heavy pat on the back and thanks you.");
                            broseph+=1;
                            //You become bros
                            break;
                        }

                    case "Leave":
                        {
                            Console.Clear();
                            inTavern = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Thy does not compute. Try again, fool!");
                            break;
                        }
                }
            }
        }

        private void LookAround()
        {
            if (lookedAround == false)
            {
                Console.WriteLine("You look around, and find a rope on the ground nearby!");
                foreach (string inventoryItem in inventory)
                {
                    if (inventoryItem == null)
                    {
                        inventory.Add("Rope");
                        lookedAround = true;
                        return;
                    }

                    else if (inventoryItem == "EndOfInv")
                    {
                        inventoryFull("Rope");
                        lookedAround = true;
                        return;
                    }
                }
            }

            else
            {
                Console.WriteLine("You've already looked around. There is nothing interesting anymore");
            }
        }
    }
}
