using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class InputManager : MonoBehaviour
{
    private BalloonSpawnerScript _balloonSpawnerScript;
    private TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField=GetComponent<TMP_InputField>();
        if (inputField != null )
        {
            
            inputField.Select();
            inputField.ActivateInputField();
            inputField.onSubmit.AddListener(SubmitInput);
#if UNITY_EDITOR
            Debug.Log("_____ Found");
#endif
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Not Found");
#endif
        }
        
        _balloonSpawnerScript= GameObject.FindGameObjectWithTag("Spawner").GetComponent<BalloonSpawnerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputField.Select(); inputField.ActivateInputField();

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            // If the InputField is focused, we submit the input
            if (inputField.isFocused)
            {
                // Submit the input manually
                SubmitInput(inputField.text);
            }
        }
    }

    private void SubmitInput(string text)
    {
        _balloonSpawnerScript.getAndCompareInput(inputField.text.ToLower());
        inputField.text = "";
    }
}
