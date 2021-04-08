using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    int actionCheck;

    public int Lives;
    public InputActionAsset asset;
    //public GameObject followTransform;
    private InputAction inputAction1;
    private InputAction inputAction2;
    ButtonControl timeStop;
    ButtonControl risingPlatform;
    public float cameraRotationSpeed;
    public bool godMode;
    public GameObject holoPlatform;
    // Movement Components
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float JumpForce;

    private Vector2 InputVector = Vector2.zero;
    private Vector3 MoveDirection = Vector3.zero;

    // Comp
    private Animator playerAnimator;
    private Rigidbody RB;

    // Animator Hashes
    private readonly int MovementXHash = Animator.StringToHash("MovementX");
    private readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private readonly int IsRunningHash = Animator.StringToHash("IsRunning");
    private readonly int IsJumpingHash = Animator.StringToHash("IsJumping");

    // Movement Checks
    public bool IsFiring;
    public bool IsReloading;
    public bool IsJumping;
    public bool IsRunning;

    public bool cameraLock;
    float rotationX = 0;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    Vector3 movementDirection;
    private bool holoActive = false;

    public bool timePowers;
    [SerializeField]
    private float timePowerLimit = 5;
    private float tempTime;
    private bool timeActive;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        //gameManager.currentRespawnPoint = gameManager.startObject;
        inputAction1 = asset.FindAction("SwitchCircle");
        inputAction2 = asset.FindAction("RisingPlatform");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        timeStop = (ButtonControl)inputAction1.controls[0];
        risingPlatform = (ButtonControl)inputAction2.controls[0];
        inputAction1.Enable();
        inputAction2.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        if (timeStop.wasPressedThisFrame)
        {
            Debug.Log(tempTime);
            if (timePowers && tempTime > timePowerLimit)
            {
                gameManager.ToggleSwitchCircle(timeActive);

                if (timeActive)
                    timeActive = false;
                else
                    timeActive = true;

                tempTime = 0;
            }
            
        }

        tempTime += Time.deltaTime;

        if (risingPlatform.wasPressedThisFrame)
        {
            if (holoPlatform != null)
            {
                holoPlatform.GetComponent<MeshRenderer>().material = gameManager.holoCube;
                holoPlatform.transform.position = transform.position + transform.forward * 5;
                holoActive = true;
            }
        }
        if (risingPlatform.wasReleasedThisFrame)
        {
            if (holoPlatform != null)
            {
                holoActive = false;
                //holoPlatform.transform.position = new Vector3(0, -10, 0);
                holoPlatform.GetComponent<MeshRenderer>().material = gameManager.realCube;
            }
        }
        if (holoActive)
        {
            holoPlatform.transform.position = transform.position + transform.forward * 5;
            holoPlatform.transform.rotation = transform.rotation;
        }

        /*
        if (timeStop.wasPressedThisFrame)
        {
            if (GameObject.FindWithTag("GameManager") != null)
                gameManager.ToggleSwitchCircle(false);
        }
        else if (timeStop.wasReleasedThisFrame)
        {
            if (GameObject.FindWithTag("GameManager") != null)
                gameManager.ToggleSwitchCircle(true);
        }*/
        //Movement Updates
        //if (IsJumping) return;

        if (!(InputVector.magnitude > 0)) MoveDirection = Vector3.zero;

        MoveDirection = transform.forward * InputVector.y + transform.right * InputVector.x;

        float currentSpeed = IsRunning ? RunSpeed : WalkSpeed;

        //movementDirection = new Vector3(InputVector.x, 0, InputVector.y) * (currentSpeed * Time.deltaTime);
        movementDirection = Quaternion.Euler(0, 1, 0) * MoveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;

        if (InputVector.y == 0 && InputVector.x == 0)
        {
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isRunning", false);
        }
        else if (!IsRunning)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", true);
            playerAnimator.SetBool("isWalking", false);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        InputVector = context.action.ReadValue<Vector2>();
        //if (!IsRunning)
            //playerAnimator.SetBool("isWalking", true);
        //playerAnimator.SetFloat(MovementXHash, InputVector.x);
        //playerAnimator.SetFloat(MovementZHash, InputVector.y);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (IsRunning)
        {
            playerAnimator.SetBool("isRunning", false);
            IsRunning = false;
        }
        else
        {
            playerAnimator.SetBool("isRunning", true);
            IsRunning = true;
        }
        //playerAnimator.SetBool(IsRunningHash, isPressed);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //playerAnimator.SetBool(IsJumpingHash, true);
        if (!IsJumping)
            RB.AddForce((transform.up + MoveDirection) * JumpForce, ForceMode.Impulse);

        IsJumping = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground") && !IsJumping) return;

        IsJumping = false;
        //playerAnimator.SetBool(IsJumpingHash, false);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (!cameraLock)
        {
            rotationX += -context.ReadValue<Vector2>().y * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, context.ReadValue<Vector2>().x * lookSpeed, 0);
        }
        //gameObject.transform.eulerAngles = movementDirection;
        /*followTransform.transform.eulerAngles = new Vector3(followTransform.transform.eulerAngles.x, followTransform.transform.eulerAngles.y, 0);

        followTransform.transform.Rotate(new Vector3(-context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x, 0) * Time.deltaTime * cameraRotationSpeed);
        followTransform.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z - 1);*/
    }

    public void Pause()
    {
        if (gameManager.IsPaused())
        {
            gameManager.PauseGame(false);
        }
        else
        {
            gameManager.PauseGame(true);
        }
    }

    public void ActivateSwitchCircle()
    {
        Debug.Log("ActivatedSwitchCircle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            gameManager.currentRespawnPoint = other.gameObject;
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if (other.gameObject.tag == "FinishObjective")
        {
            Lives = 5;
            if (GameObject.FindWithTag("VictoryCheck") != null)
                GameObject.FindWithTag("VictoryCheck").GetComponent<VictoryCheck>().Victory = true;
            gameManager.EndGame();
        }
        else if (other.gameObject.tag == "DeathPlane")
        {
            TakeDamage(1);
        }
        else if (other.gameObject.tag == "NextObjective")
        {
            if (SceneManager.GetActiveScene().name == "ToJ Level1")
            {
                timePowers = true;
                SceneManager.LoadScene("ToJ Level2");
            }
            else if (SceneManager.GetActiveScene().name == "ToJ Level2")
            {
                SceneManager.LoadScene("ToJ Level3");
            }
        }
    }

    public void TakeDamage(int r = 1)
    {
        if (!godMode)
        {
            Lives -= r;
            if (Lives == 0)
            {
                Lives = 5;
                if (GameObject.FindWithTag("VictoryCheck") != null)
                    GameObject.FindWithTag("VictoryCheck").GetComponent<VictoryCheck>().Victory = false;
                gameManager.EndGame();
            }
            transform.position = gameManager.currentRespawnPoint.transform.position;
            gameManager.SetLivesText(Lives);
        } 
    }
}
