using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAreas : MonoBehaviour {

    private int previousNone = 0;

    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            PickPlatform(transform.GetChild(i));
        }   
    }

    public void PickPlatform(Transform platformArea)
    {
        int randomPlatformLength = Random.Range(previousNone, 5);
        if (randomPlatformLength > 0)
        {
            platformArea.GetComponent<PlatformsGenerator>().Arrange(randomPlatformLength);
            previousNone = 0;
        }
        else
        {
            previousNone = 1;
        }
    }
}
