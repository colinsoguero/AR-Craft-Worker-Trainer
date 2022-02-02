using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class WebRequest : MonoBehaviour
{
    public PanelInfo info = new PanelInfo();
    public SessionTrackingData data = new SessionTrackingData();
    public PanelInfo prevInfo = new PanelInfo();

    void Start()
    {
        data.eyeTracking = "{test: \"Hello World\"}";
        data.headTracking = "{test: \"Hello World\"}";
        data.handTracking = "{test: \"Hello World\"}";
        data.sessionStartTime = System.DateTime.Now.ToString();
        // A correct website page.
        InvokeRepeating("Request", 1.0f, 1.0f);
        //StartCoroutine(Upload());
    }

    void Request()
    {
        StartCoroutine(GetRequest("https://construction-research.herokuapp.com"));
    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                {
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    info = JsonUtility.FromJson<PanelInfo>(webRequest.downloadHandler.text);
                    // Debug.Log("curr: " + info.panel);
                    data.activeLod = info.lod;
                    data.activePanel = info.panel;
                    data.sessionEndTime = System.DateTime.Now.ToString();
                    //Debug.Log("Upload data: " + JsonUtility.ToJson(data));
                    if(info.panel != prevInfo.panel || info.lod != prevInfo.lod)
                    {
                        StartCoroutine(Upload(data));
                    }
                    data.sessionStartTime = System.DateTime.Now.ToString();
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
                            break;                    
                        }
                        case 4:
                        {
                            GetComponent<LOD>().DisplayTestSide();   
                            break;              
                        }
                    }
                    prevInfo = info;
                    break;
                }
            }
        }
    }
    IEnumerator Upload(SessionTrackingData data)
    {
        WWWForm form = new WWWForm();
        //Dictionary<string, object> test = new Dictionary<string, object>();
        form.AddField("activeLod", data.activeLod);
        form.AddField("activePanel", data.activePanel);
        form.AddField("eyeTracking", "{test: \"Hello World\"}");
        form.AddField("headTracking", "{test: \"Hello World\"}");
        form.AddField("handTracking", "{test: \"Hello World\"}");
        form.AddField("sessionStartTime", data.sessionStartTime);
        form.AddField("sessionEndTime", data.sessionEndTime);


        UnityWebRequest www = UnityWebRequest.Post("https://construction-research.herokuapp.com/session-tracking-data", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}