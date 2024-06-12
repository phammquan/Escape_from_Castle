using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool _isOn = false;
    Animator _anim;
    void Start()
    {
        _anim = this.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isOn = true;
            _anim.SetBool("On", true);
        }
    }
}
