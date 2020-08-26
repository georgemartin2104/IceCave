using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise;
using LibNoise.Generator;
using LibNoise.Operator;

public class CaveGeneration : MonoBehaviour
{

    // The frequency of the noise
    public float frequency = 1f;

    // The lacunarity of the noise
    public float lacu = 1f;

    // The number of octaves
    public int octaves = 1;

    // The persistance of the noise
    public float persist = 1f;

    // The threshold to cut-off at
    public float threshold = 0.5f;

    // The falloff amount
    public float falloff = 0.25f;


    public void generate()
    {
        // Get the terrain data of the currently active terrain
        var terrainData = Terrain.activeTerrain.terrainData;

        // A new ridged multifractal generator
        var generator = new RidgedMultifractal(frequency, lacu, octaves, (int)(Random.value * 0xffffff), QualityMode.High);

        // The thresholded output -- choose either 0.0 or 1.0, based on the output
        var clamped = new LibNoise.Operator.Select(new Const(0.0f), new Const(1.0f), generator);

        // Set the threshold and falloff rate
        clamped.SetBounds(0f, threshold);
        clamped.FallOff = falloff;

        // Create a 2D noise generator for the terrain heightmap, using the generator we just created
        var noise = new Noise2D(terrainData.heightmapResolution, clamped);

        // Generate a plane from [0, 1] on x, [0, 1] on y
        noise.GeneratePlanar(0, 1, 0, 1);

        // Get the data in an array so we can use it to set the heights
        // var data = noise.GetData(true, 0, 0, true);
        var data = noise.GetNormalizedData();

        // .. and actually set the heights
        terrainData.SetHeights(0, 0, data);
    }


    // Start is called before the first frame update
    void Start()
    {
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
