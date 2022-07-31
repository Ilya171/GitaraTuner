using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class StringSound : MonoBehaviour
{
    [SerializeField] private AudioSource _stringSound;
    private void Awake() {
        _stringSound = this.GetComponent<AudioSource>();
    }
    
    public void Play()
    {
        _stringSound.Play();
    }
}
