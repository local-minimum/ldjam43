using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletMeter : MonoBehaviour {

    [SerializeField]
    Text text;

    [SerializeField]
    RectTransform meter;

    float yMax;
    float yMin;

	void Start () {
        yMin = meter.anchorMin.y;
        yMax = meter.anchorMax.y;
	}

    public void SetValue(int value)
    {
        int actualValue = Mathf.Clamp(value, 0, 100);
        text.text = string.Format("{0}", actualValue);
        meter.anchorMax = new Vector2(meter.anchorMax.x, getAnchorMaxY(actualValue));
    }

    float getAnchorMaxY(float value)
    {
        return yMin + (value / 100f);
    }
}
