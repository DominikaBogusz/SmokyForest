using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour {

    private float height;

    void Start ()
    {
        height = GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        SetPosition();
    }

    private void SetPosition()
    {
        Vector3 currentPos = transform.position;

        if (gameObject.name == "left")
        {
            Vector3 v3Pos = new Vector3(0.02f, 0f, 0f);
            transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
            transform.position = new Vector3(transform.position.x, currentPos.y, currentPos.z);
        }
        else if (gameObject.name == "right")
        {
            Vector3 v3Pos = new Vector3(0.98f, 0f, 0f);
            transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
            transform.position = new Vector3(transform.position.x, currentPos.y, currentPos.z);
        }
    }

    void OnBecameInvisible()
    {
        transform.Translate(transform.position.x, height * 3, transform.position.z);
        SetPosition();
    }
}
