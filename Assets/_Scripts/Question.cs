using _Scripts;
using UnityEngine;

public abstract class Question : MonoBehaviour
{
    [Header("Question Base")] private InGameUIManager inGameUIManager;

    private void Awake()
    {
        inGameUIManager = GameObject.Find("InGameUI").GetComponent<InGameUIManager>();
    }

    protected virtual void SetAnswerCorrect()
    {
        GameManager.Instance.currentLevelProgress.noOfCorrectAnswers++;
        if (GameManager.Instance.currentLevelProgress.noOfCorrectAnswers ==
            GameManager.Instance.currentLevelQuestions.Length)
        {
            GameManager.Instance.SaveLastAttemptInCurrentLvl(true);
        }

        inGameUIManager.IsQuestionCorrect(true);
    }

    protected virtual void SetAnswerWrong()
    {
        GameManager.Instance.currentLevelProgress.noOfWrongAnswers++;
        if (GameManager.Instance.currentLevelProgress.noOfWrongAnswers ==
            GameManager.Instance.currentLevelQuestions.Length)
        {
            GameManager.Instance.SaveLastAttemptInCurrentLvl(false);
        }

        inGameUIManager.IsQuestionCorrect(false);
    }
}