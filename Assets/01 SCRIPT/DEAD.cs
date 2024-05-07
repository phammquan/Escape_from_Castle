using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEAD : MonoBehaviour
{
    public bool _isDead = false;
    Rigidbody2D _rigi;
    public Rigidbody2D _Rigi => _rigi;
    [SerializeField] AnimDie _animDie;
    public AnimDie _AnimDie => _animDie;

    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow" && !_isDead)
        {
            _isDead = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
            _animDie = AnimDie.DIE_ARROW;
            _rigi.gravityScale = 0;
        }
        else if (other.gameObject.tag == "Sword")
        {
            _isDead = true;
            _animDie = AnimDie.DIE;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (other.gameObject.tag == "Magic")
        {
            _isDead = true;
            if (this.GetComponent<BoxCollider2D>().enabled == false)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                this.GetComponent<BoxCollider2D>().size = new Vector2(2.45655f, 2.403677f);
                this.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                this.GetComponent<BoxCollider2D>().size = new Vector2(2.45655f, 2.403677f);

            }
            _animDie = AnimDie.DIE_MAGIC;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap" && !_isDead)
        {
            _isDead = true;
            _animDie = AnimDie.DIE;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public enum AnimDie
    {
        DIE,
        DIE_ARROW,
        DIE_MAGIC
    }
}
