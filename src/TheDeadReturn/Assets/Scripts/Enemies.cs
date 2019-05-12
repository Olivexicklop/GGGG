using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private enum EnemyType
    {
        ET_Red,
        ET_Green,
        ET_Blue
    }

    private EnemyType Rurn_Type;

    // Start is called before the first frame update
    void Start()
    {
        // Set object type
        string types = gameObject.tag;
        if(types == "Rurn_Red")
        {
            Debug.Log("I'm Red");
            Rurn_Type = EnemyType.ET_Red;
        }
        else if(types == "Rurn_Green")
        {
            Debug.Log("I'm Green");
            Rurn_Type = EnemyType.ET_Green;
        }
        else if (types == "Rurn_Blue")
        {
            Debug.Log("I'm Blue");
            Rurn_Type = EnemyType.ET_Blue;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("you hit me!");
        // 若碰撞后，加入待发射的队列，且调用ModelDrag的函数发射弓箭
    }
}
