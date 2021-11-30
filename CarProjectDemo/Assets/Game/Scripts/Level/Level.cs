using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public PlayerController Player;
    public Transform EnterPoz;
    public Transform ExitPoz;
    void Start()
    {
        PlayerSpawn();
        GameManager.Instance.CurrentLevel = this;
        if (GameManager.Instance.CurrentLevel.Player!=null)
        {
            GameManager.Instance.CurrentLevel.Player.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayerSpawn()
    {
        Instantiate(GameManager.Instance.PlayerData.Players[GameManager.Instance.LevelIndex].gameObject, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
