using Entitas;
using UnityEngine;

public class TestSystem : IExecuteSystem
{
    public TestSystem(IContext<GameEntity> context)
    {
    }

    public void Execute()
    {
        Debug.Log("I'm executing!");
    }
}
