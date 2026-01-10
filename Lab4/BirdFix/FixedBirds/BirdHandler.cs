using BirdFix.FixedBirds.Abstractions;

namespace BirdFix.FixedBirds
{
    public class BirdHandler
    {
        private readonly IBirdProducer _birdProducer;
        private readonly IReadOnlyList<string> _birdTypes;
        public BirdHandler(IBirdProducer birdProducer, IReadOnlyList<string> birdTypes)
        {
            _birdProducer = birdProducer ?? throw new ArgumentNullException(nameof(birdProducer));
            _birdTypes = birdTypes ?? throw new ArgumentNullException(nameof(birdTypes));
        }

        public void DoBirdActions()
        {
            foreach (var type in _birdTypes)
            {
                var bird = _birdProducer.Produce(type);

                HandleMovement(bird);
                HandleMating(bird);
                HandleReproduction(bird);
            }
        }
        public static void HandleMating(IBird bird)
        {
            bird.SearchForSpouse();
            bird.Sing();
            if (bird is IWalkingBird walking)
            {
                walking.Dance();
            }
        }
        public static void HandleMovement(IBird bird)
        {
            if (bird is IWalkingBird walking)
            {
                HandleWalking(walking);
            }
            if (bird is IFlyingBird flying)
            {
                HandleFlying(flying);
            }
        }

        public static void HandleReproduction(IBird bird)
        {
            bird.ProduceEgg();
            bird.DefendEgg();
        }

        private static void HandleFlying(IFlyingBird bird) => bird.Fly();
        private static void HandleWalking(IWalkingBird bird) => bird.Walk();
    }
}
