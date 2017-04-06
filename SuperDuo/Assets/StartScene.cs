using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0) {
            SceneManager.LoadScene(1, LoadSceneMode.Single);    
        }

	}
}
