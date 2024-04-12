using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CB_ATTACK : Singleton<CB_ATTACK>
{
    Collider2D _colli;
    Vector2 _force;
    public Vector2 Force => _force;
    float zRotation;
    private void OnEnable()
    {
        StartCoroutine(WaitAttack());
    }

    void Start()
    {

        Add_Force();
        _colli = this.GetComponent<Collider2D>();

    }
    void Update()
    {
        Add_Force();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<DEAD>()._rigi.AddForce(_force);
            Debug.LogError("Hit");
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }
    void Add_Force()
    {
        if (GameManager.Instance.Player[0].transform.localScale.x == -1)
        {
            _force = new Vector2(-400, 600);
        }
        else
        {
            _force = new Vector2(400, 600);
        }
    }
}
