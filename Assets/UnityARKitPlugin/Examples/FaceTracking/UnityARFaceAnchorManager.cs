﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class UnityARFaceAnchorManager : MonoBehaviour {

	[SerializeField]
	public GameObject anchorPrefab;

	private UnityARSessionNativeInterface m_session;

	public static UnityARFaceAnchorManager instance;

	// Use this for initialization
	void Start ()
	{
		instance = this;
		m_session = UnityARSessionNativeInterface.GetARSessionNativeInterface();

		Application.targetFrameRate = 60;
		ARKitFaceTrackingConfiguration config = new ARKitFaceTrackingConfiguration();
		config.alignment = UnityARAlignment.UnityARAlignmentGravity;
		config.enableLightEstimation = true;

		if (config.IsSupported ) {
			
			m_session.RunWithConfig (config);

			UnityARSessionNativeInterface.ARFaceAnchorAddedEvent += FaceAdded;
			UnityARSessionNativeInterface.ARFaceAnchorUpdatedEvent += FaceUpdated;
			UnityARSessionNativeInterface.ARFaceAnchorRemovedEvent += FaceRemoved;

		}

	}

	void FaceAdded (ARFaceAnchor anchorData)
	{
		if (anchorPrefab != null)
		{
			anchorPrefab.transform.position = UnityARMatrixOps.GetPosition(anchorData.transform);
			anchorPrefab.transform.rotation = UnityARMatrixOps.GetRotation(anchorData.transform);
			anchorPrefab.SetActive(true);
		}
	}

	void FaceUpdated (ARFaceAnchor anchorData)
	{
		if (anchorPrefab != null)
		{
			if (anchorPrefab.activeSelf != anchorData.isTracked) 
			{
				anchorPrefab.SetActive (anchorData.isTracked);
			}

			if (anchorData.isTracked) 
			{
				anchorPrefab.transform.position = UnityARMatrixOps.GetPosition (anchorData.transform);
				anchorPrefab.transform.rotation = UnityARMatrixOps.GetRotation (anchorData.transform);
			}
		}
	}

	void FaceRemoved (ARFaceAnchor anchorData)
	{
		if (anchorPrefab != null)
		{
			anchorPrefab.SetActive(false);
		}
	}



	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
		
	}
}
