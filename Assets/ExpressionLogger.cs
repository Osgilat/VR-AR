using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionLogger : MonoBehaviour
{
    
    SkinnedMeshRenderer skinnedMeshRenderer;
    Dictionary<string, float> currentBlendShapes;

    public string maskType;
    
    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        InvokeRepeating("LoggingLoop", 1.0f, 0.25f);
    }
    
    public string [] GetBlendshapesWeights (GameObject obj)
    {
        SkinnedMeshRenderer head = obj.GetComponent<SkinnedMeshRenderer>();
		
        string[] arr;
        arr = new string [52];
        for (int i = 0; i < 52; i++)
        {
            string s = head.GetBlendShapeWeight(i) + "";
            //print("Blend Shape: " + i + " " + s); // Blend Shape: 4 FightingLlamaStance
            arr[i] = s;
        }
        return arr;
    }

    public string[] blendshapesWeights;
    
    // Update is called once per frame
    void LoggingLoop()
    {
        blendshapesWeights = GetBlendshapesWeights(gameObject);
        for (int i = 0; i < blendshapesWeights.Length; i++)
        {
            string stringToLog = i + "=" + blendshapesWeights[i];

            Debug.Log(DateTime.Now.ToString("M/d/yyyy") + " "
                                                        + System.DateTime.Now.ToString("HH:mm:ss") + ":"
                                                        + System.DateTime.Now.Millisecond + "," + maskType + "," + stringToLog + "," + AudioSync.instance.GetLogString());
        }
        
    }
}
