using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacement : MonoBehaviour
{
    public int rotationX;
    public int rotationZ;
    public GameObject[] Objects;
    public Vector3 newLocation;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in Objects)
        {
            newLocation = new Vector3(Random.Range(-230, 230), 0, Random.Range(-230, 230));
            int newRotation = Random.Range(0, 360);
            Objects[count].transform.position = newLocation;
            Objects[count].transform.eulerAngles = new Vector3(rotationX, newRotation, rotationZ);
            count++;
        }
    }
}
