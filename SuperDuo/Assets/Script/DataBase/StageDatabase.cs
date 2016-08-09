using UnityEngine;
using System.Collections.Generic;

public class StageDatabase : MonoBehaviour {

    //싱글 톤
    public static StageDatabase instance;
    //스테이지 정보 리스트
    public List<Stage> stages;

    void Start()
    {
        //싱글 톤 생성
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update () {
	
	}
}

public class Stage {

    public int ClearNum;
    public int Waves;
    public string Master;
    public float Stars;

}