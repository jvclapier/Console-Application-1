using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Application_1
{
    // Create Team parent class
    public class Team
    {
        //attributes
        public string name;
        public int wins;
        public int loss;
    }

    //create SoccerTeam subclass to inherit from the Team class
    public class SoccerTeam : Team
    {
        //attributes
        public int draw;
        public int goalsFor;
        public int goalsAgainst;
        public int differential;
        public int points;
        
        //
        List<Game> myGames = new List<Game>();
        
        //create constructor to receive  the name and points values
        public SoccerTeam (string name, int points){
            this.name = name;
            this.points = points;
        }

    }

    //create game class that is an attribute of SoccerTeam
    public class Game
    {
        public int pointsFor;
        public int pointsAgainst;
    }

    class Program
    {
        static string UpperCaseFirst(string s)
        {
            //check for empty string
            if(string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            //return char and concat substring
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {
            //declare variables
            int iTeams;
            string userInput, teamName;
            int iPoints;
            int iPosition = 1;
            
            //prompt user for input and convert int to string
            Console.Write("How many teams? ");
            iTeams = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            //create soccer teams list
            List<SoccerTeam> TeamsList = new List<SoccerTeam>();

            //prompt user for team names and create soccer team objects
            for (int iCount = 1; iCount <= iTeams; iCount++)
            {
                Console.Write("\nEnter Team " + iCount + "'s name: ");
                userInput = Console.ReadLine();
                teamName = UpperCaseFirst(userInput);

                Console.Write("Enter " + teamName + "'s points: ");
                iPoints = Convert.ToInt32(Console.ReadLine());

                //create SoccerTeam object and add to list
                TeamsList.Add(new SoccerTeam(teamName, iPoints));

            }

            //sort list by points
            List<SoccerTeam> sortedTeams = TeamsList.OrderByDescending(team => team.name).ToList();

            //output results
            Console.WriteLine("\nHere is the sorted list: \n");
            Console.Write("Position".PadRight(15, ' ') + "Name".PadRight(25, ' ') + "Points\n");
            Console.Write("--------".PadRight(15, ' ') + "----".PadRight(25, ' ') + "------\n");

            foreach(SoccerTeam team in sortedTeams){
                string sPosition = Convert.ToString(iPosition);
                string sPoints = Convert.ToString(team.points);
                Console.Write(sPosition.PadRight(15, ' ') + team.name.PadRight(25, ' ') + sPoints);
                iPosition++;
            }
            Console.ReadKey();
        }
    }
}
