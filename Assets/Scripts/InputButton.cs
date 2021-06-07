using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputButton : MonoBehaviour
{
    public InputPanel inputPanel;

    public void OnThis()
    {
        string myText = GetComponentInChildren<Text>().text;
        inputPanel.OnInput(myText);
    }
}