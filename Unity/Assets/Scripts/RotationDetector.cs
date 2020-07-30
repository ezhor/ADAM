using UnityEngine;

public class RotationDetector : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Axis axis;
    [SerializeField]
    private int offset;
    [SerializeField]
    private bool reversed;
#pragma warning restore 0649

    public string Rotation()
    {
        Vector3 inspectorRotation = UnityEditor.TransformUtils.GetInspectorRotation(transform);
        float rotation = 0f;
        switch (axis)
        {
            case Axis.X:
                rotation = inspectorRotation.x;
                break;
            case Axis.Y:
                rotation = inspectorRotation.y;
                break;
            case Axis.Z:
                rotation = inspectorRotation.z;
                break;
        }
        if (reversed)
        {
            rotation = 360f - rotation;
        }
        rotation += offset;
        rotation = Mathf.RoundToInt(rotation);
        if(rotation < 0f)
        {
            rotation = 0f;
        }
        if(rotation > 180f)
        {
            rotation = 180f;
        }
        return rotation.ToString("000");
    }
}
