using Console_Application_1;
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
        
        //create list of games for each team
        List<Game> myGames = new List<Game>();
       
        //create constructor to receive  the name and points values
        public SoccerTeam (string name, int points){
            this.name = name;
            this.points = points;
        }

        //default constructor
        public SoccerTeam(){

        }

        public void addGame(string hometeam, string awayteam, string winner){
            myGames.Add(new Game(hometeam, awayteam, winner));
        }

    }

    //create game class that is an attribute of SoccerTeam
    private class Game
    {
        private int homePoints;
        private int awayPoints;
        private string winner;
        private string sHomeTeam;
        private string sAwayTeam;

        //constructor
        public Game(string hometeam, string awayteam, string winner){
            this.sHomeTeam = hometeam;
            this.sAwayTeam = awayteam;
            this.winner = winner;
        }

        //default constructor
        public Game(){

        }
    }

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
            int iNumofTeams = 0;
            string userInput, teamName;
            int iPoints;
            int iPosition = 1;
            bool isValid = false;
            string sSimulateGame;
            
            //run for loop to catch an invalid entries
            for (isValid = false; isValid == false;)
            {
                try
                {
                    //prompt user for input and convert int to string
                    Console.Write("How many teams? ");
                    iNumofTeams = Convert.ToInt32(Console.ReadLine());
                    isValid = true;
                }
                catch
                {
                    Console.WriteLine("\nPlease enter a valid integer.\n");
                    isValid = false;
                }
                finally
                {

                }
            }

            //create soccer teams list
            List<SoccerTeam> TeamsList = new List<SoccerTeam>();

            //prompt user for team names and create soccer team objects
            for (int iCount = 1; iCount <= iNumofTeams; iCount++)
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
                Console.Write("\n" + sPosition.PadRight(15, ' ') + team.name.PadRight(25, ' ') + sPoints);
                iPosition++;
            }

            //implement game class by running simulator
            Console.Write("\n\nWould you like to simulate a game? (y/n) ");
            sSimulateGame = Console.ReadLine();

            while(sSimulateGame.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("\nTeam List\n");
                Console.Write("---------\n");

                //display list of teams
                for (int iCount = 0; iCount < TeamsList.Count; iCount++) {
                    Console.WriteLine((iCount + 1) + "   " + TeamsList[iCount].name);
                }

                Console.Write("\nSelect Team 1: ");
                int iHomeTeam = Convert.ToInt32(Console.ReadLine());
                string HomeTeamName = TeamsList[(iHomeTeam)].name;

                Console.Write("\nSelect Team 2: ");
                int iAwayTeam = Convert.ToInt32(Console.ReadLine());
                string AwayTeamName = TeamsList[(iAwayTeam)].name;
               
                //create random number and generate score
                Random rndScore = new Random();

                int homePoints = rndScore.Next(0,10);
                int awayPoints = rndScore.Next(0,10);
                string winner;

                    // determine winner
                    if(homePoints >= awayPoints){
                        winner = HomeTeamName;
                    }
                    else{
                        winner = AwayTeamName;
                    }

                //create game object with selected teams my calling the add game method
                TeamsList[(iHomeTeam-1)].addGame(HomeTeamName, AwayTeamName, winner);
                TeamsList[(iAwayTeam-1)].addGame(HomeTeamName, AwayTeamName, winner);

                TeamsList[(iHomeTeam-1)].GetType(Game)
            }
            Console.ReadKey();
        }
    }
}
