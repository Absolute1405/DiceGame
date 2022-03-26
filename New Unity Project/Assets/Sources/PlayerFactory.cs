using DiceGame.Configs;
using UnityEngine;

namespace DiceGame
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private PlayerView _prefab;

        public Player Instantiate(PlayerConfig config)
        {
            var instance = Instantiate(_prefab);
            var result = new Player(config.Name, instance);

            instance.Initialize(config.Sprite, config.Color);
            return result;
        }
    }
}

