namespace Task2.ChainOfResponsibility
{
    public class Authorizer : Handler
    {
        public override bool DoHandle(User user)
        {
            var ok = user.Role > 1;
            Console.WriteLine($"[Authorizer] {(ok ? "OK" : "FAIL")} (Role={user.Role})");
            return !ok;
        }
    }
}
