using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Butto_in_game : MonoBehaviour
{
    [SerializeField] Button RePlay;
    [SerializeField] Button Home;

    void Start()
    {
        RePlay.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        Home.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
