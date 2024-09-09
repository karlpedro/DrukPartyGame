using UnityEngine;
using System.Collections.Generic;

public class MostLikely : MonoBehaviour
{
    private List<string> questions;
    private List<string> usedQuestions;

    void Start()
    {
        InitializeMostLikely();
        usedQuestions = new List<string>();
        Debug.Log("MostLikely list length: " + questions.Count);
    }

    private void InitializeMostLikely()
    {
        questions = new List<string>
        {
            //Most likely
            "Mest tilbøjlig: til drikke for meget idag",
            "Mest tilbøjlig: Til bunde, vinderen bunder ;)",
            "Mest tilbøjlig: til tage ud og drikke dagen før en eksamen",
            "Mest tilbøjlig: til vågne op hos politiet i aften",
            "Mest tilbøjlig: til snave med +3 personer iaften",
            "Mest tilbøjlig: til blive tilbageholdt for at pisse på en politimand?",
            "Mest tilbøjlig: til prøve en trekant?",
            "Mest tilbøjlig: til blive indlagt på et psykiatrisk hospital?",
            "Mest tilbøjlig: til elske blive trådt på under sex?",
            "Mest tilbøjlig: til ende sammen med " + PlayerLogic.FirstPlayer() + " i fremtiden",
            "Mest tilbøjlig: til efterlade " + PlayerLogic.FirstPlayer() + " alene i en rendesten",
            "Mest tilbøjlig: til putte stoffer i " + PlayerLogic.FirstPlayer() + " drink",
            "Mest tilbøjlig: til spille russisk roulette for 100.000kr",
            "Mest tilbøjlig: til give et blowjob på et gadetoilet for 50kr",
            "Mest tilbøjlig: til have sex med et familiemedlem",
            "Mest tilbøjlig: til lave en porno derhjemme",
            "Mest tilbøjlig: til ikke komme ind nogle stedet i aften, fordi de for fulde",
            "Mest tilbøjlig: til flirte med deres underviser, for ekstra credits",
            "Mest tilbøjlig: til dumpe sin køreprøve 10 gange",
            "Mest tilbøjlig: til altid komme forsent",
            "Mest tilbøjlig: til have sex med en fra spillets mor/far",
            "Mest tilbøjlig: til have den største afhængighed for sex",
            "Mest tilbøjlig: til have gået længst tid uden have sex",
            "Mest tilbøjlig: til lave en joke, som ingen griner af",
            "Mest tilbøjlig: til bliver væk i byen",
            "Mest tilbøjlig: til se mest porno",
            "Mest tilbøjlig: til holde kort tid under sex",
            "Mest tilbøjlig: til have det frækkeste undertøj",
            "Mest tilbøjlig: til navngive deres barn efter en serie/film/spil",
            "Mest tilbøjlig: til være VIP hos en stripklub",
            "Mest tilbøjlig: til arbejde som en stripper i fremtiden",
            "Mest tilbøjlig: til alrig blive gift",
            "Mest tilbøjlig: til være utro",
            "Mest tilbøjlig: til have mest kropsbehåring",
            "Mest tilbøjlig: til onanere 5 gange om dagen",
            "Mest tilbøjlig: til give det bedste blowjob",
            "Mest tilbøjlig: til bruge 2 uger på svare på ens besked",
            "Mest tilbøjlig: til score i aften",
            "Mest tilbøjlig: til miste deres telefon i aften",
            "Mest tilbøjlig: til stjæle en vens partner",
            "Mest tilbøjlig: til stadig at sove i deres forældres seng",
            "Mest tilbøjlig: til være super desperat efter sex lige nu",
            "Mest tilbøjlig: til have de grimmeste ex-kærester",
            "Mest tilbøjlig: til smutte hjem som den første idag",
            "Mest tilbøjlig: til være fuldtids alkoholiker i fremtiden",
            "Mest tilbøjlig: til at blive kidnappet",
            "Mest tilbøjlig: til stadig bo hos deres forældre om 10 år",
            

        };
    }

    public string GetRandMostLikely()
    {
        if (questions.Count == 0)
        {
            Debug.LogWarning("No more questions available.");
            ResetMostLikely();
        }

        int randIndex = Random.Range(0, questions.Count);
        string selectedQuestion = questions[randIndex];

        // Add the question to the used list and remove it from the available list
        usedQuestions.Add(selectedQuestion);
        questions.RemoveAt(randIndex);

        return selectedQuestion;
    }

    public void ResetMostLikely()
    {
        // Reset the questions list by adding all used questions back
        questions.AddRange(usedQuestions);
        usedQuestions.Clear();
    }
}
