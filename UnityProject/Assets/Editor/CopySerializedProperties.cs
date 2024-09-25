/*
 * Created by @Kittenji
 * https://github.com/ChrisFeline
 */

using UnityEngine;
using UnityEditor;

namespace Kittenji.Editor
{
    public class CopySerializedProperties
    {
        static Object Origin;

        [MenuItem("CONTEXT/Object/Copy Serialized Properties")]
        static void CopySerialized(MenuCommand command)
        {
            Origin = command.context;
        }

        [MenuItem("CONTEXT/Object/Paste Serialized Properties", validate = true)]
        static bool ValidateSerialized()
        {
            return Origin != null;
        }

        [MenuItem("CONTEXT/Object/Paste Serialized Properties")]
        static void PasteSerialized(MenuCommand command)
        {
            using (SerializedObject origin = new SerializedObject(Origin))
            using (SerializedObject target = new SerializedObject(command.context))
            {
                origin.Update();
                target.Update();

                using (SerializedProperty iterator = origin.GetIterator())
                {
                    bool visitChildren = true;
                    iterator.NextVisible(visitChildren);
                    visitChildren = false;

                    do
                    {
                        string name = iterator.name;

                        if (iterator.name == "m_Script")
                            continue; // Ignore script field

                        using (SerializedProperty property = target.FindProperty(name))
                        {
                            if (property != null)
                                target.CopyFromSerializedPropertyIfDifferent(iterator);
                        }
                    }
                    while (iterator.NextVisible(visitChildren));
                }

                target.ApplyModifiedProperties();
            }
        }
    }
}