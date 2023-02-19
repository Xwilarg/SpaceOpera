using TMPro;
using UnityEngine;

namespace SpaceOpera.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _dialogueContainer;

        [SerializeField]
        private TMP_Text _dialogueText;

        public static DialogueManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void Hide()
        {
            _dialogueContainer.SetActive(false);
        }

        public void Show(string text)
        {
            _dialogueText.text = text;
        }

        public bool IsEnabled => _dialogueContainer.activeInHierarchy;
    }
}
