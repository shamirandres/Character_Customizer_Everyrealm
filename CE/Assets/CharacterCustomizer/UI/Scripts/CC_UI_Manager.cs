using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace CC
{
    public class CC_UI_Manager : MonoBehaviour
    {
        public static CC_UI_Manager instance;

        [Tooltip("The parent object of your customizable characters")]
        public GameObject CharacterParent;

        public List<AudioClip> UISounds = new List<AudioClip>();

        private int characterIndex = 0;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SetActiveCharacter(0);
        }

        public void playUIAudio(int index)
        {
            if (UISounds.Count > index)
            {
                var audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.clip = UISounds[index];
                audioSource.Play();
            }
        }

        public void SetActiveCharacter(int index)
        {
            characterIndex = index;

            for (int i = 0; i < CharacterParent.transform.childCount; i++)
            {
                var character = CharacterParent.transform.GetChild(i).gameObject;
                // Set character active state
                character.SetActive(i == index);
                // Fetch menu from the character's component and set active state
                character.GetComponent<CharacterCustomization>().UI.SetActive(i == index);
            }
        }

        public void characterNext()
        {
            SetActiveCharacter((characterIndex + 1) % CharacterParent.transform.childCount);
        }

        public void characterPrev()
        {
            SetActiveCharacter((characterIndex - 1 + CharacterParent.transform.childCount) % CharacterParent.transform.childCount);
        }
    }
}
