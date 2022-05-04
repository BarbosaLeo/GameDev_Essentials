using UnityEngine;

static class SmoothDamp
{
    static public Quaternion Rotate(Quaternion a, Quaternion b, float speed, float dt)
    {
        return Quaternion.Slerp(a, b, 1 - Mathf.Exp(-speed * dt));
    }

    static public float Move(float a, float b, float speed, float dt)
    {
        return Mathf.Lerp(a, b, 1 - Mathf.Exp(-speed * dt));
    }

    static public Vector3 MoveV3(Vector3 a, Vector3 b, float speed, float dt)
    {
        Vector3 newV3 = new Vector3(Mathf.Lerp(a.x, b.x, 1 - Mathf.Exp(-speed * dt)), Mathf.Lerp(a.y, b.y, 1 - Mathf.Exp(-speed * dt)), Mathf.Lerp(a.z, b.z, 1 - Mathf.Exp(-speed * dt)));

        return newV3;
    }
}
