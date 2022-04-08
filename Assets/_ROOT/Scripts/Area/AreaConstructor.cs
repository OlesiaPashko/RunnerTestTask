namespace Runner.Area
{
    using System.Collections.Generic;
    using UnityEngine;

    public class AreaConstructor : MonoBehaviour
    {
        [SerializeField] 
        private List<BoundsPair> boundPairs;

        private void Start()
        {
            foreach (var boundPair in boundPairs)
            {
                boundPair.endAchieved += ReplaceBoundsPair;
            }
        }

        private void ReplaceBoundsPair(BoundsPair boundsPair)
        {
            var last = GetLast();
            boundsPair.transform.position = last.transform.position + new Vector3(10, 0);
        }

        private BoundsPair GetLast()
        {
            var last = boundPairs[0];
            foreach (var boundPair in boundPairs)
            {
                if (boundPair.transform.position.x > last.transform.position.x)
                {
                    last = boundPair;
                }
            }

            return last;
        }

        private void OnDestroy()
        {
            foreach (var boundPair in boundPairs)
            {
                boundPair.endAchieved -= ReplaceBoundsPair;
            }
        }
    }
}