using System.Text;

namespace CSharp_Tasks
{       
	public class CLRU_Cache
	{
		internal struct SKeyVal
		{
			public string Key;
			public string Value;
		}

		private int m_Capacity = 0;
		private Dictionary<string, LinkedListNode<SKeyVal>> m_Dict = new Dictionary<string, LinkedListNode<SKeyVal>>();
		private LinkedList<SKeyVal> m_LRU_Rating = new LinkedList<SKeyVal>();
		
		public CLRU_Cache(int p_Capacity)
		{
			m_Capacity = p_Capacity;
		}
		
		private void inner_RemoveNonNeeded() 
		{
			LinkedListNode<SKeyVal>? v_LastPair = m_LRU_Rating.Last;

			if (v_LastPair == null) return;
			
			m_Dict.Remove(v_LastPair.Value.Key);
			m_LRU_Rating.RemoveLast();
		}
		
		private void inner_MoveToTop(LinkedListNode<SKeyVal> p_Entry)
		{
			
			m_LRU_Rating.Remove(p_Entry);
			m_LRU_Rating.AddFirst(p_Entry);
		}
		
		public void Put(string p_Key, string p_Value) 
		{
			if (m_Dict.ContainsKey(p_Key)) 
			{
				var v_FoundListNode = m_Dict[p_Key];
				var v_FoundKeyVal = v_FoundListNode.Value;
				v_FoundKeyVal.Value = p_Value;
				v_FoundListNode.Value = v_FoundKeyVal;

				// Move current entry to the top of Rating
				inner_MoveToTop(m_Dict[p_Key]);
				return;
			}
			
			if (m_Dict.Count >= m_Capacity) this.inner_RemoveNonNeeded();
			var v_NewKVPair = new SKeyVal { Key = p_Key, Value = p_Value };
			var v_NewListEntry = m_LRU_Rating.AddFirst(v_NewKVPair);		

			m_Dict.Add(p_Key, v_NewListEntry);		
		}
		
		public string? Get(string p_Key)
		{
			LinkedListNode<SKeyVal>? v_FoundEntry = null;		

			if (m_Dict.TryGetValue(p_Key, out v_FoundEntry)) 
			{
				// Move current entry to the top of Rating
				inner_MoveToTop(m_Dict[p_Key]);
				return v_FoundEntry.Value.Value;		
			}
			return null;
		}

		public string DisplayCache()
		{
			StringBuilder v_SB = new StringBuilder();
			foreach (var v_KVPair in m_LRU_Rating)
			{
				v_SB.Append($"{v_KVPair.Value} ");
			}
			return v_SB.ToString();
		}
	}
}