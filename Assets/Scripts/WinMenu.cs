using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timeText, scoreText;

    private float startTime;
    private void Start()
    {
        startTime = Time.time;
        Debug.Log("zzzzzzzzzzzzz");
    }

    public void SetText(float score)
    {
        float currentTime = Time.time - startTime;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timeText.text = string.Format("Время: {0:d2} : {1:d2}", minutes, seconds);
        scoreText.text = string.Format("Оценка: {0:f2} / 100", score);
        Debug.Log(scoreText.text);
    }
}
