using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Attack : MonoBehaviour
{
    [SerializeField] GameObject vfx_ice1;
    [SerializeField] GameObject vfx_ice2;

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
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Platform"))
    //     {
    //         GameObject vfx = Object_Pooling.Instance.getPreFabs(vfx_ice1);
    //         vfx.transform.position = this.transform.position;
    //         vfx.SetActive(true);
    //         this.gameObject.SetActive(false);
    //     }
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         GameObject vfx = Object_Pooling.Instance.getPreFabs(vfx_ice2);
    //         vfx.transform.position = other.transform.position;
    //         vfx.SetActive(true);
    //         this.gameObject.SetActive(false);
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            GameObject vfx = Object_Pooling.Instance.getPreFabs(vfx_ice1);
            vfx.transform.position = this.transform.position;
            vfx.SetActive(true);
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject vfx = Object_Pooling.Instance.getPreFabs(vfx_ice2);
            vfx.transform.position = other.transform.position;
            vfx.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
