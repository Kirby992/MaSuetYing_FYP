using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform cam;

    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] Vector3 offset;

    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        offset= cam.position - target.position;
    }


    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        cam.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, moveSpeed);
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, moveSpeed);
        //transform.position = smoothPosition;

        transform.LookAt(target);
    }
}
