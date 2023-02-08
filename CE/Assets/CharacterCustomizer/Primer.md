# Character Customizer v1 for Unity

Hello, this is my first Unity asset and indeed my first Unity project so if you run into any issues feel free to reach out at lindborgdev@gmail.com or on Discord (https://discord.com/invite/vMVE2kuwzV) and I'll see what I can do

To get an idea of how Character Customizer works, please open CC_Demo_Scene and, if prompted, import Text Mesh Pro essentials.

The general layout of Character Customizer looks like this:

- Character Parent
  - Character 1
    - CharacterCustomization script
  - Character 2
    - CharacterCustomization script
  - Character 3
    - CharacterCustomization script
- CameraController script
  - Camera
- CC_UI_Manager script
- Character 1 UI
  - CC_UI_Util script
- Character 2 UI
  - CC_UI_Util script
- Character 3 UI
  - CC_UI_Util script

In the demo scene each character has a respective UI assigned in their CharacterCustomization script. Without a UI assigned, the character will still load from save file, customization still works but there will be no interface to assist with it. When the character's Start() runs it calls the function Initialize in CC_UI_Util, which in turn runs the ICustomizerUI interface function InitializeUIElement for every child object that implements the interface. This is how the UI elements (sliders, pickers etc) are linked to the character's CharacterCustomization script, and how they get updated from the save data.

CC_UI_Manager is a simple singleton used for switching between the characters and their UIs and playing audio clips. In addition there's some code to change the anti-aliasing mode based on the character but you can delete that if you wish.

CameraController is another simple singleton with simple camera controls and some additional functionality for context sensitive mouse cursors.

The CharacterCustomization script contains almost all the functionality for changing properties and blendshapes, saving and loading and managing clothes and hair. The UI elements contain little functionality by themselves and just serve as a graphical interface for the main script.

Much of the customization in Character Customizer is designed around the class _CC_Property_. This thing is used to store blendshapes, texture properties, float properties and color properties. Certain variables in a CC_Property may be superfluous depending on the use case.

- propertyName is the blendshape name or the material property name
- stringValue stores a string, which is usually a reference to a resource, or an HTML color
- floatValue stores a float, for example a scalar value or a blendshape value
- materialIndex is the material index the property should be set on, the default -1 means it should be set on all materials
- meshTag lets you set the property on a mesh renderer gameObject with a specific tag, default "" means it's set on all meshes

The UI element scripts generally have one or more CC_Property to determine what properties they affect.

Clothes and hair are instantiated from data fetched from scriptable objects, scrObj_Apparel and scrObj_Hair respectively. These scriptable objects are assigned on CharacterCustomization under Apparel Tables and Hair Tables and there should be one table per category you want (categories are "Hair", "Beard", "Upper Body", "Footwear" etc). The two scriptable objects are similar but have some key differences.

scrObj_Apparel looks like this:

- _Mesh_ is the prefab containing the mesh and the skeleton and what not
- _Name_ is the name that gets added to the save file and is used to identify the item later
- _Add Copy Pose Script_ is useful if the skeletal hierarchy of the mesh is different from the character it is attached to. In standard cases the skeletons should be identical, meaning they can be merged to save performance, but in some cases you will want to have extra bones added for physics or some other purpose, and bone transforms will have to be manually copied
- _Mask_ is an optional texture that I use to simplify my character workflow by being able to mask off a certain part of the character's body based on the clothing that's equipped
- _Foot Offset_ and _Affect Foot Offset_ pertain to the FootOffset script, which allows apparel to affect the character's skeleton based on the equipped footwear. _Height Offset_ is an offset to the root bone, _Foot Rotation_ and _Ball Rotation_ apply a rotation offset to the feet and ball bones
- _Icon_ is an optional icon used for the Grid_Icon buttons
- The scriptable object itself has a _Mask Property_ which is the name of the property on the skin shader

scrObj_Hair works much the same way with some differences:

- _Shadow Map_ is (optionally) used to apply a shadow map on the character's head material to help blend the hair and the scalp
- _Shadow Map Property_ is the texture property on the skin shader
- _Tint Property_ is the color property on the skin shader

For more details on how this all works, check out setHair and setApparel in CharacterCustomization.

The characters have one final scriptable object which is scrObjPresets. This is a list of CC_CharacterData which can be used to store preset characters. One quick and easy way of adding a preset is by customizing a character in game, selecting the character in the hierarchy and copying the Stored Character Data from the CharacterCustomization script. Then you can simply paste it into the preset scriptable object as a new element and store it for later. Give it a unique name and you can get it with Presets.Presets.Find(t => t.CharacterName == "unique name") or something like that. The first element in the presets object is used as the default character preset in the CharacterCustomization script when no character has been saved to file.
