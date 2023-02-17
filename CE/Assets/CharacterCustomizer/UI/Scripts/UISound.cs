using UnityEngine;

// CC namespace
namespace CC
{
    // Class for playing UI sounds
    public class UISound : MonoBehaviour
    {
        // Public method for playing a UI sound with a given index
        public void playUISound(int index)
        {
            // Call the playUIAudio method on the CC_UI_Manager instance with the given index
            CC_UI_Manager.instance.playUIAudio(index);
        }
    }
}