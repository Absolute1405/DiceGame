using UnityEngine;

namespace DiceGame.Configs
{
    [CreateAssetMenu(fileName = "Game Config", menuName = "Configs/Game Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private PlayerConfig[] _playerConfigs;

        public PlayerConfig[] PlayerConfigs => _playerConfigs;
        public int PlayersCount => _playerConfigs.Length;
    }
}

