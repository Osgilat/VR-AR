using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RoundManager : NetworkBehaviour
{
/*
    
    public Text text;

    [Command]
    public void CmdEndRound()
    {
        RpcEndRound();
    }

    public bool gamePaused = false;
    
    [ClientRpc]
    public void RpcEndRound()
    {
        gamePaused = true;
        //Time.timeScale = 0;
        
        MultiPlayer.instance.readyButton.SetActive(true);
        rpScontroller.ReactivateAll();
        multiPlayer.ReactivateAll();

        MultiPlayer.winnerSelected = false;
            
        if (!isServer)
        {
            return;
        }
        rpScontroller.clientRPS.SetActive(false);
        rpScontroller.serverRPS.SetActive(false);
        timeForEachRound = 3;
    }

    [ClientRpc]
    public void RpcGetReady()
    {
        rpScontroller.clientRPS.SetActive(false);
        rpScontroller.serverRPS.SetActive(false);
    }
    
    [ClientRpc]
    public void RpcAction()
    {
        rpScontroller.clientRPS.SetActive(true);
        rpScontroller.serverRPS.SetActive(true);
    }

    public Slider leftTimeSlider;
    public Slider rightTimeSlider;
    
    void Update()
    {
        if (gamePaused)
        {
            return;
        }
        
        //text.text = "Time Left:" + Mathf.Round(timeForEachRound);

        leftTimeSlider.value = 3 - timeForEachRound;
        rightTimeSlider.value = 3 - timeForEachRound;
        
        if (!isServer)
        {
            return;
        }
        //Debug.Log("WINNER SELECTED " + MultiPlayer.winnerSelected);
        
        if (MultiPlayer.isCelebrating)
        {
            return;
        }
        
        if(timeForEachRound < 0)
        {
            if (!MultiPlayer.winnerSelected)
            {
                if (MultiPlayer.instance.IsServerSelectedAny())
                {
                    MultiPlayer.instance.ServerWon();
                }
                else
                if (MultiPlayer.instance.isClientSelectedAny())
                {
                    MultiPlayer.instance.ClientWon();
                }
                else
                {
                    MultiPlayer.instance.NobodyWon();
                }

                MultiPlayer.winnerSelected = true;
                
                return;
            }
            
            RpcEndRound();
            return;    
        }

        if (timeForEachRound > 2.0f && timeForEachRound < 3.0f)
        {
            RpcGetReady();
        } else 
        
        if (timeForEachRound < 2.0f)
        {
            RpcAction();
        }
        
        
        
        timeForEachRound -= Time.deltaTime;
        
        
    }
    */
}
