using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEAD : MonoBehaviour
{
    public bool _isDead = false;
    public Rigidbody2D _rigi;
    [SerializeField] Sprite arrow_hit;

    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "Magic" || other.gameObject.tag == "Sword")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            _isDead = true;
        }
    }
}
