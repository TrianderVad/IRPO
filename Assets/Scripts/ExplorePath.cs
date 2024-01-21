using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExplorePath : MonoBehaviour
{
    
    public void LoadFile()

    {

        string path = EditorUtility.OpenFilePanel("Overwrite with txt", "", "txt");
        if (path.Length != 0)
        {

            Debug.Log(path);
        }

    }
}
