Just for Unity！
==========
1、将项目文件放置到Unity项目中

2、在ILruntime中注册 Adapter: IExtensibleAdapter

3、仅使用 ProtoBuf.Serializer.Serialize(stream, typeof(T), data) 序列化协议对象 

4、仅使用 ProtoBuf.Serializer.Deserialize(typeof(T),stream) 反序列化协议数据  

5、对Protobuf进行了一定的改造，去除了Protobuf的一些类型的验证，使用过程中可能会出现不可预知的问题