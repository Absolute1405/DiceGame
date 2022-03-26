namespace DiceGame
{
    public class Player : IWaypointPlayer
    {
        public Waypoint CurrentWaypoint { get; private set; }
        public IPlayerView View => _view;
        public string Name { get; private set; }

        private PlayerView _view;

        public Player(string Name, PlayerView view)
        {
            _view = view;
            this.Name = Name;
        }

        //access only from game flow - moves player and operate on placed actions
        public void MoveTo(Waypoint waypoint)
        {
            CurrentWaypoint = waypoint;
            waypoint.PlacePlayer(this);

            foreach (var action in waypoint.SpecialActions)
            {
                action.OnPlaced(this);
            }
        }

        //access from everywhere - moves player only
        public void PlaceTo(Waypoint waypoint)
        {
            CurrentWaypoint = waypoint;
            waypoint.PlacePlayer(this);
        }
    }

    public interface IWaypointPlayer
    {
        string Name { get; }
        void PlaceTo(Waypoint waypoint);
        IPlayerView View { get; }
    }
}

