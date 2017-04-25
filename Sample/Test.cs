using System;
using System.Collections.Generic;
using ProtoBuf;

[global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"TestData")]
public partial class TestData : global::ProtoBuf.IExtensible
{
	public TestData() { }

	private long _cid = default(long);
	[global::ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"cid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
	public long cid
	{
		get { return _cid; }
		set { _cid = value; }
	}

	private global::ProtoBuf.IExtension extensionObject;
	global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
	{ return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
}

[global::System.Serializable, global::ProtoBuf.ProtoContract(Name = @"BaseProto")]
public partial class BaseProto : global::ProtoBuf.IExtensible
{
	public BaseProto() { }

	private List<TestData> m_datas = new List<TestData>();
	[global::ProtoBuf.ProtoMember(1, MemberTypeIndex = 0, IsRequired = false, Name = @"datas", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
	public List<TestData> datas
	{
		get { return m_datas; }
		set { m_datas = value; }
	}

	private string _name;
	[global::ProtoBuf.ProtoMember(2, IsRequired = false, Name = @"name", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
	public string name
	{
		get { return _name; }
		set { _name = value; }
	}

	private global::ProtoBuf.IExtension extensionObject;
	global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
	{ return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
}

public class Test
{
	public Test()
	{
		//如果使用了List<T>类型，T类型为自定义的Protobuf类则需全局仅注册一次Member中List<T>中T的类型，这个步骤必须在序列化之前注册，metaIndex与ProtoMember中的MemberTypeIndex对应
		ProtobufPropertyHelper.RegisterListMemberType(0, typeof(TestData));
		BaseProto proto = new BaseProto();
		proto.datas.Add(new TestData() { cid = 100 });
		System.IO.MemoryStream stream = new System.IO.MemoryStream();
		ProtoBuf.Serializer.Serialize(stream, typeof(BaseProto), proto);
	}
}