namespace PresTrust.FarmLand.Application.Http
{
    public class JsonContent: StringContent
    {
        public JsonContent(object obj) :
        base(System.Text.Json.JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json")
        { }
    }
}
