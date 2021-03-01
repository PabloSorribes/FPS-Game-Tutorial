namespace Sonigon
{
	public abstract class SoundTagReverbBase : SoundTagBase, ISoundDataParameter
	{
		[UnityEngine.SerializeField]
		private SoundReflectionData soundReflectionData = null;
		public SoundReflectionData SoundReflectionData => soundReflectionData;

		public virtual int GetParameterValue()
		{
			throw new System.NotImplementedException();
		}
	}
}