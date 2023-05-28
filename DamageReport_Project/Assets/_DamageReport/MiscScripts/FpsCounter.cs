using System.Collections;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float updateInterval;

    private void Start()
    {
        StartCoroutine(UpdateText());
    }

    private IEnumerator UpdateText()
    {
        while (true)
        {
            var ms = Time.unscaledDeltaTime * 1000;
            text.SetText("{0} ms\n{1} fps", (int)ms, (int)(1000 / ms));
            yield return new WaitForSeconds(updateInterval);
        }
    }
}
