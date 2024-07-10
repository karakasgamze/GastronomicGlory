using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GrabBaseState
{
    public abstract void EnterState(GrabStateManager grab);

    public abstract void UpdateState(GrabStateManager grab);

    public abstract void ExitState(GrabStateManager grab);
}
