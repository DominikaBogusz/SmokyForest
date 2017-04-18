using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject platform1, platform2, platform3, platform4;

    [SerializeField]
    private Transform[] points1, points2, points3, points4;

    private GameObject currentPlatform;

    private static int previousNone = 0;

    void Start()
    {
        Arrange();
    }

    private void Arrange()
    {
        int randomPlatformLength = Random.Range(previousNone, 5);

        switch (randomPlatformLength)
        {
            case 0:
                previousNone = 1;
                break;
            case 1:
                previousNone = 0;
                currentPlatform = Instantiate(platform1, points1[Random.Range(0, points1.Length)]);
                break;
            case 2:
                previousNone = 0;
                currentPlatform = Instantiate(platform2, points2[Random.Range(0, points2.Length)]);
                break;
            case 3:
                previousNone = 0;
                currentPlatform = Instantiate(platform3, points3[Random.Range(0, points3.Length)]);
                break;
            case 4:
                previousNone = 0;
                currentPlatform = Instantiate(platform4, points4[Random.Range(0, points4.Length)]);
                break;
            default:
                Debug.LogError("That wasn't supposed to happen");
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Fire")
        {
            GameMaster.Instance.Score += 10;
            Destroy(currentPlatform);
            transform.Translate(new Vector3(transform.position.x, 50f));
            Arrange();
        }
    }
}
