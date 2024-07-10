using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using TMPro;

public class Timer : MonoBehaviour
{
    public RectTransform bar;
    public float time = 180f;
    public bool gameEnded = false;
    private int pizzasServedCount = 0;
    public int minute, second;
    public TextMeshProUGUI clock;

    void Start()
    {
        AnimateBar();
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time <= 0)
        {
            time = 0;
            clock.color = Color.red;
            EndGame();
        }

        minute = Mathf.FloorToInt(time / 60);
        second = Mathf.FloorToInt(time % 60);
        clock.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    public void PizzaServed()
    {
        pizzasServedCount++;
        if (pizzasServedCount >= 4)
        {
            EndGame();
        }
    }

    public void AnimateBar()
    {
        LeanTween.size(bar, new Vector2(515, bar.sizeDelta.y), time).setEase(LeanTweenType.linear);
    }

    void EndGame()
    {
        gameEnded = true;

        if (pizzasServedCount >= 4)
        {
            Debug.Log("You Win!");
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }
}
