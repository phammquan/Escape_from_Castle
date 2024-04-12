using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEAD : MonoBehaviour
{
    public bool _isDead = false;
    Rigidbody2D _rigi;

    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            _isDead = true;
        }
    }
}
