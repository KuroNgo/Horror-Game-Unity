using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CharacterController))]
public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpingSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


    // Dùng để ẩn một cái gì đó ra khỏi trình inspector ngăn ngừa người dùng chỉnh sửa
    [HideInInspector]
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        // Dùng để lấy tham chiếu đến một thành phần đính kèm vào cùng một đối tượng game object
        // Chứa script đang thực thi dòng này
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Bấm Left Shift để chạy
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // 
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpingSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Gắn trọng lực vào game. Trong lực được nhân bởi 2 lần deltaTime ( một lần ở trên và một lần ở dưới )
        // khi moveDirection được nhân với deltaTime). Điều này là do trọng lực nên được áp dụng
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Di chuyển controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Người chơi và camera 
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
