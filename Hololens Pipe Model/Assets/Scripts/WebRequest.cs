using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class WebRequest : MonoBehaviour
{
    public PanelInfo info = new PanelInfo();
    public PanelInfo prevInfo = new PanelInfo();
    void Start()
    {
        // A correct website page.
        //InvokeRepeating("Request", 1.0f, 1.0f);
        //StartCoroutine(Upload());
    }

    void Request()
    {
        StartCoroutine(GetRequest("https://construction-research.herokuapp.com/"));
    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                info = JsonUtility.FromJson<PanelInfo>(webRequest.downloadHandler.text);
                if(info.panel != prevInfo.panel || info.lod != prevInfo.lod)
                {
                    StartCoroutine(Upload("Switched to side " + info.panel.ToString() + " and LOD " + info.lod.ToString()));
                }
                switch(info.panel)
                {
                    case 1:
                    {
                        if(info.lod == 300)
                            GetComponent<LOD>().Display400Side1();
                        else
                            GetComponent<LOD>().Display300Side1();
                        break;
                    }
                    case 2:
                    {
                        if(info.lod == 300)
                            GetComponent<LOD>().Display400Side2();
                        else
                            GetComponent<LOD>().Display300Side2();
                        break;;
                    }
                    case 3:
                    {
                        if(info.lod == 300)
                            GetComponent<LOD>().Display400Side3();
                        else
                            GetComponent<LOD>().Display300Side3();
                        break;                    }
                }
                prevInfo = info;
            }
        }
    }
    IEnumerator Upload(string data)
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(data);
        using (UnityWebRequest www = UnityWebRequest.Put("https://construction-research.herokuapp.com/", myData))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
            }
        }
    }
}