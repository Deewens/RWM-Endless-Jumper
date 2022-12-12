using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerAnimStates
{
    Idle = 0,
    Running = 1,
    Jumping = 2,
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AudioSource runAudio;
    [SerializeField] private AudioSource coinAudio;
    private AudioSource jumpAudio;
    public PlayerAnimStates playerAnimState;
    private static readonly int State = Animator.StringToHash("State");

    private PlayerDamageSystem _pds;

    private Animator _animator;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _capsuleCollider;
    
    private bool _verticalInput; // Jump
    private bool _isJumping;

    private GameManager _gameManager;

    private Vector2 _rayPosition;
    [SerializeField] private float rayDistance = 0.05f;

    void Start()
    {
        _pds = this.GetComponent<PlayerDamageSystem>();
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        jumpAudio = GetComponent<AudioSource>();

        _rayPosition = transform.position;
    }

    void Update()
    {
        GameOver();
        Jump();

        if (IsGrounded())
        {
            if (!runAudio.isPlaying)
            {
                runAudio.Play();
            }
            playerAnimState = PlayerAnimStates.Running;
        }
        else
        {
            if (runAudio.isPlaying)
            {
                runAudio.Stop();
            }
            playerAnimState = PlayerAnimStates.Jumping;
        }
        
        _rayPosition = transform.position;
        /*_rayPosition.y -= 0.5f;
        _rayPosition.x -= 0.5f;*/
        Debug.DrawRay(_capsuleCollider.bounds.center, Vector2.down * rayDistance, Color.yellow);
        _animator.SetInteger(State, (int)playerAnimState);
    }

    private void Jump()
    {
        if (!_verticalInput || !IsGrounded()) return;

        jumpAudio.Play();
        _rb.velocity = Vector2.up * jumpForce;
    }

    public void TouchJump()
    {
        if (!IsGrounded()) return;

        jumpAudio.Play();
        _rb.velocity = Vector2.up * jumpForce;
        _verticalInput = false;
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.y > 0) _verticalInput = true;
        else _verticalInput = false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_capsuleCollider.bounds.center, _capsuleCollider.bounds.size, 0,
            Vector2.down, rayDistance, groundMask);

        return raycastHit.collider != null;
    }

    public void GameOver()
    {
        if (transform.position.y < -3)
        {
            _pds.SetDamage(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            coinAudio.Play();
        }

    }
}