using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Utilities
{
    public static class AnimationExtensions
    {
        public static async Task AnimateMoveLocal(this Transform transform, Vector3 start, Vector3 end,
            float timeSeconds, CancellationToken ct)
        {
            float startTime = Time.time;
            float endTime = startTime + timeSeconds;

            while (Time.time < endTime)
            {
                float fraction = (Time.time - startTime) / timeSeconds;
                transform.localPosition = Vector3.Lerp(start, end, fraction);

                await Task.Yield();

                if (ct.IsCancellationRequested)
                    return;
            }

            transform.localPosition = end;
        }
    }
}
