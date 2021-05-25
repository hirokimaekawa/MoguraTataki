using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject ResultBoxPrefab;
    [SerializeField] GameObject ResultBox;
    [SerializeField] GameObject canvas;
    public GameObject rankingButton;
    public GameObject backButton;


    public static string nowTime;
    //string stringRankingList;


    //Text resultCloneText;

    public List<Text> rankingList = new List<Text>();

    // Start is called before the first frame update
    public void Start()
    {

        var timesList = PlayerPrefsX.GetStringArray("TimeKEY");
        Debug.Log(timesList);
        var scoreList = PlayerPrefsX.GetIntArray("KEY");

        foreach (int A in scoreList)
        {
            Debug.Log(A);
        }

        //得点を新しい順に表示するコード
        var zip = scoreList.Zip(timesList, (scores, times) => new { scores, times })
                    .OrderByDescending(pair => pair.times)
                    .Select((pair, index) => $"{pair.times} 得点：{pair.scores}");
        //削除：No.{index + 1}
        foreach (string A in zip)
        {


            ResultBox = Instantiate(ResultBoxPrefab);
            ResultBox.transform.SetParent(canvas.transform, false);
            var txtComp = ResultBox.GetComponentInChildren<Text>();
            txtComp.text = A;

            Debug.Log(A);


            rankingList.Add(txtComp);
            Debug.Log(rankingList[0]);
        }


    }
    public void OnToTitleButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void SwitchRankingButton()
    {
        var scoreList = PlayerPrefsX.GetIntArray("KEY");
        var timesList = PlayerPrefsX.GetStringArray("TimeKEY");
        var zip2 = scoreList.Zip(timesList, (scores, times) => new { scores, times })
            .OrderByDescending(pair => pair.scores)
                            .Select((pair, index) => $"第{index + 1}位{pair.times} 得点：{pair.scores}")
                            .ToArray();
        for (int i = 0; i < zip2.Length; i++)
        {
            rankingList[i].text = zip2[i];
        }
        rankingButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void BackButton()
    {
        rankingButton.SetActive(true);
        backButton.SetActive(false);
        var scoreList = PlayerPrefsX.GetIntArray("KEY");
        var timesList = PlayerPrefsX.GetStringArray("TimeKEY");
        var zip2 = scoreList.Zip(timesList, (scores, times) => new { scores, times })
            .OrderByDescending(pair => pair.times)
                            .Select((pair, index) => $"{pair.times} 得点：{pair.scores}")
                            .ToArray();
        for (int i = 0; i < zip2.Length; i++)
        {
            rankingList[i].text = zip2[i];
        }
    }
}
