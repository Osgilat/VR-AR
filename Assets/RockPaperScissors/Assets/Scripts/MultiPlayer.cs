using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MultiPlayer : NetworkBehaviour
{
    /*
    [SyncVar] public bool rockClicked1;

    private void Start()
    {
        roundManager = GetComponent<RoundManager>();
        rpScontroller = GetComponent<RPScontroller>();
    }

    [SyncVar] public bool paperClicked1;
    [SyncVar] public bool scissorsClicked1;
    [SyncVar] public bool rockClicked2;
    [SyncVar] public bool paperClicked2;
    [SyncVar] public bool scissorsClicked2;

    public GameObject p1win;
    public GameObject p2win;
    public GameObject draw;

    public static MultiPlayer instance;

    public RPScontroller rpScontroller;

    public void ReactivateAll()
    {
        rockClicked1 = false;
        paperClicked1 = false;
        scissorsClicked1 = false;

        rockClicked2 = false;
        paperClicked2 = false;
        scissorsClicked2 = false;
    }

    void Awake()
    {
        instance = this;

        ResetRound();
    }

    public void ResetRound()
    {

        ResetBools();
        
        p1win.gameObject.SetActive(false);
        p2win.gameObject.SetActive(false);
        draw.gameObject.SetActive(false);

        winnerSelected = false;


    }

    public void ResetBools()
    {
        
        rockClicked1 = false;
        paperClicked1 = false;
        scissorsClicked1 = false;

        rockClicked2 = false;
        paperClicked2 = false;
        scissorsClicked2 = false;
    }
    
    public void Rock1()
    {
        rockClicked1 = true;
        RpcRock1();
    }

    [ClientRpc]
    public void RpcRock1()
    {
        Debug.Log("PLAYER1_ROCK");
        rockClicked1 = true;
    }

    public void Rock2()
    {
        rockClicked2 = true;
        SetupLocalPlayer.localPlayerInstance.CmdRock2();
    }

    public void PauseGame()
    {
        SetupLocalPlayer.localPlayerInstance.CmdPauseGame();
    }

    public GameObject readyButton;
    
    public void ResumeGame()
    {
        readyButton.SetActive(false);
        
        if (isServer)
        {
            SetupLocalPlayer.localPlayerInstance.CmdResumeGame(true, false);
        }
        else
        {
            SetupLocalPlayer.localPlayerInstance.CmdResumeGame(false, true);
        }
        
        
    }


    public void Paper1()
    {
        paperClicked1 = true;
        RpcPaper1();
    }

    [ClientRpc]
    public void RpcPaper1()
    {
        Debug.Log("PLAYER1_PAPER");
        paperClicked1 = true;
    }


    public void Paper2()
    {
        paperClicked2 = true;
        SetupLocalPlayer.localPlayerInstance.CmdPaper2();
    }


    public void Scissors1()
    {
        scissorsClicked1 = true;
        RpcScissors1();
    }

    [ClientRpc]
    public void RpcScissors1()
    {
        Debug.Log("PLAYER1_SCISSORS");
        scissorsClicked1 = true;
    }

    public void Scissors2()
    {
        scissorsClicked2 = true;
        SetupLocalPlayer.localPlayerInstance.CmdScissors2();
    }


    void Update()
    {
        if
            //(isServer && 
            (rockClicked1 || paperClicked1 || scissorsClicked1)
            //  )
        {
            if (rockClicked1)
            {
                rpScontroller.serverScissors.SetActive(false);
                rpScontroller.serverRock.SetActive(true);
                rpScontroller.serverPaper.SetActive(false);
            }
            else if (paperClicked1)
            {
                rpScontroller.serverScissors.SetActive(false);
                rpScontroller.serverRock.SetActive(false);
                rpScontroller.serverPaper.SetActive(true);
            }
            else if (scissorsClicked1)
            {
                rpScontroller.serverScissors.SetActive(true);
                rpScontroller.serverRock.SetActive(false);
                rpScontroller.serverPaper.SetActive(false);
            }

        }
        else if
            (rockClicked2 || paperClicked2 || scissorsClicked2)
        {
            if (rockClicked2)
            {
                rpScontroller.clientScissors.SetActive(false);
                rpScontroller.clientRock.SetActive(true);
                rpScontroller.clientPaper.SetActive(false);
            }
            else if (paperClicked2)
            {
                rpScontroller.clientScissors.SetActive(false);
                rpScontroller.clientRock.SetActive(false);
                rpScontroller.clientPaper.SetActive(true);
            }
            else if (scissorsClicked2)
            {
                rpScontroller.clientScissors.SetActive(true);
                rpScontroller.clientRock.SetActive(false);
                rpScontroller.clientPaper.SetActive(false);
            }

            //GetComponent<RPScontroller>().localPanel.SetActive(false);
        }

        if (rockClicked1 && rockClicked2)
        {
            winnerSelected = true;
            StartCoroutine(Draw());
        }

        if (rockClicked1 && paperClicked2)
        {
            winnerSelected = true;
            StartCoroutine(P2Win());
        }

        if (rockClicked1 && scissorsClicked2)
        {
            winnerSelected = true;
            StartCoroutine(P1Win());
        }

        if (paperClicked1 && paperClicked2)
        {
            winnerSelected = true;
            StartCoroutine(Draw());
        }

        if (paperClicked1 && rockClicked2)
        {
            winnerSelected = true;
            StartCoroutine(P1Win());
        }

        if (paperClicked1 && scissorsClicked2)
        {
            winnerSelected = true;
            StartCoroutine(P2Win());
        }

        if (scissorsClicked1 && scissorsClicked2)
        {
            winnerSelected = true;
            StartCoroutine(Draw());
        }

        if (scissorsClicked1 && paperClicked2)
        {
            winnerSelected = true;
            StartCoroutine(P1Win());
        }

        if (scissorsClicked1 && rockClicked2)
        {
            winnerSelected = true;
            StartCoroutine(P2Win());
        }
    }

    public int p1WinCount = 0;
    public int p2WinCount = 0;


    public void ServerWon()
    {
        RpcServerWon();
    }

    [ClientRpc]
    public void RpcServerWon()
    {
        StartCoroutine(P1Win());
    }

    public void ClientWon()
    {
        RpcClientWon();
    }

    [ClientRpc]
    public void RpcClientWon()
    {
        StartCoroutine(P2Win());
    }

    public void NobodyWon()
    {
        RpcNobodyWon();
        
    }

    [ClientRpc]
    public void RpcNobodyWon()
    {
        StartCoroutine(Draw());
    }

    public bool IsServerSelectedAny()
    {
        return (rockClicked1 || paperClicked1 || scissorsClicked1);
    }


    public bool isClientSelectedAny()
    {
        return (rockClicked2 || paperClicked2 || scissorsClicked2);
    }

    public static bool winnerSelected = false;

    public static bool isCelebrating = false;
    private RoundManager roundManager;
    private RoundManager roundManager1;

    public ScoreSlider serverScore;
    public ScoreSlider clientScore;
    
    IEnumerator P1Win()
    {
        p1win.gameObject.SetActive(true);
        
        ResetBools();

        isCelebrating = true;

        yield return new WaitForSeconds(1f);

        isCelebrating = false;

        p1WinCount++;
        
        serverScore.IncrementSlider(p1WinCount);

        Debug.Log("PLAYER1_WIN");
        roundManager.CmdEndRound();
        ResetRound();
    }

    IEnumerator P2Win()
    {
        p2win.gameObject.SetActive(true);
        
        ResetBools();

        isCelebrating = true;

        yield return new WaitForSeconds(1f);

        isCelebrating = false;

        p2WinCount++;
        
        clientScore.IncrementSlider(p2WinCount);

        Debug.Log("PLAYER2_WIN");
        roundManager.CmdEndRound();
        ResetRound();
    }

    IEnumerator Draw()
    {
        draw.gameObject.SetActive(true);
        
        ResetBools();

        isCelebrating = true;

        yield return new WaitForSeconds(1f);

        isCelebrating = false;

        Debug.Log("DRAW");
        roundManager.CmdEndRound();
        ResetRound();
    }
    */
}
