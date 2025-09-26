using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace UnistrokeGestureRecognition {
    public sealed class RecognizerController : MonoBehaviour 
    {
        [SerializeField] private List<GesturePattern> _patterns;
        [SerializeField, Range(0.6f, 1f)] private float _minimumScore = 0.8f;

        [SerializeField] private PathDrawerBase _pathDrawer;

        private Camera _camera;
        private IGestureRecorder _gestureRecorder;

        private IGestureRecognizer<GesturePattern> _recognizer;

        private JobHandle? _recognizeJob;

        public UnityEvent<string> onSymbolRecognized = new UnityEvent<string>();

        private void Awake()
        {
            _patterns = DataLoader.GesturePatterns;
            _gestureRecorder = new GestureRecorder(256, 0.1f);
            _recognizer = new GestureRecognizer<GesturePattern>(_patterns, 256);
        }

        private void Start() 
        {
            _pathDrawer.Show();
            _camera = Camera.main;
        }

        private void OnDestroy() 
        {
            _recognizer.Dispose();
            _gestureRecorder.Dispose();
        }

        private void Update() 
        {
            if (Input.GetKeyUp(KeyCode.Mouse0)) 
            {
                if (_gestureRecorder.Length > 30) 
                    RecognizeRecordedGesture();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0)) 
                Clear();

            RecordNewPoint();
        }

        private void LateUpdate() 
        {
            if (!_recognizeJob.HasValue)
                return;

            _recognizeJob.Value.Complete();

            RecognizeResult<GesturePattern> result = _recognizer.Result;

            Debug.Log($"{result.Pattern.Name}: {result.Score}");

            if (result.Score >= _minimumScore) 
            {
                GesturePattern recognizedPattern = result.Pattern;
                //_nameController.Set($"{recognizedPattern.Name}: {result.Score:0.00}");
                onSymbolRecognized.Invoke(recognizedPattern.Name);
            }

            _recognizeJob = null;
        }

        private void RecognizeRecordedGesture() => _recognizeJob = _recognizer.ScheduleRecognition(_gestureRecorder.Path);

        private void Clear() 
        {
            //_nameController.Clear();
            _pathDrawer.Clear();
            _gestureRecorder.Reset();
        }

        private void RecordNewPoint() 
        {
            var screenPosition = Input.mousePosition;
            Vector2 point = _camera.ScreenToWorldPoint(screenPosition);

            if (Input.GetKey(KeyCode.Mouse0)) 
            {
                _gestureRecorder.RecordPoint(new Vector2(screenPosition.x, screenPosition.y));
                _pathDrawer.AddPoint(point);
            }
        }

        private void OnValidate() 
        {
            if (Application.isPlaying && _recognizer != null) 
            {
                _recognizer.Dispose();
                _recognizer = new GestureRecognizer<GesturePattern>(_patterns);
            }
        }
    }
}
