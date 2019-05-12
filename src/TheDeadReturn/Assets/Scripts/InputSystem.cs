using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public GameObject SelectGhost;
    public GameObject SelectTarget;
    public RaycastHit2D hit;
    private void Update()
    {
//        Debug.Log(Input.mousePosition);
        hit = Physics2D.Raycast(new Vector2(Input.mousePosition.x, Input.mousePosition.y), new Vector2(1, 0));
        try
        {
            if (hit.collider.name == "Ghost")
            {
                print("a");
            }
        }
        catch
        {

        }
    }
}
