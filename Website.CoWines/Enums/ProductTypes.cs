namespace Website.CoWines.Enums
{
    using System.ComponentModel;

    public enum ProductTypes
    {
        [Description("Red Wine")]
        RedWine,
        [Description("Rose Wine")]
        RoseWine,
        [Description("White Wine")]
        WhiteWine,
        Champagne,
        [Description("Rose Champagne")]
        RoseChampagne,
        [Description("Sparkling Wine")]
        SparklingWine,
        Liqueur,
        Port,
        Spirit,
        Armagnac,
        Cognac,
        EauxDeVie,
    }
}
