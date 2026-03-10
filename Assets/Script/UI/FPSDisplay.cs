using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TMP_Text fpsText;

    private float timer;

    void Update()
    {
        // Simple FPS Displayer 
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            int fps = Mathf.RoundToInt(1f / Time.deltaTime);
            fpsText.text = fps + " FPS";
            timer = 0f;
        }
    }
}
