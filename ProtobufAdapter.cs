using System;
using UnityEngine;
using ILRuntime.Runtime.Enviorment;
using System.IO;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Generated;
using System.Collections.Generic;
using System.Reflection;
using ProtoBuf;

namespace MegoEngine
{
    class ProtobufAdapter : MonoBehaviour,IProtobufTypeAdapter
    {
        private static ILRuntime.Runtime.Enviorment.AppDomain appdomain;

        void Awake()
        {
            //此处调用初始化
            InitProtobufTypes();
        }

        #region ProtobufTypeAdapter

        public object CreateInstance(Type type)
        {
            var _type = appdomain.GetType(type);
            return appdomain.Instantiate(_type.FullName);
        }

        public Type TYPE_TIMESPAN   { get; private set; }
        public Type TYPE_GUID       { get; private set; }
        public Type TYPE_URI        { get; private set; }
        public Type TYPE_BYTEARRAY  { get; private set; }
        public Type TYPE_SYSTYPE    { get; private set; }

        public object ConvertCLRInstance(object value)
        {
            ILRuntime.Runtime.Intepreter.ILTypeInstance instance = value as ILRuntime.Runtime.Intepreter.ILTypeInstance;
            if (instance != null)
            {
                return instance.CLRInstance;
            }
            return value;
        }

        void InitProtobufTypes()
        {
            TYPE_TIMESPAN  = GetType("System.TimeSpan");
            TYPE_GUID      = GetType("System.Guid");
            TYPE_URI       = typeof(Uri);
            TYPE_BYTEARRAY = GetType("System.Byte[]");
            TYPE_SYSTYPE   = GetType("System.Type");
            ProtobufTypeHelper.typeAdapter = this;
        }

        public Type GetListItemType(Type type)
        {
            var wt = type as ILRuntime.Reflection.ILRuntimeWrapperType;
            if (wt != null)
            {
                var clrType = wt.CLRType;
                if (clrType != null && clrType.GenericArguments != null && clrType.GenericArguments.Length > 0)
                {
                    type = clrType.GenericArguments[0].Value.ReflectionType;
                    return type;
                }
            }
            return null;
        }

        #endregion
    }
    
}
