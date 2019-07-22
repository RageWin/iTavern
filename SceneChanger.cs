using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public float FinalPriceVariable = 0;
    public int Counter = 0;

    public List<string> FoodPrices = new List<string>() { };
    public List<string> FoodNames = new List<string>() { };

    public string Scene_Identifier = "";
    

    public void changeScene(string scene_name){
		
        SceneManager.LoadScene(scene_name);
        
    }


}
