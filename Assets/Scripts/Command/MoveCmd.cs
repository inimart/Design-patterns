using System.Collections;
using UnityEngine;

public class MoveCommandState
{
    public Vector3 Direction { get; set; }
    public Vector3 StartPosition { get; set; }
    public Vector3 EndPosition { get; set; }
    public Transform Target { get; set; }
}
public class MoveCmd: Command
{
    private MoveCommandState state;
    private float duration = 0.2f;

    public void Initialize(Transform target, Vector3 direction)
    {
        if (state == null) 
            state = new MoveCommandState();
            
        state.Target = target;
        state.Direction = direction;
    }

    public override IEnumerator Execute()
    {
        //StartPosition and EndPosition are set here because when we initialize we could be in the middle of a prev command execution
        state.StartPosition = state.Target.position;
        state.EndPosition = state.StartPosition + state.Direction;
        
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            state.Target.position = Vector3.Lerp(state.StartPosition, state.EndPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        state.Target.position = state.EndPosition;
    }

    public override IEnumerator Undo()
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            state.Target.position = Vector3.Lerp(state.EndPosition, state.StartPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        state.Target.position = state.StartPosition;
    }
}
