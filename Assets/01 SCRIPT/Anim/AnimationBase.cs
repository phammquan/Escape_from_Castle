using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PlayerState = PlayerController.PlayerState;
using AttackState = PlayerController.AttackState;
using AnimDie = DEAD.AnimDie;
public class AnimationBase : Satebase
{
    Animator _animator;
    [SerializeField] PlayerController _player;
    bool arrow = false;
    bool done = false;

    void Update()
    {
        DeadAnim();
    }
    public override void UpdateAnimation(PlayerState playerState)
    {
        for (int i = 0; i <= (int)PlayerState.JUMP; i++)
        {
            string stateName = ((PlayerState)i).ToString();
            if (playerState == ((PlayerState)i) && _player.GetComponent<DEAD>()._isDead == false)
            {
                _animator.SetBool(stateName, true);
            }
            else
            {
                _animator.SetBool(stateName, false);
            }
        }

    }

    public override void _Start()
    {

        _animator = this.GetComponent<Animator>();
    }

    public override void UpdateAttackAnim(AttackState attackState)
    {
        _animator.SetFloat("ATTACK", (int)attackState);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (arrow && other.gameObject.tag == "Platform" && done == false)
        {
            done = true;
            this.transform.parent.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        else
        {
            this.transform.parent.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
    }
    public void DeadAnim()
    {
        if (_player.GetComponent<DEAD>()._isDead)
        {
            _animator.SetBool("RUN", false);
            _animator.SetBool("IDLE", false);
            _animator.SetBool("JUMP", false);
            _animator.SetBool("DIE", true);

            if (_player.GetComponent<DEAD>()._AnimDie == AnimDie.DIE)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                _animator.SetFloat("DEAD", 0.5f);
            }
            if (_player.GetComponent<DEAD>()._AnimDie == AnimDie.DIE_MAGIC)
            {
                _animator.SetFloat("DEAD", 1f);
            }
            if (_player.GetComponent<DEAD>()._AnimDie == AnimDie.DIE_ARROW)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                this.GetComponent<BoxCollider2D>().size = this.transform.parent.gameObject.GetComponent<BoxCollider2D>().size * 1.8f;
                if (!arrow)
                {
                    if (GameManager.Instance.Player[1].transform.localScale.x == _player.transform.localScale.x)
                    {
                        _animator.SetFloat("DEAD", 0f);
                    }
                    else
                    {
                        _player.transform.localScale = new Vector3(GameManager.Instance.Player[1].transform.localScale.x, 1, 1);
                        _animator.SetFloat("DEAD", 0f);
                    }

                }
                arrow = true;

            }

            return;
        }
    }

}
