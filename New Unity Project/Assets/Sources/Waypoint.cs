using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceGame
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private WaypointPositions _positions;

        public IWaypointSpecialAction[] SpecialActions { get; private set; }

        private Dictionary<IWaypointPlayer, Transform> _players;

        private void Awake()
        {
            SpecialActions = GetComponents<IWaypointSpecialAction>();
            _players = new Dictionary<IWaypointPlayer, Transform>();
        }

        public void PlacePlayer(IWaypointPlayer player)
        {
            var root = _positions.GetFreeRoot();

            _players.Add(player, root);
            player.View.SetPosition(root.position);
        }

        public void RemovePlayer(IWaypointPlayer player)
        {
            var root = _players[player];

            if (root == null)
                throw new ArgumentOutOfRangeException("Waypoint doesnt contain that player");

            _positions.ReleaseRoot(root);
            _players.Remove(player);
        }
    }
}

