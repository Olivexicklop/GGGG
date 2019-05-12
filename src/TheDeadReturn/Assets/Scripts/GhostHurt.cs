using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHurt : MonoBehaviour
{
    public int Health = 200;
    public float RecoverTime = 5;
    private float CurrentTime;

    public float MoveSpeed;
    public static GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = RecoverTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ammo")
        {
            Health--;
            if (Hurt.hurt == null)
            { HurtInit(); }
        }
    }

    private void HurtInit()
    {
        var g = Instantiate(Resources.Load("Prefabs/Hurt"), new Vector3(0, 0, -50), Quaternion.identity) as GameObject;
        g.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            if (gameOver == null)
            {
                var g = Instantiate(Resources.Load("Prefabs/GameOver"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                g.transform.SetParent(GameObject.Find("Canvas").transform, false);
            }
        }
    }
}
