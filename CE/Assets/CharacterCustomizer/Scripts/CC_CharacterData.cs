using System.Collections.Generic;

namespace CC
{
    // This class represents the data for a custom character that the user can create.
    [System.Serializable]
    public class CC_CharacterData
    {
        // The name of the character.
        public string CharacterName;

        // The name of the prefab for the character.
        public string CharacterPrefab;

        // A list of blendshapes for the character.
        public List<CC_Property> Blendshapes;

        // A list of names of hairstyles for the character.
        public List<string> HairNames;

        // A list of names of apparel (clothing, accessories, etc.) for the character.
        public List<string> ApparelNames;

        // A list of properties for the character's hair color.
        public List<CC_Property> HairColor;

        // A list of float properties for the character.
        public List<CC_Property> FloatProperties;

        // A list of texture properties for the character.
        public List<CC_Property> TextureProperties;

        // A list of color properties for the character.
        public List<CC_Property> ColorProperties;
    }
}