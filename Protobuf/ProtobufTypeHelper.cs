/*
*类     名  : Protobuf.cs
*版     本  : 1.0
*作     者  : 
*Unity版本  : 5.4.1f1
*说     明  : 
*创     建  : 2017-01-17
*/

using UnityEngine;
using System.Collections;
using ProtoBuf.Meta;
using System;
using System.Reflection;

namespace ProtoBuf
{
    public interface IProtobufTypeAdapter
    {
        Type TYPE_TIMESPAN    { get; }
        Type TYPE_GUID        { get; }
        Type TYPE_URI         { get; }
        Type TYPE_BYTEARRAY   { get; }
        Type TYPE_SYSTYPE     { get; }

        Type GetListItemType(Type type);
        object ConvertCLRInstance(object value);
        object CreateInstance(Type type);
    }

    class ProtobufTypeAdapter : IProtobufTypeAdapter
    {
        public ProtobufTypeAdapter()
        {
            TYPE_TIMESPAN  = typeof(TimeSpan);
            TYPE_GUID      = typeof(Guid);
            TYPE_URI       = typeof(Uri);
            TYPE_BYTEARRAY = typeof(byte[]);
            TYPE_SYSTYPE   = typeof(System.Type);
        }

        public Type TYPE_TIMESPAN
        {
            get;
            private set;
        }

        public Type TYPE_GUID
        {
            get;
            private set;
        }

        public Type TYPE_URI
        {
            get;
            private set;
        }

        public Type TYPE_BYTEARRAY
        {
            get;
            private set;
        }

        public Type TYPE_SYSTYPE
        {
            get;
            private set;
        }

        public Type GetListItemType(Type type)
        {
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsStatic || method.Name != "Add") continue;
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length == 1)
                {
                    return parameters[0].ParameterType;
                }
            }
            return null;
        }

        public object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public object ConvertCLRInstance(object value)
        {
            return value;
        }
    }

    public sealed class ProtobufTypeHelper
    {
        public static Type TYPE_TIMESPAN    
        {
            get{ return typeAdapter.TYPE_TIMESPAN; }
        }

        public static Type TYPE_GUID
        {
            get{ return typeAdapter.TYPE_GUID; }
        }

        public static Type TYPE_URI
        {
            get{ return typeAdapter.TYPE_URI; }
        }

        public static Type TYPE_BYTEARRAY   
        {
            get{ return typeAdapter.TYPE_BYTEARRAY; }
        }

        public static Type TYPE_SYSTYPE
        {
            get{ return typeAdapter.TYPE_SYSTYPE; }
        }

        public static IProtobufTypeAdapter typeAdapter = new ProtobufTypeAdapter();

        public static Type GetListItemType(Type type)
        {
            return typeAdapter.GetListItemType(type);
        }

        public static object CreateInstance(Type type)
        {
            return typeAdapter.CreateInstance(type);
        }

        public static object ConvertCLRInstance(object value)
        {
            return typeAdapter.ConvertCLRInstance(value);
        }
       
    }
}