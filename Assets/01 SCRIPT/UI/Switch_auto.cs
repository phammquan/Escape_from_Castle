using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_auto : MonoBehaviour
{
    [SerializeField] List<GameObject> switchs = new List<GameObject>();
    private int currentIndex = 0;
    private bool isSwitching = false;

    void Start()
    {

        if (switchs.Count > 0)
        {
            switchs[currentIndex].transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (!isSwitching)
        {
            StartCoroutine(Switch());
        }
    }

    IEnumerator Switch()
    {
        isSwitching = true;

        yield return new WaitForSeconds(1f);

        switchs[currentIndex].transform.GetChild(1).gameObject.SetActive(false);


        currentIndex = (currentIndex + 1) % switchs.Count;

        switchs[currentIndex].transform.GetChild(1).gameObject.SetActive(true);


        isSwitching = false;
    }
}