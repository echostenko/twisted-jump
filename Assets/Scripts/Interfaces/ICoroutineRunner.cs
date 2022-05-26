using System.Collections;
using UnityEngine;

namespace Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
        void StopCoroutine(Coroutine routine);
    }
}