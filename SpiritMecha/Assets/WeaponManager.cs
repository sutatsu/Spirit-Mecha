using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

	//Script maintains a directory for populating Katai's weapons
	/*once the GameController is activated. It will pull from here.
	 * Also tells button text to change.
	*/

	//Four WeaponClass variables which will be querried by Katai on its Start.
	public WeaponClass MainArmSetter;
	public WeaponClass SupportArmSetter;
	public WeaponClass ShoulderSetter;
	public WeaponClass BackSetter;

	public Text MainArmText;
	public Text SupportArmText;
	public Text ShoulderText;
	public Text BackText;

	public void changeMainArm(WeaponClass newWeapon){
		MainArmSetter = newWeapon;
		setText (MainArmText, newWeapon.weaponName);
	}
	public void changeSupportArm(WeaponClass newWeapon){
		SupportArmSetter = newWeapon;
		setText (SupportArmText, newWeapon.weaponName);
	}
	public void changeShoulder(WeaponClass newWeapon){
		ShoulderSetter = newWeapon;
		setText (ShoulderText, newWeapon.weaponName);
	}
	public void changeBack(WeaponClass newWeapon){
		BackSetter = newWeapon;
		setText (BackText, newWeapon.weaponName);
	}

	private void setText(Text buttonText, string s){
		buttonText.text = s;
	}


}
