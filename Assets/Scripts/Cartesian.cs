public class Cartesian 
{
    public int[] x, z;

    public Cartesian()
    {
        x = new int[4];
        z = new int[4];

        SetFirstQuadrant();
        SetSecondQuadrant();
        SetThirdQuadrant();
        SetFourtQuadrant();
    }

    private void SetFirstQuadrant()
    {
        x[0] = z[0] = 1;
    }

    private void SetSecondQuadrant()
    {
        x[1] = -1;
        z[1] = 1;
    }

    private void SetThirdQuadrant()
    {
        x[2] = z[2] = - 1;
    }

    private void SetFourtQuadrant()
    {
        x[3] = 1;
        z[3] = -1;
    }
}
