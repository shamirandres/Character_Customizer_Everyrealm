using UnityEngine;
using TMPro;

namespace CC
{
    // CC_InputField.cs defines a UI input field element that can be used to set the name of the character in the CharacterCustomization script
    public class CC_InputField : MonoBehaviour, ICustomizerUI
    {
        // A reference to the CharacterCustomization script
        private CharacterCustomization customizer;

        // InitializeUIElement is called by the parent UI script to set up the input field element with the given CharacterCustomization script
        public void InitializeUIElement(CharacterCustomization customizerScript, CC_UI_Util parentUI)
        {
            customizer = customizerScript;

            // Refresh the input field element to set its text value to the current character name
            RefreshUIElement();

            // Add a listener to the input field's onValueChanged event to call the setCharacterName function of the CharacterCustomization script when the input field text is changed
            gameObject.GetComponent<TMP_InputField>().onValueChanged.AddListener(customizer.setCharacterName);
        }

        // RefreshUIElement is called to update the input field element with the current character name
        public void RefreshUIElement()
        {
            // Set the text value of the input field to the current character name
            gameObject.GetComponent<TMP_InputField>().text = customizer.CharacterName;
        }
    }
}