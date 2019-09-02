using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;


public class SyncBlendshapes : NetworkBehaviour
{/*
    public class BlendshapesSyncClass : SyncListStruct<SyncListBlendshapeState>
    {
    }

    public BlendshapesSyncClass blendshapesSyncList = new BlendshapesSyncClass();

    public struct SyncListBlendshapeState
    {
        public int blendShapeIndex;
        public float blendShapeValue;
    }


    public SkinnedMeshRenderer skinnedMeshRenderer;

    private void Start()
    {
        PopulateBlendshapes();
        //InvokeRepeating("SyncBlendshapesNow", 5, 0.5f);
    }

    public bool badBool = false;
    
    private void Update()
    {
        if (badBool)
        {
            badBool = false;
            SyncBlendshapesNow();
        }
    }

    public void SyncBlendshapesNow()
    {
        BlendshapesSyncClass temp = new BlendshapesSyncClass();
        for (int i = 0; i < 50; i++)
        {
            temp.Add(new SyncListBlendshapeState{blendShapeIndex = i, blendShapeValue = skinnedMeshRenderer.GetBlendShapeWeight(i)});
        }

        blendshapesSyncList = temp;
    }

    public void PopulateBlendshapes()
    {
        for (int i = 0; i < 50; i++)
        {
            CmdAddStructToList(i, skinnedMeshRenderer.GetBlendShapeWeight(i));
        }
        
    }

    [Command]
    public void CmdAddStructToList(int _blendShapeIndex, float _blendShapeValue)
    {
        RpcAddStructToList(_blendShapeIndex, _blendShapeValue);
    }

    [ClientRpc]
    public void RpcAddStructToList(int _blendShapeIndex, float _blendShapeValue)
    {
        blendshapesSyncList.Add(new SyncListBlendshapeState {blendShapeIndex = _blendShapeIndex, blendShapeValue = _blendShapeValue});
    }
    */
}