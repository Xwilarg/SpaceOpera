using UnityEngine;
using FMODUnity;

namespace SpaceOpera.Audio 
{
    public class FMODEvents : MonoBehaviour 
    {
        [field: Header("Laser Shot SFX")]
        [field: SerializeField] public EventReference LaserShot { get; private set; }

        public static FMODEvents Instance { get; private set; }
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