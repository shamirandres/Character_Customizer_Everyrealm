using UnityEngine;
using UnityEngine.EventSystems;

namespace CC
{
    public class CameraController : MonoBehaviour
    {
        // Singleton Pattern
        public static CameraController instance;

        private void Awake()
        {
            // If instance is not set, this is the first CameraController object created
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                // If instance is set; Destroy object
                Destroy(gameObject);
            }
        }

        private Camera _camera;
        private Transform cameraRoot;
        public GameObject character;

        private float zoomTarget = 1;

        private Vector3 mouseOldPos;
        private Vector3 mouseDelta;

        // Camera Rotation Variables
        private Vector3 cameraRotationTarget = new Vector3(10, -5, 0);
        private Vector3 cameraRotationDefault;
        private float rotateSpeed = 5;
        private bool dragging = false;

        // Camera Panning Variables
        private Vector3 cameraOffset;
        private Vector3 cameraOffsetDefault;
        private float panSpeed = 3;
        private bool panning = false;

        // Cursor Variables
        public Texture2D cursorTexture;
        private Vector2 hotSpot;

        private void Start()

        {
            // Get camera references and the parent transforms
            _camera = Camera.main;
            cameraRoot = gameObject.transform;

            // Set cursor texture and hotSpot
            hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
            setDefaultCursor();

            // Set default camera offset and rotation
            cameraOffsetDefault = _camera.transform.localPosition;
            cameraOffset = cameraOffsetDefault;

            cameraRotationDefault = cameraRoot.localRotation.eulerAngles;
            cameraRotationTarget = cameraRotationDefault;
        }

        // Change cursor to specified texture
        public void setCursor(Texture2D texture)
        {
            Cursor.SetCursor(texture, hotSpot, CursorMode.Auto);
        }

        // Set mouse cursor to the default  texture
        public void setDefaultCursor()
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }

        private void Update()
        {
            // Ignore input if the cursor is hovering over an UI Element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Zoom based on mouse wheel scroll
                zoomTarget = Mathf.Clamp((zoomTarget - Input.mouseScrollDelta.y / 10), 0, 1);
                // Start cammera rotation if the right mouse button is pressed
                if (Input.GetMouseButtonDown(1))
                {
                    mouseOldPos = Input.mousePosition;
                    dragging = true;
                }

                // Start camera panning if middle mouse button is pressed
                if (Input.GetMouseButtonDown(2))
                {
                    mouseOldPos = Input.mousePosition;
                    panning = true;
                }
            }
            
            // Stop camera rotation when the right mouse button is pressed
            if (Input.GetMouseButtonUp(1)) { dragging = false; }

                

            // Rotate camera based on mouse movement when the right mouse button is pressed
            if (Input.GetMouseButton(1) && dragging)
            {
                mouseDelta = mouseOldPos - Input.mousePosition;

                cameraRotationTarget.x += mouseDelta.y / 5;
                //cameraRotationTarget.y -= mouseDelta.x / 5;
                character.transform.Rotate(new Vector3(0, mouseDelta.x / 5, 0));

                mouseOldPos = Input.mousePosition;
            }

            // Stop camera panning when the middle button is released
            if (Input.GetMouseButtonUp(2))

                panning = false;
            // Pan camera based on mouse movement when middle mouse button is pressed

            if (Input.GetMouseButton(2) && panning)
            {
                mouseDelta = mouseOldPos - Input.mousePosition;
                cameraOffset -= mouseDelta / 500;
                mouseOldPos = Input.mousePosition;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                cameraRotationTarget = cameraRotationDefault;
                cameraOffset = cameraOffsetDefault;
                zoomTarget = 1;
            }

            cameraOffset.z = Mathf.Lerp(-0.6f, -3.1f, zoomTarget);

            _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, cameraOffset, Time.deltaTime * panSpeed);

            cameraRoot.transform.localRotation = Quaternion.Slerp(cameraRoot.transform.localRotation, Quaternion.Euler(cameraRotationTarget), Time.deltaTime * rotateSpeed);
        }
    }
}
