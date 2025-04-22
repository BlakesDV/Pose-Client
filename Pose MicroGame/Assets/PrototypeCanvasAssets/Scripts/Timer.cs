using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public PoseGame.GameMngr _gameMngr;
    public float timer = 6;
    public TextMeshProUGUI numbersDisplayed;
    public GameObject gameOverPanel;
    public bool _isTimeOn;

    private void Start()
    {
        _isTimeOn = true;
    }
    void Update()
    {
        if (_isTimeOn && _gameMngr._gameState == PoseGame.GameStates.GAME)
        {
            timer -= Time.deltaTime;

            numbersDisplayed.text = Mathf.Ceil(timer).ToString();

            if (timer <= 0)
            {
                //GameOver();
                _gameMngr.Lose();
            }
        }
    }

    //private void GameOver()
    //{
    //    gameOverPanel.SetActive(true);
    //    Time.timeScale = 0f;
    //    _isTimeOn = false;
    //}

    public float GetSetTimer
    {
        set { timer = value; }
    }
}
