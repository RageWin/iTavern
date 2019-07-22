using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCost : MonoBehaviour {


    public GameObject StartingPriceUpCatalogue;
    public GameObject StartingPriceDownCatalogue;
    public GameObject FinalPriceLowerPart;
    public GameObject StartingPriceScript;


    public void Calculator()
    {
        

        Text StartPriceUp = StartingPriceUpCatalogue.GetComponent<Text>(); //Instantiate the StartingPriceUpCatalogue
        Text StartPriceDown = StartingPriceDownCatalogue.GetComponent<Text>(); //Instantiate the StartingPriceDownCatalogue

        StartPriceDown.text = StartPriceUp.text;//Make the price of the food chosen to be copied on the DownCatalogue

        SceneChanger FinalPrice = StartingPriceScript.GetComponent<SceneChanger>();
        Text FinalPriceText = FinalPriceLowerPart.GetComponent<Text>();

        FinalPrice.FinalPriceVariable += float.Parse(StartPriceUp.text);//Add to the final result every food chosen
        FinalPriceText.text = (FinalPrice.FinalPriceVariable).ToString();

    }


}
