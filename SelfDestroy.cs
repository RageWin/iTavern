using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfDestroy : MonoBehaviour
{
    public GameObject MainCameraScript; //To access the list inside the SceneChanger script
    public GameObject FoodTextToRemove;//Access the name of the food we are going to remove/destroy
   
    public void Delete_This()
    {
        Text FoodText = FoodTextToRemove.GetComponentInChildren<Text>();
        
        SceneChanger FoodList = MainCameraScript.GetComponent<SceneChanger>();

        for(int i = 0; i < FoodList.FoodNames.Count; i++)
        {
            string new_pref_food_str = FoodList.FoodNames[i];

            if (new_pref_food_str == FoodText.text)
            {               

                PlayerPrefs.DeleteKey("Food" + i + FoodList.Scene_Identifier);
                PlayerPrefs.DeleteKey("Price" + i + FoodList.Scene_Identifier);

                FoodList.FoodNames.Remove(FoodList.FoodNames[i]);
                FoodList.FoodPrices.Remove(FoodList.FoodPrices[i]);
                break;

            }            

            
        }
        Destroy(gameObject);

    }
}
