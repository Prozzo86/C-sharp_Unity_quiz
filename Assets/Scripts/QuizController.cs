using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    [SerializeField]
    private UIcontroller uIcontroller;
    [SerializeField]
    private QuestionCollection questionCollection;
    private QuizQuestion currentQuestion;
    [SerializeField]
    private float delayTime = 2f; //vrijeme nakon �to se odgovori, koliko se �eka za novo pitanje

    private void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        //Dohvati ne postavljeno pitanje
        currentQuestion = questionCollection.GetUnaskedQuestion();
        //Ne postavljeno pitanje prika�i na UI-u
        uIcontroller.SetUpUIForQuestion(currentQuestion);
    }

    public void SubmitAnswer(int answerNumber)
    {
        //if(answerNumber == currentQuestion.CorrectAnswer)
        //{
        //    uIcontroller.CheckUpPressedButton(true);
        //}
        //UI da odradi svoje kada se odgovori
        uIcontroller.CheckUpPressedButton(answerNumber == currentQuestion.CorrectAnswer);

        //U�itaj novo pitanje
        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        ShowQuestion();
    }
}
