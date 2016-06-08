using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

	//Script maintains a directory for populating Katai's weapons
	/*once the GameController is activated. It will pull from here.
	 * Also tells button text to change.
	*/

	//Four WeaponClass variables which will be querried by Katai on its Start.
	public WeaponClass ASetter;
	public WeaponClass WSetter;
	public WeaponClass DSetter;
	public WeaponClass SSetter;

	public Text AText;
	public Text WText;
	public Text DText;
	public Text SText;

	public void changeA(WeaponClass newWeapon){
		ASetter = newWeapon;
		setText (AText, newWeapon.weaponName);
	}
	public void changeW(WeaponClass newWeapon){
		WSetter = newWeapon;
		setText (WText, newWeapon.weaponName);
	}
	public void changeD(WeaponClass newWeapon){
		DSetter = newWeapon;
		setText (DText, newWeapon.weaponName);
	}
	public void changeS(WeaponClass newWeapon){
		SSetter = newWeapon;
		setText (SText, newWeapon.weaponName);
	}

	private void setText(Text buttonText, string s){
		buttonText.text = s;
	}


}
