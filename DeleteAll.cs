using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeleteAll : MonoBehaviour {

	// Use this for initialization
	public void Delete_All_Prefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
