using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MoguraGenerator moguraGenerator1;
    public MoguraGenerator moguraGenerator2;
    public MoguraGenerator moguraGenerator3;

    public Text scoreText;
    public Text leftTimeText;

    public GameObject resultPanal;
    public Text finalText;
    int score = 0;
    float leftTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreateMogura1");
        StartCoroutine("CreateMogura2");
        StartCoroutine("CreateMogura3");
        scoreText.text = "得点：" + score;
        resultPanal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //1秒に1秒ずつ減らしていく
        leftTime -= Time.deltaTime;
        //マイナスは表示しない
        if (leftTime < 0) leftTime = 0;

        leftTimeText.text = "残り時間：" + ((int)leftTime).ToString(); 
        if (leftTime <= 0)
        {
            resultPanal.SetActive(true);
            finalText.text = scoreText.text;
        }

        //resultPanal.activeSelf == trueの時に、クリックできなくするか
        if (resultPanal.activeSelf == true)
        {

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
}
