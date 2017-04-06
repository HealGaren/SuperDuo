using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public Text scoreTxt,timeTxt;

	// Use this for initialization
	void Start () {
        scoreTxt.text = PlayerPrefs.GetInt("Score").ToString();
        timeTxt.text = PlayerPrefs.GetString("Time").ToString();
    }

    public void GO() {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
	
}
