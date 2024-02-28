using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField] GameObject FallingPlatform;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance!= this)
            Destroy(gameObject);
    }

    private void Start()
    {
        Instantiate(FallingPlatform, new Vector2(-0.56f, 1.76f), FallingPlatform.transform.rotation);
        Instantiate(FallingPlatform, new Vector2(8.42f, 19.72f), FallingPlatform.transform.rotation);
        Instantiate(FallingPlatform, new Vector2(2.25f, 45.3f), FallingPlatform.transform.rotation);
        Instantiate(FallingPlatform, new Vector2(-1.84f, 46.73f), FallingPlatform.transform.rotation);
        Instantiate(FallingPlatform, new Vector2(-6.05f, 45.71f), FallingPlatform.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(3f);
        Instantiate (FallingPlatform, spawnPosition, FallingPlatform.transform.rotation);
    }
}
