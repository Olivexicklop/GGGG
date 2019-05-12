using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Submit : MonoBehaviour
{
    public Text ui;

    public string text;

    public int current;
    public float speed;
    public float timer=1;
    private void Start()
    {
        ui = GetComponent<Text>();
        text = ui.text;
        ui.text = "";
    }
    public bool endflag=false;
    private void Update()
    {
        if(!endflag)
        if (timer < 0)
        {
            if (current < text.Length)
            {
                ui.text += text[current];
                current++;
                timer = 1;
            }
            else
            {
                endflag = true;
            }

        }
        else
        {
            timer -= Time.deltaTime*speed;
        }
    }
}
