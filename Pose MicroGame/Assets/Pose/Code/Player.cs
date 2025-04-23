using Microsoft.Unity.VisualStudio.Editor;
using PoseGame;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Runtime Variables

    public GameObject idleSprite;
    public GameObject upSprite;
    public GameObject downSprite;
    public GameObject leftSprite;
    public GameObject rightSprite;
    public GameObject loseSprite;
    public GameObject wonSprite;

    public GameMngr _gameMngr;
    public Arrows _arrows;

    private enum State { idle,  up, down, left, right, win, lose }
    private State state = State.idle;

    #endregion

    #region Unity Methods
    private void Start()
    {
        if (_gameMngr == null) _gameMngr = FindFirstObjectByType<GameMngr>();
        if (_arrows == null) _arrows = FindFirstObjectByType<Arrows>();
        IdleReset();
    }
    #endregion

    #region Pose Changes
    
    private void SetPoseState(string state)
    {
        upSprite.SetActive(false);
        downSprite.SetActive(false);
        leftSprite.SetActive(false);
        rightSprite.SetActive(false);
        idleSprite.SetActive(false);
        wonSprite.SetActive(false);
        loseSprite.SetActive(false);

        switch (state)
        {
            case "Idle":
                idleSprite.SetActive(true);
                break;
            case "Up":
                upSprite.SetActive(true);
                break;
            case "Down":
                downSprite.SetActive(true);
                break;
            case "Left":
                leftSprite.SetActive(true);
                break;
            case "Right":
                rightSprite.SetActive(true);
                break;
            case "Won":
                wonSprite.SetActive(true);
                break;
            case "Lose":
                loseSprite.SetActive(true);
                break;
        }
    }
    public void ArrowDirectionPressed(string direction)
    {
        SetPoseState(direction);
        StartCoroutine(IdleDelayRestart(1f));
    }

    public void OnGameOver(bool youWon)
    {
        StopAllCoroutines();
        StartCoroutine(EndPose(youWon));
    }

    public void IdleReset()
    {
        StopAllCoroutines();
        SetPoseState("idle");
    }

    private IEnumerator IdleDelayRestart(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetPoseState("idle");
    }

    public IEnumerator EndPose(bool didWin)
    {
        yield return new WaitForSeconds(2f);
        SetPoseState(didWin ? "Win" : "Lose");
    }
    #endregion
}