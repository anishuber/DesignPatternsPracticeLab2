namespace BadSolidExamples.OpenClosed
{
    // Sorry for no enum
    public class Light
    {
        public int State { get; private set; } = 0;
        public void TurnOn() => State = 1;
        public void TurnOff() => State = 0;
        public void Dim() => State = 2;
    }
}