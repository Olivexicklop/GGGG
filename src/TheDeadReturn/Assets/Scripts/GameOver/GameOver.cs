using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public int delay=1;
    private void Start()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
        Invoke("GG", delay);
    }
    private void GG()
    {
        var tween = GetComponent<Image>().DOColor(new Color(1, 1, 1, 1),1);
        tween.OnKill(() => { var t2 = GetComponent<Image>().DOColor(new Color(0, 0, 0, 1), 1);
            t2.OnKill(() => { SceneManager.LoadScene("Play"); })
            ;
        });
    }
}
