using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed, checkSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] PlayerState _playState = PlayerState.IDLE;
    [SerializeField] AttackState _attackstate = AttackState.NOATTACK;
    Satebase _satebase;
    [SerializeField] AttackController _attack;

    [SerializeField] bool _isGrounded = true;
    public bool IsGrounded => _isGrounded;
    Rigidbody2D _rigi;
    void Start()
    {
        checkGroud();
        checkSpeed = _speed;
        _rigi = this.GetComponent<Rigidbody2D>();
        _satebase = this.transform.GetChild(0).gameObject.GetComponent<AnimationBase>();
        if (_satebase != null)
        {
            _satebase._Start();
        }
        else
        {
            Debug.LogError("Satebase is null");
        }
    }

    void Update()
    {
        checkGroud();
        move();
        UpdateState();
        if (_satebase != null)
        {
            _satebase.UpdateAnimation(_playState);
        }
        UpdateAttack();
        _satebase.UpdateAttackAnim(_attackstate);
    }
    void UpdateState()
    {
        if (!_isGrounded)
        {
            _playState = PlayerState.JUMP;

        }
        else
        {
            if (_rigi.velocity.x != 0)
            {
                _playState = PlayerState.RUN;
            }
            else
            {
                _playState = PlayerState.IDLE;
            }
        }
    }
    void move()
    {
        _rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime, _rigi.velocity.y);
        if (_rigi.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_rigi.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxisRaw("Vertical") == 1 && _isGrounded)
        {
            _speed /= 2;
            _rigi.velocity = new Vector2(_rigi.velocity.x, _jumpForce);
            _isGrounded = false;
        }
    }
    void checkGroud()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector3.down, 2);
        Debug.DrawRay(this.transform.position, Vector3.down * 2, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.tag.Equals("Platform") || hit.collider.tag.Equals("Player"))
            {
                _isGrounded = true;
                if (_speed < checkSpeed)
                {
                    _speed = _speed * 2;
                }
            }
        }
        else
        {
            _isGrounded = false;
        }
    }
    void UpdateAttack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _attackstate = AttackState.ATTACK;
            _attack.Attack();
            return;
        }
        _attackstate = AttackState.NOATTACK;
    }
    public enum PlayerState
    {
        IDLE,
        RUN,
        JUMP,
    }
    public enum AttackState
    {
        NOATTACK,
        ATTACK
    }
}
