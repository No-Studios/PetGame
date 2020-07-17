using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToeDestroyer : MonoBehaviour
{
    [SerializeField] private Toes _toes = null;
    [SerializeField]
    private AudioClip[] clips = null;
    public AudioSource audioSource = null;


    private void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
       
    }

    void OnTriggerStay(Collider2D collider)
    {
        if(_toes.eating == true && collider.tag == "ToeDestroyer")
        {
            AudioClip clip = GetRandomClip();
            audioSource.PlayOneShot(clip);
            Destroy(gameObject);
        }

    }
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
