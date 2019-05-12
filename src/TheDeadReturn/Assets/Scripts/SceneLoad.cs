using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    Button button;
    public string scene;
    public AudioClip clip;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            SceneManager.LoadScene(scene);
        });
    }


    private void Audio()
    {
        var audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot(clip);
    }
}
