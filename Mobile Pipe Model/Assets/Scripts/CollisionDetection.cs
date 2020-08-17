using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    Color32 whiteColor;
    Color32 blackColor;

    void Start()
    {
        whiteColor = new Color32(246, 246, 243, 255);
        blackColor = new Color32(25, 25, 25, 255);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Pipe" || other.tag == "Pipe2")
        {
            foreach(MeshRenderer m in other.GetComponentsInChildren<MeshRenderer>())
            { 
                m.material.SetColor("_Color", Color.red);
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
                m.material.SetColor("_Color", whiteColor);
            }   
        }
        else if(other.tag == "Pipe2")
        {
            foreach(MeshRenderer m in other.GetComponentsInChildren<MeshRenderer>())
            {
                m.material.SetColor("_Color", blackColor);
            }   
        }
        
    
    }
}
