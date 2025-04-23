using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using NUnit.Framework;
using PoseGame;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

namespace PoseGame 
{
    public enum GameStates
    {
        GAME,
        VICTORY,
        LOSE
    }

    public class GameMngr : MonoBehaviour
    {
        public PoseGame.Arrows _arrows;
        public Player _player;

        public GameObject winPanel, losePanel;
        private int currentLevel = 1;
        public Timer _timer;
        public GameStates _gameState;
        public GameObject idleSprite;
        public GameObject loseSprite;
        public GameObject wonSprite;

        protected Coroutine arrowCoroutine;

        private List<GameObject> danceMoves;

        void Start ()
        {
            RestartGame();
        }

        public void Lose()
        {
            if (_gameState == GameStates.GAME)
            {
                losePanel.SetActive(true);
                loseSprite.SetActive(true);
                SetPoseState("Lose");
                currentLevel = 1;
                StartCoroutine(TimeToRestartGame(2f));
                StopCoroutine(arrowCoroutine);
                _timer._isTimeOn = false;
                _gameState = GameStates.LOSE;
            }
        }
        private void Win()
        {
            if (_gameState == GameStates.GAME)
            {
                winPanel.SetActive(true);
                wonSprite.SetActive(true);
                SetPoseState("Won");
                currentLevel++;
                StartCoroutine(TimeToRestartGame(2f));
                StopCoroutine(arrowCoroutine);
                _timer._isTimeOn = false;
                _gameState = GameStates.VICTORY;
            }
        }

        void Restart()
        {
            if ( _gameState != GameStates.GAME)
            {
                RestartGame();
            }
        }

        protected void RestartGame()
        {
            if (!wonSprite.transform.parent.gameObject.activeInHierarchy)
            {
                wonSprite.transform.parent.gameObject.SetActive(true);
            }
            if (!loseSprite.transform.parent.gameObject.activeInHierarchy)
            {
                loseSprite.transform.parent.gameObject.SetActive(true);
            }
            SetPoseState("Idle");
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            idleSprite.SetActive(true);
            _timer.GetSetTimer = 6;
            _timer._isTimeOn = true; //gameState -> GAME
            arrowCoroutine = StartCoroutine(_arrows.ArrowShuffle(currentLevel, Win, Lose));
            DanceMovements(3f);
            _gameState = GameStates.GAME;
        }

        protected IEnumerator TimeToRestartGame(float time)
        {
            yield return new WaitForSeconds(time);
            Restart();
        }
        private void SetPoseState(string state)
        {
            idleSprite.SetActive(false);
            wonSprite.SetActive(false);
            loseSprite.SetActive(false);

            switch (state)
            {
                case "Idle":
                    idleSprite.SetActive(true);
                    break;
                case "Won":
                    wonSprite.SetActive(true);
                    break;
                case "Lose":
                    loseSprite.SetActive(true);
                    break;
            }
        }
        public void DanceMovements(float duration)
        {
            _player.ShufflePose(3f);
        }
    }
}