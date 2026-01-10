using BirdFix.FixedBirds.Abstractions;
using BirdFix.FixedBirds.Birds;

namespace BirdFix.FixedBirds.BirdProduction
{
    public class BirdRepository
    {
        private readonly Dictionary<string, Func<IBird>> _birbs = new()
        {
            ["Penguin"] = () => new Penguin(),
            ["Sparrow"] = () => new Sparrow(),
        };

        public IReadOnlyDictionary<string, Func<IBird>> Birds => _birbs;

        public void Add(string birdType, Func<IBird> creator)
        {
            _birbs.Add(birdType, creator);
        }
        public void Remove(string birdType)
        {
            _birbs.Remove(birdType);
        }
    }
}
