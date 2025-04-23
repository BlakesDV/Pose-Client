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
        public GameObject winPanel, losePanel;
        private int currentLevel = 1;
        public Timer _timer;
        public GameStates _gameState;
        public GameObject idleSprite;
        public GameObject upSprite;
        public GameObject downSprite;
        public GameObject leftSprite;
        public GameObject rightSprite;
        public GameObject loseSprite;
        public GameObject wonSprite;

        protected Coroutine arrowCoroutine;

        void Start ()
        {
            //_timer._isTimeOn = true;
            //winPanel.SetActive(false);
            //losePanel.SetActive(false);
            //arrowCoroutine = StartCoroutine(_arrows.ArrowShuffle(currentLevel, Win, Lose));
            //_gameState = GameStates.GAME;
            RestartGame();
        }
        //TODO: activar condicion victoria o derrota.
        //Sistema de anticipación. tiempo de espera para recibir input.
        //coroutine o cronometro X segs PARA WAITING y otra para Anticipacion y otro input

        //private IEnumerator LevelMngr()
        //{
        //    yield return StartCoroutine(_arrows.ArrowShuffle(currentLevel, Win, Lose));
        //}

        public void Lose()
        {
            if (_gameState == GameStates.GAME)
            {
                losePanel.SetActive(true);
                loseSprite.SetActive(true);
                currentLevel = 1;
                StartCoroutine(TimeToRestartGame(2f));
                StopCoroutine(arrowCoroutine);
                //Invoke(nameof(Restart), 2f);
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
                currentLevel++;
                StartCoroutine(TimeToRestartGame(2f));
                StopCoroutine(arrowCoroutine);
                //Invoke(nameof(Restart), 2f);
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
            wonSprite.SetActive(false);
            loseSprite.SetActive(false);
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            idleSprite.SetActive(true);
            _timer.GetSetTimer = 6;
            _timer._isTimeOn = true; //gameState -> GAME
            arrowCoroutine = StartCoroutine(_arrows.ArrowShuffle(currentLevel, Win, Lose));
            _gameState = GameStates.GAME;
        }

        protected IEnumerator TimeToRestartGame(float time)
        {
            yield return new WaitForSeconds(time);
            //while (time > 0)
            //{
            //    yield return new WaitForSeconds(Time.deltaTime);
            //    if (_gameState != GameStates.GAME)
            //    {
            //        time -= Time.deltaTime;
            //    }
            //}
            Restart();
        }
    }
}
