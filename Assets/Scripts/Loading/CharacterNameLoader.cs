using System.Collections.Generic;
using System.IO;

public class CharacterNameLoader
{
    public List<string> LoadCharacterNames(string filePath)
    {
        List<string> names = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                names.Add(line);
            }
        }

        return names;
    }
}