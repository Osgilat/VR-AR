using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Valve.Newtonsoft.Json.Utilities;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Random = UnityEngine.Random;

public class SetupLocalPlayer : NetworkBehaviour
{
    public BlendshapeDriver blendshapeDriver;

    public SkinnedMeshRenderer possesableMesh;
    public SkinnedMeshRenderer imitatedMesh;
    public SkinnedMeshRenderer aiMesh;


    public Vector3 offset = new Vector3(0, 0.5f, 0.4f);

    public static SetupLocalPlayer localPlayerInstance;
    public static SetupLocalPlayer localArkitInstance;

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

        //if (Application.isMobilePlatform && isLocalPlayer || !Application.isMobilePlatform && !isLocalPlayer)
        {
            localArkitInstance = this;
            arkitPart.SetActive(true);
        }
        /*
        else 
        {
            //gameObject.transform.localPosition = new Vector3(0, -1.25f, 0);
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
        */

        if (isLocalPlayer && Application.isMobilePlatform)
        {
            //Debug.Log("LOCAL PLAYER SPAWNED");
            UnityARFaceAnchorManager.instance.anchorPrefab = gameObject;
            blendshapeDriver.enabled = true;
            InvokeRepeating("UpdateBlendshapes", 5, 0.05f);
        }
        else
        {
            //Debug.Log("NOT LOCAL PLAYER SPAWNED");
            blendshapeDriver.enabled = false;
        }

        for (int i = 0; i < 52; i++)
        {
            syncListFloat.Add(0);
        }

        myVector = gameObject.AddComponent<VectorN>();
        myVector.values = new float[52];

        InvokeRepeating("MasksImitationLoop", 1.0f, 0.1f);
    }

  

    public VectorN myVector;

    [SerializeField] List<VectorN> expressions = new List<VectorN>();

    public VectorN mostLikelyExpression;

    public float[] expressionLikeness;

    public int mostLikelyIndex;

    [Serializable]
    public class ExpressionProbability
    {
        public float[] probabilityArray = new float[8];
    }

    public List<string> animatorTriggersList = new List<string>();

    public List<ExpressionProbability> expressionProbabilities = new List<ExpressionProbability>();

    public int GetRandomWeightedIndex(float[] weights)
    {
        if (weights == null || weights.Length == 0) return -1;

        float w;
        float total = 0;
        int i;
        for (i = 0; i < weights.Length; i++)
        {
            w = weights[i];
            if (float.IsInfinity(w))
            {
                return i;
            }
            else if (w >= 0f && !float.IsNaN(w))
            {
                total += weights[i];
            }
        }

        float r = Random.value;
        float s = 0f;

        for (i = 0; i < weights.Length; i++)
        {
            w = weights[i];
            if (float.IsNaN(w) || w <= 0f) continue;

            s += w / total;
            if (s >= r) return i;
        }

        return -1;
    }

    public Animator imitatedAnimator;
    public Animator aiAnimator;

    public int lastPickedEmotionIndexImitation = -1;
    public int lastPickedEmotionIndexAi = -1;

    public UDPObj udp = null;

    float[] randomVector = new float[52];

    public string[] receivedArray;

    private float[] receivedImitatedVals;
    private float[] receivedAiVals;

    
    public void ReceiveData()
    {
        receivedArray = UDPObj.instance.getLatestUDPPacket().Split(':');

        if (receivedArray.Length < 104)
        {
            return;
        }
       
        for (int i = 0; i < 52; i++)
        {
            if (string.IsNullOrEmpty(receivedArray[i]))
            {
                return;
            }
            
            imitatedMesh.SetBlendShapeWeight(i, float.Parse(receivedArray[i].Replace(".", ",")));
        }
        
        for (int i = 53; i < 104; i++)
        {
            if (string.IsNullOrEmpty(receivedArray[i]))
            {
                return;
            }
            
            aiMesh.SetBlendShapeWeight(i - 53, float.Parse(receivedArray[i].Replace(".", ",")));
        }
    }
    
    public void SendUdpData()
    {
        
        ReceiveData();
        if (!arkitPart.activeInHierarchy)
        {
            return;
        }

        for (int i = 0; i < randomVector.Length; i++)
        {
            randomVector[i] = Random.Range(0f, 100.0f);
        }

        if (udp == null)
        {
            udp = GameObject.FindWithTag("UDP").GetComponent<UDPObj>();
        }
        else
        {
            string s = DateTime.Now.ToString("M/d/yyyy") + " "
                                                         + System.DateTime.Now.ToString("HH:mm:ss") + ":"
                                                         + System.DateTime.Now.Millisecond + ","
                                                         + AudioSync.currentSlideIndex + ","
                                                         + AudioSync.instance.leftTriggerPressed + ","
                                                         + AudioSync.instance.rightTriggerPressed + ","
                                                         //+ string.Join(":", myVector.values);
                                                         + string.Join(":", randomVector);

            udp.SendData(s);
            //Debug.Log(s);
        }
    }


    public void MasksImitationLoop()
    {
        SendUdpData();

        if (!imitatedMesh.gameObject.activeInHierarchy) return;

        /*
        for (int i = 0; i < expressions.Count; i++)
        {
            float normalized = (Mathf.Sqrt(myVector.norme()) * Mathf.Sqrt(expressions[i].norme()));
                
            expressionLikeness[i] = VectorN.ScalarProduct(expressions[i], myVector) / normalized;
        }
    
        mostLikelyIndex = expressionLikeness.ToList().IndexOf(expressionLikeness.Max());
            
        //mostLikelyExpression = expressions[mostLikelyIndex];
    
        //SetImitationBlendshapes();
        
        if (AudioSync.currentSlideIndex > 0 && lastPickedEmotionIndexImitation != mostLikelyIndex)
        {
            lastPickedEmotionIndexImitation = mostLikelyIndex;
            imitatedAnimator.SetTrigger(animatorTriggersList[mostLikelyIndex]);
        }
        
        
        if (!aiAnimator.gameObject.activeInHierarchy) return;

        int pickedEmotionIndex = GetRandomWeightedIndex(expressionProbabilities[AudioSync.currentSlideIndex].probabilityArray);

        if (AudioSync.currentSlideIndex > 0 && lastPickedEmotionIndexAi != pickedEmotionIndex)
        {
            lastPickedEmotionIndexAi = pickedEmotionIndex;
            aiAnimator.SetTrigger(animatorTriggersList[pickedEmotionIndex]);
        }

        */
    }

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

    public void SetImitationBlendshapes()
    {
        for (int i = 0; i < 52; i++)
        {
            imitatedMesh.SetBlendShapeWeight(i, mostLikelyExpression[i] * expressionLikeness[mostLikelyIndex]);
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
            syncListFloat[i] = possesableMesh.GetBlendShapeWeight(i);
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
            possesableMesh.SetBlendShapeWeight(i, syncListFloat[i]);
            myVector.values[i] = possesableMesh.GetBlendShapeWeight(i);
        }
    }
}