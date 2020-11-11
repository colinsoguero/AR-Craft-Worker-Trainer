using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

#if WINDOWS_UWP
using Windows.Storage;
using Windows.System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
#endif

public class FileOutput : MonoBehaviour
{

    //define filePath
#if WINDOWS_UWP
    Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
#endif

    //private string saved line;
    private string saveInformation = "";

    private static string timeStamp = System.DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
    private static string fileName = timeStamp + ".txt";

    //private save counter
    private static bool firstSave = true;


#if WINDOWS_UWP
    async void WriteData()
    {
        if (firstSave){
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        await FileIO.AppendTextAsync(sampleFile, saveInformation + "\r\n");
        firstSave = false;
        }
    else{
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        await FileIO.AppendTextAsync(sampleFile, saveInformation + "\r\n");
    }
    }
#endif

    public void AddToLog(string message)
    {
        saveInformation = message;
#if WINDOWS_UWP
        WriteData();
#endif
    }
}
