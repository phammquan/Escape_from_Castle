using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackmove : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D _rigi;
    private void OnEnable()
    {
        StartCoroutine(DisableTime());
    }
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        move();
    }
    void move()
    {
        _rigi.velocity = _speed * this.transform.right;
    }
    IEnumerator DisableTime()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}