using UnityEngine;

namespace DiceGame.Configs
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Configs/Player Config", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _spriteColor;

        public string Name => _name;
        public Sprite Sprite => _sprite;
        public Color Color => _spriteColor;
    }
}

