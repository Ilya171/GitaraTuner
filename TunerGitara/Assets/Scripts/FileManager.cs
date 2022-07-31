/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Unity.IO;

public class FileManager : MonoBehaviour
{
    public string path;
    public static string ClientJson;



    public void OpenFileExplorer()
    {
        path = EditorUtility.OpenFilePanel("Show json", "", "json");
        Getjson();

        LevelAbstract.lev = 3;
        Debug.Log(LevelAbstract.lev);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Getjson()
    {
        if (path != null)
        {
            Updatejson();

        }
    }

    void Updatejson()
    {
        WWW www = new WWW("file:///" + path);
        Debug.Log(www.text);
        ClientJson = www.text;
    }
}
 */