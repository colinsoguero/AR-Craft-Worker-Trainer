using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepByStep : MonoBehaviour
{
    public GameObject[] parts;
    public int i = 0;                                     
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in parts)
        {
            go.SetActive(true);                             //CHANGED
        }
        //Debug.Log("width: " + width.ToString("F5"));
    }

    void Update()
    {
/*        for(int j = 0; j<=parts.Length; j++)
        {
            if(j<i) //for every object up to i in the parts array, make visible
            {
                parts[j].SetActive(true);
                foreach(MeshRenderer m in parts[j].GetComponentsInChildren<MeshRenderer>())
                {
                    Color color = m.material.color;
                    m.material.shader = Shader.Find( "Standard" );
                    color.a = 1.0f;
                    m.material.color = color;
                }
            }
            else if(j==i) //Displays the next step as transparent
            {
                parts[j].SetActive(true);
                foreach(MeshRenderer m in parts[i].GetComponentsInChildren<MeshRenderer>())
                { 
                    Color color = m.material.color;
                    m.material.shader = Shader.Find( "Transparent/Diffuse" );
                    color.a = 0.4f;
                    m.material.color = color;
                }
            }
            else //Set every object after i inactive
            {
                parts[j].SetActive(false);
            }
        }*/

    }

    public void NextStep()
    {
        if(i<parts.Length)
            i++;
        else
            i=parts.Length;
    }

    public void BackStep()
    {
        if(i>0)
            i--;
        else
            i=0;
    }
}
