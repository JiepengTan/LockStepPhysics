using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using LockStepMath;

/*
*/
namespace LockStepCollision
{
    public partial class BaseShape
    {
        public virtual void OnDrawGizmos(bool isGizmo)
        {
        }
    }

    public partial class AABB
    {
        public override void OnDrawGizmos(bool isGizmo)
        {
#if UNITY_EDITOR
            DebugExtension.DebugLocalCube(Matrix4x4.TRS(c.ToVector3,Quaternion.identity, Vector3.one),r.ToVector3, Color.red);
#endif
        }
    }

    public partial class Sphere
    {
        public override void OnDrawGizmos(bool isGizmo)
        {
#if UNITY_EDITOR
            DebugExtension.DebugWireSphere(c.ToVector3, Color.red,r.ToFloat);
#endif
        }
    }
    
    public partial class Capsule
    {
        public override void OnDrawGizmos(bool isGizmo)
        {
#if UNITY_EDITOR
            DebugExtension.DrawCapsule(a.ToVector3, b.ToVector3,r.ToFloat);
#endif
        }
    }
}
