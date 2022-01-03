using System;
using Newtonsoft.Json;

public static class DebugExtension
{
  public static string ToJson(this object anObject, bool isWriteConsole = true)
  {
    string json = JsonConvert.SerializeObject(anObject, Formatting.Indented, new JsonSerializerSettings()
    {

      PreserveReferencesHandling = PreserveReferencesHandling.Objects
    });
    if (isWriteConsole)
    {
      Console.WriteLine(json);

    }
    return json;

  }
}