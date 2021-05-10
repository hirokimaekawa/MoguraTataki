using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public MoguraGenerator moguraGenerator1;
    public MoguraGenerator moguraGenerator2;
    public MoguraGenerator moguraGenerator3;

    public Text scoreText;
    public Text leftTimeText;

    public GameObject resultPanal;
    public Text finalText;
    int score;
    string playTime;
    float leftTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreateMogura1");
        StartCoroutine("CreateMogura2");
        StartCoroutine("CreateMogura3");
        scoreText.text = "得点：" + score;
        resultPanal.SetActive(false);
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        playTime = System.DateTime.Now.ToString();
        //1秒に1秒ずつ減らしていく
        leftTime -= Time.deltaTime;
        //マイナスは表示しない
        if (leftTime < 0) leftTime = 0;

        leftTimeText.text = "残り時間：" + ((int)leftTime).ToString(); 
        if (leftTime <= 0)
        {
            resultPanal.SetActive(true);
            finalText.text = scoreText.text;
            //Debug.Log("時間になった");
            //Debug.Log(score);
            //Debug.Log(playTime);
            Record();
        }

      
        
    }
    IEnumerator CreateMogura1()
    {
        yield return new WaitForSeconds(0.5f);
        moguraGenerator1.SpawnMogura();
    }
    IEnumerator CreateMogura2()
    {
        yield return new WaitForSeconds(1.0f);
        moguraGenerator2.SpawnMogura();
    }
    IEnumerator CreateMogura3()
    {
        yield return new WaitForSeconds(1.5f);
        moguraGenerator3.SpawnMogura();
    }

    public void AddScore()
    {
        score += 10;

        scoreText.text = "得点:" + score;
    }

    void InitScore()
    {
        //スコア初期化
        score = 0;
    }


    public void OnTitleButton()
    {
        SceneManager.LoadScene("Title");
        InitScore();
        
    }
    public void OnRetryButton()
    {
        SceneManager.LoadScene("Main");
        InitScore();
        
    }

    string SAVEKEY1 = "PLAY-TIME-KEY";
    string SAVEKEY2 = "SCORE-KEY";

    void Record()
    {
        PlayerPrefs.SetString(SAVEKEY1, playTime);
        PlayerPrefs.SetInt(SAVEKEY2,score);
        PlayerPrefs.Save();
    }
    void Load()
    {
        PlayerPrefs.GetString(SAVEKEY1, playTime);
        PlayerPrefs.GetInt(SAVEKEY2,score);
        Debug.Log(score);
        Debug.Log(playTime);
        Debug.Log("ロードした");
       
    }

    /*void DeleteSaveData()
    {
        PlayerPrefs.SetString(SAVEKEY1, playTime);
        PlayerPrefs.Save();
    }*/


}
