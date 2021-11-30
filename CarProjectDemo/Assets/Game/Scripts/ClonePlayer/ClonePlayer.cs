using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePlayer : MonoBehaviour,ICollectable
{
    public List<GhostRecord> ghostRecords = new List<GhostRecord>();
    public int CurrentIndex;
    public int NextIndex;
    public bool IsPlay;


    public Transform _startPoz;
    void Start()
    {
        
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        GameManager.Instance.ClonePlayer = this;
        gameObject.SetActive(false);
        _startPoz = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (IsPlay)
        {
            NextIndex = CurrentIndex + 1;
            if (NextIndex<ghostRecords.Count)
            {
                SetTransform(NextIndex);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Exit")
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.GetComponent<ICollectable>() != null)
        {
            other.gameObject.GetComponent<ICollectable>().DoCollect(gameObject);
        }
    }

    public void SetTransform(int index)
    {
        
        CurrentIndex = index;
        GhostRecord ghostRecord = ghostRecords[index];
        transform.position = ghostRecord.Position;
        transform.rotation = ghostRecord.Rotation;

    }
    public void ResetPoz()
    {
        gameObject.SetActive(true);
        CurrentIndex = 0;
    }

    public void DoCollect(GameObject collectObj)
    {
        if (collectObj.GetComponent<PlayerController>() == null)
        {
            GameManager.Instance.OldClones.Remove(this);
            GameManager.Instance.OldClones.Remove(collectObj.GetComponent<ClonePlayer>());
            Destroy(collectObj);
            Destroy(gameObject);
        }
        else
        {
            GameManager.Instance.RetryLevel();
        }
    }
}
