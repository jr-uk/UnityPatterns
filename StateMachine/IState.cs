/// <summary>
/// Used for state implementations
/// </summary>
public interface IState
{
    public void Tick();
    public void OnEnter();
    public void OnExit();
}
