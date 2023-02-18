using System.Linq;
using UnityEngine;

namespace SpaceOpera.NPC
{
    public class AIController : Character
    {
        private Node _targetNode;

        private void Awake()
        {
            Init();
            _targetNode = GameObject.FindGameObjectsWithTag("Node").OrderBy(x => Mathf.Abs(x.transform.position.x - transform.position.x) + Mathf.Abs(x.transform.position.y - transform.position.y)).First().GetComponent<Node>();
        }

        private void FixedUpdate()
        {
            _mov = (_targetNode.transform.position - transform.position).normalized;

            _FixedUpdate();

            if (Vector2.Distance(transform.position, _targetNode.transform.position) < .5f)
            {
                _targetNode = _targetNode.GetNextNode(_targetNode);
            }
        }
    }
}
