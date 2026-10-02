Auto meinAuto = new Auto("BMW", 2020);
Console.WriteLine(meinAuto.GetMarke());
Console.WriteLine(meinAuto.GetBaujahr());

class Auto
{
    private string marke;
    private int baujahr;

    public Auto(string marke, int baujahr)
    {

        this.marke = marke;
        this.baujahr = baujahr;

    }

    public string GetMarke()
    {
        return marke;
    }

    public int GetBaujahr()
    {
        return baujahr;
    }


}


