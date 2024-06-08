using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class TextOutputs : MonoBehaviour
{   
    private List<Card> textList = null;
    public TextMeshProUGUI textListCount;
    public TextMeshProUGUI textMeshProText;
    List<Card> newTextList;
    public CardEffects cardEffects;
    private int textListTotalSize = 0;
    public void ChangeText()
    {
        if(textList == null || textList.Count <= 0) {
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

    private List<Card> StartText() {
        UnityEngine.Debug.Log("New list created");
        newTextList = new List<Card>();

        AddCards(
            // Alle drikker
            "Drik hvis du var fuld igår",
            "Alle drikker 2 tårer",
            "SKÅL!!",
            "DrengeSkål",
            "Dame Skål",
            "Drik for hvert forhold man har haft",
            "Drik for hver toilet tur du har været på den sidste time",
            "Drik hvis du har haft sex, med mere end 2 denne uge",
            PlayerLogic.FirstPlayer() + " vælger hvem har grimmere tøj på end " + PlayerLogic.SecondPlayer() + ", de drikker 3 tårer",
            PlayerLogic.FirstPlayer() + ", giv 1 tår ud for hver spiller.",
            PlayerLogic.FirstPlayer() + " nævn en accessory (ring, ur, bælte, halskæde..), alle med det nævnte drikker",
            "Drik hvis foretrækker bade om morgenen, istedet for aften",
            "Spillere med under 50% strøm, drikker 3 tårer",
            "Drik hvis du har set porno idag",
            "Drik hvis du har et kondom på dig lige nu",
            "Alle der drikker øl skåler",
            "Drik hvis du har prøvet hårde stoffer",
            "Drik hvis du røget en smøg denne uge",
            "Drik hvis du har prøvet ryge hash",
            "Drik hvis du har prøvet stjæle noget",
            "Drik hvis du har prøvet drikke før kl 12",
            "Drik hvis du har haft sex et offentligt sted",
            "Drik hvis du har været fuld på arbejde",
            "Drik hvis du har været fuld i skole",
            "Drik hvis du har badet i et springvand",
            "Drik hvis du har skinnydippet",
            "Drik hvis du fik 12 i en studenterhue, giv 2 tårer hvis du aldrig har fået en",
            "Drik hvis du har kysset en i dette rum",
            "Drik hvis du har en datingapp installeret lige nu",
            "Drik hvis du har haft en kønssygdom",
            "Drik hvis du har haft sex, med andre i rummet",
            "Drik hvis du har sendt et nude",
            "Drik hvis du har blackouted",
            "Drik hvis du har arbejdet i et supermarked",
            "Drik hvis du har brugt pisk under sex",
            "Drik hvis du har sneget dig in på klub som mindreårig",
            "Drik hvis du har løjet om din alder",
            "Drik vis du blevet stoppet af politiet",
            "Drik hvis du har en story/bereal på sociale medier lige nu",
            "Drik hvis du mere til katte end hunde",
            "Drik hvis du har sko på, sutsko tæller",
            "Drik hvis du skal arbejde i morgen, du kan bare melde dig syg ;)",
            "Færdigør din drink, hvis du har drukket mindre end 3 genstande siden spillet startede",


            //Enkelt person drikker
            "Højeste person drikker",
            "Laveste person drikker",
            "Bedste tøjstil drikker",
            "Sidste person med fingeren på næsen drikker 5 tårer",
            "Drik for hver tatovering eller piercing du har",
            "Sidste person/personer der havde sex, drikker",
            "Sidste person med panden mod bordet drikker",
            "Sidste person som står op drikker",
            "Sidste person med finger på næsen drikker",
            "Sidste person med hænderne på hovedet drikker",
            "Sidste person der holder på deres bryst drikker",
            "De 2 yngste spillere drikker",
            "De 3 ældste spillere drikker",
            "Næste person der får tårer, må også give 5 ud",
            "Drik hvis du har en iphone",
            "Personen med mest væske i deres drink/øl drikker 5 tårer",
            "Alle stem på personen som sidder mest på sin telefon i dette spil. \"vinderen\" drikker 5 tårer. Spiltelefonen tæller ikke ;)",
            PlayerLogic.FirstPlayer() + " har sniper næste 2 min. (Tæl højlydt mens du kigger på en person, de skal sige STOP, og drikke det antal tårer)",
            PlayerLogic.FirstPlayer() + " med flest instagram followers drikker",
            PlayerLogic.FirstPlayer() + " vælger en at drikke 4 tårer med",
            PlayerLogic.FirstPlayer() + " drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " stirrerkonkurrence mod " + PlayerLogic.SecondPlayer()+ ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " drik for hvert glas der står på bordet",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + " drikker 5 tårer",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + " laver sten, saks, papir om en bunder",
            PlayerLogic.FirstPlayer() + " drikker X antal tårer. Personen til højre drikker 1 tår mindre, dette fortsætter til højre indtil 0 tårer.",
            PlayerLogic.FirstPlayer() +" hvem ville du stole på hjælpe dig med et mord, drik 3 tårer med personen",
            PlayerLogic.FirstPlayer() + " skål med den du tror bliver gift tidligst",
            PlayerLogic.FirstPlayer() + " gæt farven på "+ PlayerLogic.SecondPlayer() + "s undertøj. Giv 3 tårer ud, hvis du gætter, ellers drik dem selv",
            PlayerLogic.FirstPlayer() + " sig den hotteste feature om hver spiller, eller drik 5 tårer",
            PlayerLogic.FirstPlayer() + " fortæl en ting du kan lide ved "+ PlayerLogic.SecondPlayer()+" eller drik 3 tårer",
            PlayerLogic.FirstPlayer() + " skål med den der vil tage sig af dig, hvis du drikker for meget idag",
            PlayerLogic.FirstPlayer()+ " og " + PlayerLogic.SecondPlayer() + ". Tommefingerkrig. Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " giv en konsekves til "+ PlayerLogic.SecondPlayer()+ ". bund redder",
            PlayerLogic.FirstPlayer() + " slap "+ PlayerLogic.SecondPlayer()+ ". Han kan drikke 5 tårer, hvis han er for bange",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + ". Sammenlign sko. Alle stemmer på de grimmeste sko, den person drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + ". Sammenlign bukser. Alle stemmer på de grimmeste bukser, den person drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " lav 20 squats eller drik 3 tårer",
            PlayerLogic.FirstPlayer() + " drik hvis du ikke vaskede hænder sidst du tissede, giv 2 tårer hvis du gjorde",
            PlayerLogic.FirstPlayer() + " nævn noget spiseligt du elsker. Alle som ikke kan lide det drikker. Hvis ingen kan lide det, drikker du 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror ville være dårligst på skateboard. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror er dårligst til matematik. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror kan score flest. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror fik dårligst karakterer i folkeskolen. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror ville være vildest i sengen. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror ville give dig den bedst datenight. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " vælg hvem du tror kunne smadre den anden person i en fight. " + PlayerLogic.SecondPlayer() +" eller " + PlayerLogic.ThirdPlayer() + ". Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " har 2 min til at få en person til at grine eller smile. Hvis det lykkedes, drikker personen 3 tårer, ellers drikker du 3 tårer",
            PlayerLogic.FirstPlayer() + " lav 2 personer om til dyr, de skal stirre hinanden i øjnene indtil en griner eller smiler. Taberen drikker 3 tårer",
            PlayerLogic.FirstPlayer() + " du har 3 sekundter til sige antallet personer i dette rum eller drik 3 tårer. 3.. 2 ... 1",
            
            //Most likely
            "Most likely: Få en sugar daddy/mamma",
            "Most likely: Drikke for meget idag",
            "Most likely: I seng før 12",
            "Most likely: Til at bunde, vinderen bunder ;)",
            "Most likely: Blive den strammeste far/mor",
            "Most likely: Tage ud og drikke dagen før en eksamen",
            "Most likely: Blive et bæst når de drikker",
            "Most likely: Vågne op hos politiet i aften",
            "Most likely: Give alkohol til deres 3 årige barn",
            "Most likely: Smadre sin telefon",
            "Most likely: snave med +3 personer iaften",
            "Most likely: Have en stor sex-legetøjs collection derhjemme",
            "Most likely: At løbe ind i en glasdør",
            "Most likely: At blive ved med at tjekke deres telefon, selvom den ikke ringer",
            "Most likely: Blive vred iaften",
            "Most likely: At gifte sig med en narkobaron?",
            "Most likely: At komme for sent til sit eget bryllup?",
            "Most likely: At blive tilbageholdt for at pisse på en politimand?",
            "Most likely: At blive skilt mindre end en uge inde i sit ægteskab?",
            "Most likely: At blive nonne?",
            "Most likely: At få et hjerteanfald af at se en gyserfilm?",
            "Most likely: ville græde over spildt mælk?",
            "Most likely: At prøve en trekant?",
            "Most likely: sprede gossip?",
            "Most likely: At være akavet på første date?",
            "Most likely: At blive indlagt på et psykiatrisk hospital?",
            "Most likely: At deltage i en bande?",
            "Most likely: At elske blive trådt på under sex?",
            "Most likely: Miste sit kældedyr indenfor en uge?",
            "Most likely: At være den bedste løgner?",
            "Most likely: At ende sammen med " + PlayerLogic.FirstPlayer() + " i fremtiden",
            "Most likely: At efterlade " + PlayerLogic.FirstPlayer() + " alene i en rendesten",
            "Most likely: At putte stoffer i " + PlayerLogic.FirstPlayer() + " drink",
            "Most likely: At åbne en sexlegetøjs butik",
            "Most likely: At åbne en sexlegetøjs butik",
            "Most likely: At spille russisk roulette for 100.000kr",
            "Most likely: At give et blowjob på et gadetoilet for 50kr",
            "Most likely: At have sex med et familiemedlem",
            "Most likely: At stoppe et toilet",
            "Most likely: At blive en komiker",
            "Most Likely: At lave en porno derhjemme",
            "Most likely: ikke komme ind nogle stedet i aften, fordi de for fulde",
            "Most likely: Blive en lummer satan når han/hun bliver ældrer",
            "Most likely: Dårlig til lave mad",
            "Most likely: Bruge hele sin opsparing på casino",
            "Most likely: Aflyse sin egen fest på dagen",
            "Most likely: Have den største pik",
            "Most likely: Bæst i sengen",
            "Most likely: Flirte med deres underviser, for ekstra credits",
            "Most likely: Dumpe sin køreprøve 10 gange",

            //Minigames
            "MiniGame: Medusa. Alle holder sig for øjnene og åbner dem samtidig efter 3 sekunder. Alle som får øjenkontakt drikker",
            "MiniGame: Vandfald. " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Ting du kan finde på/i en " + Location() + ". " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Ting du kan finde på/i en " + Location() + ". " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Ting du kan finde på/i en " + Location() + ". " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: værste ting ved en/et " + Location() + ". " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Jeg har aldrig. " + PlayerLogic.FirstPlayer() + " starter",
            "MiniGame: Back 2 Back. " + PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer()+ ". Til 3 rigtige i streg",
            "MiniGame: Back 2 Back. " + PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer()+ ". Til 3 rigtige i streg",
            "MiniGame: Two Truths and a Lie. " + PlayerLogic.FirstPlayer() + " fortæl 2 sandheder og en løgn. Alle skal gætte løgnen, taberne drikker",
            "MiniGame: Two Truths and a Lie. " + PlayerLogic.FirstPlayer() + " fortæl 2 sandheder og en løgn. Alle skal gætte løgnen, taberne drikker",
            "MiniGame: "+ PlayerLogic.FirstPlayer() +", tænk på en frugt du ville putte i røven. Første som gætter, må give 3 tårer. "+ PlayerLogic.SecondPlayer() +" starter",
            "MiniGame: Kategori. "+ PlayerLogic.FirstPlayer()+ " find på en kategori. Fejl eller gentagelser drikker 3 tårer",
            "MiniGame: Kategori. "+ PlayerLogic.FirstPlayer()+ " find på en kategori. Fejl eller gentagelser drikker 3 tårer",
            "MiniGame: DrengeNavne. "+ PlayerLogic.FirstPlayer() + " starter siger et drengenavn der starter med A, næste person skal fortsætte med et drengenavn med samme forbogstav, som det sidste navn sluttede på. Fortsæt til en fejler, straf: 3 tårer",
            "MiniGame: Hot Seat." + PlayerLogic.FirstPlayer()+ " bliver stillet et spørgsål fra hver person. og skal svarer sandt indenfor 3 sekundter. Fejl/afvisning resulterer 1 tår.",
            "MiniGame: Alle nævner en drikkevarer der starter med det næste forbogstav i alfabetet. " + PlayerLogic.FirstPlayer() + " Starter med A",
            "MiniGame: Gæt en coctail. " + PlayerLogic.FirstPlayer()+ " tænker på en drink. Hver spiller stiller et ja/nej spørgsmål. Nej giver 1 tår." +PlayerLogic.SecondPlayer() + " starter",
            "MiniGame: Fuck, Marry, Kill. "+ PlayerLogic.FirstPlayer()+ " kom med 3 fiktive personer. " + PlayerLogic.SecondPlayer() + " skal vælge fuck marry kill blandt dem",
            "MiniGame: Fuck, Marry, Kill. "+ PlayerLogic.FirstPlayer()+ " kom med 3 ægte personer. " + PlayerLogic.SecondPlayer() + " skal vælge fuck marry kill blandt dem",
            "MiniGame: 20 spørgsmål. " + PlayerLogic.FirstPlayer() + " tænker på en person eller ting. De andre spillere har 20 spørgsmål til at gætte hvad det er.",

            //Giv tårer ud
            "Første spiller der kan finde et trekantet objekt i rummet, må give 5 tårer",
            "Første spiller der kan finde et objekt, som kunne bruges som en penis i rummet, må give 3 tårer",
            "Første spiller der kan finde et rundt objekt i rummet, må give 3 tårer",
            "Første spiller som kan vise 100kr kontant, må give en bunder ud",
            "Første spiller som mobilpayer oplæser 10kr, må give en bunder",
            "Giv 2 tårer, hvis du ikke har noget imod betale for sex",
            "Giv 2 tårer, hvis du har tabt en telefon i toilettet før",
            "Giv 2 tårer hvis du har glemt børste tænder idag",
            PlayerLogic.FirstPlayer() + " og " + PlayerLogic.SecondPlayer() + " skal blive enige om en spiller som skal drikke 3 tårer",
            PlayerLogic.FirstPlayer() + " nyn en selvvalgt sang, første spiller som kan gætte den må give 3 tårer ud",
            PlayerLogic.FirstPlayer() + " du vælger selv hvor mange tårer " + PlayerLogic.SecondPlayer() + " drikker",
            PlayerLogic.FirstPlayer() + " du vælger selv hvor mange tårer " + PlayerLogic.SecondPlayer() + " og " + PlayerLogic.ThirdPlayer() + " drikker",
            PlayerLogic.FirstPlayer() + " giv 5 tårer ud",
            PlayerLogic.FirstPlayer() + " giv 3 tårer ud",
            PlayerLogic.FirstPlayer() + " giv 4 tårer til en som er laver end dig, hvis der ikke er nogen, drikker du dem selv",
            PlayerLogic.FirstPlayer() + " giv 4 tårer til en som er højere end dig, hvis der ikke er nogen, drikker du dem selv",
            PlayerLogic.FirstPlayer() + " giv 3 tårer til den hotteste, du kan godt vælge dig selv, lille svin",
            "Giv 3 tårer ud, hvis du har boet i et andet land end du blev født i",
            PlayerLogic.FirstPlayer() + " nævn navne på personer som " + PlayerLogic.SecondPlayer() + " har været i seng med. Giv det antal tårer. Hvis du ikke kan en, drik 4",
            PlayerLogic.FirstPlayer()+ " og " + PlayerLogic.SecondPlayer() + " skal give en overdreven imitering af "+ PlayerLogic.ThirdPlayer()+ ". Resten bedømmer, vinderen giver 5 tårer",
            "giv 3 tårer, hvis du kan slikke din albue",
            PlayerLogic.FirstPlayer() + " hvem ville du fortrække organiserede din næste rejse" + PlayerLogic.SecondPlayer()+ " eller " + PlayerLogic.ThirdPlayer() + " vinderen giver 3 tårer ud",
            PlayerLogic.FirstPlayer() + " giv en tår for hver A i dit fulde navn. Drik for hver E",

            //Extra
            PlayerLogic.FirstPlayer() + " Vælg en drinking buddy, i begge drikker alle tårer sammen",
            PlayerLogic.FirstPlayer() + " du spillets bitch. Hent drinks of snacks til folk, indtil en ny bitch bliver udvalgt.",
            PlayerLogic.FirstPlayer() + " du spillets bitch. Hent drinks of snacks til folk, indtil en ny bitch bliver udvalgt.",
            PlayerLogic.FirstPlayer() + " du spillets bitch. Hent drinks of snacks til folk, indtil en ny bitch bliver udvalgt.",
            PlayerLogic.FirstPlayer() + " og "+ PlayerLogic.SecondPlayer()+ " er drinkin buddies, i begge drikker alle tårer sammen"

        );

        AddCardsWithEffect(
            (PlayerLogic.FirstPlayer() + " er kongen i 20 rundter. Deres ord er lov", CardEffectType.BecomeKing, PlayerLogic.getLastPlayer()), 
            (PlayerLogic.FirstPlayer() + " er kongen i 20 rundter. Deres ord er lov", CardEffectType.BecomeKing, PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " er træmand i 20 rundter. Hver gang nogle skåler med træmand, drikker træmand med", CardEffectType.BecomeTramand, PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " er træmand i 20 rundter. Hver gang nogle skåler med træmand, drikker træmand med", CardEffectType.BecomeTramand, PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " Lav en regel, eller fjerne en regel", CardEffectType.MakeRule , PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " Lav en regel, eller fjerne en regel", CardEffectType.MakeRule , PlayerLogic.getLastPlayer()),
            (PlayerLogic.FirstPlayer() + " Lav en regel, eller fjerne en regel", CardEffectType.MakeRule , PlayerLogic.getLastPlayer())
        );
        textListTotalSize = newTextList.Count;
        textListCount.gameObject.SetActive(true);
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
            newTextList.Add(new Card(description, effectType, extraString));
        }
    }

}

