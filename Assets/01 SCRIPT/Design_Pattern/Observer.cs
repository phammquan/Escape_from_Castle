using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Singleton<Observer>
{
    private Dictionary<string, List<Action<object>>> _listeners = new Dictionary<string, List<Action<object>>>();

    public bool AddListener(string key, Action<object> value)
    {
        List<Action<object>> actions = new List<Action<object>>();
        if (_listeners.ContainsKey(key))
        {
            actions = _listeners[key];
        }
        else
        {
            _listeners.TryAdd(key, actions);
        }
        _listeners[key].Add(value);
        return true;
    }

    public void Notify(string key, object value)
    {
        if (_listeners.ContainsKey(key))
        {
            foreach (Action<object> a in _listeners[key])
            {
                try
                {
                    a?.Invoke(value);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
            return;
        }
        Debug.LogErrorFormat("Listener {0} not exist!", key);
    }
}
