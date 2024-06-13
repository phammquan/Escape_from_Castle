using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    Collider2D _coli;
    DEAD _isDead;
    PhysicsMaterial2D material;


    void Start()
    {
        _coli = this.GetComponent<Collider2D>();
        material = _coli.sharedMaterial;
        checkGroud();
        checkSpeed = _speed;
        _rigi = this.GetComponent<Rigidbody2D>();
        _isDead = this.GetComponent<DEAD>();
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
        checkwall();
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
            _speed /= 1.95f;
            _rigi.velocity = new Vector2(_rigi.velocity.x, _jumpForce);
            _isGrounded = false;
        }
    }
    void checkGroud()
    {
        RaycastHit2D[] rays = new RaycastHit2D[5];
        _coli.Cast(Vector2.down, rays, 0.2f, true);

        foreach (RaycastHit2D hit in rays)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.red);
            if (hit.collider != null)
            {
                if (hit.collider.tag.Equals("Platform") || hit.collider.tag.Equals("Player"))
                {
                    _isGrounded = true;
                    if (_speed < checkSpeed)
                    {
                        _speed = _speed * 2;
                    }
                    return;
                }
            }
            else
            {
                _isGrounded = false;
            }
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
    void checkwall()
    {
        RaycastHit2D[] hits = new RaycastHit2D[2];
        hits[0] = Physics2D.Raycast(this.transform.position, Vector2.left, 3f);
        hits[1] = Physics2D.Raycast(this.transform.position, Vector2.right, 3f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.tag.Equals("Platform"))
            {

                if (_coli != null)
                {

                    if (material != null)
                    {
                        material.friction = 0;
                    }
                    else
                    {
                        material = new PhysicsMaterial2D();
                        material.friction = 0;
                        _coli.sharedMaterial = material;
                    }
                }
                return;

            }
            else
            {
                if (_coli != null)
                {

                    if (material != null)
                    {
                        material.friction = 1.0f;
                    }
                    else
                    {
                        material = new PhysicsMaterial2D();
                        material.friction = 1.0f;
                        _coli.sharedMaterial = material;
                    }
                }
            }
        }
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
