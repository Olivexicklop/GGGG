using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public bool isEnd;
    public float speed=10;
    public enum Type { Front,BackGround,Mask}
    public Type type;

    private void Start()
    {
        switch (type)
        {
            case Type.BackGround:
                speed = MapRoll.mapRoll.BackgroundSpeed;
                break;
            case Type.Front:
                speed = MapRoll.mapRoll.FrontSpeed;
                break;
            case Type.Mask:
                //TODO:前景速度
                speed = 0;
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0)*Time.deltaTime;
    }

    private void Update()
    {
        if (transform.localPosition.x < -5940)
        {
            if (!isEnd)
            {
                transform.localPosition += new Vector3(5940 * (MapRoll.MapsFront.Count + 1), 0, 0);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
