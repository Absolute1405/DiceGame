using UnityEngine;

namespace DiceGame
{
    public class WaypointReplaceAction : MonoBehaviour, IWaypointSpecialAction
    {
        [SerializeField] private Waypoint _navigation;

        public void OnPlaced(IWaypointPlayer player)
        {
            Debug.Log($"Wow! {player.Name} replaced to another waypoint!");
            player.PlaceTo(_navigation);
        }
    }
}

