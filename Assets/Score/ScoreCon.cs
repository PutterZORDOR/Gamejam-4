using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class ScoreCon : MonoBehaviour
{
    public int Score;
    public TMP_Text scoreText;

    private void Start()
    {
        
    }

    private void Update()
    {
        ShowPoint();
    }

    private void ShowPoint()
    {
        scoreText.text = Score.ToString();
    }

    public void AddPointEnermy()
    {
        Score += 100;
    }
}
