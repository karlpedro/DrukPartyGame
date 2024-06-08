public class Player
{
    private string playerName;
    private int points;
    private bool isKing;
    private bool isMand;

    public Player(string name, int points)
    {
        this.playerName = name;
        this.points = points;
        this.isKing = false;
        this.isMand = false;
    }

    public string GetName()
    {
        return this.playerName;
    }

    public int GetPoints()
    {
        return this.points;
    }

    public void AddPoints(int value)
    {
        this.points += value;
    }
    public void SetKing(bool boolean) {
        this.isKing = boolean;
    }
    public bool IsKing(bool boolean) {
        return this.isKing;
    }

    public void SetMand(bool boolean) {
        this.isMand = boolean;
    }
    public bool IsMmand(bool boolean) {
        return this.isMand;
    }
}
