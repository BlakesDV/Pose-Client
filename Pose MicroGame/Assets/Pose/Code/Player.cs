using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //TODO: input jugador a cada flecha?
    #region Runtime Variables

    public GameObject idleSprite;
    public GameObject upSprite;
    public GameObject downSprite;
    public GameObject leftSprite;
    public GameObject rightSprite;
    public GameObject loseSprite;
    public GameObject wonSprite;

    private enum State { idle,  up, down, left, right, win, lose }
    private State state = State.idle;

    private PlayerInputActions inputActions;
    private PoseGame.Arrows[] arrows;
    private PoseGame.GameMngr gameMngr;

    #endregion

    #region Unity Methods
    private void Start()
    {
        
        gameMngr = FindFirstObjectByType<PoseGame.GameMngr>();
        arrows = FindObjectsByType<PoseGame.Arrows>(FindObjectsSortMode.None);
    }
    #endregion

    #region Pose Changes
    private void PoseUpdate()
    {
        
    }
    void ChangePoseUp(InputAction.CallbackContext value)
    {
        //if para preguntar estado finito en input
        if (value.performed)
        {
            //upRenderer.sprite = upSprite; pasar a arrow script
            //INVOKE ARROW UP
            foreach (PoseGame.Arrows arrow in arrows)
            {

            }
        }
    }
    void ChangePoseDown(InputAction.CallbackContext value)
    {
        //if para preguntar estado finito en input
        if (value.performed)
        {
            
        }
    }
    void ChangePoseLeft(InputAction.CallbackContext value)
    {
        //if para preguntar estado finito en input
        if (value.performed)
        {

        }
    }
    void ChangePoseRight(InputAction.CallbackContext value)
    {
        //if para preguntar estado finito en input
        if (value.performed)
        {

        }
    }
    private void SetPoseState(string state)
    {
        upSprite.SetActive(false);
        downSprite.SetActive(false);
        leftSprite.SetActive(false);
        rightSprite.SetActive(false);
        idleSprite.SetActive(false);

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
        }
    }
    #endregion
}