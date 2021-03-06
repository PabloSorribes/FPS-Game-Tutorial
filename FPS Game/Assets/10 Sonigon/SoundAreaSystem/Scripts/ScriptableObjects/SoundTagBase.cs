﻿using UnityEngine;

namespace Sonigon
{
	public abstract class SoundTagBase : ScriptableObject
	{

		// Managed Name
		[System.NonSerialized]
		protected string cachedName;
		public virtual string GetName()
		{
			if (Application.isPlaying)
			{
				if (cachedName == null)
				{
					cachedName = name;
				}
				return cachedName;
			}
			else
			{
				return name;
			}
		}
	}
}