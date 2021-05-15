using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HogeHoge : MonoBehaviour
{
    string KEY = "KEY";
    string TimeKEY = "TimeKEY";

    void Start()
    {
        SaveScore(UnityEngine.Random.Range(-10, 10));
        SaveTime(DateTime.Now.ToString());


        string[] times = PlayerPrefsX.GetStringArray(TimeKEY);  //[0,0,0]
        int[] scores = PlayerPrefsX.GetIntArray(KEY);  //[0,0,0]

        for (int i = 0; i < scores.Length; i++)
        {
            Debug.Log($"得点:{scores[i]} 時間:{times[i]}");
            // aaa.text = $"得点:{scores[i]} 時間:{times[i]}";
        }
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