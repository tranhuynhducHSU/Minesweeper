class Cell{
    private string measure;
    private bool bomb;
    private bool flag;
    private string border;
    private int x;
    private int y;

    public string Measure { get => measure; set => measure = value; }
    public bool Bomb { get => bomb; set => bomb = value; }
    public bool Flag { get => flag; set => flag = value; }
    public string Border { get => border; set => border = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    public Cell(){
        Measure=" ";
        Bomb=false;
        Flag=false;
        Border="";
        X=0;
        Y=0;
    }
}