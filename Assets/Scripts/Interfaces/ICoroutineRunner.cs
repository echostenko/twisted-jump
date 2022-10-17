using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
        void StopCoroutine(Coroutine routine);
    }
}