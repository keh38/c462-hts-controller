using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HTSController.Utilities
{
    /// <summary>
    /// Serializes KLib.Signals.Editor.* types using their runtime
    /// KLib.Signals.* equivalents so HTS can deserialize them correctly.
    /// </summary>
    public class SignalEditorBinder : ISerializationBinder
    {
        private const string EditorNamespace = "KLib.Signals.Editor";
        private const string RuntimeNamespace = "KLib.Signals";
        private const string SharedAssembly = "C462.Shared";

        public void BindToName(Type serializedType,
            out string assemblyName, out string typeName)
        {
            assemblyName = null;
            // Strip .Editor from the namespace so HTS sees runtime type names
            typeName = serializedType.FullName
                .Replace(EditorNamespace + ".", RuntimeNamespace + ".");
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            // On the HTSController side we can resolve both namespaces
            // Try runtime namespace first, then Editor namespace as fallback
            var type = Type.GetType($"{typeName}, {SharedAssembly}");
            if (type != null) return type;

            var editorName = typeName.Replace(
                RuntimeNamespace + ".", EditorNamespace + ".");
            return Type.GetType($"{editorName}, {SharedAssembly}");
        }
    }

    /// <summary>
    /// Pre-configured JSON serialization for the HTSController↔HTS
    /// signal boundary. Use Serialize/Deserialize at all call sites
    /// rather than constructing JsonSerializerSettings directly.
    /// </summary>
    public static class SignalSerialization
    {
        private static readonly JsonSerializerSettings _settings =
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = new SignalEditorBinder(),
                NullValueHandling = NullValueHandling.Ignore
            };

        /// <summary>Serialize any signal object for transmission to HTS.</summary>
        public static string Serialize(object obj)
            => JsonConvert.SerializeObject(obj, _settings);

        /// <summary>Deserialize a signal object received from HTS.</summary>
        public static T Deserialize<T>(string json)
            => JsonConvert.DeserializeObject<T>(json, _settings);
    }
}