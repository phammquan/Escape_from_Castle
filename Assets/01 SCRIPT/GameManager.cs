using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] List<GameObject> _player = new List<GameObject>();
    [SerializeField] int _playerSelect = 0;
    public int PlayerSelect => _playerSelect;
    void Update()
    {
        ChangePlayer();
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_playerSelect < _player.Count - 1)
            {
                _playerSelect++;
            }
            else
            {
                _playerSelect = 0;
            }
            ChangePlayer();
        }

    }
    void ChangePlayer()
    {

        foreach (GameObject player in _player)
        {
            if (_playerSelect == _player.IndexOf(player))
            {
                player.GetComponent<PlayerController>().enabled = true;
                player.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                player.GetComponent<PlayerController>().enabled = false;
                player.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}
