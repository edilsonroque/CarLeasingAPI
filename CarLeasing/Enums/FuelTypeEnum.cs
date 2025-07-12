using System.Text.Json.Serialization;

namespace CarLeasing.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FuelTypeEnum
    {
        Gasolina,
        Diesel,
        Eletrico
    }
}
