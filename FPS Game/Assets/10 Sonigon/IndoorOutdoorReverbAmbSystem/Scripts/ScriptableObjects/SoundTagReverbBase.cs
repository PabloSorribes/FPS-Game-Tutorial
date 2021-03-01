using UnityEngine;

namespace Sonigon
{
	public abstract class SoundTagReverbBase : SoundTagBase
	{
		public SoundReflectionData soundReflection;

		public abstract int GetParameterValue();
	}
}