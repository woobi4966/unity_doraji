using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingSelect : MonoBehaviour
{

    int selectedFeeling = 0;
    UIManager UIManager;

    public GameManager gameManager;

    [HideInInspector] public bool isSelected = false;

    void Start()
    {
           
    }

    void Update()
    {
        
    }

    public void Feeling1(){
        selectedFeeling = 1;
        gameManager.SetFeelingSelection(selectedFeeling);
        Debug.Log("selectedFeeling : " + selectedFeeling);
        isSelected = true;
    }
    public void Feeling2()
    {
        selectedFeeling = 2;gameManager.SetFeelingSelection(selectedFeeling);
        Debug.Log("selectedFeeling : " + selectedFeeling);
        isSelected = true;
    }
    public void Feeling3()
    {
        selectedFeeling = 3;gameManager.SetFeelingSelection(selectedFeeling);
        Debug.Log("selectedFeeling : " + selectedFeeling);
        isSelected = true;
    }
    public void Feeling4()
    {
        selectedFeeling = 4;gameManager.SetFeelingSelection(selectedFeeling);
        Debug.Log("selectedFeeling : " + selectedFeeling);
        isSelected = true;
    }
    public void Feeling5()
    {
        selectedFeeling = 5;gameManager.SetFeelingSelection(selectedFeeling);
        Debug.Log("selectedFeeling : " + selectedFeeling);
        isSelected = true;
    }
}
