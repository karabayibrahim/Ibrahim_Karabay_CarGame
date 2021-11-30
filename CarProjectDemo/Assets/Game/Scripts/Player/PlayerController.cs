using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public bool LeftBool;
    public bool RightBool;
    public bool IsPlayMode;
    public List<GameObject> FrontWheels = new List<GameObject>();

    private int _currentIndex;
    private bool _startBool;
    private ClonePlayer myClone;
    void Start()
    {
        GameManager.Instance.CurrentLevel.Player = this;
        gameObject.transform.position = GameManager.Instance.CurrentLevel.EnterPoz.position;
        gameObject.transform.right = GameManager.Instance.CurrentLevel.EnterPoz.transform.right;
        CloneSpawn();
        StartCoroutine(StartStatus());
    }

    // Update is called once per frame
    void Update()
    {
        CarMovementSystem();
        if (LeftBool)
        {
            CarRotateLeft();
        }
        if (RightBool)
        {
            CarRotateRight();
        }
    }
    private void FixedUpdate()
    {
        if (IsPlayMode==false)
        {
            myClone.ghostRecords.Add(new GhostRecord { Position = transform.position, Rotation = transform.rotation });
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Exit")
        {
            myClone.IsPlay = true;
            GameManager.Instance.NextLevel();
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<ICollectable>()!=null)
        {
            other.gameObject.GetComponent<ICollectable>().DoCollect(gameObject);
        }
    }
    private void CarMovementSystem()
    {
        if (_startBool)
        {
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
    }
    private void CarRotateLeft()
    {
        transform.Rotate(0, -100f*Time.deltaTime, 0);
    }
    private void CarRotateRight()
    {
        transform.Rotate(0, 100f*Time.deltaTime, 0);
    }

    private void CloneSpawn()
    {
        var clone = Instantiate(gameObject, transform.position, Quaternion.identity);
        Destroy(clone.GetComponent<PlayerController>());
        clone.AddComponent<ClonePlayer>();
        myClone = clone.GetComponent<ClonePlayer>();

    }

    public void MoveLeftBool(bool _left)
    {
        LeftBool = _left;
        //foreach (var item in FrontWheels)
        //{
        //    item.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 45f, transform.eulerAngles.z);
        //}
    }
    public void MoveRightBool(bool _right)
    {
        RightBool = _right;
    }
    public void RetryStatus()
    {
        _startBool = false;
        transform.position = GameManager.Instance.CurrentLevel.EnterPoz.position;
        transform.right = GameManager.Instance.CurrentLevel.EnterPoz.right;
        StartCoroutine(StartStatus());
    }
    private IEnumerator StartStatus()
    {
        yield return new WaitForSeconds(1f);
        _startBool = true;
    }
}
