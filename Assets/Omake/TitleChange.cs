using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleChange : MonoBehaviour
{
    // Start is called before the first frame update
  public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
    }

  public void OnResultButton()
    {
        SceneManager.LoadScene("Result");
    }
}
