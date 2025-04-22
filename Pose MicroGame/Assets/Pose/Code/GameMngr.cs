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
    public class GameMngr : MonoBehaviour
    {
        public PoseGame.Arrows _arrows;
        public GameObject winPanel, losePanel;
        private int currentLevel = 1;

        void Start ()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            StartCoroutine(LevelMngr());
        }
        //TODO: activar condicion victoria o derrota.
        //Sistema de anticipación. tiempo de espera para recibir input.
        //coroutine o cronometro X segs PARA WAITING y otra para Anticipacion y otro input

        private IEnumerator LevelMngr()
        {
            yield return StartCoroutine(_arrows.ArrowShuffle(currentLevel, Win, Lose));
        }

        private void Lose()
        {
            losePanel.SetActive(true);
            currentLevel = 1;
            Invoke(nameof(Restart), 2f);
        }
        private void Win()
        {
            winPanel.SetActive(true);
            currentLevel++;
            Invoke(nameof(Restart), 2f);
        }

        void Restart()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            StartCoroutine(LevelMngr());
        }
    }
}
