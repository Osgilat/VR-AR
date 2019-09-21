using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Valve.VR;

public class SetupLocalPlayer : NetworkBehaviour
{
    public BlendshapeDriver blendshapeDriver;

    public SkinnedMeshRenderer skinnedMeshRenderer;


    public Vector3 offset = new Vector3(0, 0.5f, 0.4f);

    public static SetupLocalPlayer localPlayerInstance;
    
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        localPlayerInstance = this;
    }
    
    public GameObject arkitPart;
    public GameObject vrPart;

    public static bool vrInitialized = false;

    public Camera vrCamera;
    public SteamVR_PlayArea playArea;
    public SteamVR_Behaviour_Pose leftHand;
    public SteamVR_Behaviour_Pose rightHand;
    public ViveCursor viveCursor;
    
    public Animator animator;
    
    
    private void OnGUI() // OnGUI is called twice per frame
    {
        GUI.Label(new Rect(50, 50, 100, 25), !Application.isMobilePlatform ? "VR MODE" : "IOS MODE");
    }
    
    // Start is called before the first frame update
    void Start()
    {
    
        animator = GetComponent<Animator>();
        
        if (Application.isMobilePlatform && isLocalPlayer || !Application.isMobilePlatform && !isLocalPlayer)
        {
            arkitPart.SetActive(true);
        }
        else 
        {
            gameObject.transform.localPosition = new Vector3(0, -1.25f, 0);
            vrPart.SetActive(true);
            if(!Application.isMobilePlatform)
            {
                vrCamera.enabled = true;
                playArea.enabled = true;
                leftHand.enabled = true;
                rightHand.enabled = true;
                viveCursor.enabled = true;
                
                vrInitialized = true;
            }
            
        }
        
        if (isLocalPlayer && Application.isMobilePlatform)
        {
            Debug.Log("LOCAL PLAYER SPAWNED");
            UnityARFaceAnchorManager.instance.anchorPrefab = gameObject;
            blendshapeDriver.enabled = true;
            InvokeRepeating("UpdateBlendshapes",5, 0.05f);
        }
        else
        {
            Debug.Log("NOT LOCAL PLAYER SPAWNED");
            blendshapeDriver.enabled = false;
        }
        
        for (int i = 0; i < 52; i++)
        {
            syncListFloat.Add(0);
        }
        
    }

    
    public VectorN scared = new VectorN(52);
    
   
    public void UpdateBlendshapes()
    {
        
        if (isServer)
        {
            GetBlendshapes();
        }
        else
        {
            float[] clientsWeights = new float[52]; 

            GetBlendshapes();
 
            clientsWeights = syncListFloat.ToArray();
            
            CmdGetBlendShapes(clientsWeights);
        }
        
       
    }
    
    
    
    private void Update()
    {
        if (isLocalPlayer)
        {
            return;
        }
        
        SetBlendshapes();
    }
    
    
    
    private void LateUpdate()
    {
        /*
        if (isLocalPlayer && Application.isMobilePlatform)
        {
            Camera.main.transform.position = Vector3.zero + Vector3.up * transform.position.y;
            Camera.main.transform.LookAt(transform.position);
        }
        */
        
        
    }

     [Command]
    public void CmdGetBlendShapes(float[] clientsWeights)
    {
        for (int i = 0; i < 52; i++)
        {
            syncListFloat[i] = clientsWeights[i];
        }
  
    }
   
    private SyncListFloat syncListFloat = new SyncListFloat();

    public void GetBlendshapes()
    {
        for (int i = 0; i < 52; i++)
        {
            
            syncListFloat[i] = skinnedMeshRenderer.GetBlendShapeWeight(i);
        }
   
    }

    [Command]
    public void CmdSetBlendShapes()
    {
        SetBlendshapes();
        
        //RpcSetBlendShapes();
    }
    
    
    [ClientRpc]
    public void RpcSetBlendShapes()
    {
        SetBlendshapes();
    }


    public void SetBlendshapes()
    {
        
        for (int i = 0; i < 52; i++)
        {
             skinnedMeshRenderer.SetBlendShapeWeight(i,syncListFloat[i]);
        }
 
    }
}
