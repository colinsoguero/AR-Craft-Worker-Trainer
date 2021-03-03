using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    GameObject textPrefab;
    Transform cam;
    GameObject target;

    public GameObject lengthText;
    public GameObject stepText;
    public GameObject nameText;

    [Range(0.0f, 2.0f)]
    public float lengthErrorPct;

    public bool overrideLengthText;
    public bool overridePhysicalLength;

    void Start()
    {
        target = GameObject.Find("ImageTarget");
        cam = GameObject.Find("ARCamera").GetComponent<Transform>();

        textPrefab = GameObject.Find("TextPrefab");

        // Instantiate text prefab for length, step number, and part name
        lengthText = Instantiate(textPrefab, transform.position, Quaternion.Euler(0, 0, 0)); 
        stepText = Instantiate(textPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        nameText = Instantiate(textPrefab, transform.position, Quaternion.Euler(0, 0, 0));

        // Find and set length text
        Vector3 v3 = this.GetComponentInChildren<Renderer>().bounds.size;        
        float length = Mathf.Max(Mathf.Max(v3.x, v3.y), v3.z);
        length = length*39.3701f;

        if(overrideLengthText)
        {
            length *= lengthErrorPct;
        }

        if(overridePhysicalLength)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1,1, lengthErrorPct));
        }

        lengthText.GetComponent<TextMesh>().text = length.ToString("F2") + "in";
        lengthText.GetComponent<TextMesh>().color = new Color32(255, 0, 0, 255);

        // Set the step number
        int num = System.Array.IndexOf(target.GetComponent<StepThrough>().parts, this.gameObject);
        num++; // Because array starts at 0
        stepText.GetComponent<TextMesh>().text = "Step " + num;
        stepText.GetComponent<TextMesh>().color = new Color32(0, 255, 14, 255);

        // Set the part name
        int index = gameObject.name.IndexOf("-");
        string name = gameObject.name.Substring(0, index);
        nameText.GetComponent<TextMesh>().text = name;
        nameText.GetComponent<TextMesh>().color = new Color32(0, 139, 255, 255);



    }

    void Update()
    {
        lengthText.transform.position = transform.position + new Vector3(0.0f, 0.03f, 0.0f);
        stepText.transform.position = transform.position + new Vector3(0f, 0.0f, 0.0f);
        nameText.transform.position = transform.position + new Vector3(0.0f, -0.03f, 0f); 

        lengthText.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        stepText.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        nameText.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position); 

        // if(gameObject.activeSelf && target.GetComponent<InfoDisplay>().lengthDisplayed)
        //     lengthText.SetActive(true);
        // else
        //     lengthText.SetActive(false);

        // if(gameObject.activeSelf && target.GetComponent<InfoDisplay>().stepDisplayed)
        //     stepText.SetActive(true);
        // else
        //     stepText.SetActive(false);

        // if(gameObject.activeSelf && target.GetComponent<InfoDisplay>().nameDisplayed)
        //     nameText.SetActive(true);
        // else
        //     nameText.SetActive(false);

        // if(gameObject.tag == "Debug")
        //     Debug.Log("Update");       

    }
}
