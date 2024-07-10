using Unity.VisualScripting;
using UnityEngine;

public abstract class WaiterBaseState
{
    public abstract void EnterState(WaiterStateManager waiter);

    public abstract void UpdateState(WaiterStateManager waiter);

    public abstract void ExitState(WaiterStateManager waiter);

}