using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Adam : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private float delay;
    [SerializeField]
    private RotationDetector[] rotationDetectors;
#pragma warning restore 0649

    private readonly StringBuilder stringBuilder = new StringBuilder();

    private void Start()
    {
        StartCoroutine(SendData());
    }

    private IEnumerator SendData()
    {
        UnityWebRequest request;
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FetchRotations();
            request = UnityWebRequest.Post("http://192.168.0.31:2727", stringBuilder.ToString());
            request.SendWebRequest();
        }
    }

    private void FetchRotations()
    {
        stringBuilder.Clear();
        foreach(RotationDetector rotationDetector in rotationDetectors)
        {
            stringBuilder.Append(rotationDetector.Rotation());
        }
    }
}
