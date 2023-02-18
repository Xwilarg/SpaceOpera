using TMPro;
using UnityEngine;

namespace SpaceOpera.Computer
{
    public class UpdateDoorToggleText : MonoBehaviour
    {
        private string _orText;

        private void Awake()
        {
            _orText = GetComponent<TMP_Text>().text;
            UpdateDoorStatus(false);
        }

        public void UpdateDoorStatus(bool value)
        {
            GetComponent<TMP_Text>().text = _orText.Replace("{0}", value ? "Unlocked" : "Locked");
        }
    }
}
