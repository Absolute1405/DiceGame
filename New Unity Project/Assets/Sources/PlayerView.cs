using UnityEngine;

namespace DiceGame
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private SpriteRenderer _renderer;

        public void Initialize(Sprite sprite, Color color)
        {
            _renderer.sprite = sprite;
            _renderer.color = color;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }

    public interface IPlayerView
    {
        void SetPosition(Vector3 position);
    }
}

