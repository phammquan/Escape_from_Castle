using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int cnt = 0;
    public int check;
    [SerializeField] List<GameObject> _switch = new List<GameObject>();

    void Start()
    {
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
            gameObject.SetActive(false);
        }
    }
}
