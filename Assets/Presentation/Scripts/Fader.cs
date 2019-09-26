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

    public GameObject nextSlideButton;
    public GameObject previousSlideButton;

    public Sprite[] mySlides;
    
    // Use this for initialization
    void Start()
    {
        sprites.Clear();
        //Sprite[] spriteList = Resources.LoadAll<Sprite>("sprites");
        Sprite[] spriteList = mySlides;
        Debug.Log("Sprite list : " + spriteList.Count());
        for (int i = 0; i < spriteList.Length; i++)
        {
            if (!sprites.ContainsKey(spriteList[i].name))
            {
                sprites.Add(spriteList[i].name, spriteList[i]);
            }
        }
        
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

    public AudioSync audioSync;
    public void ChangeSlide()
    {
        currentSlide = Mathf.Clamp(currentSlide, 0, sprites.Keys.Count - 1);
        string spriteKey = Enumerable.ToList(sprites.Keys)[currentSlide];
        rendy1.sprite = sprites[spriteKey];
        
        audioSync.PlayAudioMessageForSlide(currentSlide);
        
        //image.sprite = sprites[spriteKey];
    }
    
    public bool badBoolNext = false;

    public bool badBoolPrev = false;

    public bool badBoolShowInterface = false;
    
    
    void Update()
    {
        if (Application.isMobilePlatform || badBoolShowInterface)
        {
            nextSlideButton.SetActive(currentSlide < (sprites.Keys.Count - 1));
            previousSlideButton.SetActive(currentSlide > 0);
        }
        else
        {
            nextSlideButton.SetActive(false);
            previousSlideButton.SetActive(false);
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