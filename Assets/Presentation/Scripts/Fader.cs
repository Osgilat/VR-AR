using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Networking;
using UnityEngine.UI;
using Valve.VR;

public class Fader : NetworkBehaviour
{
    private static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    public GameObject slideGameobject;
    
    
    private GameObject slideObj;
    SpriteRenderer rendy1;

    // Use this for initialization
    void Start()
    {
        sprites.Clear();
        Sprite[] spriteList = Resources.LoadAll<Sprite>("sprites");
        Debug.Log("Sprite list : " + spriteList.Count());
        for (int i = 0; i < spriteList.Length; i++)
        {
            if (!sprites.ContainsKey(spriteList[i].name))
            {
                sprites.Add(spriteList[i].name, spriteList[i]);
            }
        }

        /*
        slideObj = new GameObject();
        slideObj.transform.position = new Vector3(0, 0, 2f);
        rendy1 = slideObj.AddComponent<SpriteRenderer>();
        */
        
        slideObj = slideGameobject;
        rendy1 = slideObj.GetComponent<SpriteRenderer>();
        
        string spriteKey = Enumerable.ToList(sprites.Keys)[0];
        rendy1.sprite = sprites[spriteKey];

        currentSlide = 0;
    }

    [SyncVar(hook = nameof(OnSlideChanged))]
    public int currentSlide = 0;

    public Image image;
    
    
    [Command]
    public void CmdToNextSlide()
    {
        RpcToNextSlide();
    }

    [ClientRpc]
    public void RpcToNextSlide()
    {
        currentSlide++;

        ChangeSlide();
    }

    [Command]
    public void CmdToPreviousSlide()
    {
        RpcToPreviousSlide();
    }
    
    [ClientRpc]
    public void RpcToPreviousSlide()
    {
        currentSlide--;

        ChangeSlide();
    }

    public void OnSlideChanged(int valueToChangeTo)
    {
        currentSlide = valueToChangeTo;
        
        ChangeSlide();
    }

    
    public void ChangeSlide()
    {
        currentSlide = Mathf.Clamp(currentSlide, 0, sprites.Keys.Count - 1);
        string spriteKey = Enumerable.ToList(sprites.Keys)[currentSlide];
        rendy1.sprite = sprites[spriteKey];
        //image.sprite = sprites[spriteKey];
    }
    
    public bool badBoolNext = false;

    public bool badBoolPrev = false;


    void Update()
    {
        if (SetupLocalPlayer.vrInitialized && !Application.isMobilePlatform)
        {
            if (SteamVR_Actions._default.GrabPinch.GetLastStateDown(SteamVR_Input_Sources.RightHand))
            {
                CmdToNextSlide();

                return;
            }

            if (SteamVR_Actions._default.GrabPinch.GetLastStateDown(SteamVR_Input_Sources.LeftHand))
            {
                CmdToPreviousSlide();

                return;
            }
        }
        
        if (badBoolNext)
        {
            badBoolNext = false;

            CmdToNextSlide();
        }

        if (badBoolPrev)
        {
            badBoolPrev = false;

            CmdToPreviousSlide();
        }
    }
}