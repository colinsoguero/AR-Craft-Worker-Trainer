using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonLogging : MonoBehaviour
{
    FileOutput file;

    bool buttonOneActive = false;
    bool buttonTwoActive = false;
    bool buttonThreeActive = false;
    bool buttonFourActive = false;
    bool buttonFiveActive = false;
    bool buttonSixActive = false;
    
    public static ButtonLogging instance;

    void Start()
    {
        instance = this;
        file = GetComponent<FileOutput>();
    }

    public void ButtonOnePressed()
    {
        if(!buttonOneActive)
        {
            buttonOneActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "1,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            buttonOneActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "1,deactivated," + time;
            file.AddToLog(message);
        }
    }

    public void ButtonTwoPressed()
    {
        if(!buttonTwoActive)
        {
            buttonTwoActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "2,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            buttonTwoActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "2,deactivated," + time;
            file.AddToLog(message);
        }
    }
    
    public void ButtonThreePressed()
    {
        if(!buttonThreeActive)
        {
            buttonThreeActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "3,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            buttonThreeActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "3,deactivated," + time;
            file.AddToLog(message);     
        }
    }

    public void ButtonFourPressed()
    {
        if(!buttonFourActive)
        {
            buttonFourActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "4,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            buttonFourActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "4,deactivated," + time;
            file.AddToLog(message);     
        }
    }

    public void ButtonFivePressed()
    {
        if(!buttonFiveActive)
        {
            buttonFiveActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "5,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            buttonFiveActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "5,deactivated," + time;
            file.AddToLog(message);     
        }
    }

    public void ButtonSixPressed()
    {
        if(!buttonSixActive)
        {
            buttonSixActive = true;
            string time = System.DateTime.Now.ToString();
            string message = "6,activated," + time;
            file.AddToLog(message);
        }
        else
        {
            buttonSixActive = false;
            string time = System.DateTime.Now.ToString();
            string message = "6,deactivated," + time;
            file.AddToLog(message);     
        }
    }

    public void ObjectLookedAt(GameObject go)
    {
        string time = System.DateTime.Now.ToString();
        string message = go.name + " looked at: " + time;
        file.AddToLog(message);
    }

    public void ObjectLookAway(GameObject go)
    {
        string time = System.DateTime.Now.ToString();
        string message = go.name + " look away: " + time;
        file.AddToLog(message);
    }
}
