using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveInput;
    private PlayerInputActions inputActions;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMoveCanceled;

        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMoveCanceled;

        inputActions.Player.Disable();
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        //if (Touch.activeFingers.Count > 0)
        //{
        //    Vector2 touchPos = Touch.activeFingers[0].screenPosition;
        //    float screenMiddle = Screen.width / 2f;

        //    if (touchPos.x < screenMiddle)
        //    {
        //        moveInput = -1f;
        //    }
        //    else
        //    {
        //        moveInput = 1f;
        //    }
        //}
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    //private void OnMove(InputAction.CallbackContext context)
    //{
    //    moveInput = context.ReadValue<float>();
    //}
    private void OnMove(InputAction.CallbackContext context)
    {
        // 这里的 context 会自动根据触发设备（键盘或触摸）提供值
        object rawValue = context.ReadValueAsObject();

        if (context.control.device is Touchscreen)
        {
            // 如果是触摸，读取的是像素坐标 (Position/X)
            float touchX = (float)rawValue;
            float screenMiddle = Screen.width / 2f;

            // 根据坐标判断方向
            moveInput = touchX < screenMiddle ? -1f : 1f;
        }
        else
        {
            // 如果是键盘，读取的是 1D Axis 的值 (-1, 0, 1)
            moveInput = (float)rawValue;
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = 0f;
    }
}