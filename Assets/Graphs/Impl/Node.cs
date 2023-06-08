using System.Collections.Generic;
using UnityEngine;

namespace Graphs
{
    [ExecuteAlways]
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private List<Node> neighbours;

        /// <summary>
        /// Cost from start to this node.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Estimated cost from this node to goal.
        /// </summary>
        public float EstimatedCost { get; set; }

        public Node Predecessor { get; set; }

        public IReadOnlyList<Node> GetNeighbors()
        {
            return neighbours;
        }

        private void OnDrawGizmos()
        {
            Color oldColor = Gizmos.color;
            Gizmos.color = Color.green;
            foreach (Node node in neighbours)
            {
                if (node != null)
                {
                    Gizmos.DrawLine(transform.position, node.transform.position);
                }
            }
            Gizmos.color = oldColor;
        }

        private void OnValidate()
        {
            foreach (Node node in neighbours)
            {
                if (!node.neighbours.Contains(this))
                {
                    node.neighbours.Add(this);
                }
            }
        }
    }
}