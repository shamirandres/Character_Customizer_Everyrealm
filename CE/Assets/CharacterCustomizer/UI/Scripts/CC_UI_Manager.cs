using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace CC
{
    public class CC_UI_Manager : MonoBehaviour
    {
        public static CC_UI_Manager instance; // static reference to the UI manager instance

        [Tooltip("The parent object of your customizable characters")]
        public GameObject CharacterParent; // a reference to the parent object of the customizable characters

        public List<AudioClip> UISounds = new List<AudioClip>(); // a list of audio clips to play for UI sounds

        private int characterIndex = 0; // the current index of the active character

        private void Awake()
        {
            if (instance == null) // if no UI manager instance exists
            {
                instance = this; // set this as the UI manager instance
            }
            else // otherwise, if a UI manager instance already exists
            {
                Destroy(gameObject); // destroy this object to ensure only one UI manager instance exists
            }
        }

        private void Start()
        {
            SetActiveCharacter(0); // set the first character as active on start
            Invoke("characterNext", 0.1f);
        }

        public void playUIAudio(int index)
        {
            if (UISounds.Count > index) // if the index is within the range of the UISounds list
            {
                var audioSource = gameObject.GetComponent<AudioSource>(); // get the audio source component on this object
                audioSource.clip = UISounds[index]; // set the audio clip to the one at the given index
                audioSource.Play(); // play the audio clip
            }
        }

        public void SetActiveCharacter(int index)
        {
            characterIndex = index; // set the current index to the given index

            foreach (Transform child in CharacterParent.transform) // iterate over all the child objects of the CharacterParent object
            {
                var character = child.gameObject; // get the child object as a game object
                // Set character active state
                character.SetActive(child.GetSiblingIndex() == index && index != 0); // set the active state of the character object based on whether its index is equal to the current index
                // Fetch menu from the character's component and set active state
                character.GetComponent<CharacterCustomization>().UI.SetActive(child.GetSiblingIndex() == index && index != 0); // set the active state of the UI object associated with the character based on whether its index is equal to the current index
            }

        }

        public void characterNext()
        {
            int value = (characterIndex + 1) % CharacterParent.transform.childCount;
            if (value == 0) {
                SetActiveCharacter(1);
            }
            else {
                SetActiveCharacter(value); // set the active character to the next character by incrementing the index (with wraparound)
            }
            
        }

        public void characterPrev()
        {
            int value = ((characterIndex - 1) + CharacterParent.transform.childCount) % CharacterParent.transform.childCount;
            if (value == 0)
            {
                SetActiveCharacter(CharacterParent.transform.childCount-1);
            }
            else { 
                SetActiveCharacter(value); // set the active character to the previous character by decrementing the index (with wraparound)
            }
        }
    }
}
