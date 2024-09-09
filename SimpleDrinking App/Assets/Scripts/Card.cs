public class Card {
    string text;
    Card[] allCards = new Card[13];
    CardEffectType effectType;
    string effectString;

    public Card(string text, CardEffectType effect, string effectString) {
        this.text = text;
        this.effectType = effect;
        this.effectString = effectString;
    }

    public string GetText() {
        return this.text;
    }

    public CardEffectType GetEffectType()
    {
        return this.effectType;
    }
    public string getEffectString() {
        return this.effectString;
    }

}

public enum CardEffectType
{
    None,
    BecomeKing,
    LoseKing,
    BecomeTramand,
    MakeRule,
    NeverHave,
    Reset
}