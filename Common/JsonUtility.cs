using System;
using UnityEngine;

namespace HemdemGames.Utilities
{
    public static class JsonUtility
    {
        public static string ToJson<T>(T obj)
        {
            JsonObject<T> jsonObject = new JsonObject<T>();
            jsonObject.obj = obj;
            return UnityEngine.JsonUtility.ToJson(jsonObject);
        }

        public static T FromJson<T>(string json)
        {
            JsonObject<T> jsonObject = (JsonObject<T>) UnityEngine.JsonUtility.FromJson(json, typeof(JsonObject<T>));
            return jsonObject.obj;
        }

        [Serializable]
        private class JsonObject<T>
        {
            public T obj;
        }
    }
}