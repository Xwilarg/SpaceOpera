using SpaceOpera.Dialogue;
using System.Linq;
using UnityEngine;

namespace SpaceOpera.NPC
{
    public class AIController : Character
    {
        private Node _targetNode;
        private Node _previousNode;

        private bool _isSpeaking;

        private void Awake()
        {
            Init();
            _targetNode = GameObject.FindGameObjectsWithTag("Node").OrderBy(x => Mathf.Abs(x.transform.position.x - transform.position.x) + Mathf.Abs(x.transform.position.y - transform.position.y)).First().GetComponent<Node>();
        }

        private void FixedUpdate()
        {
            _mov = _isSpeaking ? Vector2.zero : (_targetNode.transform.position - transform.position).normalized;

            _FixedUpdate();

            if (Vector2.Distance(transform.position, _targetNode.transform.position) < .5f)
            {
                var prev = _previousNode;
                _previousNode = _targetNode;
                _targetNode = _targetNode.GetNextNode(prev);
            }
        }

        public void StartSpeak()
        {
            _isSpeaking = true;
            DialogueManager.Instance.Show("Sir!");
        }

        public void StopSpeak()
        {
            _isSpeaking = false;
        }
    }
}
