using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(ItemSlot))]
public class ItemSlotEditor : Editor
{
    //public override void OnInspectorGUI() {
    //    serializedObject.Update();
    //    ItemSlot slot = target as ItemSlot;

    //    slot.item = (Item)EditorGUILayout.ObjectField(slot.item, typeof(Item), true);
    //    slot.winMessage = EditorGUILayout.TextArea("Win message");
    //    slot.loseMessage = EditorGUILayout.TextArea("Lose message");
    //}
}
