using CoreLib.Taxonomy.Data;

namespace CoreLib.Taxonomy
{
    class TaxonomicObject
    {
        public int TIK { get; }
        public string Name { get; }

        public TaxonomicObject(int tik)
        {
            Name = Factory.FetchTaxaDetails(tik);
            TIK = tik;
        }
    }
}
