# Unity ChatGPT Project

This is a Unity project that uses ChatGPT, a large language model trained by OpenAI, to enable natural language conversations with an AI agent.

## Installation

To use this project, you will need to have Unity (at least 2022.2.12f1) installed on your computer. You can download Unity from the [official website](https://unity.com/).

Once you have Unity installed, you can clone this repository or download the ZIP file and extract it to a folder of your choice.

## Usage

To use the ChatGPT agent in your own Unity project, you can import the `ChatGPT` folder from this project into your own Unity project. The `ChatGPT` folder contains the necessary scripts and prefabs to add the ChatGPT agent to your scene.

To use the ChatGPT agent, you will need an API key from OpenAI. You can get an API key by [signing up for the OpenAI API](https://beta.openai.com/signup/). Once you have an API key, you can add it to the Unity inspector at --LOGIC-- > Discussion Manager > Api Key and Organization ID.

You can then add the `ChatGPT` prefab to your scene and configure it as needed. The `ChatGPT` prefab contains a `ChatWindow` script that handles the user interface for the chat window, and a `ChatBot` script that handles the communication with the ChatGPT API.

## Credits

This project uses the [OpenAI API](https://beta.openai.com/) to power the ChatGPT agent.

The UI for the chat window is based on the [Unity UI Extensions](https://bitbucket.org/UnityUIExtensions/unity-ui-extensions) asset by Arnaud Trouvé.

The project was created by Charles Dorff.
