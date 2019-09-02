using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button singlePlayerButton;
    public Button multiPlayerButton;
    public Button exitButton;
    int randomS;
    int randomM;
    int randomE;

    void Awake()
    {
        randomS = Random.Range(1, 4);
        randomM = Random.Range(1, 4);
        exitButton.image.color = Color.red;
    }

    void Start()
    {
        if (randomM == randomS)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void Update()
    {
        if (randomS == 1)
            singlePlayerButton.image.color = Color.white;
        if (randomS == 2)
            singlePlayerButton.image.color = Color.green;
        if (randomS == 3)
            singlePlayerButton.image.color = Color.yellow;
        if (randomS == 4)
            singlePlayerButton.image.color = Color.white;
        //
        if (randomM == 1)
            singlePlayerButton.image.color = Color.white;
        if (randomM == 2)
            singlePlayerButton.image.color = Color.green;
        if (randomM == 3)
            singlePlayerButton.image.color = Color.yellow;
        if (randomM == 4)
            singlePlayerButton.image.color = Color.white;
    }

    public void SinglePlayer()
    {
        Application.LoadLevel("SinglePlayer");
    }

    public void MultiPlayer()
    {
        Application.LoadLevel("MultiPlayer");
    }

    public void Quit()
    {
        Application.Quit();
    }
}