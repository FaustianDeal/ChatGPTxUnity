using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiscussionBubble : MonoBehaviour
{
    [Header("Elements")] 
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Image bubbleImage;
    [SerializeField] private Sprite userBubbleSprite;

    [Header("Settings")]
    [SerializeField] private Color userBubbleColor;

    public void Configure(string message, bool isUserMessage)
    {
        if (isUserMessage)
        {
            bubbleImage.sprite = userBubbleSprite;
            bubbleImage.color = userBubbleColor;
            messageText.color = Color.white;
        }

        messageText.text = message;
        messageText.ForceMeshUpdate();
    }
}
