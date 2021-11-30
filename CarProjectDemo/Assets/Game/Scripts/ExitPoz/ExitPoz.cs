using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.CurrentLevel.ExitPoz = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
