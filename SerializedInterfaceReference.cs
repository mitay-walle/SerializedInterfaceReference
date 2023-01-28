using System;
using UnityEngine;

[Serializable]
public class SerializedInterfaceReference<T1, T2> : ISerializationCallbackReceiver where T1 : UnityEngine.Object
{
    [SerializeField] T1 _classField;

    public T1 ClassField
    {
        get => _classField;
        set
        {
            if (value is T2 field)
            {
                InterfaceValue = field;
                _classField = value;
            }
            else if (value == default)
            {
                InterfaceValue = default;
                _classField = value;
            }
            else
            {
                throw new InvalidCastException($"Can't assign {value.GetType()} to {typeof(T2)}");
            }
        }
    }

    T2 _interfaceValue;

    public T2 InterfaceValue
    {
        get => _interfaceValue;
        set
        {
            _interfaceValue = value;
            ClassField = value as T1;
        }
    }

    public void OnBeforeSerialize()
    {
        if (ClassField != null && ClassField is not T2)
        {
            ClassField = null;
        }
    }

    public void OnAfterDeserialize()
    {
        InterfaceValue = ClassField is T2 field ? field : default;
    }
}
