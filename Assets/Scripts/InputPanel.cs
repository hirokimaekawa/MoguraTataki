using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;


public class InputPanel : MonoBehaviour
{
    [SerializeField] Text nameText = default;
    string userName = "";

    // 50音のボタンを生成する
    [SerializeField] GameObject inputButton = default;
    string[] mojiArray = {
        "あ", "い", "う", "え", "お",
        "か", "き", "く", "け", "こ",
        "さ", "し", "す", "せ", "そ",
        "た", "ち", "つ", "て", "と",
        "な", "に", "ぬ", "ね", "の",
        "は", "ひ", "ふ", "へ", "ほ",
        "ま", "み", "む", "め", "も",
        "や", "", "ゆ", "", "よ",
        "ら", "り", "る", "れ", "ろ",
        "わ", "", "を", "", "ん",
    };


    private void Start()
    {
        Spawns();
    }

    public void Spawns()
    {
        for (int i = 0; i < 50; i++)
        {
            // 生成
            GameObject buttonObj = Instantiate(inputButton, transform);

            InputButton button = buttonObj.GetComponent<InputButton>();
            button.inputPanel = this;

            // 文字の変更
            buttonObj.GetComponentInChildren<Text>().text = mojiArray[i];
        }
    }

    public void OnInput(string moji)
    {
        userName += moji;
        nameText.text = userName;
    }

    public void OnDeleteButton()
    {
        userName = userName.Remove(userName.Length - 1);
        nameText.text = userName;
    }
    public void OnSubmitButton()
    {
        Debug.Log("決定:" + userName);
        SaveUserName(userName);
        SceneManager.LoadScene("Title");
    }

    public void OnDakutenButton()
    {
        //一回目のボタン入力　flag= true
        //文字入力された文字がか行、さ行、た行、は行なら
        //if ()
        //{
        //    //がぎぐげこ、ざじずぜぞ、だぢづでど、ばびぶべぼに変換する
        //}

        ////二回目のボタン入力　flag = false
        //else if ()
        //{
        //    //がぎぐげご→かきくけこに戻す
        //}

    }

    public void OnHanDakutenButton()
    {

    }

    public void OnKomojiButton()
    {

    }

    string UserNameKEY = "UserNameKEY";

    // 追加するための関数
    string[] Add(string[] array, string point)
    {
        List<string> tmp = array.ToList();// リストへ変換
        tmp.Add(point);
        return tmp.ToArray();// 配列に戻す
    }

    void SaveUserName(string name)
    {
        string[] names = PlayerPrefsX.GetStringArray(UserNameKEY);  //[0,0,0]// 取得
        names = Add(names, name);// 新しい得点を追加
        Debug.Log(string.Join(",", names)); // 配列の要素を,区切りのstring型で表示する
        PlayerPrefsX.SetStringArray(UserNameKEY, names); // 保存
    }
}