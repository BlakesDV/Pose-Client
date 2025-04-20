using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using PoseGame;

namespace PoseGame 
{ 
    public class Arrows : MonoBehaviour
    {
        public GameMngr _gameMngr;
        public static Arrows _arrowsI;

        #region Runtime Variables

        public Image arrowUp, arrowDown, arrowLeft, arrowRight;

        private Dictionary<string, Image> arrows; 

        #endregion

        #region Enums

        private enum State { Inactive, Warning, Active };

        #endregion

        private void Awake()
        {
            arrows = new Dictionary<string, Image>
            {
                {"up", arrowUp},
                {"down", arrowDown},
                {"left", arrowLeft},
                {"right", arrowRight}
            };
        }

        public void HighlightArrow(string dir)
        {
            arrows[dir].color = Color.blue;
        }
        public void TurnOffAll()
        {
            foreach(var arrow in arrows.Values)
                arrow.color = Color.white;
        }
    }
}
