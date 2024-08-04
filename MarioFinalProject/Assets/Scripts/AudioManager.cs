using System;
using UnityEngine;

namespace _app.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioClip audio;
        public AudioSource audioSource;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(obj:this);
            }
            else
            {
                Instance = this;
            }
        }

        public void PlayAudio()
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
}