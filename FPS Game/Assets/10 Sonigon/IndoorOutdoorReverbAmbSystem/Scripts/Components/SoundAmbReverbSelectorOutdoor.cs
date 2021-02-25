using UnityEngine;

namespace Sonigon
{
	public class SoundAmbReverbSelectorOutdoor : MonoBehaviour
	{
		[Header("If field is null, it wont change the master amb/reverb")]
		[Tooltip("The 2D ambience sound that will be playing inside this area")]
		public SoundTagAmbOutdoor tagAmb;
		[Tooltip("The reverb snapshot that will be used for any sounds played in this area (eg. Gunshots, Footsteps, etc)")]
		public SoundTagReverbOutdoor tagReverb;
	}
}
