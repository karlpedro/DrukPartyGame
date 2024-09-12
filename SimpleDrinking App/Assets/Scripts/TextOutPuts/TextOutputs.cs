using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class TextOutputs : MonoBehaviour
{   
    private List<Card> textList = null;
    public TextMeshProUGUI textListCount;
    public TextMeshProUGUI textMeshProText;
    List<Card> newTextList;
    public CardEffects cardEffects;
    private int textListTotalSize = 0;
    public MostLikely mostLikely;
    public NeverHave neverHave;

    public GameOverLogic gameOverLogic;
    public void ChangeText()
    {
        if(textList == null) {
            textList = StartText();
        }
        else if (textList.Count == 0)
        {   
            gameOverLogic.TriggerGameOver();
            textList = StartText();
        }

        int rand = Random.Range(0, textList.Count);
        Debug.Log("textlist count: "+textList.Count);
        textListCount.text = textList.Count.ToString()+ "/"+ textListTotalSize;
        Card tempCard = textList[rand];
        cardEffects.ApplyEffect(tempCard.GetEffectType(), tempCard.getEffectString());
        textMeshProText.text = tempCard.GetText();
        textList.RemoveAt(rand);

    }

    private void ShuffleDeck(List<Card> deck)
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            // Swap the cards
            Card temp = deck[i];
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }

    private List<Card> StartText() {
        UnityEngine.Debug.Log("New list created");
        newTextList = new List<Card>();

        AddCards(
            // Alle drikker
            "Drik hvis du var fuld igår",
            "Alle drikker 2 tårer",
            "SKÅL!!",
            "DrengeSkål",
            "DrengeSkål",
            "Dame Skål",
            "Dame Skål",
            "Drik for hvert forhold man har haft",
            "Drik for hver toilet tur du har været på den sidste time",
            "Drik hvis du har haft sex, med mere end 2 denne uge",
            PlayerLogic.FirstPlayer() + " vælger hvem har grimmere tøj på end " + PlayerLogic.SecondPlayer() + ", de drikker 3 tårer",
            PlayerLogic.FirstPlayer() + ", giv 1 tår ud for hver spiller.",
            PlayerLogic.FirstPlayer() + " nævn en accessory (ring, ur, bælte, halskæde..), alle med det nævnte drikker",
            "Spillere med under 50% strøm, drikker 3 tårer",
            "Alle som har set porno idag",
            "Alle med et kondom på sig drikker",
            "Alle der drikker øl skåler",
            "Alle der har røget denne uge drikker",
            "Alle som har snavet en i dette rum drikker",
            "Alle med en datingapp instalerret drikker",
            "Alle med sko på drikker",
            "Alle med læbestift på, drik 4 tårer",
            "Færdigør din drink, hvis du har drukket mindre end 2 genstande siden spillet startede",
            "Alle hvis drink indeholder vodka eller rom, drikker 4 tårer",
            "Alle drikker en tår, for hver stykke sort tøj de har på",
            "Alle med t-shirt på, giv en tår ud",
            "Alle under 160cm drikker",
            "Alle som har faldet i søvn i offentligt tranport under en brandert drikker",
            "Alle som har prøvet farve deres hår drikker 3 tårer",
            "Alle som har været i fitten denne uger drikker 2 tårer",
            "Alle født i samme måned som " + PlayerLogic.FirstPlayer() + " drikker 3 tårer",
            "Alle brunetter drikker",
            "ALle som stod op efter kl 8 idag drikker",
            "Alle singler drikker",
            "Alle som ikke har festet denne måned, drikker 3 tårer",
            
        
            //Enkelt person drikker
            "Højeste person drikker",
            "Laveste person drikker",
            "Sidste person med fingeren på næsen drikker 5 tårer",
            "Drik for hver tatovering eller piercing du har",
            "Sidste person med panden mod bordet drikker",
            "Sidste person som står op drikker",
            "Sidste person med finger på næsen drikker",
            "Sidste person med hænderne på hovedet drikker",
            "Sidste person der holder på deres bryst drikker",
            "De 2 yngste spillere drikker",
            "De 3 ældste spillere drikker",
            "Næste person der får en tår, må også give 5 ud",
            "Drik hvis du har en iphone",
            "Personen med mest væske i deres drink/øl drikker 5 tårer",
            "Sidste person som ankom til festen, drikker 4 tårer",
            "Alle stem på personen som sidder mest på sin telefon i dette spil. \"vinderen\" drikker 5 tårer. Spiltelefonen tæller ikke ;)",
            PlayerLogic.FirstPlayer() + " har sniper næste 2 min. (Tæl højlydt mens du kigger på en person, de skal sige STOP, og drikke det antal tårer)",
            PlayerLogic.FirstPlayer() + " vis de sidste 5 billeder på din kamerarulle, eller drik 5 tårer",
            PlayerLogic.FirstPlayer() + " vælger en at drikke 4 tårer med",
            PlayerLogic.FirstPlayer() + " drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " stirrerkonkurrence mod " + PlayerLogic.SecondPlayer()+ ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " drik for hvert glas der står på bordet",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + " drikker 5 tårer",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + " laver sten, saks, papir om en bunder",
            PlayerLogic.FirstPlayer() + " drikker X antal tårer. Personen til højre drikker 1 tår mindre, dette fortsætter til højre indtil 0 tårer.",
            PlayerLogic.FirstPlayer() + " gæt farven på "+ PlayerLogic.SecondPlayer() + "s undertøj. Giv 3 tårer, hvis du gætter, ellers drik dem selv",
            PlayerLogic.FirstPlayer() + " skål med den der vil tage sig af dig, når du har drukket for meget i dag",
            PlayerLogic.FirstPlayer()+ " og " + PlayerLogic.SecondPlayer() + ". Tommefingerkrig. Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer()+ " nævn " + PlayerLogic.SecondPlayer() + " fødseldag eller drik 3 tårer",
            PlayerLogic.FirstPlayer() + " giv en konsekves til "+ PlayerLogic.SecondPlayer()+ ". bund redder",
            PlayerLogic.FirstPlayer() + " slap "+ PlayerLogic.SecondPlayer()+ ". Han kan drikke 5 tårer, hvis han er for bange",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + ". Sammenlign sko. Alle stemmer på de grimmeste sko, den person drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " lav 20 squats eller drik 4 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror ville være vildest i sengen. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror ville give dig det bedste blowjob. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror kunne smadre den anden person i en fight. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " har 2 min til at få en person til at grine eller smile. Hvis det lykkedes, drikker personen 3 tårer, ellers drikker du 3 tårer",
            PlayerLogic.FirstPlayer() + " lav 2 personer om til dyr, de skal stirre hinanden i øjnene indtil en griner eller smiler. Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " du har 3 sekundter til sige antallet personer i dette rum eller drik 3 tårer. 3.. 2 ... 1",
            PlayerLogic.FirstPlayer() + " drik så mange tårer du har lyst. " + PlayerLogic.SecondPlayer() + " drikker det dobbelte",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + ". Den af jer med flest søskene, må give difference i tårer til den anden",
            "Sidste person som slog op med en kæreste, drikker 2 tårer",
            "Den som har larmet mest dette spil drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " drej rundt om dig selv 10 gange, eller drik 4 tårer",
            PlayerLogic.FirstPlayer() + " fortæl en pinlig historie fra en brandert, eller drik 3 tårer",
            PlayerLogic.FirstPlayer() + " hvis du forskellige typer alkohol idag, drik 3 tårer",
            PlayerLogic.FirstPlayer() + " fortæl det mærkeligste sted du har vågnet op efter en fest",
            PlayerLogic.FirstPlayer() + " drik en tår, for hver person født samme år som dig",
            PlayerLogic.FirstPlayer() + " tag 3 tårer hvis du ikke kan spille noget musik instrument",
            PlayerLogic.FirstPlayer() + " skål med din bedste ven i gruppen",
            PlayerLogic.FirstPlayer() + " skål med den du taler mindst i gruppen",
            "Alle spillere som kan få toppen af et glas i deres mund, må give 2 tårer ud",
            "Næste person som griner, drikker 3 tårer. Folk må gerne sabotere",
            

            //Oplæser
            "Personen til højre fra oplæser, må give 2 tårer",
            "Personen til venstre fra oplæser, må give 2 tårer",
            "Personen til højre fra oplæser, drikker 2 tårer",
            "Personen til venstre fra oplæser, drikker 2 tårer",
            "Oplæseren drikker 3 tårer",
            "Oplæseren drikker 3 tårer",
            "Oplæseren må give 3 tårer",
            "Oplæseren må give 3 tårer",
            "Første person som får øjenkontakt med oplæser, drikker 3 tårer",
            "Alle født samme år som oplæser drikker",
            "Oplæser trækker et nyt kort, han må frit ændre personer eller vælge personer på dette kort",
            "Oplæser trækker et nyt kort, han må frit ændre personer eller vælge personer på dette kort",
            "Oplæseren drik 3 tårer, og træk et nyt kort",
            "Oplæseren drik 3 tårer, og træk et nyt kort",
            "Oplæseren drik 3 tårer, spillet skifter retning",
            "Oplæseren drik 3 tårer, spillet skifter retning",
            "Giv telefonen til en valgfri person",
            "Oplæseren drik 2 tårer. Giv derefter telefonen til en valgfri person",
            "Oplæseren drik 2 tårer. Giv derefter telefonen til en valgfri person",
            "Første person som highfiver oplæser, drikker 3 tårer",
            "Første person som kysser oplæsers kind, må give 5 tårer",
            "Næster oplæser bliver skippet, og bunder ud",
            "Oplæser trækker et nyt kort, tårer på næste kort giver dobbelt",
            "Oplæser trækker et nyt kort, tårer på næste kort giver dobbelt",



            

            //Minigames
            "MiniGame: Medusa. Alle holder sig for øjnene og åbner dem samtidig efter 3 sekunder. Alle som får øjenkontakt drikker",
            "MiniGame: Vandfald. " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Jeg har aldrig. " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Back 2 Back. " + PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer()+ ". Til 3 rigtige i streg",
            "MiniGame: Two Truths and a Lie. " + PlayerLogic.FirstPlayer() + " fortæl 2 sandheder og en løgn. Alle skal gætte løgnen, taberne drikker",
            "MiniGame: Røvfrugt. "+ PlayerLogic.FirstPlayer() +", tænk på en frugt du ville putte i røven. Første som gætter, må give 3 tårer. "+ PlayerLogic.SecondPlayer() +" starter",
            "MiniGame: Kategori. "+ PlayerLogic.FirstPlayer()+ " find på en kategori. Fejl eller gentagelser drikker 3 tårer",
            "MiniGame: Kategori. "+ PlayerLogic.FirstPlayer()+ " find på en kategori. Fejl eller gentagelser drikker 3 tårer",
            "MiniGame: DrengeNavne. "+ PlayerLogic.FirstPlayer() + " starter siger et drengenavn der starter med A, næste person skal fortsætte med et drengenavn med samme forbogstav, som det sidste navn sluttede på. Fortsæt til en fejler, straf: 3 tårer",
            "MiniGame: Alle nævner en drikkevarer der starter med det næste forbogstav i alfabetet. " + PlayerLogic.FirstPlayer() + " Starter med A",
            "MiniGame: Gæt en coctail. " + PlayerLogic.FirstPlayer()+ " tænker på en drink. Hver spiller stiller et ja/nej spørgsmål. Nej giver 1 tår." +PlayerLogic.SecondPlayer() + " starter",
            "MiniGame: Fuck, Marry, Kill. "+ PlayerLogic.FirstPlayer()+ " kom med 3 fiktive personer. " + PlayerLogic.SecondPlayer() + " skal vælge fuck marry kill blandt dem",
            "MiniGame: Fuck, Marry, Kill. "+ PlayerLogic.FirstPlayer()+ " kom med 3 ægte personer. " + PlayerLogic.SecondPlayer() + " skal vælge fuck marry kill blandt dem",
            "MiniGame: 20 spørgsmål. " + PlayerLogic.FirstPlayer() + " tænker på en person eller ting. De andre spillere har 20 spørgsmål til at gætte hvad det er.",
            "MiniGame: TIMING. Start et stoppur på 1 min, den person som rammer tættest på 0 sekundter må give 5 tårer, folk som ikke når sige stop drikker 3 tårer",
            "MiniGame: Min Pik er...  Den første som gentager eller er gramatisk ukorrekt drikker 5 tårer. Alle ordene skal have samme forbogstav " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Telefonleg. " + PlayerLogic.FirstPlayer() + " skale viske et ord til venstre sidemand, dette fortsætter rundt. 5 straftårer til alle, hvis sidste person laver fejl",
            "MiniGame: Hobby. " + PlayerLogic.FirstPlayer() + " beskriv en hobby du har haft uden at fortælle hvad det er. Første person som gætter det, må give 3 tårer",
            "MiniGame: Fuld eller Barn. " + PlayerLogic.FirstPlayer() + " fortæl noget du dumt du har gjort. Alle stemmer om du var fuld eller barn. Taberne drikker 3 tårer",
            "MiniGame: Nynne. " + PlayerLogic.FirstPlayer() + " nynner en sang, de andre skal gætte. Første person som gætter, må give 3 tårer",
            "MiniGame: Match Ord. "+ PlayerLogic.FirstPlayer()+ " og " + PlayerLogic.SecondPlayer() + ", vælg en makker hver. Hvert hold skiftes til sige et enkelt ord samtidig. Første hold som siger det samme ord, må give 3 tårer",

            //Giv tårer
            "Første spiller der kan finde et trekantet objekt i rummet, må give 5 tårer",
            "Første spiller der kan finde et objekt, som kunne bruges som en penis i rummet, må give 3 tårer",
            "Første spiller der kan finde et rundt objekt i rummet, må give 3 tårer",
            "Første spiller som kan vise minimum 100kr kontant, må give en bunder ud",
            "Første spiller som mobilpayer telefonens ejer 10kr, må give en bunder",
            "Første spiller som rører ved et rødt objekt, må give 3 tårer",
            "Sidste spiller som rører ved et blåt object, drikker 4 tårer",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() +". Åben en ny øl. Den som kan bunde hurtigst, må give en bunder til en anden spiller i lokalet",
            PlayerLogic.FirstPlayer() + " vælg en spiller som skal tage 3 tårer af din drink, eller de kan tage 6 af deres egen",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + " skal blive enige om en spiller som skal drikke 3 tårer",
            PlayerLogic.FirstPlayer() + " du vælger selv hvor mange tårer " + PlayerLogic.SecondPlayer() + " drikker",
            PlayerLogic.FirstPlayer() + " du vælger selv hvor mange tårer " + PlayerLogic.SecondPlayer() + " og " + PlayerLogic.ThirdPlayer() + " drikker",
            PlayerLogic.FirstPlayer() + " giv 5 tårer",
            PlayerLogic.FirstPlayer() + " giv 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg en som må give 5 tårer",
            PlayerLogic.FirstPlayer() + " giv 4 tårer til en som er laver end dig, hvis der ikke er nogen, drikker du dem selv",
            PlayerLogic.FirstPlayer() + " giv 4 tårer til en som er højere end dig, hvis der ikke er nogen, drikker du dem selv",
            PlayerLogic.FirstPlayer() + " giv 3 tårer til den hotteste, du kan godt vælge dig selv, lille svin",
            PlayerLogic.FirstPlayer() + " nævn navne på personer som " + PlayerLogic.SecondPlayer() + " har været i seng med. Giv det antal tårer. Hvis du ikke kan en, drik 4",
            PlayerLogic.FirstPlayer()+ " og " + PlayerLogic.SecondPlayer() + " skal give en overdreven imitering af "+ PlayerLogic.ThirdPlayer()+ ". Resten bedømmer, vinderen giver 5 tårer",
            "giv 3 tårer, hvis du kan slikke din albue",
            PlayerLogic.FirstPlayer() + " hvem ville du fortrække organiserede din næste rejse" + PlayerLogic.SecondPlayer()+ " eller " + PlayerLogic.ThirdPlayer() + " vinderen må give 3 tårer",
            PlayerLogic.FirstPlayer() + " giv en tår for hver A i dit fulde navn. Drik for hver E",
            PlayerLogic.FirstPlayer() + " hvis du kan få en til tage en fake straf tår dette spil, skal de bunde",
            "Personen som forslog dette spil, må dele 5 tårer",
            PlayerLogic.FirstPlayer() + " vælg en kategori. Alle byder på, hvor mange de kan nævne. Den med det højeste bud skal nævne det antal. Lykkedes: Giv antallet af tårer. fejl: drik dem selv",
            "Alle som har en tattoo kan vise en og give 2 tårer",
            "Første person som tømmer deres glas, må give 5 tårer",
            "Alle som tisser i badet, må give 2 tårer",
            "Spilleren med mindst hår på hovedet, må dete 2 tårer",
            "Alle med hul i sokkerne, må give 3 tårer",
            "Personen som har været single længst, må give 3 tårer",
            "Personen med den længste tunge må give 3 tårer",
            PlayerLogic.FirstPlayer() + " du må give 3 tårer, hvis du kan snakke 3 eller flere sprog",



            //Extra
            PlayerLogic.FirstPlayer() + " vælg en drinking buddy, i begge drikker alle tårer sammen",
            PlayerLogic.FirstPlayer() + " du spillets bitch. Hent drinks of snacks til folk, indtil en ny bitch bliver udvalgt.",
            PlayerLogic.FirstPlayer() + " du spillets bitch. Hent drinks of snacks til folk, indtil en ny bitch bliver udvalgt.",
            PlayerLogic.FirstPlayer() + " du spillets bitch. Hent drinks of snacks til folk, indtil en ny bitch bliver udvalgt.",
            PlayerLogic.FirstPlayer() + " og "+ PlayerLogic.SecondPlayer()+ " er drinkin buddies, i begge drikker alle tårer sammen",
            PlayerLogic.FirstPlayer() + " du drikker 1 tår hver gang nogle får en tår, indtil der kommer et nyt kort med dit navn igen."

        );

        AddCardsWithEffect(

            // Roles
            (PlayerLogic.FirstPlayer() + " er kongen de næste 20 kort. Deres ord er lov", CardEffectType.BecomeKing, PlayerLogic.getLastPlayer()), 
            (PlayerLogic.FirstPlayer() + " er kongen de næste 20 kort. Deres ord er lov", CardEffectType.BecomeKing, PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " er træmand de næste 20 kort. Hver gang nogle skåler med træmand, drikker træmand med", CardEffectType.BecomeTramand, PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " er træmand de næste 20 kort. Hver gang nogle skåler med træmand, drikker træmand med", CardEffectType.BecomeTramand, PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " Lav en regel", CardEffectType.MakeRule , PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " Lav en regel", CardEffectType.MakeRule , PlayerLogic.getLastPlayer())
        );

        AddCardsWithEffect( 
            // Never have i ever
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),
            (neverHave.GetRandNeverHave(), CardEffectType.NeverHave),


            //Most likely
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely),
            (mostLikely.GetRandMostLikely(), CardEffectType.MostLikely)
        );

        textListTotalSize = newTextList.Count;
        textListCount.gameObject.SetActive(true);


        ShuffleDeck(newTextList);
        return newTextList;
    }

    private string Location() {   
        string location = null;
        List<string> newLoc = null;
        if(newLoc==null || newLoc.Count<2) {
            newLoc = new List<string>();
            newLoc.Add("svømmehal");
            newLoc.Add("Camping");
            newLoc.Add("Stripklub");
            newLoc.Add("RoadTrip");
            newLoc.Add("Bodega");
            newLoc.Add("Cafe");
            newLoc.Add("Badeværelse");
            newLoc.Add("Strand");
            newLoc.Add("Bjerg");
            newLoc.Add("Skov");
            newLoc.Add("Parkeringsplads");
            newLoc.Add("Supermarked");
            newLoc.Add("Restaurant");
            newLoc.Add("Biograf");
            newLoc.Add("Museum");
            newLoc.Add("Bibliotek");
            newLoc.Add("Fitnesscenter");
            newLoc.Add("Spillehal");
            newLoc.Add("Teater");
            newLoc.Add("Stadion");
            newLoc.Add("Fodboldbane");
            newLoc.Add("Basketballbane");
            newLoc.Add("Universitet");
            newLoc.Add("Hospital");
            newLoc.Add("Kirke");
            newLoc.Add("Slot");
            newLoc.Add("Mark");
            newLoc.Add("Kontor");
            newLoc.Add("Have");
            newLoc.Add("NonneKloster");
        }

        int rand = Random.Range(0, newLoc.Count); 
        location = newLoc[rand];
        Debug.Log("location: "+location);
        newLoc.RemoveAt(rand);
        return location;
    }

    private void AddCards(params string[] descriptions)
    {
        foreach (string description in descriptions)
        {
            newTextList.Add(new Card(description, CardEffectType.None, null)); // Assuming SomeValue is always 0 for simplicity
        }
    }
    public void AddCardsWithEffect(params (string description, CardEffectType effectType, string extraString)[] cards)
{
    foreach ((string description, CardEffectType effectType, string extraString) in cards)
    {
        // Handle default case
        newTextList.Add(new Card(description, effectType, extraString));
    }
}

    public void AddCardsWithEffect(params (string description, CardEffectType effectType)[] cards)
    {
        // Convert 2-element tuples to 3-element tuples with extraString as null
        var extendedCards = cards.Select(c => (description: c.description, effectType: c.effectType, extraString: (string)null)).ToArray();
        AddCardsWithEffect(extendedCards);
    }


}

