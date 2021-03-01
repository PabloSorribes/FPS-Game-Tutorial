namespace Sonigon
{
	public abstract class SoundTagAmbBase : SoundTagBase, ISoundDataParameterInt
	{
		public virtual int GetIntParameterValue()
		{
			throw new System.NotImplementedException();
		}
	}
}