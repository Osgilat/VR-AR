using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SinglePlayer : MonoBehaviour {
    public int random;
    public bool rockClicked; bool paperClicked; bool ScissorsClicked;
    public GameObject draw; public GameObject win; public GameObject lose;
    void Awake () {
        rockClicked = false;
        paperClicked = false;
        ScissorsClicked = false;
        random = Random.Range(1, 3);
        draw.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);


    }
    public void Exit()
    {
        Application.LoadLevel("MainMenu");
    }
    void Draw ()
    {
        StartCoroutine(drw());
    }
    IEnumerator drw ()
    {
        draw.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Awake();
    }
	void Update () {
        if (rockClicked == true && random == 1)
        {
            Draw();
        }
        if (paperClicked == true && random == 2)
        {
            Draw();
        }
        if (ScissorsClicked == true && random == 3)
        {
            Draw();
        }
        if (ScissorsClicked == true && random == 2)
        {
            P1Win();
        }
        if (ScissorsClicked == true && random == 1)
        {
            P2Win();
        }
        if (paperClicked == true && random == 1)
        {
            P1Win();
        }
        if (paperClicked == true && random == 3)
        {
            P2Win();
        }
        if (ScissorsClicked == true && random == 1)
        {
            P2Win();
        }
        if (ScissorsClicked == true && random == 2)
        {
            P1Win();
        }
        if (rockClicked == true && random == 2)
        {
            P2Win();
        }
        if (rockClicked == true && random == 3)
        {
            P1Win();
        }
    }
    void P1Win ()
    {
        StartCoroutine(Winp1());
    }
    IEnumerator Winp1 ()
    {
        win.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Awake();
    }
    void P2Win ()
    {
        StartCoroutine(Winp2());
    }
    IEnumerator Winp2()
    {
        lose.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        Awake();
    }

    public void Rock()
    {
        rockClicked = true;
    }

    public void Paper()
    {
        paperClicked = true;
    }

    public void Scissors()
    {
        ScissorsClicked = true;
    }
}
