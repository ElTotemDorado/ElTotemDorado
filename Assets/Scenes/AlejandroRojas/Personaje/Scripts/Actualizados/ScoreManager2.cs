using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager2 : MonoBehaviour
{
    public static ScoreManager2 instance;
    public TextMeshProUGUI Luigitext;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int LuigiValue)
    {
        score += LuigiValue;
        Luigitext.text = "X" + score.ToString();
    }
}