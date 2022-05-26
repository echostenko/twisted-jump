﻿using Interfaces;
using UnityEngine;

namespace Services
{
    public class AssetProvider : IAssetProvider
    {
        public T Load<T>(string path) where T : Object =>
            Resources.Load<T>(path);

        public T[] LoadAll<T>(string path) where T : Object =>
            Resources.LoadAll<T>(path);
    }
}