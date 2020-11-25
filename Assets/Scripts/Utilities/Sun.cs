using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float minRotation;
    public float maxRotation;

    float isReverse;
    Vector3 rotation;
    void Start()
    {
        isReverse = 1;
        rotation = transform.rotation.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        if(rotation.x > maxRotation)
        {
            isReverse = -1f;
        }
        else if(rotation.x < minRotation)
        {
            isReverse = 1f;
        }

        rotation.x += Time.deltaTime * isReverse;

        transform.localRotation = Quaternion.Euler(rotation);
    }
}
