using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Time_VFX : MonoBehaviour
{
    float _lifeTime = 0.6f;

    private void OnEnable()
    {
        StartCoroutine(DisableVFX());
    }

    IEnumerator DisableVFX()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
