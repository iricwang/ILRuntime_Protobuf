using System;

namespace Libs
{


    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BaseProto2")]
    public sealed class BaseProto2 : global::ProtoBuf.IExtensible
    {
        private int _roomID;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"roomID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public int roomID
        {
            get { return _roomID; }
            set { _roomID = value; }
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BaseProto")]
    public sealed class BaseProto : global::ProtoBuf.IExtensible
    {
        public BaseProto() {}

        private long _cid = default(long);
        [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"cid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        public long cid
        {
            get { return _cid; }
            set { _cid = value; }
        }
      
        private readonly global::System.Collections.Generic.List<BaseProto2> _nnRoomInfos = new global::System.Collections.Generic.List<BaseProto2>();
        [global::ProtoBuf.ProtoMember(2, Name=@"nnRoomInfos", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public global::System.Collections.Generic.List<BaseProto2> nnRoomInfos
        {
            get { return _nnRoomInfos; }
        }

        [global::ProtoBuf.ProtoMember(3, Name=@"nnRoomInfos2", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public BaseProto2[] nnRoomInfos2
        {
            get;
            set;
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }

    public class Test
    {
        public Test()
        {
            BaseProto proto = new BaseProto();
            proto.cid = 100;
            proto.nnRoomInfos.Add(new BaseProto2(){ roomID = 10 });
            proto.nnRoomInfos.Add(new BaseProto2(){ roomID = 10 });
            proto.nnRoomInfos.Add(new BaseProto2(){ roomID = 10 });
            proto.nnRoomInfos.Add(new BaseProto2(){ roomID = 10 });
            proto.nnRoomInfos.Add(new BaseProto2(){ roomID = 10 });

            proto.nnRoomInfos2 = new BaseProto2[2];
            proto.nnRoomInfos2[0] = new BaseProto2(){roomID = 1001};
            proto.nnRoomInfos2[1] = new BaseProto2(){roomID = 1002};

            System.IO.MemoryStream stream = new System.IO.MemoryStream();

            ProtoBuf.Serializer.Serialize(stream, typeof(BaseProto), proto);

            byte[] bytes = stream.ToArray();
            stream.Dispose();

            UnityEngine.Debug.Log(bytes.Length);

            stream = new System.IO.MemoryStream(bytes);
            var obj = ProtoBuf.Serializer.Deserialize(typeof(BaseProto),stream) as BaseProto;

            UnityEngine.Debug.Log(obj.nnRoomInfos2[0].roomID + " - " + obj.nnRoomInfos2[1].roomID);

        }
    }
}

