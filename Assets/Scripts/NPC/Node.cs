﻿using System.Collections.Generic;
using UnityEngine;

namespace SpaceOpera.NPC
{
    public class Node : MonoBehaviour
    {
        public static int id = 0;

        [SerializeField]
        private Node[] _nextNodes;

        private int _id;
        private List<Node> _nodes = new();

        private void Awake()
        {
            _id = id++;
            foreach (var n in _nextNodes)
            {
                Add(n);
                n.Add(this);
            }
        }

        private void Add(Node n)
        {
            if (!_nodes.Contains(n))
            {
                _nodes.Add(n);
            }
        }

        public static bool operator ==(Node left, Node right)
        {
            if (left is null)
            {
                return right is null;
            }
            if (right is null)
            {
                return false;
            }
            return left._id == right._id;
        }

        public static bool operator !=(Node left, Node right)
        {
            return !(left == right);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            foreach (var n in _nextNodes)
            {
                Gizmos.DrawLine(transform.position, n.transform.position);
            }
        }
    }
}
