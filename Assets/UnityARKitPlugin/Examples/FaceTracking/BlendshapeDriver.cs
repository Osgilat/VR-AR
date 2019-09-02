using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using Random = System.Random;

public class BlendshapeDriver : MonoBehaviour
{
	SkinnedMeshRenderer skinnedMeshRenderer;
	Dictionary<string, float> currentBlendShapes;

	// Use this for initialization
	void Start()
	{
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

		if (skinnedMeshRenderer)
		{
			UnityARSessionNativeInterface.ARFaceAnchorAddedEvent += FaceAdded;
			UnityARSessionNativeInterface.ARFaceAnchorUpdatedEvent += FaceUpdated;
		}
	}

	private bool blendShapesEnabled = false;

	void FaceAdded(ARFaceAnchor anchorData)
	{
		currentBlendShapes = anchorData.blendShapes;
		blendShapesEnabled = true;
	}

	void FaceUpdated(ARFaceAnchor anchorData)
	{
		currentBlendShapes = anchorData.blendShapes;
	}

	void FaceRemoved(ARFaceAnchor anchorData)
	{
		blendShapesEnabled = false;
	}


	public float delayFor = 1.0f;
	private float delayTimer = 0;

	// Update is called once per frame
	void Update()
	{
		if (currentBlendShapes != null)
		{
			foreach (KeyValuePair<string, float> kvp in currentBlendShapes)
			{
				int blendShapeIndex =
					skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(

						
						"BS_node." + kvp.Key.Replace("_L", "Left").Replace("_R", "Right"));
				
					Debug.Log("Trying " + kvp.Key);
					Debug.Log("Trying2 " + "BS_node." + kvp.Key.Replace("_L", "Left").Replace("_R", "Right"));
				if (blendShapeIndex >= 0)
				{
					skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, kvp.Value * 100.0f);
				}
			}
		}

		if (!blendShapesEnabled)
		{
			return;
		}

		if (delayTimer >= delayFor)
		{
			LogExpressions();
			delayTimer = 0;
		}
		else
		{
			delayTimer += Time.deltaTime * 1.0f;
		}
	}

	void LogExpressions()
	{
		foreach (KeyValuePair<string, float> kvp in currentBlendShapes)
		{
			//loggingSystem.writeMessageWithTimestampToLog(currentBlendShapeUIs[blendshapeName] + ",");
			string stringToLog = kvp.Key + "=" + kvp.Value;

			Debug.Log(DateTime.Now.ToString("M/d/yyyy") + " "
			                                            + System.DateTime.Now.ToString("HH:mm:ss") + ":"
			                                            + System.DateTime.Now.Millisecond + "," + stringToLog);
		}
	}
}
