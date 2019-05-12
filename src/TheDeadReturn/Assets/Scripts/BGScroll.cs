using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public List<GameObject> bgNear;
    public List<GameObject> bgFar;
    public float speedNear = 10.0f;
    public float speedfar = 5.0f;
    private void FixedUpdate()
    {
        for (int i = 0; i<bgNear.Count; i++)
        {
            bgNear[i].transform.position -= new Vector3(speedNear, 0, 0) * Time.deltaTime;
        }
        for (int i = 0; i < bgFar.Count; i++)
        {
            bgFar[i].transform.position -= new Vector3(speedfar, 0, 0) * Time.deltaTime;
        }
    }
}
