using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour {

    //public GameObject FinalPriceObj2;
    public GameObject FinalPriceObj;
    public GameObject FinalPriceObjScript;

    public Transform ChildCountTransform; //parent of those childs
    //public GameObject ChildCountObj; //parent of those childs
    public Text NameOfFood;
    
    public GameObject MainCameraObjScript; //camera
    
    public Text CataloguePrice;
    public GameObject Foods; //The childs of Foods 
    public GameObject ChosenFood;

    public void Start()
    {
        SceneChanger FoodList = MainCameraObjScript.GetComponent<SceneChanger>();

        Scene currentScene = SceneManager.GetActiveScene();
        // Retrieve the name of this scene.
        FoodList.Scene_Identifier = currentScene.name;
        

        try
        {
            


            Text FinalPriceText = FinalPriceObj.GetComponent<Text>();//intantiate the FinalPriceObj as FinalPriceText
            FinalPriceText.text = PlayerPrefs.GetString("FinalPrice" + FoodList.Scene_Identifier);//get the saved string and save it to the one in the scene

            SceneChanger savethefinalprice = FinalPriceObjScript.GetComponent<SceneChanger>();//intantiate the FinalPriceObjScript as savethefinalprice
            savethefinalprice.FinalPriceVariable = PlayerPrefs.GetFloat("FinalPriceData" + FoodList.Scene_Identifier, 0); //get the total we had before and recreate it by saving it to the main variable we used
                                                                                            //Debug.Log(FinalPrice.FinalPriceVariable);

            for (int i = 0; i < 100; i++)//FoodList.Counter = 20?
            {
                //int HowManySaved = 0;

                if (PlayerPrefs.HasKey("Food" + i + FoodList.Scene_Identifier)) //we check if the foods are more than what they should to solve the duplication problem
                {
                    FoodList.FoodNames.Add(PlayerPrefs.GetString("Food" + i + FoodList.Scene_Identifier));
                    FoodList.FoodPrices.Add(PlayerPrefs.GetString("Price" + i + FoodList.Scene_Identifier));
                  
                    Text FoodsText = Foods.GetComponentInChildren<Text>();

                    string Listed_food = FoodList.FoodNames[i];
                    string Listed_price = FoodList.FoodPrices[i];

                    string details = Listed_food;
                    FoodsText.text = details;

                    CataloguePrice.text = Listed_price;

                    GameObject food = Instantiate(Foods) as GameObject; ///here

                    food.transform.parent = ChosenFood.transform;

                    PlayerPrefs.DeleteKey("Food" + i + FoodList.Scene_Identifier);
                    PlayerPrefs.DeleteKey("Price" + i + FoodList.Scene_Identifier);

                }
            }
        }
        catch
        {
            Debug.Log("Maybe another list problem(SaveData script)");
        }        
    }


    public void Save_For_Reload()
    {
        SceneChanger FoodList = MainCameraObjScript.GetComponent<SceneChanger>();

        for(int i = 0; i < FoodList.FoodNames.Count; i++)
        {
                        
            PlayerPrefs.SetString("Price" + i + FoodList.Scene_Identifier, FoodList.FoodPrices[i]); //save the price of the food
            PlayerPrefs.SetString("Food" + i + FoodList.Scene_Identifier, FoodList.FoodNames[i]);

            
            
        }       
    }

    public void Save()//save all the needed data and the use them again on the Start Method above
    {
        SceneChanger FoodList = MainCameraObjScript.GetComponent<SceneChanger>();

        SceneChanger savethefinalprice = FinalPriceObjScript.GetComponent<SceneChanger>();//intantiate the FinalPriceObjScript as savethefinalprice
        Text FinalPriceText = FinalPriceObj.GetComponent<Text>();//intantiate the FinalPriceObj as FinalPriceText

        string finalptext = FinalPriceText.text;//make finalptext equal to the FinalPriceText for easier understanding
       
        PlayerPrefs.SetString("FinalPrice" + FoodList.Scene_Identifier, finalptext);//set the key as FinalPrice and use it to save the finalptext or FinalPriceText
        PlayerPrefs.SetFloat("FinalPriceData" + FoodList.Scene_Identifier, savethefinalprice.FinalPriceVariable);//set the key as FinalPriceData and use it to save the savethefinalprice.FinalPriceVariable
                
        int HowManyKids = ChildCountTransform.childCount;
        PlayerPrefs.SetInt("NumberOfChilds" + FoodList.Scene_Identifier, HowManyKids);

        
             
    }


}

  




