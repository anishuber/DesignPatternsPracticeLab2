using BirdFix.FixedBirds.Abstractions;


namespace BirdFix.FixedBirds.BirdProduction
{
    public class BirdProducer : IBirdProducer
    {
        private readonly BirdRepository _repository;

        public BirdProducer(BirdRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IBird Produce(string birdType)
        {
            _repository.Birds.TryGetValue(birdType, out var result);
            ArgumentNullException.ThrowIfNull(result);

            return result();
        }
    }
}
