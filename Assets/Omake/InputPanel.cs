using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Text;

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
        //しつへ
        string input = userName[userName.Length - 1].ToString();　//　へ

        Debug.Log("userName" + userName);　//しつへ
        Debug.Log(input); //へ
        //UTF-8 NFDで他の文字と結合すると濁点になるもの
        char dakuten = '\x3099';

        //くっつけてNFCにNormalize
        //べ
        string add = (input + dakuten).Normalize(NormalizationForm.FormC);



        Debug.Log("userName" + userName);

        //べ＝１文字
        if (add.Length == 1)
        {
            //しつ
            userName = userName.Substring(0, userName.Length - 1);
            //しつ　＋べ
            userName += add;
        }

        Debug.Log(userName);  // "べ"になる
        nameText.text = userName;
    }

    public void OnHanDakutenButton()
    {
        //しつへ
        string input = userName[userName.Length - 1].ToString();　//　へ

        Debug.Log("userName" + userName);　//しつへ
        Debug.Log(input); //へ
        //UTF-8 NFDで他の文字と結合すると半濁点になるもの
        char dakuten = '\x309A';
        //くっつけてNFCにNormalize
        //ぺ
        string add = (input + dakuten).Normalize(NormalizationForm.FormC);



        Debug.Log("userName" + userName);

        //ぺ＝１文字
        if (add.Length == 1)
        {
            //しつ
            userName = userName.Substring(0, userName.Length - 1);
            //しつ　＋ぺ
            userName += add;
        }

        Debug.Log(userName);  // "ぺ"になる
        nameText.text = userName;
    }
    //小文字：ぁぃぅぇぉっゃゅょ
    string[] kogakiMoji = { "ぁ", "ぃ", "ぅ", "ぇ", "ぉ", "っ", "ゃ", "ゅ", "ょ" };

    //小書き文字にできる並字をあらかじめ用意
    string[] namiji = { "あ", "い", "う", "え", "お", "つ", "や", "ゆ", "よ" };
    public void OnKomojiButton()
    {
        for (int i = 0; i < kogakiMoji.Length; i++)
        {
            Debug.Log(kogakiMoji[i] + "小文字の格納確認");
        }
        for (int i = 0; i < namiji.Length; i++)
        {
            Debug.Log(namiji[i] + "並字の格納確認");
        }
        //inputが小書き文字かどうか
        //UderName＝かみつ
        string input = userName[userName.Length - 1].ToString(); //つ

        //inputが小書き文字にできる並字かどうか
        for (int i = 0; i < namiji.Length; i++)
        {
            //namijiの配列の中にあるひらがなと inputの「つ」が一致したら
            if (namiji[i] == input) //一致したら

            {
                userName = userName.Remove(userName.Length - 1) + kogakiMoji[i];
                nameText.text = userName;
                return;
            }
        }

        for (int i = 0; i < kogakiMoji.Length; i++)
        {
            if (kogakiMoji[i] == input) //一致したら

            {
                userName = userName.Remove(userName.Length - 1) + namiji[i];
                nameText.text = userName;
                return;
            }
        }




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
