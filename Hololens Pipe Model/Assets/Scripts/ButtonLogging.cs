using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonLogging : MonoBehaviour
{
    FileOutput file;

    void Start()
    {
        file = GetComponent<FileOutput>();
    }

    public void LengthPressed()
    {
        string time = System.DateTime.Now.ToString();
        string message = "1,pressed," + time;
        file.AddToLog(message);
    }
    
    public void LengthReleased()
    {
        string time = System.DateTime.Now.ToString();
        string message = "1,released," + time;
        file.AddToLog(message);
    }

    public void PartPressed()
    {
        string time = System.DateTime.Now.ToString();
        string message = "2,pressed," + time;
        file.AddToLog(message);
    }
    
    public void PartReleased()
    {
        string time = System.DateTime.Now.ToString();
        string message = "2,released," + time;
        file.AddToLog(message);
    }
    public void StepPressed()
    {
        string time = System.DateTime.Now.ToString();
        string message = "3,pressed," + time;
        file.AddToLog(message);
    }
    
    public void StepReleased()
    {
        string time = System.DateTime.Now.ToString();
        string message = "3,released," + time;
        file.AddToLog(message);        
    }
}
