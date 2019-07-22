using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Catalogue : MonoBehaviour{

    public int EndPrice = 0;

    public GameObject Foods; //The childs of Foods 
    public GameObject ChosenFood; //Parent
    
    public GameObject DetailsToCopy; //The child we will use to take its details
    
    public Text Price;
    public Text CataloguePrice;

    public GameObject ObjScriptMainCamera; //access the script from MainCamera so we can use the list from SceneChanger **

    public void CreateNew(){



        Text DetailsToCopyText = DetailsToCopy.GetComponentInChildren<Text>(); //get text of child and save it to DetailsToCopyText
        Text FoodsText = Foods.GetComponentInChildren<Text>(); //get text of child and save it to FoodsText

        string details = DetailsToCopyText.text;
        FoodsText.text = details;

        CataloguePrice.text = Price.text;

        GameObject food = Instantiate(Foods) as GameObject; ///here

        food.transform.parent = ChosenFood.transform; //object1 is now the child of object2 ///here
                                                      //object1                   //object2   


        //save the above variable in list and via playerprefs
 
        SceneChanger FoodList = ObjScriptMainCamera.GetComponent<SceneChanger>(); //to access the variables inside SceneChanger **
        
        FoodList.FoodPrices.Add(CataloguePrice.text);//Add the current price to the FoodPrices list
        FoodList.FoodNames.Add(details);//Add the current price to the FoodNames list

        PlayerPrefs.SetString("Price" + FoodList.Counter + FoodList.Scene_Identifier, CataloguePrice.text); //save the price of the food
        PlayerPrefs.SetString("Food" + FoodList.Counter + FoodList.Scene_Identifier, details); //save the name of the food

        FoodList.Counter++; //add to the public counter so we can navigate through PlayerPrefs and  

        PlayerPrefs.SetInt("Counter" + FoodList.Scene_Identifier, FoodList.Counter);
        

    }

}
