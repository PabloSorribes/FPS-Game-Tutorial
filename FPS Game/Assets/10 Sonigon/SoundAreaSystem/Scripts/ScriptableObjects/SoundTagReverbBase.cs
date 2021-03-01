namespace Sonigon
{
	public abstract class SoundTagReverbBase : SoundTagBase, ISoundDataParameterInt
	{
		[UnityEngine.SerializeField]
		private SoundReflectionData soundReflectionData = null;
		public SoundReflectionData SoundReflectionData => soundReflectionData;

		[UnityEngine.SerializeField]
		private bool isIndoor = false;
		public bool IsIndoor => isIndoor;

		public virtual int GetIntParameterValue()
		{
			throw new System.NotImplementedException();
		}
	}
}