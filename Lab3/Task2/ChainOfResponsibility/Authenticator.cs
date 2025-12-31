namespace Task2.ChainOfResponsibility
{
    public class Authenticator : Handler
    {
        public override bool DoHandle(User user)
        {
            var ok = user.Name != "Vasili";
            Console.WriteLine($"[Authenticator] {(ok ? "OK" : "FAIL (sorry you were banned)")} (Name={user.Name})");
            return !ok;
        }
    }
}
