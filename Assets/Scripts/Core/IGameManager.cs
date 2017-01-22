using Assets.Scripts.Utils;

public interface IGameManager
{
    ManagerStatus status { get; }
    void Startup();
    void Start();
    void Update();
}