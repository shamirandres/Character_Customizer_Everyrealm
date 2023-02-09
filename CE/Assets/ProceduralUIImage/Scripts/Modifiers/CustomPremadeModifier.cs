using UnityEngine;
using UnityEngine.UI.ProceduralImage;

[ModifierID("Your Modifier Identity here")]
public class CustomPremadeModifier : ProceduralImageModifier {

	#region implemented abstract members of ProceduralImageModifier

	public override Vector4 CalculateRadius (Rect imageRect){
		float r = Mathf.Min (imageRect.width,imageRect.height)*0f;
		return new Vector4(r,r,r,0);
	}

	#endregion
	
}