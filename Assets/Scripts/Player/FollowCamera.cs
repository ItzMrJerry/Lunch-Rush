using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    private void FixedUpdate()
    {
        transform.position = new Vector3(Target.position.x + Offset.x, Offset.y, Target.position.z + Offset.z);
    }
}
