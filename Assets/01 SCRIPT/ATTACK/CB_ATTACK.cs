using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CB_ATTACK : Singleton<CB_ATTACK>
{
    Collider2D _colli;
    Vector2 _force;
    Quaternion q;
    public Quaternion Q => q;
    public Vector2 Force => _force;
    private void OnEnable()
    {
        StartCoroutine(WaitAttack());
    }

    void Start()
    {
        q = this.transform.rotation;
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
        if (q.z < 0)
        {
            _force = new Vector2(-500, 600);
        }
        if (q.z == 0)
        {
            _force = new Vector2(500, 600);
        }
    }
}
