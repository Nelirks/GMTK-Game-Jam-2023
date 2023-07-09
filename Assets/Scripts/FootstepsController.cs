using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    public AudioClip[] walkingSounds;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayRandomWalkingSound()
    {
        int index = Random.Range(0, walkingSounds.Length);
        audioSource.PlayOneShot(walkingSounds[index]);
    }
}
