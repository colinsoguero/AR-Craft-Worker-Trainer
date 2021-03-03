using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepThrough : MonoBehaviour
{
    public GameObject[] parts;
    private int i = 0;
    public static StepThrough instance;                                     
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(parts.Length);
        if(instance == null)
            instance = this;
        foreach(GameObject go in parts)
        {
            go.SetActive(false);                             
        }
        SetStep();
        //Debug.Log("width: " + width.ToString("F5"));
    }

    void Update()
    {

    }

    public void NextStep()
    {
        if(i<parts.Length)
            i++;
        else
            i=parts.Length;
        SetStep();
    }

    public void BackStep()
    {
        if(i>0)
            i--;
        else
            i=0;
        SetStep();
    }

    void SetStep()
    {
        for (int j = 0; j <= parts.Length-1; j++)
        {
            if (j < i) //for every object up to i in the parts array, make visible
            {
                Debug.Log("j < i");
                parts[j].SetActive(true);
                foreach (MeshRenderer m in parts[j].GetComponentsInChildren<MeshRenderer>())
                {
                    m.material.SetColor("_Color", Color.green);
                    Color color = m.material.color;
                    m.material.shader = Shader.Find("Transparent/Diffuse"); //m.material.shader = Shader.Find("Standard");
                    color.a = 0.4f;
                    m.material.color = color;
                }
            }
            else if (j == i) //Displays the next step as transparent
            {
                Debug.Log("j == i");
                parts[j].SetActive(true);
                foreach (MeshRenderer m in parts[i].GetComponentsInChildren<MeshRenderer>())
                {
                    m.material.SetColor("_Color", Color.green);
                    Color color = m.material.color;
                    m.material.shader = Shader.Find("Transparent/Diffuse");
                    color.a = 0.4f;
                    m.material.color = color;
                }
            }
            else //Set every object after i inactive
            {
                Debug.Log("j>i");
                parts[j].SetActive(false);
            }
        }
    }
}
