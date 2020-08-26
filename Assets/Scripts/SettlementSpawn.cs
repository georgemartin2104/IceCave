using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementSpawn : MonoBehaviour
{
    public int rotationX;
    public int rotationZ;
    public int positionX;
    public int positionZ;
    public GameObject[] Objects;
    public Vector3 newLocation;
    public float randomSize;
    public float newSizeX;
    public float newSizeY;
    public float newSizeZ;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in Objects)
        {
            positionX = Random.Range(-210, 210);
            positionZ = Random.Range(-210, 210);
            newLocation = new Vector3(positionX, 0, positionZ);
            int newRotation = Random.Range(0, 360);
            if (positionX < -190)
            {
                newRotation = Random.Range(240, 300);
            }
            if (positionX > 190)
            {
                newRotation = Random.Range(60, 120);
            }
            if (positionZ < -190)
            {
                newRotation = Random.Range(150, 210);
            }
            if (positionZ > 190)
            {
                newRotation = Random.Range(-30, 30);
            }
            newSizeX = Random.Range(0, randomSize);
            newSizeX = newSizeX + Objects[count].transform.localScale.x;
            newSizeY = Random.Range(0, randomSize);
            newSizeY = newSizeY + Objects[count].transform.localScale.y;
            newSizeZ = Random.Range(0, randomSize);
            newSizeZ = newSizeZ + Objects[count].transform.localScale.z;
            Objects[count].transform.localScale = new Vector3(newSizeX, newSizeY, newSizeZ);
            Objects[count].transform.position = newLocation;
            Objects[count].transform.eulerAngles = new Vector3(rotationX, newRotation, rotationZ);
            count++;
        }
    }
}
