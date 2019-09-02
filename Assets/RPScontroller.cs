using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RPScontroller : NetworkBehaviour
{
    public GameObject serverRPS;
    public GameObject clientRPS;

    public GameObject localPanel;

    public GameObject serverScissors;
    public GameObject serverRock;
    public GameObject serverPaper;

    public GameObject clientScissors;
    public GameObject clientRock;
    public GameObject clientPaper;

    public static RPScontroller instance;

    public void ReactivateAll()
    {
        serverScissors.SetActive(true);
        serverRock.SetActive(true);
        serverPaper.SetActive(true);

        clientScissors.SetActive(true);
        clientRock.SetActive(true);
        clientPaper.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (isServer)
        {
            //serverRPS.SetActive(true);
            foreach (Transform obj in clientRPS.transform)
            {
                if (obj.GetComponent<Button>())
                {
                    obj.GetComponent<Button>().enabled = false;
                }
            }

            localPanel = serverRPS;
        }
        else
        {
            //clientRPS.SetActive(true);
            foreach (Transform obj in serverRPS.transform)
            {
                if (obj.GetComponent<Button>())
                {
                    obj.GetComponent<Button>().enabled = false;
                }
            }

            localPanel = clientRPS;
        }


        localPanel.SetActive(true);
    }
}
