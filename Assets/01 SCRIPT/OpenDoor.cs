using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int cnt = 0;
    public int check;
    [SerializeField] List<GameObject> _switch = new List<GameObject>();
    Animator _anim;

    void Start()
    {
        _anim = this.GetComponent<Animator>();
        check = _switch.Count;
    }

    void Update()
    {
        foreach (GameObject switchObj in _switch)
        {
            if (switchObj.GetComponent<Switch>()._isOn == true)
            {
                _switch.Remove(switchObj);
                cnt++;
                continue;
            }
        }
        if (cnt == check)
        {
            _anim.SetBool("Open", true);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
