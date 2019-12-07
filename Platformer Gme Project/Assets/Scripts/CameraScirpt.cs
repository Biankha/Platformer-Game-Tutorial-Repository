using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScirpt : MonoBehaviour
{
    public AudioClip musicClipTwo;
    public AudioClip musicClipOne;
    public AudioSource musicSource;
    public GameObject target;
    public Text winText;
    private int scoreValue = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = musicClipTwo;
        musicSource.Play();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void SetWinText()
    {
        winText.text = "";
        if (scoreValue == 8)
        {
            //winText.text = "You win! \n Game created by Biankha Hughes!";
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
    }

   
}
