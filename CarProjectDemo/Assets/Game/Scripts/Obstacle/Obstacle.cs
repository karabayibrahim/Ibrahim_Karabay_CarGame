using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,ICollectable
{
    public void DoCollect(GameObject collectObj)
    {
        if (collectObj.GetComponent<PlayerController>()==null)
        {
            GameManager.Instance.OldClones.Remove(collectObj.GetComponent<ClonePlayer>());
            Destroy(collectObj);
        }
        else
        {
            GameManager.Instance.RetryLevel();
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
