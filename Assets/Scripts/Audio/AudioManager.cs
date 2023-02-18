using UnityEngine;
using FMODUnity;

namespace SpaceOpera.Audio 
{
    public class AudioManager : MonoBehaviour 
    {
        public static AudioManager Instance { get; private set; }
        protected virtual void Awake() 
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayOneShot(EventReference sound, Vector3 worldPos) 
        {
            RuntimeManager.PlayOneShot(sound, worldPos);
        }
    }
}