using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using OpenAI;
using OpenAI.Chat;
using Random = UnityEngine.Random;

public class DiscussionManager : MonoBehaviour
{
    [Header("Elements")] 
    [SerializeField] private DiscussionBubble bubblePrefab;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Transform bubblesParent;

    [Header("Events")] public static Action onMessageReceived;

    [Header("Authentication")] 
    [SerializeField] private string apiKey; // You're going to have to use your own APIKey and orgID from https://platform.openai.com/account/org-settings 
    [SerializeField] private string organizationId;

    private OpenAIClient api;

    [Header("Settings")] 
    [SerializeField] private List<ChatPrompt> chatPrompts = new List<ChatPrompt>();
    // Start is called before the first frame update
    void Start()
    {
        CreateBubble("Hey there! How can I help you?", false);
        Authenticate();
        Initialize();
    }

    private void Authenticate()
    {
        api = new OpenAIClient(new OpenAIAuthentication(apiKey, organizationId));
    }

    private void Initialize()
    {
        
        ChatPrompt prompt = new ChatPrompt("system", "You are a Unity expert.");
        chatPrompts.Add(prompt);
    }

    public async void AskButtonCallback()
    {
        CreateBubble(inputField.text, true);
        //CreateBubble("Message Received: " + Random.Range(0,100), false);


        ChatPrompt prompt = new ChatPrompt("user", inputField.text);
        chatPrompts.Add(prompt);
        
        inputField.text = "";
        
        ChatRequest request = new ChatRequest(
            messages: chatPrompts,
            model: OpenAI.Models.Model.GPT3_5_Turbo,
            temperature: 0.2);

        try
        {
            var result = await api.ChatEndpoint.GetCompletionAsync(request);

            ChatPrompt chatResult = new ChatPrompt("system", result.FirstChoice.ToString());
            chatPrompts.Add(chatResult);
            
            CreateBubble(result.FirstChoice.ToString(), false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void CreateBubble(string message, bool isUserMessage)
    {
        DiscussionBubble discussionBubble = Instantiate(bubblePrefab, bubblesParent);
        discussionBubble.Configure(message, isUserMessage);
        
        onMessageReceived?.Invoke();
    }
}
