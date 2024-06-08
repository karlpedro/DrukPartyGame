using UnityEngine;

public class PlayerLogic
{
    private static Player[] players;
    public static int numberOfPlayers;
    private static int rand;
    private static int secRand;
    private static string lastPlayer;

    public static Player[] getPlayers() {
        return players;
    }
    public static Player getPlayerWithName(string name) {
        Player tempPlayer = null;
        if(name!=null) {
            for(var i = 0; i < players.Length; i++) {
                if(name.Equals(players[i].GetName())) {
                    tempPlayer = players[i];
                    break; 
                }
            }
        }
        return tempPlayer;
    }
    public static string FirstPlayer()
    {
        rand = Random.Range(0, players.Length);
        string playerName = players[rand].GetName();
        lastPlayer = players[rand].GetName();
        return playerName;
    }

    public static string SecondPlayer()
    {
        secRand = rand;
        while (secRand == rand)
        {
            secRand = Random.Range(0, players.Length);
        }
        string playerName = players[secRand].GetName();
        return playerName;
    }

    public static string ThirdPlayer()
    {
        string playerName = "NULL";
        if (numberOfPlayers > 2)
        {
            int thirdRand = rand;
            while (thirdRand == rand || thirdRand == rand)
            {
                thirdRand = Random.Range(0, players.Length);
            }
            playerName = players[thirdRand].GetName();
            return playerName;
        }
        return playerName;
    }

    public static string getLastPlayer(){
        return lastPlayer;;
    }

    public static void InitiatePlayers(int number)
    {
        numberOfPlayers = number;
        players = new Player[number];
    }

    public static void AddPlayer(string name)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == null && i < numberOfPlayers)
            {
                players[i] = new Player(name, 0);
                return;
            }
        }
    }
}
