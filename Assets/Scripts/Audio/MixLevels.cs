using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour {

	public AudioMixer MasterMixer;

	public void SetSfxLvl(float sfxLvl)
	{
		MasterMixer.SetFloat("sfxVol", sfxLvl);
	}

	public void SetMusicLvl (float musicLvl)
	{
		MasterMixer.SetFloat ("musicVol", musicLvl);
	}
}
