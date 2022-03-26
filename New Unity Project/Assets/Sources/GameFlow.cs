using System.Collections.Generic;
using UnityEngine;

namespace DiceGame
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private Dice _dice;
        [SerializeField] private Map _map;

        public void StartGame(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.PlaceTo(_map.StartWaypoint);
            }

            Debug.Log("Prepare for game");

            PlayTurnsInOrder(players);
        }

        public async void PlayTurnsInOrder(IEnumerable<Player> players)
        {
            while (true)
            {
                foreach (var player in players)
                {
                    Debug.Log($"{player.Name}, your turn!");

                    var steps = await _dice.WaitThrow();
                    Debug.Log($"Dice thrown and result is {steps}!");

                    var nextWaypoint = _map.GetNextWaypoint(player.CurrentWaypoint, steps);

                    player.MoveTo(nextWaypoint);

                    if (nextWaypoint == _map.FinishWaypoint)
                    {
                        FinishGame(player);
                        return;
                    }
                }
            }
        }

        private void FinishGame(Player leader)
        {
            Debug.Log($"{leader.Name} is winner");
        }

    }
}

