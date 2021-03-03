using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonLogging : MonoBehaviour
{
    FileOutput file;

    bool lengthActive = false;
    bool partActive = false;
    bool stepActive = false;

    void Start()
    {
        file = GetComponent<FileOutput>();
    }

    public void LengthPressed()
    {
        if(!lengthActive)
        {
            lengthActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "1,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            lengthActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "1,deactivated," + time;
            file.AddToLog(message);
        }
    }

    public void PartPressed()
    {
        if(!partActive)
        {
            partActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "2,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            partActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "2,deactivated," + time;
            file.AddToLog(message);
        }
    }
    
    public void StepPressed()
    {
        if(!stepActive)
        {
            stepActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "3,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            stepActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "3,deactivated," + time;
            file.AddToLog(message);     
        }
    }
}
