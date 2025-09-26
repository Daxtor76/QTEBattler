using UnityEngine;

namespace UnistrokeGestureRecognition {
    [CreateAssetMenu(fileName = "SingleLinePattern", menuName = "Scriptable Objects/GesturePattern")]
    public class GesturePattern : GesturePatternBase 
    {
        [SerializeField] private string _name;

        public string Name => _name;
    }
}