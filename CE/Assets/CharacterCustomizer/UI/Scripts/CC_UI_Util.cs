using UnityEngine;

namespace CC
{
    public class CC_UI_Util : MonoBehaviour
    {
        private CharacterCustomization customizer;

        //Initialize all child UI elements
        public void Initialize(CharacterCustomization customizerScript)
        {
            customizer = customizerScript;

            ICustomizerUI[] interfaces;
            interfaces = gameObject.GetComponentsInChildren<ICustomizerUI>(true);

            foreach (ICustomizerUI element in interfaces)
            {
                element.InitializeUIElement(customizerScript, this);
                Debug.Log("Customizer referenced");
            }
        }

        //Refresh UI elements, for example after loading a different preset
        public void refreshUI()
        {
            ICustomizerUI[] interfaces;
            interfaces = gameObject.GetComponentsInChildren<ICustomizerUI>(true);

            foreach (ICustomizerUI element in interfaces)
            {
                element.RefreshUIElement();
            }
        }

        public void characterNext()
        {
            CC_UI_Manager.instance.characterNext();
        }

        public void characterPrev()
        {
            CC_UI_Manager.instance.characterPrev();
        }

        public void saveCharacter()
        {
            customizer.SaveToJSON();
        }

        public void loadCharacter()
        {
            customizer.LoadFromJSON();
        }

        public void setCharacterName(string newName)
        {
            customizer.setCharacterName(newName);
        }
    }
}