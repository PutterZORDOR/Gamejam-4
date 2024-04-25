using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCon : MonoBehaviour
{
    public static ScoreCon instance;
    public TMP_Text score;
    private int ScoreNum;

    private void Awake()
    {
        instance = this;
        score = GetComponent<TMP_Text>();
    }
    public void AddScore(int Scored)
    {
        ScoreNum += Scored;
        score.text = $"Score: {ScoreNum}";
    }
}
