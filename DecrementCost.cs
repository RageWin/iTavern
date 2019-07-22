using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecrementCost : MonoBehaviour
{
    public GameObject StartingPriceDownCatalogue;
    public GameObject FinalPriceLowerPart;
    public GameObject StartingPriceScript;
    


    public void Calculator()
    {
        Text StartPriceDown = StartingPriceDownCatalogue.GetComponent<Text>(); //Instantiate the StartingPriceDownCatalogue
   
        SceneChanger FinalPrice = StartingPriceScript.GetComponent<SceneChanger>();
        Text FinalPriceText = FinalPriceLowerPart.GetComponent<Text>();

        FinalPrice.FinalPriceVariable -= float.Parse(StartPriceDown.text);//Decrement off the final result every food chosen
        FinalPriceText.text = (FinalPrice.FinalPriceVariable).ToString();
    }
}
