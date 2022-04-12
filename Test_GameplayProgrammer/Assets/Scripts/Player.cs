using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Action onOpenOptions;
    [Tooltip("Define limits for the rotation (in angles) on the X axis.")]
    [SerializeField] private Vector2 rotationLimit = Vector2.zero;
    [Tooltip("How fast can the Player walk.")]
    [SerializeField] private float movementSpeed = 10f;
    [Tooltip("How fast can the Player move the camera around.")]
    [SerializeField] private float rotationSpeed = 10f;
    private Vector3 movementValue = Vector3.zero;
    private Vector3 rotationValue = Vector3.zero;
    private bool interaction1Pressed = false;
    private bool interaction2Pressed = false;
    private bool canRotate = true;
    private bool canMove = true;
    private bool targetSelected = false;
    private bool gamePaused = false;
    private float startingHeight;
    private TargetingSystem targetingSystem;
    private PlayerInteraction playerInteraction;

    public PlayerInteraction PlayerInteraction { get => playerInteraction; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }

    private void Awake()
    {
        startingHeight = transform.position.y;
        SetInteractionSystem();
    }

    private void Update()
    {
        if (gamePaused)
            return;

        if (canRotate) Rotate();
        if (canMove) Move();
        if (targetSelected)
        {
            ItemInteraction1();
            ItemInteraction2();
        }
    }

    // This and gamePaused should ideally be outside the Player script.
    public void PauseGame(bool pauseGame)
    {
        gamePaused = pauseGame;
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        movementValue = new Vector3(inputValue.x, 0, inputValue.y);
    }

    private void OnRotate(InputValue value)
    {
        // mouse returns values higher than 1 and -1.
        Vector2 inputValue = value.Get<Vector2>();
        rotationValue = new Vector3(-inputValue.y, inputValue.x, 0);
    }

    private void OnItemInteraction1(InputValue value)
    {
        interaction1Pressed = !interaction1Pressed;
    }

    private void OnItemInteraction2(InputValue value)
    {
        interaction2Pressed = !interaction2Pressed;
    }

    private void OnSelectItem()
    {
        if (playerInteraction.SelectTarget())
        {
            targetSelected = true;
            canRotate = false;
            canMove = false;
            Cursor.visible = true;
        }
    }

    private void OnDeselectItem()
    {
        playerInteraction.DeselectTarget();
        targetSelected = false;
        canRotate = true;
        canMove = true;
        Cursor.visible = false;
    }

    private void OnOpenOptions()
    {
        if (!gamePaused)
            onOpenOptions?.Invoke();
    }

    private void Move()
    {
        transform.Translate(movementSpeed * Time.deltaTime * movementValue);
        transform.position = new Vector3(transform.position.x,
            startingHeight, transform.position.z);
    }

    private void Rotate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * rotationValue);

        float rotationX = ClampAngle(transform.rotation.eulerAngles.x, rotationLimit.x, rotationLimit.y);
        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y, 0.0f);
    }

    private void ItemInteraction1()
    {
        if (interaction1Pressed && !interaction2Pressed)
            playerInteraction.Interact1();
    }

    private void ItemInteraction2()
    {
        if (interaction2Pressed && !interaction1Pressed)
            playerInteraction.Interact2();
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle > 180)
        {
            angle -= 360;
        }
        angle = Mathf.Clamp(angle, min, max);

        return angle;
    }

    private void SetInteractionSystem()
    {
        targetingSystem = GetComponent<TargetingSystem>();
        if (targetingSystem)
        {
            playerInteraction = GetComponent<PlayerInteraction>();
            if (playerInteraction)
                targetingSystem.OnTargeting += playerInteraction.SetTargetedObject;
        }
    }
}
