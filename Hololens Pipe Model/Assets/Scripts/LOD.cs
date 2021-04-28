using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOD : MonoBehaviour
{
    public GameObject[] models;

    public void Display300()
    {
        ResetModels();
        models[0].SetActive(true);
    }

    public void Display400()
    {
        ResetModels();
        models[1].SetActive(true);
    }

    private void ResetModels()
    {
        foreach(GameObject model in models)
        {
            model.SetActive(false);
        }
    }
}
