using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] List<GameObject> _player = new List<GameObject>();
    public List<GameObject> Player => _player;
    [SerializeField] int _playerSelect;
    public int PlayerSelect => _playerSelect;
    void Start()
    {
        _playerSelect = _player.IndexOf(_player[0]);
    }
    void Update()
    {
        ChangePlayer();
        if (_player[_playerSelect].GetComponent<DEAD>()._isDead == true || Input.GetKeyDown(KeyCode.C)
         && _player[_playerSelect].GetComponent<PlayerController>().IsGrounded)
        {
            int nextPlayerIndex = _playerSelect;
            do
            {
                if (nextPlayerIndex < _player.Count - 1)
                {
                    nextPlayerIndex++;
                }
                else
                {
                    nextPlayerIndex = 0;
                }
            } while (_player[nextPlayerIndex].GetComponent<DEAD>()._isDead == true
            && nextPlayerIndex != _playerSelect);

            if (_player[nextPlayerIndex].GetComponent<DEAD>()._isDead == false)
            {
                _playerSelect = nextPlayerIndex;
                ChangePlayer();
            }
            else
            {
                StartCoroutine(ChangeScene());
            }
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
                player.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                player.GetComponent<PlayerController>().enabled = false;
                player.transform.GetChild(1).gameObject.SetActive(false);
                player.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
