using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6;

    private Transform _transform;
    private Vector3 _movement;
    private Animator _anim;
    private Rigidbody _playerRigidbody;
    private int _floorMask;
    private float _camRayLength = 100;

    private void Awake()
    {
        _floorMask = LayerMask.GetMask("Floor");
        _anim = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void FixedUpdate()
    {
        //physics updates go here
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {
        _movement.Set(h, 0, v);
        _movement = _movement.normalized * Speed * Time.deltaTime;
        _playerRigidbody.MovePosition(_transform.position + _movement);
    }

    private void Turning()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, _camRayLength, _floorMask))
        {
            Vector3 playerToMouse = hit.point - _transform.position;
            playerToMouse.y = 0;

            _playerRigidbody.MoveRotation(Quaternion.LookRotation(playerToMouse)); 
        } 
    }

    private void Animating(float h, float v)
    {
        bool isWalking = h != 0 || v != 0;
        _anim.SetBool("IsWalking", isWalking);
    }
}
