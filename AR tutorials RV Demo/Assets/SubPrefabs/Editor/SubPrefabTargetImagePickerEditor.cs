using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace RVir.GrupoTres
{
    /// <summary>
    /// Custom inspector for SubPrefabTargetImagePicker components.
    /// </summary>
    [CustomEditor(typeof(SubPrefabTargetImagePicker)), CanEditMultipleObjects]
    public class SubPrefabTargetImagePickerEditor : Editor
    {
        SerializedProperty library;
        SerializedProperty clip;

        Color defaultColor;
        Color highlightedColor = new Color(1, 1, 0);

        SubPrefabTargetImagePicker picker;

        XRReferenceImage emptyImage;

        private void OnEnable()
        {
            library = serializedObject.FindProperty("referenceImageLibrary");
            clip = serializedObject.FindProperty("clip");

            emptyImage = new XRReferenceImage();

            picker = (SubPrefabTargetImagePicker)serializedObject.targetObject;
            defaultColor = GUI.backgroundColor;
        }

        public override void OnInspectorGUI()
        {
            // Handle the library variable the proper way
            EditorGUILayout.PropertyField(clip);
            EditorGUILayout.PropertyField(library);
            serializedObject.ApplyModifiedProperties();

            // If no library is set, exit.
            if (picker.referenceImageLibrary == null)
            {
                picker.image = emptyImage;
                return;
            }

            // Show a button for each ReferenceImage in the library, with thumbnail
            foreach (XRReferenceImage image in picker.referenceImageLibrary)
            {
                // Set the active button (if any) to the highligh Color;
                GUI.backgroundColor = (picker.image == image)
                                        ? highlightedColor
                                        : defaultColor;

                // If user clicked the button for this ReferenceImage
                if (GUILayout.Button(AssetPreview.GetAssetPreview(image.texture)))
                {
                    // Set the component's image variable to this ReferenceImage
                    picker.image = image;
                    // Force the Editor to save the new value to disk
                    EditorUtility.SetDirty(picker);
                }
            }

            // Set the background color for buttons back to the default.
            GUI.backgroundColor = defaultColor;
        }

    }
}