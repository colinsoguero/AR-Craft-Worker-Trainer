using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDisplay : MonoBehaviour
{
    GameObject target, water;
    Transform cam;
    GameObject[] waterArr;
    public bool lengthDisplayed = false;
    public bool stepDisplayed = false;
    public bool nameDisplayed = false;

    public bool waterDisplayed = false;
    void Start()
    {
        target = GameObject.Find("ImageTarget");
        water = GameObject.Find("Water");
        waterArr = new GameObject[water.transform.childCount];

        for (int i = 0; i < water.transform.childCount; i++)
        {
            waterArr[i] = water.transform.GetChild(i).gameObject;
            waterArr[i].SetActive(false);
        }
    }


    void Update()
    { 
        foreach(GameObject go in target.GetComponent<StepByStep>().parts)
        {
            if(go.activeSelf && lengthDisplayed)
                go.GetComponent<Text>().lengthText.SetActive(true);
            else
                go.GetComponent<Text>().lengthText.SetActive(false);

            if(go.activeSelf && stepDisplayed)
                go.GetComponent<Text>().stepText.SetActive(true);
            else
                go.GetComponent<Text>().stepText.SetActive(false);

            if(go.activeSelf && nameDisplayed)
                go.GetComponent<Text>().nameText.SetActive(true);
            else
                go.GetComponent<Text>().nameText.SetActive(false);
        }

        if(waterDisplayed)
        {
            foreach(GameObject go in target.GetComponent<StepByStep>().parts)
            {
                foreach(MeshRenderer m in go.GetComponentsInChildren<MeshRenderer>())
                { 
                    Color color = m.material.color;
                    m.material.shader = Shader.Find( "Transparent/Diffuse" );
                    color.a = 0.4f;
                    m.material.color = color;
                }
            }

            foreach(GameObject go in waterArr)
            {
                go.SetActive(true);
            }

        }
        else if(!waterDisplayed)
        {
            foreach(GameObject go in waterArr)
            {
                go.SetActive(false);
            }
        }
    }

    public void DisplayLength()
    {
        if(!lengthDisplayed)
            lengthDisplayed = true;
        else
            lengthDisplayed = false;
    }
    public void DisplayStep()
    {
        if(!stepDisplayed)
            stepDisplayed = true;
        else
            stepDisplayed = false;
    }
    public void DisplayName()
    {
        if(!nameDisplayed)
            nameDisplayed = true;
        else
            nameDisplayed = false;      
    }

    public void DisplayWater()
    {
        if(!waterDisplayed)
            waterDisplayed = true;
        else
            waterDisplayed = false;  
    }

}
