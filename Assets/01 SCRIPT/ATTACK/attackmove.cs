using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackmove : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D _rigi;
    SpriteRenderer _sprite;
    Collider2D _collider;
    private bool hasHitPlayer = false;
    [SerializeField] Sprite arrow_hit;
    bool done = false;
    private void OnEnable()
    {
        StartCoroutine(DisableTime());
    }
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (!done)
        {
            move();
        }
    }
    void move()
    {
        _rigi.velocity = _speed * this.transform.right;
    }
    IEnumerator DisableTime()
    {
        yield return new WaitForSeconds(3f);
        if (!hasHitPlayer)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !done)
        {
            _sprite.sprite = arrow_hit;
            other.gameObject.transform.SetParent(this.transform);
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                playerRigidbody.gravityScale = 0;
            }
            hasHitPlayer = true;
            done = true;
        }
    }
}