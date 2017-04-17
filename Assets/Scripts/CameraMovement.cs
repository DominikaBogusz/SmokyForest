using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Vector3 cameraPosition;
    public static float cameraSpeed;

    void Start()
    {
        cameraSpeed = 5f;
    }

    void Update()
    {
        cameraPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector3(0f, cameraPosition.y + cameraSpeed * Time.deltaTime, -10f);
    }

    public static void IncreaseCameraSpeed()
    {
        if (cameraSpeed < 18f)
        {
            cameraSpeed += 1f;
        }
    }

    public float getCameraSpeed()
    {
        return cameraSpeed;
    }
}
