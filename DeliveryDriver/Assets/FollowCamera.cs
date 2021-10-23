using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject car;

    // camera's position should be car's position
    void Update()
    {
        transform.position = car.transform.position + new Vector3(0, 0, -10);
    }
}
