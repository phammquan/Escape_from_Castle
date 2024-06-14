using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackmove : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D _rigi;
    [SerializeField] GameObject _vfx_hit;
    Quaternion dir;
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
        dir = this.transform.rotation;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            GameObject bl = Object_Pooling.Instance.getPreFabs(_vfx_hit);
            bl.transform.position = this.transform.position;

            bl.transform.localScale = new Vector3(dir.z < 0 ? 1 : -1, 1, 1);
            bl.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}