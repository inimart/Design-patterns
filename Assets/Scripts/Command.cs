using System.Collections;
using UnityEngine;

public abstract class Command
{
    public abstract IEnumerator Execute();
    public abstract IEnumerator Undo();
}
