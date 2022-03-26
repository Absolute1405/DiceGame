using DiceGame.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace DiceGame
{
    public class GameInitializator : MonoBehaviour
    {
        [SerializeField] private GameConfig _config;
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private GameFlow _flow;

        private List<Player> _players;

        private void Awake()
        {
            _players = new List<Player>();

            foreach (var config in _config.PlayerConfigs)
            {
                var player = _playerFactory.Instantiate(config);
                _players.Add(player);
            }
        }

        private void Start()
        {
            _flow.StartGame(_players.ToArray());
        }
    }
}

