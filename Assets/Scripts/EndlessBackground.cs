using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour {

    private float height;

    void Start()
    {
        height = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
    }

    void OnBecameInvisible()
    {
        transform.Translate(transform.position.x, height * 4, transform.position.z);
    }
}
