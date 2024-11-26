public abstract class EnemyState
{
    protected EnemySeeking enemy;

    public EnemyState(EnemySeeking enemy)
    {
        this.enemy = enemy;
    }

    public abstract void EnterState(); // Called when entering the state
    public abstract void UpdateState(); // Called every frame while in this state
    public abstract void ExitState(); // Called when exiting the state
}
