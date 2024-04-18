using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pooling : Singleton<Object_Pooling>
{
    Dictionary<GameObject, List<GameObject>> _listObject = new Dictionary<GameObject, List<GameObject>>();
    public GameObject getPreFabs(GameObject defaultPrefab)
    {
        if (_listObject.ContainsKey(defaultPrefab))
        {
            foreach (GameObject o in _listObject[defaultPrefab])
            {
                if (o.activeSelf)
                    continue;
                return o;
            }

            GameObject g = Instantiate(defaultPrefab, this.transform.position, Quaternion.identity);

            _listObject[defaultPrefab].Add(g);
            g.SetActive(false);

            return g;
        }
        List<GameObject> newList = new List<GameObject>();

        GameObject g2 = Instantiate(defaultPrefab, this.transform.position, Quaternion.identity);

        newList.Add(g2);
        g2.SetActive(false);

        _listObject.Add(defaultPrefab, newList);

        return g2;
    }

}
