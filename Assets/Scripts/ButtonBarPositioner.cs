using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBarPositioner : MonoBehaviour {

	void Start ()
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect.height * 0.075f);
    }
}
