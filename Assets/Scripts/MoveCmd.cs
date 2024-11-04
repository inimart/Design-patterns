using System.Collections;
using UnityEngine;

public class MoveCmd: Command
{
    public Vector3 direction;
    private Transform target;
    private Vector3 startPosition;
    private Vector3 endPosition;
    float duration = 0.2f;

    public MoveCmd(Transform target, Vector3 direction)
    {
        this.target = target;
        this.direction = direction;
    }

    public override IEnumerator Execute()
    {
        startPosition = target.position;
        endPosition = startPosition + direction;
        
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            target.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.position = endPosition;
    }

    public override IEnumerator Undo()
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            target.position = Vector3.Lerp(endPosition, startPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.position = startPosition;
    }
}
