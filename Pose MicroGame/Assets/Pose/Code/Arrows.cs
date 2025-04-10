using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class Arrows : MonoBehaviour
{
    #region Runtime Variables

    public Sprite inactiveSprite;
    public Sprite warningSprite;
    public Sprite activeSprite;
    private SpriteRenderer spriteRenderer;
    private InputAction action;
    private bool arrowInput;
    private State actualState = State.Inactive;

    #endregion

    #region Enums

    private enum State { Inactive, Warning, Active };

    #endregion

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = inactiveSprite;

        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        yield return new WaitForSeconds(2f);
        actualState = State.Warning;
        spriteRenderer.sprite = warningSprite;

        yield return new WaitForSeconds(2f);
        actualState = State.Active;
        spriteRenderer.sprite = activeSprite;

        //Get input action? or on player call to check state? idk 
    }

    private void Update()
    {
        if (actualState == State.Active && !arrowInput) 
        { 
            Vector2 movement = action.ReadValue<Vector2>();
            if (movement != Vector2.zero)
            {
                arrowInput = true;
                //TODO: cambiar sprites
            }
        }
    }
}
