using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController _controller;
    public Transform _camera;
    public Transform _groundCheck;

    public Vector2 _direction;
    public float turnSmoothTime = 0.1f;
    public float walkSpeed = 1.5f;
    public float sprintSpeed = 8f;
    public float targetSpeed;
    public Vector3 velocity;

    [Range(-30,-5)]
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float _jumpHeight = 1.5f;
    public bool isGrounded;

    public bool _cusorLockState = true;

    private Animator _anim;
    private float turnSmoothVelocity;

    private void Start()
    {
        _anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        Escape_Check();
        Inventory_Check();
        Ground_Check();
        Move_Check();
    }

    private void Move_Check() 
    {
        if(FindObjectOfType<CursorStates>().IsLocked) { return; }

        Move();
        Jump();
    }

    private void Move()
    {
        float sprint = 0f;

        _direction = FindObjectOfType<KeyManager>()._direction;

        float horizontal = _direction.y;
        float vertical = _direction.x;

        if (FindObjectOfType<KeyManager>()._sprintState) { 
            sprint = 1f;
            targetSpeed = sprintSpeed;
        }
        else { 
            sprint = 0f;
            targetSpeed = walkSpeed;
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (horizontal == 0 && vertical == 0) { _anim.SetFloat("Blend", 0f); }

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _controller.Move(moveDir.normalized * targetSpeed * Time.deltaTime);

            _anim.SetFloat("Blend", 1f + sprint);
        }
    }

    private void Ground_Check() {

        isGrounded = Physics.CheckSphere(_groundCheck.position, groundDistance, groundMask);

        if(!isGrounded) { _anim.SetBool("Grounded", false); }

        if(isGrounded && velocity.y < 0) { 
            velocity.y = -2f;
            _anim.SetBool("Jump", false);
            _anim.SetBool("Grounded", true);
        }

        velocity.y += gravity * Time.deltaTime;

        _controller.Move(velocity * Time.deltaTime);
    
    }

    private void Jump()
    {
       
        if (FindObjectOfType<KeyManager>()._jumpState && isGrounded) {
            _anim.SetBool("Jump", true);
            _anim.SetBool("Grounded", false);
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
        }

    }

    private void OnTriggerStay(Collider collider)
    {
        if (FindObjectOfType<KeyManager>()._eventState) {
            _anim.SetFloat("Blend", 0f);
        }
    }

    private void Inventory_Check()
    {
        if (FindObjectOfType<InventoryUI>()._inventoryUI.activeSelf) 
        { 
            _anim.SetFloat("Blend", 0f);
        }
    }

    private void Escape_Check()
    {
        if (FindObjectOfType<SettingManager>()._isOpened)
        {
            _anim.SetFloat("Blend", 0f);
        }
    }
}