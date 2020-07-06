using System.Collections;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;

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

    private void Start()
    {
        StartCoroutine(SendData());
    }

    private IEnumerator SendData()
    {
        string before = "090120120090060";
        string after = "090120120090060060";
        string content;
        UnityWebRequest request;
        while (true)
        {
            yield return new WaitForSeconds(10f);
            content = before + Rotation() + after;
            request = UnityWebRequest.Post("http://192.168.0.31:2727", content);
            request.SendWebRequest();
        }        
    }

    private string Rotation()
    {
        float rotation = 0f;
        switch (axis)
        {
            case Axis.X:
                rotation = transform.localRotation.x;
                break;
            case Axis.Y:
                rotation = transform.localRotation.y;
                break;
            case Axis.Z:
                rotation = transform.localRotation.z;
                break;
        }
        return Mathf.Round(rotation).ToString("000");
    }
}
