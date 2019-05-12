using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Talker : MonoBehaviour
{
    public string talker;

    public Color color;

    public Text text;

    //透明周期
    public float clock=1;

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = string.Format("<Color=#{0}>{1}</Color>",ColorUtility.ToHtmlStringRGB(color),talker);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        Application.Quit();
    }

    public void SetAlpha()
    {
        text.DOColor(new Color(0, 0, 0, 0),clock);
    }
}
