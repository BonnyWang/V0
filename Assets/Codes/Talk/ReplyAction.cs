using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReplyAction:MonoBehaviour
{
    // Return -1 when no following talker needed
    public abstract int nextMove(int i);
}
