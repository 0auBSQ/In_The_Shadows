using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f, 40f, 0f) / 60f, Space.World);
    }
}
