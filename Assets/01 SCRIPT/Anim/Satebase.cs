using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Satebase : MonoBehaviour
{
    public abstract void _Start();
    public abstract void UpdateAnimation(PlayerController.PlayerState playState);
    public abstract void UpdateAttackAnim(PlayerController.AttackState shootSate);
}
