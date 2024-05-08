using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioSource SwingSource;
    [SerializeField] List<AudioClip> SwingClip = new List<AudioClip>();
    [SerializeField] AudioSource HooraySource;
    [SerializeField] List<AudioClip> HoorayClip = new List<AudioClip>();
    [SerializeField] AudioSource OuchSource;
    [SerializeField] AudioClip GameOver;
    [SerializeField] AudioClip Heal;
    [SerializeField] AudioClip HyperBeam;
    [SerializeField] AudioClip Pop;
    [SerializeField] AudioClip Ouch;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwingSFX()
    {

        SwingSource.PlayOneShot(SwingClip[0]);
    }

    public void HooraySFX()
    {

        HooraySource.PlayOneShot(HoorayClip[0]);
    }


    public void ChangeMusic(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }

    public void GameOverSFX()
    {
        ChangeMusic(GameOver);
    }

    public void HealSFX()
    {

        SwingSource.PlayOneShot(Heal);
    }

    public void BeamSFX()
    {

        SwingSource.PlayOneShot(HyperBeam);
    }

    public void PopSFX()
    {

        HooraySource.PlayOneShot(Pop);
    }
    public void OuchSFX()
    {

        OuchSource.PlayOneShot(Ouch);
    }
}
