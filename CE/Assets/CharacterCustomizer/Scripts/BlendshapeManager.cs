using System.Collections.Generic;
using UnityEngine;

// BlendshapeManager.cs Defines "BlendshapeManager" That's used to manage the blendshapes on "SkinnedMeshRenderer"
    // The "BlendshapeManager" Uses two methods
        // "parseBlendshapes()" Retrieves the list of Blendshape names from "SkinnedMeshRenderer" Component attached to the game object that the "BlendshapeManager" Script is attached to.

namespace CC
{
    public class BlendshapeManager : MonoBehaviour
    {
        // A list to hold the names of all the blendshapes in the skinned mesh
        private List<string> blendshapeNames = new List<string>();
        
        // A reference to the SkinnedMeshRenderer component attached to this game object
        private SkinnedMeshRenderer mesh;

        // A method that retrieves the list of blendshape names from the SkinnedMeshRenderer
        public void parseBlendshapes()
        {
            // Get a reference to the SkinnedMeshRenderer attached to this game object
            mesh = gameObject.GetComponent<SkinnedMeshRenderer>();

            // Loop through each blendshape in the shared mesh and add its name to the list
            for (int i = 0; i < mesh.sharedMesh.blendShapeCount; i++)
            {
                blendshapeNames.Add(mesh.sharedMesh.GetBlendShapeName(i));
            }
        }

        // A method that sets the weight of a blendshape
        public void setBlendshape(string name, float value)
        {
            // Find the index of the blendshape with the given name in the list of blendshape names
            int index = blendshapeNames.FindIndex(t => t == name);
            if (index != -1) mesh.SetBlendShapeWeight(index, value);
        }
    }
}