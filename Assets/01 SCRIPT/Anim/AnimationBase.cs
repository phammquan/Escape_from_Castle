using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PlayerState = PlayerController.PlayerState;
using AttackState = PlayerController.AttackState;

public class AnimationBase : Satebase
{
    Animator _animator;
    [SerializeField] PlayerController _player;

    void Update()
    {
        if (_player.GetComponent<DEAD>()._isDead)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            _animator.SetBool("IDLE", false);
            _animator.SetBool("DIE", true);
            return;
        }
    }
    public override void UpdateAnimation(PlayerState playerState)
    {
        for (int i = 0; i <= (int)PlayerState.JUMP; i++)
        {
            string stateName = ((PlayerState)i).ToString();
            if (playerState == ((PlayerState)i))
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
}
