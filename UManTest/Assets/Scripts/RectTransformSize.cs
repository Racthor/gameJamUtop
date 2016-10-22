using UnityEngine;
using System.Collections;

public class RectTransformSize : MonoBehaviour {

    int xPosition = 960;
    int yPosition = 900;
    float width = 1800.0f;
    float height = 240.0f;

    private void setRectTransformPosition()
    {
        GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(xPosition, yPosition);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }

    // Use this for initialization
    void Start () {
        if (name == "Answers")
        {
            xPosition = 960;
            yPosition = 100;
            width = 1800.0f;
            height = 100.0f;
        }

        setRectTransformPosition();
	}
	
}
