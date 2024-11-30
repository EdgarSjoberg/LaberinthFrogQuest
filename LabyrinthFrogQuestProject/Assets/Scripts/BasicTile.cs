public class BasicTile : Tile
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool CheckPaths(int direction)
    {
        if (paths[direction])
            return true;
        else return false;
    }
}
