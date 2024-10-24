class Fraction {
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int top) 
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        if (bottom <= 0 )
        {
            bottom = 1;
        }

        _top = top;
        _bottom = bottom;
    }
}