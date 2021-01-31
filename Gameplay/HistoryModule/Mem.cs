using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryHistory
{
	public class Mem : MonoBehaviour
	{
		public List<GameObject> memory_;

		public Mem(List<GameObject> items)
		{
			memory_ = items;
		}


	}
}