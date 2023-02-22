using System;
using System.Collections.Generic;

namespace SwimApp
{
    class Program
    {
        //global variables
        static List<string> teamA = new List<string>();
        static List<string> teamB = new List<string>();
        static List<string> teamReserves = new List<string>();

        static float fastestTime = 9999f;
        static string topSwimmer = "";

        static void OneSwimmer()
        {
            Console.WriteLine("Enter Swimmer's Name:");

            string swimmerName = Console.ReadLine(); ;

            Console.WriteLine($"Swimmer name: {swimmerName}");

            int sumTotalTime = 0;
            
            //loop 4 times
            for (int i = 0; i < 4; i++)
            {
                int minutes, seconds, totalTime = 0;

                //Generate a random number between 1 and 4 (incl)

                Random randomNumber = new Random();

                minutes = randomNumber.Next(1, 4);
                seconds = randomNumber.Next(0, 59);

                totalTime = (minutes * 60) + seconds;

                Console.WriteLine($"Swimmer Time {i+1}: {minutes} min  {seconds} seconds \t\tTotal time in seconds: {totalTime}s\n");

                sumTotalTime = sumTotalTime + totalTime;

            }

            float avgTime = (float)sumTotalTime / 4;

            if (avgTime < fastestTime)
            {
                fastestTime = avgTime;
                topSwimmer = swimmerName;
            }

            string allocateTeam = "Reserve";

            //assign the swimmer to a team
            if(avgTime <= 160)
            {
                teamA.Add(swimmerName);
                allocateTeam = "A";
            }
            else if(avgTime <= 210)
            {
                teamB.Add(swimmerName);
                allocateTeam = "B";
            }
            else
            {
                teamReserves.Add(swimmerName);
            }

            
            Console.WriteLine($"Avg time {avgTime}s");

            Console.WriteLine($"Team {allocateTeam}");


        }

        //Returns a string containing team lists
        static string createTeamlists()
        {
            string teamLists = "The teams are:\n\nTeam A\n";

            //Add team A to team list
            foreach(string swimmer in teamA)
            {
                teamLists += swimmer + "\t";
            }

            teamLists += $"\nwith {teamA.Count} team member(s)\n\nTeam B";

            //Add team B to team list
            foreach (string swimmer in teamB)
            {
                teamLists += swimmer + "\t";
            }

            teamLists += $"\nwith {teamB.Count} team member(s)\n\nTeam Reserves";

            //Add team Reserves to team list
            foreach (string swimmer in teamReserves)
            {
                teamLists += swimmer + "\t";
            }

            teamLists += $"\nwith {teamReserves.Count} team member(s)\n\n";

            return teamLists;

        }

        static void Main(string[] args)
        {
            string flag = "";

            while (!flag.Equals("Stop"))
            {
                OneSwimmer();

                Console.WriteLine("Press <Enter> to add another swimmer or type 'Stop' to end");
                flag = Console.ReadLine();

                Console.WriteLine($"The fastest swimmer was {topSwimmer} with an average time of {fastestTime} seconds");

                Console.WriteLine(createTeamlists());
            }

        }
    }
}
