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

        string[] times = PlayerPrefsX.GetStringArray(TimeKEY);  //[0,0,0]
        int[] scores = PlayerPrefsX.GetIntArray(KEY);  //[0,0,0]

        for (int i = 0; i < scores.Length; i++)
        {
            Debug.Log($"得点:{scores[i]} 時間:{times[i]}");
            // aaa.text = $"得点:{scores[i]} 時間:{times[i]}";
        }
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
        if (leftTime == 0)
        {
            resultPanal.SetActive(true);
            finalText.text = scoreText.text;
            //Debug.Log("時間になった");
            //Debug.Log(score);
            //Debug.Log(playTime);
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
        SaveScore(score);
        SaveTime(DateTime.Now.ToString());
        InitScore();
        
    }
    public void OnRetryButton()
    {
        SceneManager.LoadScene("Main");
        SaveScore(score);
        SaveTime(DateTime.Now.ToString());
        InitScore();
        
    }

    string KEY = "KEY";
    string TimeKEY = "TimeKEY";

    void Record()
    {
        //PlayerPrefs.SetString(SAVEKEY1, playTime);
        //PlayerPrefs.SetInt(SAVEKEY2,score);
        //PlayerPrefs.Save();
    }
    void Load()
    {
        //PlayerPrefs.GetString(SAVEKEY1, playTime);
        //PlayerPrefs.GetInt(SAVEKEY2,score);
        //Debug.Log(score);
        //Debug.Log(playTime);
        //Debug.Log("ロードした");
       
    }

    void SaveTime(string time)
    {
        string[] times = PlayerPrefsX.GetStringArray(TimeKEY);  //[0,0,0]// 取得
        times = Add(times, time);// 新しい得点を追加
        Debug.Log(string.Join(",", times)); // 配列の要素を,区切りのstring型で表示する
        PlayerPrefsX.SetStringArray(TimeKEY, times); // 保存
    }


    // 追加するための関数
    string[] Add(string[] array, string point)
    {
        List<string> tmp = array.ToList();// リストへ変換
        tmp.Add(point);
        return tmp.ToArray();// 配列に戻す
    }



    void SaveScore(int score)
    {
        // 取得
        int[] scores = PlayerPrefsX.GetIntArray(KEY);  //[0,0,0]
        scores = Add(scores, score);// 新しい得点を追加
        Debug.Log(string.Join(",", scores)); // 配列の要素を,区切りのstring型で表示する
        PlayerPrefsX.SetIntArray(KEY, scores);// 保存
    }


    // 追加するための関数
    int[] Add(int[] array, int point)
    {
        List<int> tmp = array.ToList();// リストへ変換
        tmp.Add(point);
        return tmp.ToArray();// 配列に戻す
    }

}
