using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResizeImageBasedOnText : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textComponent;  // Reference to the Text component
    [SerializeField]
    public Image imageComponent;  // Reference to the Image component

    // Update is called once per frame
    void Update()
    {
        // Get the preferred width and height of the text
        float textWidth = textComponent.preferredWidth;
        float textHeight = textComponent.preferredHeight;

        // Set the size of the image to match the text size
        RectTransform imageRectTransform = imageComponent.GetComponent<RectTransform>();
        imageRectTransform.sizeDelta = new Vector2(textWidth, textHeight);
    }
}
