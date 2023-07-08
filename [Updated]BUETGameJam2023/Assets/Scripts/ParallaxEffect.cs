using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startPos;
    private float length;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    private PlatformSpawn platformSpawn; // Reference to the PlatformSpawn script

    private void Start()
    {
        cam = GameObject.Find("Virtual Camera");
        startPos = transform.position.x;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        // Get the PlatformSpawn component attached to the spawn point GameObject
        platformSpawn = GetComponent<PlatformSpawn>();

        // Call the SpawnPlatform method from the PlatformSpawn script to spawn the initial platform.
        platformSpawn.SpawnPlatform();
    }

    private void Update()
    {
        float temp = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;

            // Call the SpawnPlatform method from the PlatformSpawn script to spawn a new platform.
            platformSpawn.SpawnPlatform();
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
