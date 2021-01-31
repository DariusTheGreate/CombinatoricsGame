using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MemoryHistory;

public static class history_container
{
	public static Stack<GameObject> to_destoy = new Stack<GameObject>();
	public static Stack<Mem> history_of_destoyed = new Stack<Mem>();
	public static Stack<GameObject> past_game_objects = new Stack<GameObject>();
}
