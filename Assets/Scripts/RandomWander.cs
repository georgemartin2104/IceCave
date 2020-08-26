using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWander : MonoBehaviour
{
    public float speed;

    public float noise1;
    public float noise2;
    public float noise3;
    public float noise4;
    public float noise5;
    public bool isNegative;
    public float frequency;
    public float result;
    public float random1;
    public float random2;
    public float random5;

    // Start is called before the first frame update
    void Start()
    {
        random1 = Random.Range(0, 4);
        random2 = Random.Range(0, 4);
        random5 = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        noise1 = Mathf.PerlinNoise(Time.time * random1, 0);
        noise2 = Mathf.PerlinNoise(Time.time * random2, 0);
        noise3 = Mathf.PerlinNoise(0.5f, 0);
        noise4 = Mathf.PerlinNoise(Mathf.Floor(Time.time), 0);
        noise5 = Mathf.PerlinNoise(Time.time * random5, 0);

        if (noise5 < noise3)
        {
            isNegative = true;
        }
        else
        {
            isNegative = false;
        }
        

        result = perlin(noise1, noise2, frequency, isNegative);
        transform.Rotate(Vector3.up * result);
    }
    public float perlin(float x, float y, float frequency, bool isNegative)
    {
        float temp = Mathf.PerlinNoise(x * frequency, y * frequency);
        if(isNegative == true)
        {
            temp = temp * (0-1);
        }
        return temp;
    }
}
