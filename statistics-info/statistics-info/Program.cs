using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statistics_info {
    class Program {
        static void CheckDice(int setsize, int howmany) {
            List<int> rolls = new List<int>();

            Random rand = new Random();

            float average = 0.0f;

            float[] successes = new float[howmany];
            float[] failures = new float[howmany];

            for (int i = 0; i < howmany; i++) {
                for (int j = 0; j < setsize; j++) {
                    //rolls.Add(rand.Next(1, 7));
                }
            }

            foreach (int num in rolls) {
                average += num;
                Console.WriteLine(num); 
            }

            average = average / rolls.Count;
            Console.WriteLine("Average was " + average.ToString());
        }

        static void Main(string[] args)
        {
            bool bLoop = true;
            string sInput = "";
            int iSetSize = 0;
            int iNumSets = 0;

            while (bLoop) {
                Console.WriteLine("Enter [num sets/repititions], q to quit, or c to clear.\n");
                sInput = Console.ReadLine();

                if (sInput.Substring(0, 1) == "q") {
                    bLoop = false;
                }
                else if (sInput.Substring(0, 1) == "c") {
                    Console.Clear();
                }
                else {
                    string[] readin = sInput.Split('/');

                    if (readin.Count() >= 2) {
                        if (int.TryParse(readin[0], out iSetSize)) {

                            if (int.TryParse(readin[1], out iNumSets)) {
                                CheckDice(iSetSize, iNumSets);
                                Console.WriteLine("Done.\n");
                            }
                            else {
                                Console.WriteLine("Invalid input.\n");
                            }
                        }
                        else {
                            Console.WriteLine("Invalid input.\n");
                        }
                    }
                    else {
                        Console.WriteLine("Invalid input.\n");
                    }
                }
            }
        }
    }
}
