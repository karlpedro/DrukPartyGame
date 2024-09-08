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
    }

    private void InitializeMostLikely()
    {
        questions = new List<string>
        {
            //Most likely
            "Most likely: Drikke for meget idag",
            "Most likely: Til at bunde, vinderen bunder ;)",
            "Most likely: Tage ud og drikke dagen før en eksamen",
            "Most likely: Vågne op hos politiet i aften",
            "Most likely: snave med +3 personer iaften",
            "Most likely: At blive tilbageholdt for at pisse på en politimand?",
            "Most likely: At prøve en trekant?",
            "Most likely: At blive indlagt på et psykiatrisk hospital?",
            "Most likely: At elske blive trådt på under sex?",
            "Most likely: At ende sammen med " + PlayerLogic.FirstPlayer() + " i fremtiden",
            "Most likely: At efterlade " + PlayerLogic.FirstPlayer() + " alene i en rendesten",
            "Most likely: At putte stoffer i " + PlayerLogic.FirstPlayer() + " drink",
            "Most likely: At spille russisk roulette for 100.000kr",
            "Most likely: At give et blowjob på et gadetoilet for 50kr",
            "Most likely: At have sex med et familiemedlem",
            "Most Likely: At lave en porno derhjemme",
            "Most likely: ikke komme ind nogle stedet i aften, fordi de for fulde",
            "Most likely: Flirte med deres underviser, for ekstra credits",
            "Most likely: Dumpe sin køreprøve 10 gange",
            "Most likely: Altid komme forsent",
            "Most likely: Have sex med en fra spillets mor/far",
            
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
