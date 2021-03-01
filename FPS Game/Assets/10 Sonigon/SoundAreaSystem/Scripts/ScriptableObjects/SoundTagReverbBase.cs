namespace Sonigon
{
	public abstract class SoundTagReverbBase : SoundTagBase, ISoundDataParameterInt
	{
		[UnityEngine.SerializeField]
		private SoundReflectionData soundReflectionData = null;
		public SoundReflectionData SoundReflectionData => soundReflectionData;

		public virtual int GetIntParameterValue()
		{
			throw new System.NotImplementedException();
		}
	}
}