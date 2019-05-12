using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grave : MonoBehaviour
{
    public Vector3 pos;
    public float speed=0.01f;
    private void Start()
    {
        var i = GhostPicker.CurrentIndex+1;
    }

    private static GameObject GraveInit()
    {
        GameObject g;
        switch (GhostPicker.CurrentIndex)
        {
            case 1:
                g = Instantiate(Resources.Load("Prefabs/Grave/Grave_Green")) as GameObject;
                break;
            case 2:
                g = Instantiate(Resources.Load("Prefabs/Grave/Grave_Red")) as GameObject;
                break;
            case 3:
                g = Instantiate(Resources.Load("Prefabs/Grave/Grave_Blue")) as GameObject;
                break;
            default:
                return null;
        }
        return g;
    }

    private void FixedUpdate()
    {
        transform.position -= Time.deltaTime * new Vector3(1, 0, 0) * speed;
        //pos = transform.position;
        if (transform.position.x < -10)
        {
            GhostPicker.ghosts[GhostPicker.CurrentIndex].transform.BroadcastMessage("Show");
            Destroy(gameObject);
        }
    }
    
}
