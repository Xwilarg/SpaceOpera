using UnityEngine;
using FMODUnity;

namespace SpaceOpera.Audio 
{
    public class AudioManager : MonoBehaviour 
    {
        public const float ThemePhaseBase = 0f;
        public const float ThemePhaseKick = 1f;
        public const float ThemePhaseHat  = 2f;

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

        public void SetBackgroundMusicParameter(string paramName, float paramValue)
        {
            var emitter = GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.SetParameter(paramName, paramValue);
        }
    }
}