using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DiceGame
{
    public class WaypointPositions : MonoBehaviour
    {
        [Tooltip("Roots arrays for each player count")]
        [SerializeField] private Transform[] _rootPoints;

        //Dictionary gives information about root free or not
        private Dictionary<Transform, bool> _roots;

        private void Awake()
        {
            _roots = new Dictionary<Transform, bool>();

            foreach (var rootTransform in _rootPoints)
            {
                _roots.Add(rootTransform, false);
            }
        }

        public Transform GetFreeRoot()
        {
            var result = _roots.FirstOrDefault(x => x.Value == false).Key;
            
            if (result == null)
                throw new InvalidOperationException("No free roots at waypoint");

            _roots[result] = true;

            return result;
        }

        public void ReleaseRoot(Transform root)
        {
            if (_roots.ContainsKey(root) == false)
                throw new ArgumentException("Root has not found");

            _roots[root] = false;
        }
    }
}

