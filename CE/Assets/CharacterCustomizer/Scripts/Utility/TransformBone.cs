using UnityEngine;

namespace CC
{
    public class TransformBone : MonoBehaviour
    {
        // Offset to apply to the transform
        public Vector3 offset = new Vector3(0f, 0f, 0f);

        // Mode of the offset
        public enum Mode { Height, FootRotation, BallRotation }
        public Mode mode;

        // Axis of the offset
        public enum Axis { X, Y, Z }
        public Axis axis;

        // Set the offset based on the provided foot offset values
        public void SetOffset(FootOffset footOffset)
        {
            float value;

            // Determine the value to use for the offset based on the selected mode
            switch (mode)
            {
                case Mode.Height:
                    value = footOffset.HeightOffset;
                    break;
                case Mode.FootRotation:
                    value = footOffset.FootRotation;
                    break;
                case Mode.BallRotation:
                    value = footOffset.BallRotation;
                    break;
                default:
                    value = 0f;
                    break;
            }

            // Determine the vector to use for the offset based on the selected axis
            offset = axis switch
            {
                Axis.X => new Vector3(value, 0f, 0f),
                Axis.Y => new Vector3(0f, value, 0f),
                Axis.Z => new Vector3(0f, 0f, value),
                _ => offset
            };
        }

        // Apply the offset to the transform
        private void LateUpdate()
        {
            transform.position = mode == Mode.Height ? transform.position + offset / 100 : transform.position;
            transform.eulerAngles = mode != Mode.Height ? transform.eulerAngles + offset : transform.eulerAngles;
         }
    }
}