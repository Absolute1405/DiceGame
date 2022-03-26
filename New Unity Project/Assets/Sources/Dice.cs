using System.Threading.Tasks;
using UnityEngine;

namespace DiceGame
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private int _facesCount = 6;
        [SerializeField] private DiceClickHandler _clickHandler;

        private TaskCompletionSource<int> _throwTask;

        private void Awake()
        {
            _clickHandler.Clicked += OnClicked;
        }

        private void OnDestroy()
        {
            _clickHandler.Clicked -= OnClicked;
        }

        public async Task<int> WaitThrow()
        {
            _clickHandler.enabled = true;
            _throwTask = new TaskCompletionSource<int>();
            return await _throwTask.Task;
        }

        private void OnClicked()
        {
            var result = GetRandom();
            _clickHandler.enabled = false;
            _throwTask.SetResult(result);
        }

        private int GetRandom()
        {
            var result = Random.Range(0, _facesCount);
            return result + 1;
        }
    }
}

