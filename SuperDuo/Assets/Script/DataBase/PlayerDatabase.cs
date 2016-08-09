using UnityEngine;
using System.Collections;

public class PlayerDatabase : MonoBehaviour {

    //싱글 톤
    public static PlayerDatabase instance;

	
	void Start () {
        //싱글 톤 생성
        if (instance == null)
            instance = this;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
