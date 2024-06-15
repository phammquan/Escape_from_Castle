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
    [SerializeField] GameObject _vfx_blood;
    [SerializeField] GameObject _vfx_blood_magic;

    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            if (!_isDead)
            {
                GameObject bl = Object_Pooling.Instance.getPreFabs(_vfx_blood);
                bl.transform.position = this.transform.position;
                bl.SetActive(true);
                _animDie = AnimDie.DIE_ARROW;
                _isDead = true;
                this.GetComponent<BoxCollider2D>().isTrigger = true;
                _rigi.gravityScale = 0;
            }
            else
            {
                if (_animDie == AnimDie.DIE_MAGIC)
                {
                    GameObject bl = Object_Pooling.Instance.getPreFabs(_vfx_blood_magic);
                    bl.transform.position = this.transform.position;
                    bl.SetActive(true);
                }
                if (_animDie == AnimDie.DIE)
                {
                    GameObject bl = Object_Pooling.Instance.getPreFabs(_vfx_blood);
                    bl.transform.position = this.transform.position;
                    bl.SetActive(true);
                    _animDie = AnimDie.DIE_ARROW;
                    this.GetComponent<BoxCollider2D>().isTrigger = true;
                    _rigi.gravityScale = 0;
                }
                else
                {
                    GameObject bl = Object_Pooling.Instance.getPreFabs(_vfx_blood);
                    bl.transform.position = this.transform.position;
                    bl.SetActive(true);
                    _rigi.gravityScale = 0;
                }
            }
        }
        else if (other.gameObject.tag == "Sword")
        {
            if (_animDie == AnimDie.DIE_MAGIC)
            {
                GameObject bl0 = Object_Pooling.Instance.getPreFabs(_vfx_blood_magic);
                bl0.transform.position = this.transform.position;
                bl0.SetActive(true);
            }
            else
            {
                GameObject bl = Object_Pooling.Instance.getPreFabs(_vfx_blood);
                bl.transform.position = this.transform.position;
                bl.SetActive(true);
                if (!_isDead)
                {
                    _animDie = AnimDie.DIE;
                    this.GetComponent<BoxCollider2D>().enabled = false;
                }
                _isDead = true;

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap" && !_isDead)
        {
            GameObject bl = Object_Pooling.Instance.getPreFabs(_vfx_blood);
            bl.transform.position = this.transform.position;
            bl.SetActive(true);
            _isDead = true;
            _animDie = AnimDie.DIE;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.tag == "Magic")
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            _rigi.gravityScale = 3;
            _animDie = AnimDie.DIE_MAGIC;
            _isDead = true;
            if (this.GetComponent<BoxCollider2D>().isTrigger == true)
            {
                if (this.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
                {
                    this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
                this.GetComponent<BoxCollider2D>().isTrigger = false;
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.82f, 2.403677f);
                this.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.82f, 2.403677f);

            }

        }
    }
    public enum AnimDie
    {
        DIE,
        DIE_ARROW,
        DIE_MAGIC
    }
}
