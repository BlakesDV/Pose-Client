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

        private InputAction moveAction;
        private string correctDirection;
        public GameObject winPanel, losePanel;
        //TODO: activar condicion victoria o derrota.
        //Sistema de anticipación. tiempo de espera para recibir input.
        //coroutine o cronometro X segs PARA WAITING y otra para Anticipacion y otro input
        void CheckResults()
        {

        }

        private void Awake()
        {
            var inputActions = new PlayerInputActions();
            moveAction = inputActions.Player.Move;
            inputActions.Player.Enable();

            moveAction.performed += MovePerformed;

        }
        private void Start()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
            StartCoroutine(GameplayLogic());
        }

        private IEnumerator GameplayLogic()
        {
            List<string> directions = new List<string> { "up", "down", "left", "right"};
            
            //On arrows and baiting player before actual input
            float time = 3f;
            while (time > 0) 
            {
                string dir = directions[Random.Range(0, directions.Count)];
                yield return new WaitForSeconds(0.3f);
            }

            //Show and highlight the actual input for correct arrow
        }

        private bool inputReceived = false;
        protected void MovePerformed(InputAction.CallbackContext context)
        {
            if (inputReceived) return;
            Vector2 input = context.ReadValue<Vector2>();
            string inputDir = "";

            if (input == Vector2.up) inputDir = "up";
            if (input == Vector2.down) inputDir = "down";
            if (input == Vector2.left) inputDir = "left";
            if (input == Vector2.right) inputDir = "right";

            inputReceived = true;

            if (inputDir == correctDirection) Win();
            else Lose();
        }
        private void Lose()
        {
            losePanel.SetActive(true);
        }
        private void Win()
        {
            winPanel.SetActive(true);
        }
    }
}
