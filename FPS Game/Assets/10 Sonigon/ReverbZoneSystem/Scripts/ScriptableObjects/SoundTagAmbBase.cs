using UnityEngine;

namespace Sonigon
{
	public abstract class SoundTagAmbBase : SoundTagBase
	{
		public SoundReflectionData soundReflection;

		public abstract int GetParameterValue();
	}
}