using System;
using System.Collections.Generic;

namespace ProtoBuf
{
    public class ProtobufPropertyHelper
    {
        static ProtobufPropertyHelper m_current;
        static ProtobufPropertyHelper current
        {
            get
            { 
                if (m_current == null)
                    m_current = new ProtobufPropertyHelper();
                return m_current;
            }
        }
		Dictionary<int, Type> m_types = new Dictionary<int, Type>();
		
        private ProtobufPropertyHelper() { }

        void RegisterMemberTypeInternal(int metaIndex, Type type)
        {
            if (!m_types.ContainsKey(metaIndex))
            {
				m_types.Add(metaIndex,type);
            }
            else
                throw new SystemException(string.Format("PropertyMeta : {0} is registered!",metaIndex));
        }

        Type FindMemberTypeInternal(int metaIndex)
		{
			Type type = null;
			if (!m_types.TryGetValue(metaIndex, out type))
			{
				throw new SystemException(string.Format("PropertyMeta : {0} is not registered!", metaIndex));
			}
			return type;
		}

        public static void RegisterMemberType(int metaIndex, Type type)
        {
            current.RegisterMemberTypeInternal(metaIndex, type);
        }

		public static Type FindMemberType(int metaIndex)
		{
            return current.FindMemberTypeInternal(metaIndex);
		}
    }
}

