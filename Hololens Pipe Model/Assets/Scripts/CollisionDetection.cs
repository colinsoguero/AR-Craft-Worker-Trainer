using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    Color32 whiteColor;
    Color32 blackColor;
    Color32 redColor;
    Color32 greenColor;

    void Start()
    {
        whiteColor = new Color32(246, 246, 243, 255);
        blackColor = new Color32(25, 25, 25, 255);
        redColor = new Color32(255, 0, 0, 102);
        greenColor = new Color32(0, 255, 0, 102);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pipe" || other.tag == "Pipe2")
        {
            Debug.Log("Collision Detected");
            foreach(MeshRenderer m in other.GetComponentsInChildren<MeshRenderer>())
            { 
                m.material.SetColor("_Color", redColor);
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Trigger exited");
        if(other.tag == "Pipe")
        {
            foreach(MeshRenderer m in other.GetComponentsInChildren<MeshRenderer>())
            {
                //m.material.SetColor("_Color", whiteColor);
                m.material.SetColor("_Color", greenColor);
            }   
        }
        else if(other.tag == "Pipe2")
        {
            foreach(MeshRenderer m in other.GetComponentsInChildren<MeshRenderer>())
            {
                //m.material.SetColor("_Color", blackColor);
                m.material.SetColor("_Color", greenColor);
            }   
        }
        
    
    }
}
