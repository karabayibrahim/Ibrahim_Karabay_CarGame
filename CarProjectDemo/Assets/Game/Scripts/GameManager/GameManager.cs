using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIManager UIManager;
    public Level CurrentLevel;
    public LevelScriptableObject LevelsData;
    public PlayerScriptableObjects PlayerData;
    public ClonePlayer ClonePlayer;
    public List<ClonePlayer> OldClones = new List<ClonePlayer>();
    public int LevelIndex = 0;
    // Start is called before the first frame update
    void Awake()
    {
        SpawnLevel(LevelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnLevel(int _levelIndex)
    {
        if (CurrentLevel==null)
        {
            var currentlevel=Instantiate(LevelsData.Levels[_levelIndex], new Vector3(0, 0, 0), Quaternion.identity);
            CurrentLevel = currentlevel;
        }
        else
        {
            Destroy(CurrentLevel);
        }
    }

    public void NextLevel()
    {
        Destroy(CurrentLevel.gameObject);
        CurrentLevel = null;
        LevelIndex++;
        SpawnLevel(LevelIndex);
        //if (OldClone!=null)
        //{
        //    Destroy(OldClone.gameObject);
        //}
        OldClones.Add(ClonePlayer);
        foreach (var item in OldClones)
        {
            item.ResetPoz();
        }
        
    }

    public void RetryLevel()
    {
        CurrentLevel.Player.RetryStatus();
        foreach (var item in OldClones)
        {
            item.ResetPoz();
        }
    }
}
