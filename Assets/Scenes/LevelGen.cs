using UnityEngine;

public class LevelGen : MonoBehaviour
{
    //pixel map of level
    public Texture2D mapTexture;
    //aray (list) pixel and prefab mappings
    public PixelToObject[] pixelColorMappings;
    //current pixel color to map to compare to the mappings
    private Color pixelColor;

    private void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        //scan the hole texture and get the poitions of objects
        for (int x = 0; x < mapTexture.width; x++)
        {
            for (int y = 0; y < mapTexture.height; y++)
            {
                GenerateObject(x, y);
            }
        }
    }

    void GenerateObject(int x, int y)
    {
        //read pixel color
        pixelColor = mapTexture.GetPixel(x, y);
        if(pixelColor == Color.white)
        {
            //do nothing
            return;
        }
        foreach(PixelToObject pixelColorMapping in pixelColorMappings)
        {
            //scan pixelColorMappings aray for matching color
            if(pixelColorMapping.pixelColor.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(pixelColorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
