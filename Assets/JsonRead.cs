using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonRead : MonoBehaviour
{

    public JsonData userData;

    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson() {
        
        string jsonData = JsonUtility.ToJson(userData, true);
        string path = Path.Combine(Application.dataPath, "UserData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadPlayerDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "UserData.json");
        string jsonData = File.ReadAllText(path);
        userData = JsonUtility.FromJson<JsonData>(jsonData);

    }

    public void UpdateUserDate(string questionAnswer, int feelingSelection){
        userData.SetTodayQuestion(questionAnswer);
        userData.SetFeelingSelection(feelingSelection);
    
    }


    [System.Serializable]
    public class JsonData
    {
        // PK
        public string dateTime = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy/MM/dd");
        public string todayQuestion; // 오늘 성찰 질문 답변
        public int feelingSelection; // 오늘 기분


        void Start(){
            SetDateTime();
        }

        public void SetDateTime(){
            dateTime = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy/MM/dd");
        }
        public void SetTodayQuestion(string questionAnswer){
            todayQuestion = questionAnswer;
        }
        public void SetFeelingSelection(int feelingSelect){
            feelingSelection = feelingSelect;
        }
    }
}
