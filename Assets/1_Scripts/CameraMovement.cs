using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _smoothTime;

    void FixedUpdate()
    {
        var target = new Vector3(_target.position.x + 1, _target.position.y, _target.position.z);
        var smoothPos = Vector3.Lerp(transform.position, target, _smoothTime * Time.fixedDeltaTime);
        smoothPos = new Vector3(smoothPos.x, transform.position.y, transform.position.z);
        transform.position = smoothPos;
    }
}
