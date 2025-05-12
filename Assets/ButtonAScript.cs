using System;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public DialogueManager DM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnMouseDown()
    {
        DM.MakeChoiceA();

    }
}
