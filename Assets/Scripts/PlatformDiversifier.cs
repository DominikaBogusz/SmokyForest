using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDiversifier : MonoBehaviour {

    [SerializeField]
    private Sprite[] objects;

    void Start()
    {
        int amount = objects.Length;
        if (amount > 0)
        {
            int chances = amount + amount/2;
            int randomObject = Random.Range(0, chances);
            if (randomObject < amount)
            {
                SpriteRenderer dp = transform.GetChild(0).GetComponent<SpriteRenderer>();
                dp.sprite = objects[randomObject];
            }
        }
        int randomSide = Random.Range(0, 2);
        if (randomSide == 1)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
