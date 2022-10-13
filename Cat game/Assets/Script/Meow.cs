using UnityEngine;

public class Meow : MonoBehaviour
{
    private AudioSource _audioSource;
    
    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMeow()
    {
        _audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        _audioSource.Play();
    }
}
