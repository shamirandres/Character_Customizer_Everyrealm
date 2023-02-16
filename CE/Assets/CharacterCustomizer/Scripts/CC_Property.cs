namespace CC
{
    // This is a class called "CC_Property"
    [System.Serializable]
    public class CC_Property
    {
        // These are public fields for this class
        public string propertyName = "";  // A string to store the name of the property
        public string stringValue = "";  // A string to store the value of the property as a string
        public float floatValue = 0;     // A float to store the value of the property as a float
        public int materialIndex = -1;   // An int to store the material index of the property, initialized to -1
        public string meshTag = "";      // A string to store the mesh tag of the property
    }
}