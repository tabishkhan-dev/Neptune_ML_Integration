using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using Newtonsoft.Json.Linq;

public class MLCommunicator : MonoBehaviour
{
    public string apiURL = "http://127.0.0.1:5000/predict";
    public TMP_Text feedbackText;
    public GameObject cube;

    private Renderer cubeRenderer;
    private Color targetColor;

    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
        targetColor = cubeRenderer.material.color;   // start from current color
        StartCoroutine(CallAPIRepeatedly());
    }

    void Update()
    {
        // Smoothly blend towards target color (tweak 2f for faster/slower)
        cubeRenderer.material.color =
            Color.Lerp(cubeRenderer.material.color, targetColor, Time.deltaTime * 2f);
    }

    IEnumerator CallAPIRepeatedly()
    {
        while (true)
        {
            yield return GetPrediction();
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator GetPrediction()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiURL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                JObject data = JObject.Parse(json);

                string prediction = data["prediction"].ToString();
                float confidence = data["confidence"].ToObject<float>(); // 0..1

                feedbackText.text = $"Prediction: {prediction} ({confidence * 100f:F0}%)";
                UpdateCubeColor(confidence);
            }
            else
            {
                feedbackText.text = "Error connecting to API!";
            }
        }
    }

    void UpdateCubeColor(float confidence)
    {
        // Red (low) -> Green (high)
        targetColor = Color.Lerp(Color.red, Color.green, confidence);
    }
}
