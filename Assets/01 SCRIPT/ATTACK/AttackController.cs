using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject _sword;
    [SerializeField] GameObject _arrow;
    [SerializeField] GameObject _magic;


    float count = 0.75f;
    [SerializeField] PlayerController _playerController;
    [SerializeField] float _timeAttack = 0;
    GameObject bullet;

    void Update()
    {
        _timeAttack -= Time.deltaTime;

    }
    public void Attack()
    {
        if (_timeAttack > 0)
            return;
        if (GameManager.Instance.PlayerSelect == 0)
        {
            bullet = Object_Pooling.Instance.getPreFabs(_sword);
        }
        else if (GameManager.Instance.PlayerSelect == 1)
        {
            bullet = Object_Pooling.Instance.getPreFabs(_arrow);
        }
        else if (GameManager.Instance.PlayerSelect == 2)
        {
            bullet = Object_Pooling.Instance.getPreFabs(_magic);
        }
        bullet.transform.position = _playerController.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, this.transform.parent.localScale.x == 1 ? 0 : 180);
        bullet.SetActive(true);
        _timeAttack = count;
    }
}
