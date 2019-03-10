using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public AudioClip gameStart;
    [SerializeField] public AudioClip gameNextLevel;
    [SerializeField] public AudioClip gameRestart;
    [SerializeField] public AudioClip gameMusic;

    public AudioSource audioSource;

    public static GameController i;
    void Awake()
    {
        BePersistent();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(gameMusic);
    }

    private void BePersistent()
    {
        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    private void Update()
    {
        SetUpGame();
    }

    private void SetUpGame()
    {
        if (Input.GetKey(KeyCode.W))
        {
            var intro = GameObject.Find("IntroString");
            if (intro != null)
            {
                Destroy(intro);
                audioSource.PlayOneShot(gameStart);
            }
        }
    }
}
