using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiceGame
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Waypoint[] _waypointsOrder;

        public Waypoint StartWaypoint => _waypointsOrder[0];
        public Waypoint FinishWaypoint => _waypointsOrder[_waypointsOrder.Length - 1];

        private List<Waypoint> _waypoints;

        private void Awake()
        {
            _waypoints = new List<Waypoint>(_waypointsOrder);
        }

        public Waypoint GetNextWaypoint(Waypoint currentWaypoint, int steps)
        {
            var currentIndex = _waypoints.IndexOf(currentWaypoint);

            if (currentIndex == -1)
                throw new InvalidOperationException("Waypoint not found");

            var nextIndex = currentIndex + steps;
            if (nextIndex >= _waypoints.Count)
                return FinishWaypoint;

            return _waypoints[nextIndex];
        }
    }
}

