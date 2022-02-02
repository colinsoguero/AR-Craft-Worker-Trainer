using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOD : MonoBehaviour
{
    public GameObject[] models;

    public void Display300Side1()
    {
        ResetModels();
        models[0].SetActive(true);
    }

    public void Display300Side2()
    {
        ResetModels();
        models[1].SetActive(true);
    }

    public void Display300Side3()
    {
        ResetModels();
        models[2].SetActive(true);
    }

    public void Display400Side1()
    {
        ResetModels();
        models[3].SetActive(true);
    }

    public void Display400Side2()
    {
        ResetModels();
        models[4].SetActive(true);
    }

    public void Display400Side3()
    {
        ResetModels();
        models[5].SetActive(true);
    }

    public void DisplayTestSide()
    {
        ResetModels();
        models[6].SetActive(true);
    }

    private void ResetModels()
    {
        foreach(GameObject model in models)
        {
            model.SetActive(false);
        }
    }
}
