using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour {

    public Button level01;
    public GameObject gameObjectv, imagesone, imagestwo, images3, images4, images5, images6, images7, images8, images9, images10, images11, imagesone_b, images1f, images1_R;
    //public  SpriteRenderer sr;
    public Sprite Penguins;
    Image Imagechange;

    public float zRotation = 5.0F;
	// Use this for initialization
	void Start () {
      //  level01 = GameObject.Find("Alexandarvv");
        level01 = GameObject.Find("level01").GetComponent<Button>();
        gameObjectv = GameObject.Find("GameObject");

        imagesone = GameObject.Find("imagesone");
        images1f = GameObject.Find("images1f");
        images1_R = GameObject.Find("images1_R");

        imagesone_b = GameObject.Find("imagesone_b");

        imagestwo = GameObject.Find("imagestwo");

        images3 = GameObject.Find("images3");
        images4 = GameObject.Find("images4");

        images5 = GameObject.Find("images5");
        images6 = GameObject.Find("images6");

        images7 = GameObject.Find("images7");
        images8 = GameObject.Find("images8");

        images9 = GameObject.Find("images9");
        images10 = GameObject.Find("images10");

        images11 = GameObject.Find("images11");
     
      //  imagesone.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (imagesone.active)
        {
          

            imagestwo.SetActive(false);


            images3.SetActive(false);
            images4.SetActive(false);

            images5.SetActive(false);
            images6.SetActive(false);

            images7.SetActive(false);
            images8.SetActive(false);

            images9.SetActive(false);
            images10.SetActive(false);

            images11.SetActive(false);
        }
	}

    void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = 40;

        if (GUI.Button(new Rect(Screen.width - 250f, 20f, 70f, 50f), "+", myButtonStyle))
        {
            if (imagesone.active)
            {
                imagesone.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }
            else if (imagestwo.active)
            {

                imagestwo.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images3.active)
            {

                images3.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images4.active)
            {

                images4.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images5.active)
            {

                images5.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images6.active)
            {

                images6.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images7.active)
            {

                images7.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images8.active)
            {

                images8.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }
            else if (images9.active)
            {

                images9.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images10.active)
            {

                images10.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images11.active)
            {

                images11.gameObject.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }
         }

        if (GUI.Button(new Rect(Screen.width - 350f, 20f, 70f, 50f), "-", myButtonStyle))
        {
            if (imagesone.active)
            {
                imagesone.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }
            else if (imagestwo.active)
            {

                imagestwo.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }


            else if (images3.active)
            {

                images3.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images4.active)
            {

                images4.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images5.active)
            {

                images5.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images6.active)
            {

                images6.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images7.active)
            {

                images7.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images8.active)
            {

                images8.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }
            else if (images9.active)
            {

                images9.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images10.active)
            {

                images10.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }

            else if (images11.active)
            {

                images11.gameObject.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            }
        }
        if (GUI.Button(new Rect(Screen.width - 450f, 20f, 70f, 50f), "R", myButtonStyle))
        {
            zRotation += Input.GetAxis("Horizontal");
            if (imagesone.active)
            {
                imagesone.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (imagestwo.active)
            {

                imagestwo.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images3.active)
            {

                images3.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images4.active)
            {

                images4.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images5.active)
            {

                images5.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images6.active)
            {

                images6.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images7.active)
            {

                images7.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images8.active)
            {

                images8.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }
            else if (images9.active)
            {

                images9.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images10.active)
            {

                images10.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }

            else if (images11.active)
            {

                images11.gameObject.transform.eulerAngles += new Vector3(0, 0, zRotation);
            }
        }

       
    }


    public void GazeEnterEvent()
    {

        imagesone.SetActive(true);
        images1f.SetActive(true);
        imagesone_b.SetActive(true);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);
    }

    public void GazeEnterEventtwo()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(true);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);
       
    
    }


    public void Gazeimages3()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(true);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);


    }

    public void Gazeimages4()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(true);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);


    }
    public void Gazeimages5()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(true);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);


    }


    public void Gazeimages6()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(true);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);


    }


    public void Gazeimages7()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(true);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);


    }


    public void Gazeimages8()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(true);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(false);


    }

    public void Gazeimages9()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(true);
        images10.SetActive(false);
        images11.SetActive(false);


    }

    public void Gazeimages10()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(true);
        images11.SetActive(false);


    }

    public void Gazeimages11()
    {
        imagesone.SetActive(false);
        imagestwo.SetActive(false);
        images3.SetActive(false);
        images4.SetActive(false);
        images5.SetActive(false);
        images6.SetActive(false);
        images7.SetActive(false);
        images8.SetActive(false);
        images9.SetActive(false);
        images10.SetActive(false);
        images11.SetActive(true);


    }
}
