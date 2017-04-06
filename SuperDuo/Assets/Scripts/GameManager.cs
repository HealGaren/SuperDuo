using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Text scoreText, time;
    public float times;

    public GameObject blue, black, GameOver;

    public static int Score;
    public static int die;

    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        InvokeRepeating("heal", 0f, 10f);
    }

    void Update()
    {
        scoreText.text = "Score : " + Score.ToString();
        times += Time.deltaTime;
        time.text = string.Format("{0:00}:{1:00}", (int)(times / 60), (int)(times % 60));
    }

    void heal()
    {
        blue.GetComponent<Player>().HP += 5;
        black.GetComponent<Player>().HP += 5;

        blue.GetComponent<Player>().HP = Mathf.Clamp(blue.GetComponent<Player>().HP, 0, 100);
        black.GetComponent<Player>().HP = Mathf.Clamp(blue.GetComponent<Player>().HP, 0, 100);
    }

    public void Die()
    {
        if (die + 1 >= 2) {
            GameOver.SetActive(true);
            if (Score - PlayerPrefs.GetInt("Score") > 0) {
                GameOver.transform.GetChild(2).GetComponent<Text>().text = "신 기록!";
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.SetString("Time", time.text);
            }
            GameOver.transform.GetChild(3).GetComponent<Text>().text = Score.ToString();
            GameOver.transform.GetChild(5).GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();
            Invoke("Over", 2f);
        }
        else
            ++die;
    }

    void Over()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }




}
