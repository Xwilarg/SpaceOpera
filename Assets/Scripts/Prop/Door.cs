using SpaceOpera.Audio;
using UnityEngine;

namespace SpaceOpera.Prop
{
    public class Door : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(false);
            AudioManager.Instance.SetBackgroundMusicParameter("ThemePhase", AudioManager.ThemePhaseKick);
        }
    }
}
