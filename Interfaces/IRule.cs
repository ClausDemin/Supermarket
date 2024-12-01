namespace Supermarket.Interfaces
{
    public interface IRule
    {
        public bool CanExecute { get; }
        public void Execute();
    }
}
