using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : Singleton<UI_Manager>
{
    [SerializeField] Button playButton;
    [SerializeField] Button closeButton;

    [SerializeField] Button[] level;
    [SerializeField] GameObject levelselect;
    [SerializeField] Canvas Button;

    void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            levelselect.SetActive(true);
        });
        closeButton.onClick.AddListener(() =>
        {
            levelselect.SetActive(false);
        });
        level[0].onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
        level[1].onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });
    }

}
