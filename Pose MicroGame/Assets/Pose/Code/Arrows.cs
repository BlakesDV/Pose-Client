using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using PoseGame;
using System;

namespace PoseGame 
{ 
    public class Arrows : MonoBehaviour
    {
        #region References

        public GameMngr _gameMngr;
        public static Arrows _arrowsI;
        public Player _player;
        #endregion

        #region Runtime Variables

        public Image arrowUp, arrowDown, arrowLeft, arrowRight;
        private InputAction moveAction;
        private PlayerInputActions inputActs;
        private string correctDirection;
        private bool inputReceived;
        private Action succes;
        private Action failed;
        private Dictionary<string, Image> arrows; 

        #endregion

        #region Enums

        private enum State { Inactive, Warning, Active };

        #endregion

        private void Awake()
        {
            inputActs = new PlayerInputActions();
            moveAction = inputActs.Player.Move;
            inputActs.Player.Enable();
            moveAction.performed += PressPerformed;
            arrows = new Dictionary<string, Image>
            {
                {"up", arrowUp},
                {"down", arrowDown},
                {"left", arrowLeft},
                {"right", arrowRight}
            };
        }

        public void HighlightArrow(string dir, Color? colorOverride = null)
        {
            if (arrows.ContainsKey(dir))
            arrows[dir].color = colorOverride ?? Color.yellow;
        }
        public void TurnOffAll()
        {
            foreach(var arrow in arrows.Values)
                arrow.color = Color.magenta;
        }

        public IEnumerator ArrowShuffle(int level, Action win, Action lose)
        {
            succes = win;
            failed = lose;
            List<string> directions = new List<string> { "up", "down", "left", "right"};
            
            //Random highlight
            float time = 3f;
            while (time > 0)
            {
                string dir = directions[UnityEngine.Random.Range(0, directions.Count)];
                HighlightArrow(dir);
                yield return new WaitForSeconds(0.3f);
                TurnOffAll();
                yield return new WaitForSeconds(0.3f);
                time -= 0.6f;
            }

            //Actual input
            correctDirection = directions[UnityEngine.Random.Range(0, directions.Count)];

            //Baiting phase
            int baitCount = Mathf.Clamp(level - 1, 0, 3);
            float baitTime = 0.4f;
            float totalBaitTime = baitCount * baitTime;
            float actualTime = Mathf.Max(0.1f, 6f - 3f - totalBaitTime);

            List<string> used = new List<string> { correctDirection };
            for (int i = 0; i < baitCount; i++)
            {
                string fake;
                do { fake = directions[UnityEngine.Random.Range(0, directions.Count)]; }
                while (used.Contains(fake));
                used.Add(fake);
                HighlightArrow(fake, Color.red);
                yield return new WaitForSeconds(0.3f);
                TurnOffAll();
                yield return new WaitForSeconds(0.3f);
            }

            //Highlight actual input
            HighlightArrow(correctDirection, Color.green);
            inputReceived = false;
            yield return new WaitForSeconds(actualTime);
            if (!inputReceived)
            {
                failed?.Invoke();
            }
        }

        void PressPerformed(InputAction.CallbackContext context)
        {
            if ( _gameMngr._gameState == GameStates.GAME)
            {
                if (inputReceived) return;
                Vector2 input = context.ReadValue<Vector2>();
                string inputDir = "";

                if (input == Vector2.up) inputDir = "up";
                else if (input == Vector2.down) inputDir = "down";
                else if (input == Vector2.left) inputDir = "left";
                else if (input == Vector2.right) inputDir = "right";
                inputReceived = true;
                //_player?.ArrowDirectionPressed(inputDir);

                if (inputDir == correctDirection)
                {
                    succes?.Invoke();
                    //_player?.OnGameOver(true);
                }
                else
                {
                    failed?.Invoke();
                    //_player?.OnGameOver(false);
                }
            }
        }
    }
}
