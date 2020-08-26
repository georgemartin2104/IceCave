using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public int randomNo = 0;
    // Start is called before the first frame update
    void Start()
    {
        object1.SetActive(false);
        object2.SetActive(false);
        randomNo = Random.Range(0, 2);
        if (randomNo == 0)
        {
            object1.SetActive(true);
        }
        randomNo = Random.Range(0, 2);
        if (randomNo == 0)
        {
            object2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
