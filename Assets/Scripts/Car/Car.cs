namespace Car
{
    public class Car : IUpgradableCar
    {
        private float _speed;
        private float _defaultSpeed;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float DefaultSpeed => _defaultSpeed;

        public Car(float speed)
        {
            _defaultSpeed = speed;
            _speed = _defaultSpeed;
        }
    }
}