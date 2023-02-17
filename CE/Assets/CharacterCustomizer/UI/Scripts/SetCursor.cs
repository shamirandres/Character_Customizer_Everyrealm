using UnityEngine;
using UnityEngine.EventSystems;

namespace CC
{
    public class SetCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        // The cursor texture to set when the pointer enters this object
        public Texture2D cursorTexture;

        // When the pointer enters the object, set cursor texture using the cameracontroller
        public void OnPointerEnter(PointerEventData eventData) => CameraController.instance.setCursor(cursorTexture);

        // Calls the pointer then exiting the object, the default cursor is set using CameraController singleton instance
        public void OnPointerExit(PointerEventData eventData) => CameraController.instance.setDefaultCursor();
    }
}