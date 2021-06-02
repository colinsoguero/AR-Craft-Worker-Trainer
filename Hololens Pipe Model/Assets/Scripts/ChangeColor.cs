using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float alphaVal;
    // Start is called before the first frame update
    void Start()
    {
        foreach (MeshRenderer m in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            m.material.SetColor("_Color", Color.red);
            Color color = m.material.color;
            m.material.shader = Shader.Find("Transparent/Diffuse");
            color.a = alphaVal;
            m.material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
