using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
   //to use this add first a slider to your canvas in the editor.
   public GameObject sliderObject; //attachs this to the slider gameobject in  the editor or use Gameobject.Find
   Slider slider;
   public int score;
   public int maxScore = 50; //insert your maxium time
   
   void Start()
   {
       sliderObject = gameObject;
       
       slider = sliderObject.GetComponent<Slider>();
       
       slider.maxValue = maxScore;
   }

   public void IncrementSlider(int newScore)
   {
       if (newScore < maxScore)
       {
           slider.value = newScore;
       }
   }

   public bool badBool = false;
   
   void Update()
   {
       if (badBool)
       {
           badBool = false;

           slider.value = score;
       }
   }
   
}
