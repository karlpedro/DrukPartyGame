using UnityEngine;
using System.Collections.Generic;


//Never have i ever questions, used for textoutputs.
public class NeverHave : MonoBehaviour
{
    private List<string> questions;
    private List<string> usedQuestions;

    void Start()
    {
        InitializeNeverHave();
        usedQuestions = new List<string>();
        Debug.Log("NeverHave list length: " + questions.Count);
    }

    private void InitializeNeverHave()
    {
        questions = new List<string>
        {
            "Jeg har aldrig: set mit eget røvhul",
            "Jeg har aldrig: Set mine forældre have sex",
            "Jeg har aldrig: kommet til skade under sex",
            "Jeg har aldrig: haft en trekant",
            "Jeg har aldrig: lavet en der har en kæreste",
            "Jeg har aldrig: liked et billede ved en fejl, da jeg tjekkede persones profil ud",
            "Jeg har aldrig: haft sex et offentligt sted",
            "Jeg har aldrig: spist en bussemand",
            "Jeg har aldrig: taget en graviditetstest",
            "Jeg har aldrig: givet et falsk telefonnummer",
            "Jeg har aldrig: været jalloux på nogle i dette rum",
            "Jeg har aldrig: fortrudt at have snavet med en person",
            "Jeg har aldrig: haft noget i røven",
            "Jeg har aldrig: googlet mig selv",
            "Jeg har aldrig: blackouted",
            "Jeg har aldrig: kastet op på en ven",
            "Jeg har aldrig: kastet op i offentligt transport",
            "Jeg har aldrig: faldet i søvn udendørs efter en bytur",
            "Jeg har aldrig: stalket en i dette rum",
            "Jeg har aldrig: haft sex hjemme hos en ven",
            "Jeg har aldrig: givet oralsex",
            "Jeg har aldrig: gemt en pornovideo, for kunne finde den igen",
            "Jeg har aldrig: haft håndjern på",
            "Jeg har aldrig: sagt jeg elsker dig, men løjet",
            "Jeg har aldrig: faked en orgasme",
            "Jeg har aldrig: mødt på arbejde fuld",
            "Jeg har aldrig: filmet mig selv have sex",
            "Jeg har aldrig: betalt for sex",
            "Jeg har aldrig: snavet med en person der over 10 år ældre",
            "Jeg har aldrig: snavet med mere end 1 på en aften",
            "Jeg har aldrig: puttet noget i en andens drink",
            "Jeg har aldrig: røget hash",
            "Jeg har aldrig: taget stærke stoffer",
            "Jeg har aldrig: ødelagt en seng",
            "Jeg har aldrig: set gay porno",
            "Jeg har aldrig: tænk på noget klamt, for at holde længere under sex",
            "Jeg har aldrig: snavet med en kollega",
            "Jeg har aldrig: haft sex med en ex (efter breakup)",
            "Jeg har aldrig: kysset med personen der læser dette op",
            "Jeg har aldrig: brugt sex legetøj",
            "Jeg har aldrig: haft en god samtale med "+ PlayerLogic.FirstPlayer(),

        };
    }

    public string GetRandNeverHave()
    {
        if (questions.Count == 0)
        {
            Debug.LogWarning("No more questions available.");
            ResetNeverHave();
        }

        int randIndex = Random.Range(0, questions.Count);
        string selectedQuestion = questions[randIndex];

        // Add the question to the used list and remove it from the available list
        usedQuestions.Add(selectedQuestion);
        questions.RemoveAt(randIndex);

        return selectedQuestion;
    }

    public void ResetNeverHave()
    {
        // Reset the questions list by adding all used questions back
        questions.AddRange(usedQuestions);
        usedQuestions.Clear();
    }
}
