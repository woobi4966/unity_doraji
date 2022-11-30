using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    public GameManager gameManager;
    public Text feelingSelect;
    public InputField questionAnswer;

    public Image feelingIcon;
    public Text QuestionAnswerText;
    public Sprite[] feelingIconForShow;

    void Start()
    {
        
    }

    private void OnEnable() {
        SetFeelingIcon();
        SetQuestionText();
    }

    private void OnDisable() {
        
    }

    void SetQuestionText(){
        gameManager.questionAnswer = questionAnswer.text;
        print("Gamemanager.questionAnswer :" + gameManager.questionAnswer);
        QuestionAnswerText.text = gameManager.questionAnswer;
        // print("CalendarManager.questionAnswer :" + gameManager.questionAnswer);

    }

    void SetFeelingIcon() {
        switch(gameManager.feelingSelection)
        {
            case 0:
                feelingIcon.sprite = feelingIconForShow[0];
                break;
            case 1:
                feelingIcon.sprite = feelingIconForShow[1];
                break;
            case 2:
                feelingIcon.sprite = feelingIconForShow[2];
                break;
            case 3:
                feelingIcon.sprite = feelingIconForShow[3];
                break;
            case 4:
                feelingIcon.sprite = feelingIconForShow[4];
                break;
            case 5:
                feelingIcon.sprite = feelingIconForShow[5];
                break;
            default:
                break;
        }
    }
}
