using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class QuizTest : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    void Start()
    {
       /* if(unansweredQuestions == null || unansweredQuestions.Count ==0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        Debug.Log(currentQuestion.fact + "is" + currentQuestion.isTrue);*/
    }

   /* void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {
        if(currentQuestion.isTrue)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectFalse()
    {
        if(!currentQuestion.isTrue)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("wrong");
        }

        StartCoroutine(TransitionToNextQuestion());
    }*/
}
