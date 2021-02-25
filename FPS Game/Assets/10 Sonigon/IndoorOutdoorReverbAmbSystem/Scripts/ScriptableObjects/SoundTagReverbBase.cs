using UnityEngine;

namespace Sonigon
{
	public abstract class SoundTagReverbBase : SoundTagBase
	{
		public SoundReflection soundReflection;

		public abstract int GetParameterValue();
	}
}