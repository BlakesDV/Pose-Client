using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //TODO: input jugador a cada flecha?
    //#region Runtime Variables

    //public Sprite upSprite;
    //public Sprite downSprite;
    //public Sprite leftSprite;
    //public Sprite rightSprite;
    //public SpriteRenderer upRenderer;
    //public SpriteRenderer downRenderer;
    //public SpriteRenderer leftRenderer;
    //public SpriteRenderer rightRenderer;

    //public SpriteRenderer playerPose;
    //private Sprite actualPose;

    //private PlayerInputActions inputActions;
    //private Arrows[] arrows;
    //private GameMngr gameMngr;

    //#endregion

    //#region Unity Methods
    //private void Start()
    //{
    //    gameMngr = FindFirstObjectByType<GameMngr>();
    //    arrows = FindObjectsByType<Arrows>(FindObjectsSortMode.None);
    //}
    //#endregion

    //#region Pose Changes
    //void ChangePoseUp(InputAction.CallbackContext value)
    //{
    //    //if para preguntar estado finito en input
    //    if (value.performed)
    //    {
    //        //upRenderer.sprite = upSprite; pasar a arrow script
    //        //INVOKE ARROW UP
    //        playerPose.sprite = upSprite;
    //        upRenderer.sprite = upSprite;

    //        foreach (Arrows arrow in arrows)
    //        {
                
    //        }
    //    }
    //}
    //void ChangePoseDown(InputAction.CallbackContext value)
    //{
    //    //if para preguntar estado finito en input
    //    if (value.performed)
    //    {
    //        downRenderer.sprite = downSprite;
    //    }
    //}
    //void ChangePoseLeft(InputAction.CallbackContext value)
    //{
    //    //if para preguntar estado finito en input
    //    if (value.performed)
    //    {

    //    }
    //}
    //void ChangePoseRight(InputAction.CallbackContext value)
    //{
    //    //if para preguntar estado finito en input
    //    if (value.performed)
    //    {

    //    }
    //}
    //#endregion
}