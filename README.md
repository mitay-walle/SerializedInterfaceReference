# SerializedInterfaceReference
Unity3d script to Serialize reference to UnityEngine.Object inherited from interface, with constraints

![](https://github.com/mitay-walle/SerializedInterfaceReference/blob/main/SerializedInterfaceReference.gif)

Type switch used in gif by Odin Inspector

## Problems
1. Interface reference to UnityEngine.Object can't be serialized with built-in serialization
2. two-fields solution for 1. allow wrong-typed references
3. need some execution-context to cast serialized reference to interface
4. UnityEngine.Object and C#-plain classes implementing same interface can't be save to same field

## Solutions
1. Use plain C#-class to serialize reference
2. ISerializationCallback.OnBeforeSerialize (for serialization) and property setters (for runtime assign) to prevent wrong-typed values
3. ISerializationCallback.OnAfterDeserialize to cast value before any other execution, and no need to duplicate execution
4. use SerializeReference with interface and create plain class-container, including field with reference and inherited from interface
